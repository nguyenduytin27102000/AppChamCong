//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using TimeKeeping.Models;

//namespace TimeKeeping.Controllers
//{
//    public class ShiftsController : Controller
//    {
//        private readonly TimeKeepingDBContext _context;

//        public ShiftsController(TimeKeepingDBContext context)
//        {
//            _context = context;
//        }

//        public async Task<IActionResult> CreateShiftForAWorkSchedule(string workScheduleID, IFormCollection fields)
//        {
//            // If id doesn't extict.
//            if (workScheduleID == null)
//            {
//                return NotFound();
//            }

//            var workSchedule = await _context.WorkSchedules.FindAsync(workScheduleID);
//            if (workSchedule == null)
//            {
//                return NotFound();
//            }

//            var dayOfWeek = _context.DaysOfWeeks.ToList();

//            foreach (var item in dayOfWeek)
//            {
//                Shift shift = new Shift();

//                for (int i = 1; i <= numberOfShift; i++)
//                {
//                    shift.WorkScheduleId = workScheduleID;
//                    shift.DaysOfWeekId = item.DaysOfWeekId;
//                    shift.ShiftId = $"{workScheduleID}-{item.DaysOfWeekId}-{i}";
//                    shift.ShiftName = fields[$"{item.DaysOfWeekName}-shiftName-{i}"];
//                    shift.TypeShiftId = fields[$"{item.DaysOfWeekName}-typeShift-{i}"];
//                    shift.StartTime = Convert.ToDateTime(fields[$"{item.DaysOfWeekName}-startTime-{i}"]);
//                    shift.EndTime = Convert.ToDateTime(fields[$"{item.DaysOfWeekName}-endTime-{i}"]);

//                    string checkBox = fields[$"{item.DaysOfWeekName}-dayOff-{i}"];

//                    if (checkBox != null)
//                    {
//                        shift.DayOff = true;
//                    }
//                    else
//                    {
//                        shift.DayOff = false;
//                    }

//                    if (ModelState.IsValid)
//                    {
//                        _context.Add(shift);
//                        await _context.SaveChangesAsync();
//                    }
//                }
//            }
//            return RedirectToAction("Details", "WorkSchedules", new { id = workScheduleID });
//        }
//    }
//}
