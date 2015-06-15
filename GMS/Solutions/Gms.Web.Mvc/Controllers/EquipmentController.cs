using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    public class EquipmentController : BaseController
    {
        #region 库存

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(EquipmentQuery query)
        {
            var list = this.EquipmentRepository.GetList(query);
            var data = list.Data.Select(c => EquipmentModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }

        public ActionResult GetEquipment(int id)
        {
            return JsonSuccess(this.EquipmentRepository.Get(id));
        }
        
        [Transaction]
        public ActionResult SaveOrUpdate(Equipment equi)
        {
            if (equi.Id > 0)
            {
                equi = this.EquipmentRepository.Get(equi.Id);

                TryUpdateModel(equi);
            }

            equi= this.EquipmentRepository.SaveOrUpdate(equi);
            return JsonSuccess(equi);
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            try
            {
                var item = EquipmentRepository.Get(id);
                if (item != null)
                {
                    EquipmentRepository.Delete(item);
                }

                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

        }

        #endregion

        #region 预警

        public ActionResult Warning()
        {
            return View();
        }

        public ActionResult WarningList(EquipmentQuery query)
        {
            if (query == null)
            {
                query = new EquipmentQuery();
            }

            query.IsWarning = true;
            
            var list = this.EquipmentRepository.GetList(query);
            var data = list.Data.Select(c => EquipmentModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }

        #endregion

        #region 物价变化
        public ActionResult PriceChange()
        {
            return View();
        }

        public ActionResult PriceChangeList(EquiPriceChangeQuery query)
        {
            var list = this.EquiPriceChangeRepository.GetList(query);
            var data = list.Data.Select(c => EquiPriceChangeModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);

        }
        #endregion
        
    }

    public class EquipmentModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string EquiType { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 型号
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 最低数量
        /// </summary>
        public int MinQuantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        public EquipmentModel()
        {
        }

        public EquipmentModel(Equipment equi)
        {
            this.Id = equi.Id;

            this.EquiType = equi.EquiType == null ? "" : equi.EquiType.Name;

            this.Name = equi.Name;

            this.Model = equi.Model;

            this.Unit = equi.Unit;

            this.Quantity = equi.Quantity;

            this.MinQuantity = equi.MinQuantity;

            this.Price = equi.Price;

            this.Note = equi.Note;
        }

        public EquipmentModel(EquiIn equi)
        {
            if (equi.Equipment != null)
            {
                this.Id = equi.Equipment.Id;

                this.EquiType = equi.Equipment.EquiType == null ? "" : equi.Equipment.EquiType.Name;

                this.Name = equi.Equipment.Name;

                this.Model = equi.Equipment.Model;

                this.Unit = equi.Equipment.Unit;
                
                this.MinQuantity = equi.Equipment.MinQuantity;

                this.Note = equi.Equipment.Note;
            }
            
            this.Quantity = equi.Quantity;

            this.Price = equi.Price;
        }

        public EquipmentModel(EquiOut equi)
        {
            if (equi.Equipment != null)
            {
                this.Id = equi.Equipment.Id;

                this.EquiType = equi.Equipment.EquiType == null ? "" : equi.Equipment.EquiType.Name;

                this.Name = equi.Equipment.Name;

                this.Model = equi.Equipment.Model;

                this.Unit = equi.Equipment.Unit;
                
                this.MinQuantity = equi.Equipment.MinQuantity;

                this.Note = equi.Equipment.Note;
            }
            
            this.Quantity = equi.Quantity;

            this.Price = equi.Price;
        }
       

        public static EquipmentModel From(Equipment equi)
        {
            return new EquipmentModel(equi);
        }

        public static EquipmentModel From(EquiIn equi)
        {
            return new EquipmentModel(equi);
        }

        public static EquipmentModel From(EquiOut equi)
        {
            return new EquipmentModel(equi);
        }
    }
    
    public class EquiPriceChangeModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        public string EquiType { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string EquiName { get; set; }

        /// <summary>
        /// 物料型号
        /// </summary>
        public string EquiModel { get; set; }

        /// <summary>
        /// 原库存量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 原价格
        /// </summary>
        public decimal OldPrice { get; set; }

        /// <summary>
        /// 新价格
        /// </summary>
        public decimal NewPrice { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 价格变动时间
        /// </summary>
        public string CreateDateTimeString { get; set; }

        public EquiPriceChangeModel(EquiPriceChange equi)
        {
            this.Id = equi.Id;

            if (equi.EquiIn != null && equi.EquiIn.Equipment != null)
            {
                this.EquiType = equi.EquiIn.Equipment.EquiType == null?"":equi.EquiIn.Equipment.EquiType.Name;
                this.EquiName = equi.EquiIn.Equipment.Name;
                this.EquiModel = equi.EquiIn.Equipment.Model;
            }

            this.Quantity = equi.Quantity;
            this.OldPrice = equi.OldPrice;
            this.NewPrice = equi.NewPrice;
            this.UserName = equi.User == null ? "" : equi.User.LoginName;
            this.CreateDateTimeString = equi.CreateDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static EquiPriceChangeModel From(EquiPriceChange equi)
        {
            return new EquiPriceChangeModel(equi);
        }
    }
}