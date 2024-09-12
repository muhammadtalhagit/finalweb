using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using symphonylimited.Models;
using System.Diagnostics;

namespace symphonylimited.Controllers
{
	public class HomeController : Controller
	{
		  
        private readonly SymphonyContext db;
        public HomeController(SymphonyContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
		{
			var CoursesData = db.Courses.Include(c => c.RegisteredStudents);
			return View(CoursesData.ToList());
		 
        }

		public IActionResult About()
		{
            //if (HttpContext.Session.GetString("role") == "user")
            //{
            //    ViewBag.email = HttpContext.Session.GetString("userEmail");
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Admin");
            //}
            return View();
        }

		public IActionResult Courses()
		{
			var CoursesData = db.Courses.Include(c => c.RegisteredStudents);
			return View(CoursesData.ToList());
		}

		public IActionResult CoursesDetails(int id)
		{
           var courses = db.Courses.Include(c => c.RegisteredStudents);
           var CoursesDetails = courses.FirstOrDefault(c => c.Id==id);
			return View(CoursesDetails);
        }
		public IActionResult EntranceExammination()
		{
            //if (HttpContext.Session.GetString("role") == "user")
            //{
            //    ViewBag.email = HttpContext.Session.GetString("userEmail");
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Admin");
            //}
            return View();
        }

		public IActionResult FAQs()
		{
            //if (HttpContext.Session.GetString("role") == "user")
            //{
            //    ViewBag.email = HttpContext.Session.GetString("userEmail");
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Admin");
            //}
            return View();
        }

		public IActionResult Contact()
		{
            //if (HttpContext.Session.GetString("role") == "user")
            //{
            //    ViewBag.email = HttpContext.Session.GetString("userEmail");
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Admin");
            //}
            return View();

        }

        public IActionResult Registeredstudents()
        {
            //if (HttpContext.Session.GetString("role") == "user")
            //{
            //    ViewBag.email = HttpContext.Session.GetString("userEmail");
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Admin");
            //}
            return View();

        }

        public IActionResult LogoutUser()
		{
			HttpContext.Session.Clear();
			HttpContext.Session.Remove("role");
			HttpContext.Session.Remove("userEmail");

			return RedirectToAction("Login", "Admin");

		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
