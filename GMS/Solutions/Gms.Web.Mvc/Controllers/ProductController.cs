using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
using Gms.Domain;
using Gms.Infrastructure;
using SharpArch.NHibernate.Web.Mvc;
using Newtonsoft.Json;

namespace Gms.Web.Mvc.Controllers
{
    [HandleError]
    [Authorize]
    public class ProductController:BaseController
    {
        public ActionResult List(ProductQuery query)
        {
            var list = this.ProductRepository.GetList(query);
            var data = list.Data.Select(c => ProductModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }

        public ActionResult Products( ProductQuery query)
        {
            var list = this.ProductRepository.GetList(query);
            var data = list.Data.Select(c => ProductModel.From(c)).ToList();
            //var result = new { total = list.RecordCount, rows = data };
   
            ViewData["OrderId"] = query.OrderId;

            String strTmp = "";
            var typs = this.CommonCodeRepository.GetRoot(CommonCodeType.玻璃品种);
            foreach (var item in typs)
            {
                strTmp += "'";
                strTmp += item.Name;
                strTmp += "',";
            }
            strTmp = strTmp.TrimEnd(',');
            ViewData["GlasssTypeString"] = strTmp;

            strTmp = "";
            var names = Enum.GetNames(typeof (Thickness));
            foreach (var item in names)
            {
                strTmp += "'";
                strTmp += item;
                strTmp += "',";
            }
            strTmp = strTmp.TrimEnd(',');
            ViewData["ThicknessString"] = strTmp;

            return View(data);
        }


        [Transaction]
        public ActionResult SaveOrUpdate(ProductModel productModel)
        {
            Product product;

            if (productModel.Id != 0)
            {
                product = this.ProductRepository.Get(productModel.Id);
            }
            else
            {
                product = new Product();

                var order = this.OrderRepository.Get(productModel.OrderId);
                if (order == null)
                {
                    return JsonError("无效订单，无法保存产品！");
                }

                product.Order = order;

                //order.ModifyTime = DateTime.Now;
                //this.OrderRepository.SaveOrUpdate(order);
            }

            product = TryUpdate(productModel, product);

            product = this.ProductRepository.SaveOrUpdate(product);

            return JsonSuccess(product);
        }

        [Transaction]
        public ActionResult SaveProducts(int orderId, decimal totalPrice, string products)
        {
            var order = this.OrderRepository.Get(orderId);
            if (order == null)
            {
                return JsonError("无效订单，无法保存产品！");
            }
            try
            {
                var dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductModel[]>(products);
                var oldList = order.Products;
                //var addList, deleteList;

                //先删除产品
                foreach (var oldProduct in oldList)
                {
                    bool bFind = false;

                    foreach (var newProduct in dataList)
                    {
                        if (oldProduct.Id == newProduct.Id)
                        {
                            bFind = true;
                        }
                    }

                    //在新的列表中没有找到数据库存的产品，说明此产品已经删除。
                    if (!bFind)
                    {
                        this.ProductRepository.Delete(oldProduct);
                    }
                }

                //添加或者更新产品
                foreach (var productModel in dataList)
                {
                    Product product;

                    if (productModel.Id < 1)
                    {//新建产品
                        product = new Product();

                        product.Order = order;
                    }
                    else
                    {//更新产品
                        product = this.ProductRepository.Get(productModel.Id);
                    }

                    product = TryUpdate(productModel, product);
                    this.ProductRepository.SaveOrUpdate(product);
                }

                //更新订单相关属性
                order.ModifyTime = DateTime.Now;
                order.TotalPrice = totalPrice;
                this.OrderRepository.SaveOrUpdate(order);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
            

            //Product product;

            //if (productModel.Id != 0)
            //{
            //    product = this.ProductRepository.Get(productModel.Id);
            //}
            //else
            //{
            //    product = new Product();

            //    product.Order = order;

            //    //order.ModifyTime = DateTime.Now;
            //    //this.OrderRepository.SaveOrUpdate(order);
            //}

            //product = TryUpdate(productModel, product);

            //product = this.ProductRepository.SaveOrUpdate(product);

            return JsonSuccess();
        }


        public Product TryUpdate(ProductModel productModel,Product product)
        {
            if (!productModel.Name.IsNullOrEmpty())
            {
                product.Name = productModel.Name;
            }

            if (!productModel.GlassTypeString.IsNullOrEmpty())
            {
                product.GlassType = CommonCodeRepository.GetBy(productModel.GlassTypeString,CommonCodeType.玻璃品种);
            }

            if (!productModel.ThicknessString.IsNullOrEmpty())
            {
                product.Thickness = (Thickness)Enum.Parse(typeof(Thickness),productModel.ThicknessString);
            }

            product.LongEdge = productModel.LongEdge;
            product.ShortEdge = productModel.ShortEdge;
            product.EdgeLength = productModel.EdgeLength;
            product.Area = productModel.Area;
            product.Amount = productModel.Amount;
            product.Price = productModel.Price;

            if (!productModel.Note.IsNullOrEmpty())
            {
                product.Note = productModel.Note;
            }

            return product;
        }

        [Transaction]
        public ActionResult AddMulti(int number,int copyid)
        {

            Product product = this.ProductRepository.Get(copyid);

            if (product == null)
            {
                return JsonError("无法复制产品，请重新选择！");
            }

            for (int i =0 ;i<number;i++)
            {
                this.ProductRepository.SaveOrUpdate(
                    new Product()
                    {
                        Order = product.Order,
                        Name = product.Name,
                        GlassType = product.GlassType,
                        Thickness = product.Thickness,
                        LongEdge = product.LongEdge,
                        ShortEdge = product.ShortEdge,
                        EdgeLength = product.EdgeLength,
                        Area = product.Area,
                        Amount = product.Amount,
                        Price = product.Price,
                        Note = product.Note
                    });
            }

            return JsonSuccess();
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            var product = this.ProductRepository.Get(id);

            if (product != null)
            {
                this.ProductRepository.Delete(product);
            }

            return JsonSuccess();
        }



    }

    public class ProductModel
    {
        public ProductModel()
        {
        }

        public int OrderId { get; set; }

        public int Id { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 玻璃品种
        /// </summary>
        public string GlassTypeString { get; set; }

        /// <summary>
        /// 玻璃厚度
        /// </summary>
        public string ThicknessString { get; set; }


        /// <summary>
        /// 长边
        /// </summary>
        public int LongEdge { get; set; }

        /// <summary>
        /// 短边
        /// </summary>
        public int ShortEdge { get; set; }

        /// <summary>
        /// 边长
        /// </summary>
        public int EdgeLength { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 小计（计算值）
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Note { get; set; }

        public ProductModel(Product product)
        {
            this.OrderId = product.Order == null ? 0 : product.Order.Id;

            this.Id = product.Id;

            this.Name = product.Name ?? "";

            this.GlassTypeString = product.GlassType==null?"":product.GlassType.Name;

            this.ThicknessString = product.Thickness.ToString();

            this.LongEdge = product.LongEdge;

            this.ShortEdge = product.ShortEdge;

            this.EdgeLength = product.EdgeLength;

            this.Area = product.Area;

            this.Amount = product.Amount;

            this.Price = product.Price;

            this.Note = product.Note??"";
        }

        public static ProductModel From(Product product)
        {
            return new ProductModel(product);
        }
        
    }


}