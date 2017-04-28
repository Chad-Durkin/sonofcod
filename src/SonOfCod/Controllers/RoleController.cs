using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SonOfCod.Models;
using SonOfCod.ViewModels;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SonOfCod.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _db;
        // GET: /<controller>/
        public ActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _db.Roles.Add(new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                _db.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
