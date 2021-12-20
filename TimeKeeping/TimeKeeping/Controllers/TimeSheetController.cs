using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeping.Models;
using TimeKeeping.Supporters;

namespace TimeKeeping.Controllers
{
    public class TimeSheetController : Controller
    {
        private readonly TimeKeepingDBContext _context;
        public TimeSheetController(TimeKeepingDBContext context)
        {
            _context = context;
        }

        [HttpGet("/time-sheet/overview/{year:int:maxlength(4)}-{month:int:maxlength(2)}")]
        public IActionResult Overview(int month, int year)
        {
            if(false)
            {
                month = DateTime.Now.Month;
                year = DateTime.Now.Year; 
            }
            var days = DateTime.DaysInMonth(year, month);
            var dateInfos = new List<DateInfo>();
            

            // get date of month
            for(int i = 1; i <= days; i++)
            {
                var date = new DateTime(year, month, i);
                var dateInfo = new DateInfo()
                {
                    DayName = date.DayOfWeek.ToString().Substring(0,3),
                    Day = i,
                    Month = month,
                    Year = year
                };
                dateInfos.Add(dateInfo);
            }
            // get personnel and time
            var employees = _context.Personnel.Select(p => new {
                FullName = $"{p.FirstName} {p.LastName}",
                PersonnelId = p.PersonnelId,


                // còn tính lại cái này
                Days = p.Checkins.Where(c => c.Time.Month == month && c.Time.Year == year).Select(c => c.Time.Date).Distinct().Count(),

                // còn cái này chưa tính
                Hours = 20,

                Checkin = p.Checkins.OrderBy(c => c.Time).Where(c => c.Time.Month == month && c.Time.Year == year).Select(c => 
                new
                {
                    Hour = $"{c.Time.Hour}:{c.Time.Minute.ToString().PadLeft(2, '0')}",
                    Date = c.Time.Date,
                })
            }).ToList();

            string timeInfoJson = JsonConvert.SerializeObject(employees);

            string dateInfoJson = JsonConvert.SerializeObject(dateInfos);

            ViewData["time-info"] = timeInfoJson;

            ViewData["days"] = dateInfoJson;
            return View();
        }
    }
}
