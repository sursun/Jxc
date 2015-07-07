using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gms.Common;
using Gms.Domain;
using Gms.Infrastructure;
using SharpArch.NHibernate.Contracts.Repositories;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    //[HandleError]
    //[Authorize]
    public class GoodsController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Select()
        {
            return View();
        }

        public ActionResult List(GoodsQuery query)
        {
            var list = this.GoodsRepository.GetList(query);
            var data = list.Data.Select(c => GoodsModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }

        public ActionResult Detail(int id)
        {
            Goods item = this.GoodsRepository.Get(id);

            if (item == null)
            {
                item = new Goods();
            }

            return View(GoodsModel.From(item));
        }

        public ActionResult Edit(int? id)
        {
            Goods item = null;

            if (id.HasValue)
            {
                item = this.GoodsRepository.Get(id.Value);
            }

            if (item == null)
            {
                item = new Goods();
            }

            return View(item);
        }


        [Transaction]
        public ActionResult SaveOrUpdate(Goods obj)
        {
            if (obj.Id > 0)
            {
                obj = this.GoodsRepository.Get(obj.Id);
                TryUpdateModel(obj);
            }
            obj = this.GoodsRepository.SaveOrUpdate(obj);
            return JsonSuccess(obj);
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = this.GoodsRepository.Get(id);

                this.GoodsRepository.Delete(obj);

                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

    }

    public class GoodsModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public String CodeNo { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public String BarCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 名称 简拼
        /// </summary>
        public String Pinyin { get; set; }

        /// <summary>
        /// 商品缩略图
        /// </summary>
        public String Picture { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public String Model { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public String UnitName { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 最低数量
        /// </summary>
        public decimal MinQuantity { get; set; }

        /// <summary>
        /// 最高数量
        /// </summary>
        public decimal MaxQuantity { get; set; }

        /// <summary>
        /// 低值预警
        /// </summary>
        public Boolean IsMinWarning { get; set; }
        
        /// <summary>
        /// 高值预警
        /// </summary>
        public Boolean IsMaxWarning { get; set; }

        /// <summary>
        /// 商品品牌
        /// </summary>
        public String BrandName { get; set; }

        /// <summary>
        /// 陈列架
        /// </summary>
        public String DisplayStandsName { get; set; }

        /// <summary>
        /// 进价
        /// 采购价
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 零售价
        /// </summary>
        public decimal RetailPrice { get; set; }

        /// <summary>
        /// 最低限价
        /// </summary>
        public decimal MinPrice { get; set; }

        /// <summary>
        /// 是否特价
        /// </summary>
        public String IsBarginStr { get; set; }

        /// <summary>
        /// 特价
        /// </summary>
        public decimal BarginPrice { get; set; }

        /// <summary>
        /// 是否允许前台改价销售
        /// </summary>
        public String IsFreePriceStr { get; set; }

        /// <summary>
        /// 积分金额
        /// 消费多少元获得1积分，0代表按系统设置统一积分
        /// </summary>
        public decimal PointBase { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public String GoodsStatusStr { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public String CreateTimeStr { get; set; }

        public GoodsModel(Goods goods)
        {
            this.Id = goods.Id;
            this.CodeNo = goods.CodeNo;
            this.BarCode = goods.BarCode;
            this.Name = goods.Name;
            this.Pinyin = goods.Pinyin;
            this.Picture = goods.Picture;
            this.Model = goods.Model;

            if (goods.Unit != null)
                this.UnitName = goods.Unit.Name;

            this.Quantity = goods.Quantity;
            this.MinQuantity = goods.MinQuantity;
            this.MaxQuantity = goods.MaxQuantity;
            this.IsMinWarning = goods.IsMinWarning;
            this.IsMaxWarning = goods.IsMaxWarning;

            if (goods.Brand != null)
                this.BrandName = goods.Brand.Name;

            if (goods.DisplayStands != null)
                this.DisplayStandsName = goods.DisplayStands.Name;

            this.PurchasePrice = goods.PurchasePrice;
            this.RetailPrice = goods.RetailPrice;
            this.MinPrice = goods.MinPrice;
            this.IsBarginStr = goods.IsBargin.ToString();
            this.BarginPrice = goods.BarginPrice;
            this.IsFreePriceStr = goods.IsFreePrice.ToString();
            this.PointBase = goods.PointBase;
            this.GoodsStatusStr = goods.GoodsStatus.ToString();
            this.Note = goods.Note;
            this.CreateTimeStr = goods.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static GoodsModel From(Goods goods)
        {
            return new GoodsModel(goods);
        }

    }
}