using Cloud.LifeTool.Infrasturcture;
using Cloud.LifeTool.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cloud.LifeTool.Web.Controllers
{
    public class WorkDayController : BaseController
    {
        /// <summary>
        /// 按日期计算工作日天数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CalByDate()
        {
            var startDate = UrlManager.FormDateTime("start_date") ?? DateTime.Now.Date;
            var endDate = UrlManager.FormDateTime("end_date") ?? DateTime.Now.Date;

            WorkdayService service = new WorkdayService();
            var result = service.CalByDate(startDate, endDate);
            return Json(result);
        }

        /// <summary>
        /// 按工作日天数计算日期
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CalByDay()
        {
            var startDate = UrlManager.FormDateTime("start_date") ?? DateTime.Now.Date;
            var days = UrlManager.FormInt("days") ?? 1;
            WorkdayService service = new WorkdayService();
            var result = service.CalByDay(startDate, days);
            return Json(result);
        }

    }
}
