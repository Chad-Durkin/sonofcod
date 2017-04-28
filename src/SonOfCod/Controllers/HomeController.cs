using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Diagnostics;
using SonOfCod.ViewModels;
using SonOfCod.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SonOfCod.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, IHostingEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _environment = environment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.MailingList = _db.MailingLists.ToList();
            return View();
        }
        [HttpPost, ActionName("Index")]
        public IActionResult AddToMailList()
        {
            var name = Request.Form["Name"];
            var email = Request.Form["Email"];
            var newMailList = new MailingList { Name = name, Email = email };
            _db.MailingLists.Add(newMailList);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
