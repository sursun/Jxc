using System;
using System.Collections.Generic;
using System.Linq;
using Gms.Domain;
using Gms.Infrastructure;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    using System.Web.Mvc;
    [HandleError]
    [Authorize]
    public class GlassStoreController : BaseController
    {

        public ActionResult Index()
        {
            return View(new GlassStore());
        }

        public ActionResult StoreList(GlassStoreQuery query)
        {
            var list = this.GlassStoreRepository.GetList(query);
            var data = list.Data.Select(c => GlassStoreModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }


        public ActionResult ChangeIndex()
        {
            return View(new StoreChange());
        }

        public ActionResult ChangeList(StoreChangeQuery query)
        {
            var list = this.StoreChangeRepository.GetList(query);
            var data = list.Data.Select(c => StoreChangeModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }

        public ActionResult StoreAdd()
        {
            return View(new GlassStore());
        }

        [Transaction]
        public ActionResult StoreAddAction(GlassStore glassStore)
        {
            try
            {
                var list = this.GlassStoreRepository.GetList(new GlassStoreQuery()
                {
                    GlassTypeId = glassStore.GlassType.Id,
                    Thickness = glassStore.Thickness,
                    LongEdge = glassStore.LongEdge,
                    ShortEdge = glassStore.ShortEdge
                });

                GlassStore store = list.Data.FirstOrDefault();

                if (store != null)
                {
                    store.Amount += glassStore.Amount;
                    store = this.GlassStoreRepository.SaveOrUpdate(store);
                }
                else
                {
                    store = this.GlassStoreRepository.SaveOrUpdate(glassStore);
                }

                this.StoreChangeRepository.SaveOrUpdate(new StoreChange()
                {
                    GlassUsage = GlassUsage.入库,
                    GlassStore = store,
                    Amount = glassStore.Amount,
                    CreateUser = CurrentUser,
                    CreateTime = DateTime.Now
                });
                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

        }

        public ActionResult StoreDelete()
        {
            var change = new StoreChange();
            change.GlassUsage = GlassUsage.加工;
            return View(change);
        }

        [Transaction]
        public ActionResult StoreDeleteAction(StoreChange storeChange)
        {
            try
            {
               GlassStore store = storeChange.GlassStore;

               if (storeChange.Amount < 1)
                {
                    return JsonError("数量必须大于1");
                }

                if (store != null)
                {
                    store.Amount -= storeChange.Amount;
                    this.GlassStoreRepository.SaveOrUpdate(store);
                }
                else
                {
                    return JsonError("库存中不存在此玻璃品种及规格！");
                }

                storeChange.CreateUser = CurrentUser;
                storeChange.CreateTime = DateTime.Now;
                this.StoreChangeRepository.SaveOrUpdate(storeChange);
                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

    }

    public class GlassStoreModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 玻璃品种
        /// </summary>
        public string GlassTypeString { get; set; }

        /// <summary>
        /// 厚度
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
        /// 数量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 总面积
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        public GlassStoreModel(GlassStore glassStore)
        {
            Id = glassStore.Id;
            GlassTypeString = glassStore.GlassType.Name;
            ThicknessString = glassStore.Thickness.ToString();
            LongEdge = glassStore.LongEdge;
            ShortEdge = glassStore.ShortEdge;
            Amount = glassStore.Amount;
            Area = glassStore.Area;
            Note = glassStore.Note;
        }

        public static GlassStoreModel From(GlassStore glassStore)
        {
            return new GlassStoreModel(glassStore);
        }
    }

    public class StoreChangeModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 玻璃品种
        /// </summary>
        public string GlassTypeString { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string LongAndShort { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string GlassUsageString { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCodeNo { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 登记员
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreateTimeString { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        public StoreChangeModel(StoreChange storeChange)
        {
            Id = storeChange.Id;
            GlassTypeString = storeChange.GlassStore.GlassType.Name + storeChange.GlassStore.Thickness;
            LongAndShort = String.Format("{0} * {1}", storeChange.GlassStore.LongEdge, storeChange.GlassStore.ShortEdge);
            GlassUsageString = storeChange.GlassUsage.ToString();
            OrderCodeNo = storeChange.Order == null ? "" : storeChange.Order.CodeNo;
            Amount = storeChange.Amount;
            UserName = storeChange.CreateUser == null ? "" : storeChange.CreateUser.LoginName;
            CreateTimeString = storeChange.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            Note = storeChange.Note;
        }

        public static StoreChangeModel From(StoreChange storeChange)
        {
            return new StoreChangeModel(storeChange);
        }

    }
}
