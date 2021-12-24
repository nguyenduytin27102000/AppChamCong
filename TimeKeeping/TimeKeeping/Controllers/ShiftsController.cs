using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeping.Models;

namespace TimeKeeping.Controllers
{
    public class ShiftsController : Controller
    {
        private readonly TimeKeepingDBContext _context;

        public ShiftsController(TimeKeepingDBContext context)
        {
            _context = context;
        }
    }
}
