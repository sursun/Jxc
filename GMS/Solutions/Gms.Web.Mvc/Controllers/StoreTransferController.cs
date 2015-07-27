using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Gms.Common;
using Gms.Domain;
using Gms.Infrastructure;
using NUnit.Framework.Constraints;
using SharpArch.NHibernate.Contracts.Repositories;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    //[HandleError]
    //[Authorize]
    public class StoreTransferController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(StoreTransferQuery query)
        {
            var list = this.StoreTransferRepository.GetList(query);
            var data = list.Data.Select(c => StoreTransferModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }
        
        public ActionResult Add()
        {
            return View(new StoreTransfer());
        }

        public ActionResult Edit(int id)
        {
            StoreTransfer item = this.StoreTransferRepository.Get(id);
            
            return View(item);
        }

        public ActionResult Detail(int id)
        {
            StoreTransfer item = this.StoreTransferRepository.Get(id);
            
            return View(item);
        }
        
        [Transaction]
        public ActionResult SaveOrUpdate(StoreTransfer obj, string sgoods)
        {
            try
            {
                if (obj.Id > 0)
                {
                    obj = this.StoreTransferRepository.Get(obj.Id);
                    TryUpdateModel(obj);


                    var jser = new JavaScriptSerializer();
                    IList<StoreTransferDetailModel> datas = jser.Deserialize<IList<StoreTransferDetailModel>>(sgoods);


                    var list = this.StoreTransferDetailRepository.GetAll(new StoreTransferDetailQuery
                    {
                        StoreTransferId = obj.Id
                    });

                    IList<StoreTransferDetail> dts = new List<StoreTransferDetail>();

                    //找到存在的进行更新,不存在的删除
                    foreach (var item1 in list)
                    {
                        bool bFlag = false;

                        for (int i = datas.Count - 1; i >= 0; i--)
                        {
                            var item2 = datas[i];

                            if (item1.Goods.Id == item2.Id)
                            {
                                item1.Price = item2.Price;
                                item1.Quantity = item2.StoreGoodsQuantity;
                                item1.TotalAomount = item2.TotalAomount;
                                item1.Note = item2.StoreGoodsNote;

                                dts.Add(item1);
                                datas.Remove(item2);

                                bFlag = true;
                            }
                        }

                        if (!bFlag)
                        {
                            this.StoreTransferDetailRepository.Delete(item1);
                        }
                    }

                    //添加新增的
                    foreach (var item in datas)
                    {
                        dts.Add(new StoreOutDetail()
                        {
                            StoreOut = obj,
                            Goods = this.GoodsRepository.Get(item.Id),
                            Price = item.Price,
                            Quantity = item.StoreGoodsQuantity,
                            TotalAomount = item.TotalAomount,
                            Note = item.StoreGoodsNote
                        });
                    }
                    
                    foreach (var item in dts)
                    {
                        this.StoreOutDetailRepository.SaveOrUpdate(item);
                    }
                }
                else
                {
                    if (obj.Store == null)
                    {
                        return JsonError("请选择仓库");
                    }

                    if (obj.Customer == null)
                    {
                        return JsonError("请选择客户");
                    }

                    if (obj.Seller == null)
                    {
                        return JsonError("请选择销售员");
                    }
                }

                obj = this.StoreOutRepository.SaveOrUpdate(obj);
                
                return JsonSuccess(obj);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = this.StoreOutRepository.Get(id);

                var list = this.StoreOutDetailRepository.GetAll(new StoreOutDetailQuery
                {
                    StoreOutId = obj.Id
                });

                if (list.Count > 0)
                {
                    return JsonError("出库单中存在商品，请清空后再试！");
                }

                this.StoreOutRepository.Delete(obj);

                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        #region 商品维护

        public ActionResult DetailList(int storeOutId)
        {
            var list = this.StoreOutDetailRepository.GetAll(new StoreOutDetailQuery
            {
                StoreOutId = storeOutId
            });

            var data = list.Select(c => StoreOutDetailModel.From(c)).ToList();
            var result = new { total = list.Count, rows = data };
            return Json(result);
        }
        
        #endregion
        
        #region 商品审核

        public ActionResult Audit()
        {
            return View();
        }

        [Transaction]
        public ActionResult SaveAudit(int id, int pass)
        {
            var item = this.StoreOutRepository.Get(id);

            if (item != null && item.AuditState == AuditState.未审核)
            {
                item.Auditor = CurrentUser;
                item.AuditTime = DateTime.Now;

                if (pass == 1)
                {
                    item.AuditState = AuditState.审核成功;
                }
                else
                {
                    item.AuditState = AuditState.审核失败;
                }

                item = this.StoreOutRepository.SaveOrUpdate(item);

                return JsonSuccess(item);
            }

            return JsonError("审核失败，请刷新后再试");
        }
   
        
        #endregion

    }


    public class StoreTransferModel : AuditBaseModel
    {
        /// <summary>
        /// 票号
        /// </summary>
        public String CodeNo { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public String OrderCode { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public String OrderTimeStr { get; set; }

        /// <summary>
        /// 调出仓库
        /// </summary>
        public int FromStoreId { get; set; }
        public String FromStoreName { get; set; }

        /// <summary>
        /// 调入仓库
        /// </summary> 
        public int ToStoreId { get; set; }
        public String ToStoreName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        public StoreTransferModel(StoreTransfer storeTransfer)
            : base(storeTransfer)
        {
            this.CodeNo = storeTransfer.CodeNo;
            this.OrderCode = storeTransfer.OrderCode;
            this.OrderTimeStr = storeTransfer.OrderTime.ToString("yyyy-MM-dd HH:mm:ss");

            if (storeTransfer.FromStore != null)
            {
                this.FromStoreId = storeTransfer.FromStore.Id;
                this.FromStoreName = storeTransfer.FromStore.Name;
            }

            if (storeTransfer.ToStore != null)
            {
                this.ToStoreId = storeTransfer.ToStore.Id;
                this.ToStoreName = storeTransfer.ToStore.Name;
            }
            
            this.Note = storeTransfer.Note;
        }

        public static StoreTransferModel From(StoreTransfer storeTransfer)
        {
            return new StoreTransferModel(storeTransfer);
        }
    }

    public class StoreTransferDetailModel : StoreGoodsModel
    {
        public int StoreTransferId { get; set; }
        public String StoreTransferCodeNo { get; set; }

        public StoreTransferDetailModel()
        {
        }

        public StoreTransferDetailModel(StoreTransferDetail storeTransferDetail)
            : base(storeTransferDetail)
        {
            if (storeTransferDetail.StoreTransfer != null)
            {
                this.StoreTransferId = storeTransferDetail.StoreTransfer.Id;
                this.StoreTransferCodeNo = storeTransferDetail.StoreTransfer.CodeNo;
            }
        }

        public static StoreTransferDetailModel From(StoreTransferDetail storeTransferDetail)
        {
            return new StoreTransferDetailModel(storeTransferDetail);
        }

    }

}