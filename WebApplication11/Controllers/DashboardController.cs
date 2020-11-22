using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;

namespace WebApplication11.Controllers
{
    public class DashboardController : Controller
    {
        public Project2Context _context;
        public DashboardController(Project2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.EmployeeDetail.ToList();
            List<int> ageCount = new List<int>();
            var ages = list.Select(x => x.Age).Distinct();

            foreach (var age in ages)
            {
                ageCount.Add(list.Count(e => e.Age == age));
            }

            var rep = ageCount;
            ViewBag.AGES = ages;
            ViewBag.ACOUNT = ageCount.ToList();

            return View();
        }
    }
}
