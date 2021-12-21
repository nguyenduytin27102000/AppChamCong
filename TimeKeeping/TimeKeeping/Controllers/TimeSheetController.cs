using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        [HttpGet("/Timesheet/Overview/{year:int:maxlength(4)}-{month:int:maxlength(2)}")]
        public IActionResult Overview(int month, int year)
        {
            if(!IsValidateMonthAndYear(month, year))
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
                Off = p.TimeOffRequestPersonnel.Where(t => t.TimeOffDate.Month == month && t.TimeOffDate.Year == year 
                        && t.TimeOffRequestState.TimeOffRequestStateName.ToLower().Equals("accepted")).Count(),

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
            ViewData["title-time"] = $"1/{month} - {days}/{month}";
            ViewData["label-time"] = $"{month}/{year}";
            ViewData["cur-timesheet"] = $"{year}-{month}";
            ViewData["pre-timesheet"] = PreMonthYear(month, year);
            ViewData["next-timesheet"] = NextMonthYear(month, year);
            return View();
        }

        private bool IsValidateMonthAndYear(int month, int year)
        {
            if (month > 12 || month < 1) return false;
            if (year < 2000 || year > 2100) return false;
            return true;
        }

        private string NextMonthYear(int month, int year)
        {
            if(month < 0 || month > 12)
            {
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;
                
            }
            else
            {
                if(month < 12)
                {
                    month++;
                }
                else
                {
                    month = 1;
                    year++;
                }
            }
            return $"{year}-{month}";
        }

        private string PreMonthYear(int month, int year)
        {
            if (month < 0 || month > 12)
            {
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;

            }
            else
            {
                if (month > 1)
                {
                    month--;
                }
                else
                {
                    month = 12;
                    year--;
                }
            }
            return $"{year}-{month}";
        }

        [HttpGet("/Timesheet/Export/{year:int:maxlength(4)}-{month:int:maxlength(2)}")]
        public IActionResult OverviewExportExcelFile(int month, int year)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            DataTable dt = new DataTable("TimesheetOverview");
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("No"),
                new DataColumn("Id"),
                new DataColumn("FullName"),
                new DataColumn("DOB"),
                new DataColumn("Office"),
                new DataColumn("Gender"),
            });

            for(int i = 1; i <= daysInMonth; i++)
            {
                dt.Columns.Add(new DataColumn($"{i}/{month}"));
            }
            var employees = _context.Personnel.Select(p => new {
                FullName = $"{p.FirstName} {p.LastName}",
                PersonnelId = p.PersonnelId,
                DOB = p.DateOfBirth.Date.ToString("dd/MM/yyyy"),
                Office = p.Office.OfficeName,
                Gender = p.Sex ? "Male" : "Female",
                Days = p.Checkins.Where(c => c.Time.Month == month && c.Time.Year == year).Select(c => c.Time.Date).Distinct().Count(),

                // còn cái này chưa tính
                Off = p.TimeOffRequestPersonnel.Where(t => t.TimeOffDate.Month == month && t.TimeOffDate.Year == year
                        && t.TimeOffRequestState.TimeOffRequestStateName.ToLower().Equals("accepted")).Count(),

                Checkin = p.Checkins.OrderBy(c => c.Time).Where(c => c.Time.Month == month && c.Time.Year == year).Select(c =>
                new
                {
                    Hour = $"{c.Time.Hour}:{c.Time.Minute.ToString().PadLeft(2, '0')}",
                    Date = c.Time.Date,
                })
            }).ToList();

            int no = 1;
            foreach(var item in employees)
            {
                string checkinTime = "";
                int count = 1;
                
                DataRow dr = dt.NewRow();
                dr["No"] = no;
                dr["Id"] = item.PersonnelId;
                dr["FullName"] = item.FullName;
                dr["DOB"] = item.DOB;
                dr["Office"] = item.Office;
                dr["Gender"] = item.Gender;

                for(int i = 1; i <= daysInMonth; i++)
                {
                    var ck = item.Checkin.Where(c => c.Date.Day == i).ToArray();
                    if(ck.Length == 0)
                    {
                        dr[$"{i}/{month}"] = "";
                    }
                    else
                    {
                        foreach (var c in ck)
                        {
                            if (count >= 2)
                            {
                                checkinTime += $"-{c.Hour}";
                            }
                            else
                            {
                                checkinTime += c.Hour;
                            }
                            count++;
                        }
                        dr[$"{i}/{month}"] = checkinTime;
                    }
                    count = 1;
                    checkinTime = "";
                }
                no++;
                dt.Rows.Add(dr);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), 
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"TIMESHEETOVERVIEW--{year}-{month}.xlsx");
                }
            }
        }
    }
}
