using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
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
        
        // go to overview timesheet, there are all employees's timesheet
        [HttpGet]
        public IActionResult Overview(int month, int year)
        {
            if(month == 0 || year == 0)
            {
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;
            }
            else if(!IsValidateMonthAndYear(month, year))
            {
                return NotFound();
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
            #region get personnel and time
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
                    DayName = c.Time.DayOfWeek.ToString().Substring(0, 3)
                }),
                DayOff = p.TimeOffRequestPersonnel.Select(p1 => new {
                    DateTime = p1.DayOffs.Where(d => d.DayOffAt.Month == month && d.DayOffAt.Year 
                        == year && d.TimeOffRequest.TimeOffRequestState.TimeOffRequestStateName.ToLower().Equals("accepted"))
                    .Select(d => new { 
                        Date = d.DayOffAt,
                        To = d.ToHour,
                        From = d.FromHour
                    }),
                })
            }).ToList();
            #endregion

            // get shift time
            var morning = _context.Shifts.Where(s => s.StartTime.Hour <= 9)
                .Select(s => new { Start = s.StartTime, End = s.EndTime })
                .FirstOrDefault();
            var afternoon = _context.Shifts.Where(s => s.StartTime.Hour >= 12)
                .Select(s => new { Start = s.StartTime, End = s.EndTime })
                .FirstOrDefault();
            var fullday = new { Start = morning.Start, End = afternoon.End };
            var shift = new { Morning = morning, Afternoon = afternoon, Fullday = fullday };

            // convert object to json
            string shiftsJson = JsonConvert.SerializeObject(shift);
            string timeInfoJson = JsonConvert.SerializeObject(employees);
            string dateInfoJson = JsonConvert.SerializeObject(dateInfos);

            // binding data to view
            ViewData["time-info"] = timeInfoJson;
            ViewData["days"] = dateInfoJson;
            ViewData["shifts"] = shiftsJson;

            ViewData["label-time"] = $"{month.ToString().PadLeft(2, '0')}/{year}";

            // using Tuple get current month and year
            (ViewData["current-month"], ViewData["current-year"]) = (month, year);

            // using Tuple get previous month and year 
            (ViewData["previous-month"], ViewData["previous-year"]) = PreMonthYear(month, year);

            // using Tuple get next month and year 
            (ViewData["next-month"], ViewData["next-year"]) = NextMonthYear(month, year);

            // go to View
            return View();
        }

        // check validity of month and year 
        private bool IsValidateMonthAndYear(int month, int year)
        {
            // The year's value is between 2018 and 2050
            if (month > 12 || month < 1) return false;
            if (year < 2018 || year > 2050) return false;
            return true;
        }

        // get next month and year from input
        private (int, int) NextMonthYear(int month, int year)
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
            return (month, year);
        }

        // get previous month, year from input
        private (int, int) PreMonthYear(int month, int year)
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
            return (month, year);
        }

        // export excel file
        [HttpGet]
        public IActionResult OverviewExportExcelFile(int month, int year, string idFilter)
        {
            if(month == 0 && year == 0 || !IsValidateMonthAndYear(month, year))
            {
                return NotFound();
            }
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
            var employees = _context.Personnel
                .Where(p => string.IsNullOrEmpty(idFilter) ? true : idFilter.Contains(p.PersonnelId))
                .Select(p => new {
                    FullName = $"{p.FirstName} {p.LastName}",
                    PersonnelId = p.PersonnelId,
                    DOB = p.DateOfBirth.Date.ToString("dd/MM/yyyy"),
                    Office = p.Office.OfficeName,
                    Gender = p.Sex ? "Male" : "Female",
                    Days = p.Checkins.Where(c => c.Time.Month == month && c.Time.Year == year)
                    .Select(c => c.Time.Date).Distinct().Count(),

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

        public IActionResult ChangeTimeSheetOverview(int month, int year)
        {
            //return Redirect($"/Timesheet/Overview?month={year}&{month}");
            return RedirectToAction(nameof(Overview), new { month = month, year = year });
        }
    }
}
