using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeping.Supporters;

namespace TimeKeeping.Controllers
{
    public class TimeSheetController : Controller
    {
        [HttpGet("/time-sheet/overview")]
        public IActionResult Overview()
        {
            //ViewData["Now-month"] = DateTime.Now.Month;
            //ViewData["Number-days"] = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var days = DateTime.DaysInMonth(year, month);
            var dateInfos = new List<DateInfo>();
            for(int i = 1; i <= days; i++)
            {
                var date = new DateTime(year, month, i);
                var dateInfo = new DateInfo()
                {
                    DayName = date.DayOfWeek.ToString().Substring(0,3),
                    Day = i,
                    Month = month
                };
                dateInfos.Add(dateInfo);
            }
            string dateInfoJson = JsonConvert.SerializeObject(dateInfos);


            ViewData["days"] = dateInfoJson;
            return View();
        }
    }
}
