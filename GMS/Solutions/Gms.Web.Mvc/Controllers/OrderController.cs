using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Gms.Common;
using Gms.Domain;
using Gms.Infrastructure;
using Gms.Web.Mvc.Controllers.Attribute;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    [HandleError]
    [Authorize]
    public class OrderController : BaseController
    {
        private string FILE_DIR = "/OrderFiles/";
     
        #region 订单
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(OrderQuery query)
        {
            var list = this.OrderRepository.GetList(query);
            var data = list.Data.Select(c => OrderModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
            
        }

        public ActionResult CreateNew()
        {
            Order order = new Order();
            
            order.CodeNo = order.CreateTime.ToString("yyyyMMddHHmmss");
            order.CreateUser = CurrentUser;
            return View("Edit", this.OrderRepository.SaveOrUpdate(order));
        }

        public ActionResult Edit(int id,bool isOnlyRead = false)
        {
            Order order = this.OrderRepository.Get(id);

            IList<FileModel> fList = new List<FileModel>();

            String savePath = FILE_DIR + order.CodeNo + "/";
            String dirPath = Server.MapPath(savePath);

            DirectoryInfo theFolder = new DirectoryInfo(dirPath);
            if (theFolder.Exists)
            {
                foreach (FileInfo nextFile in theFolder.GetFiles())
                {
                    fList.Add(new FileModel() { filename = nextFile.Name, fileurl = (savePath + nextFile.Name) });
                }
            }

            ViewData["orderfilelist"] = fList;

            if (isOnlyRead)
            {
                return View("OrderView", order);
            }
            
            return View(order);
        }

        public ActionResult OrderPrint(int id)
        {
            return View(this.OrderRepository.Get(id));
        }

        [Transaction]
        public ActionResult CreateOrUpdate(Order order,int customerid, string newcustomername, string newcustomermobile, string newcustomercompany)
        {
            if (order == null)
            {
                return JsonError("订单错误，无法保存！");
            }

            Customer newCustomer = null;
            if (customerid == 0)
            {
                if (newcustomername.NotNullAndEmpty() || newcustomermobile.NotNullAndEmpty() ||
                    newcustomercompany.NotNullAndEmpty())
                {
                    newCustomer = new Customer();
                    newCustomer.Name = newcustomername;
                    newCustomer.Mobile = newcustomermobile;
                    newCustomer.Company = newcustomercompany;
                    newCustomer = this.CustomerRepository.SaveOrUpdate(newCustomer);
                }
            }
            else
            {
                newCustomer = this.CustomerRepository.Get(customerid);
            }

            if (!order.Note.IsNullOrEmpty())
            {
                order.Note = Server.HtmlEncode(order.Note);
            }
            order = this.OrderRepository.Get(order.Id);

            TryUpdateModel(order);

            order.ModifyTime = DateTime.Now;
            if (newCustomer != null)
            {
                order.Customer = newCustomer;
            }

            order = this.OrderRepository.SaveOrUpdate(order);
            if (order != null && !order.Note.IsNullOrEmpty())
            {
                order.Note = Server.HtmlDecode(order.Note);
            }
            return JsonSuccess(order);
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            var order = OrderRepository.Get(id);
            if (order != null)
            {
                OrderRepository.Delete(order);
            }

            return JsonSuccess();
        }
        
        [Transaction]
        public ActionResult ChangeState(int id,OrderState state)
        {
            var order = OrderRepository.Get(id);
            if (order != null)
            {
                order.OrderState = state;

                this.OrderRepository.SaveOrUpdate(order);
            }

            return JsonSuccess();
        }
        #endregion
        

        #region 附件管理
        [HttpPost]
        public ActionResult UploadFile()
        {
            HttpPostedFileBase uploadFile = this.Request.Files["Filedata"];
            if (uploadFile == null)
            {
                return JsonNetnError("请选择文件。");
            }

            String strOrderid = Request["orderid"];
            int orderId = int.Parse(strOrderid);

            Order order = OrderRepository.Get(orderId);


            //文件保存目录路径
            String savePath = FILE_DIR + order.CodeNo + "/";
            String dirPath = Server.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            String fileName = uploadFile.FileName;
            String filePath = dirPath + fileName;
            uploadFile.SaveAs(filePath);

            return JsonNetSuccess(new { fileurl = (savePath + fileName),ordercode=order.CodeNo });
        }

        [HttpPost]
        public ActionResult DeleteFile(string ordercode,string filename)
        {
            //文件保存目录路径
            String savePath = FILE_DIR + ordercode + "/";
            String dirPath = Server.MapPath(savePath);
            String filePath = dirPath + filename;

            System.IO.File.Delete(filePath);

            return JsonNetSuccess(filename);
        }
        #endregion
    }

    public class OrderModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string CodeNo { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public string CustomerString { get; set; }

        /// <summary>
        /// 录单员
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderState { get; set; }

        /// <summary>
        /// 交货日期
        /// </summary>
        public string DeliveryDate { get; set; }

        /// <summary>
        /// 总价（计算值）
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 总价（实收金额）
        /// </summary>
        public decimal RealTotalPrice { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public string ModifyTime { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        public OrderModel(Order order)
        {
            this.Id = order.Id;

            this.CodeNo = order.CodeNo;

            this.CustomerString = order.Customer == null
                                      ? ""
                                      : String.Format("{0}[{1}]", order.Customer.Name, order.Customer.Mobile);

            this.CreateUser = order.CreateUser == null ? "" : order.CreateUser.LoginName;

            this.TotalPrice = order.TotalPrice;

            this.RealTotalPrice = order.RealTotalPrice;

            this.OrderState = order.OrderState.ToString();

            this.DeliveryDate = order.DeliveryDate.ToString("yyyy-MM-dd HH:mm:ss");

            this.ModifyTime = order.ModifyTime.ToString("yyyy-MM-dd HH:mm:ss");

            this.CreateTime = order.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");

            this.Note = order.Note;
        }


        public static OrderModel From(Order order)
        {
            return new OrderModel(order);
        }
    }


    public class FileModel
    {
        public string filename { get; set; }
        public string fileurl { get; set; }
    }

}