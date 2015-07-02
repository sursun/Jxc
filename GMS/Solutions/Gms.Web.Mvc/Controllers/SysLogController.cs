using System;
using System.Linq;
using Gms.Domain;

namespace Gms.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    public class SysLogController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(SysLogQuery query)
        {
            var list = this.SysLogRepository.GetList(query);
            var data = list.Data.Select(c => SysLogModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }
    }

    public class SysLogModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public String CreateTimeString { get; set; }

        public SysLogModel(SysLog sysLog)
        {
            this.Id = sysLog.Id;

            if (sysLog.User != null)
                this.UserName = sysLog.User.LoginName;
            this.Content = sysLog.Content;
            this.CreateTimeString = sysLog.CreateTime.ToString("yyyy-MM-dd HH:mm:ss dddd");
        }

        public static SysLogModel From(SysLog sysLog)
        {
            return new SysLogModel(sysLog);
        }

    }
}
