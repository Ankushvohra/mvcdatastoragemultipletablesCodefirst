using Microsoft.Win32;
using mvcregister.Data;
using mvcregister.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace mvcregister.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext context;

        public RegisterController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var userlist = context.registers.Include(r => r.City).Include(r => r.City.State).Include(r => r.City.State.Country).ToList();
            return View(userlist);
        }
        [HttpPost]
        public ActionResult Index(Register register)
        {
            return View();
        }
        public ActionResult Upsert(int? Id) {
            ViewBag.countrylist = context.countries.ToList();
            ViewBag.statelist = context.States.ToList();
            ViewBag.citylist = context.Cities.ToList();
            Register register = new Register();
            //create 
            if(Id == null) { return View(register); }
            register = context.registers.Find(Id);
            if(register == null) { return HttpNotFound(); }
            register.countryid = register.City.State.countryId;
            register.StateId = register.City.StateId;
            return View(register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Upsert(Register register)
        {
            if (register == null)
            {
                return HttpNotFound();
            }
            if (!ModelState.IsValid)
            {
                ViewBag.countrylist = context.countries.ToList();
                ViewBag.statelist = context.States.ToList();
                ViewBag.citylist = context.Cities.ToList();
                return View();
            }
            if (register.Id == 0)
                context.registers.Add(register);
            else
            {
                var userIndb = context.registers.Find(register.Id);
                if (userIndb == null) return HttpNotFound();
                userIndb.Name = register.Name;
                userIndb.Address = register.Address;
                userIndb.Email = register.Email;
                userIndb.Gender = register.Gender;
                userIndb.Subscribe = register.Subscribe;
                userIndb.CityId = register.CityId;
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int id)
        {
            var userindb = context.registers.Include(r => r.City).Include(r => r.City.State).Include(r => r.City.State.Country).FirstOrDefault(r => r.Id == id);
            if (userindb == null) { return HttpNotFound(); }
            return View(userindb);
        }
        public ActionResult delete(int Id)
        {
            var userindb = context.registers.Find(Id);
            if (userindb == null) { return HttpNotFound(); }
            return View(userindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete(Register register)
        {
            if (register == null) { return HttpNotFound(); }
            var userindb = context.registers.Find(register.Id);
            if (userindb == null) { return HttpNotFound(); }
            context.registers.Remove(userindb);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete_new(int ID)
        {
            var employeeInDb = context.registers.Find(ID);
            if (employeeInDb == null) { return HttpNotFound(); }
            context.registers.Remove(employeeInDb);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}