using System;
using System.Collections;
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
    public class StoreGoodsController : BaseController
    {

        
    }

    /// <summary>
    /// 库存商品
    /// </summary>
    public class StoreGoodsModel:GoodsModel
    {
        public StoreGoodsModel()
        {
        }

        public int StoreGoodsId { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public decimal StoreGoodsQuantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 总额
        /// </summary>
        public decimal TotalAomount { get; set; }

        /// <summary>
        /// 
        /// 备注
        /// </summary>
        public String StoreGoodsNote { get; set; }

        public StoreGoodsModel(StoreGoods storeGoods):base(storeGoods.Goods)
        {
            this.StoreGoodsId = storeGoods.Id;

            this.StoreGoodsQuantity = storeGoods.Quantity;
            this.Price = storeGoods.Price;
            this.TotalAomount = storeGoods.TotalAomount;
            this.StoreGoodsNote = storeGoods.Note;
        }


        //public static StoreGoodsModel From(StoreGoods storeGoods)
        //{
        //    return new StoreGoodsModel(storeGoods);
        //}
    }

}