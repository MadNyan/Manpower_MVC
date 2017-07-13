using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.Controllers.Api;

namespace Manpower_MVC.Controllers
{
    public class HomeController : ApiController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult a01()
        {
            var Get = from p in db.Employee orderby p.ID descending select p;
            return View(Get.ToList());
        }
        public ActionResult a01Ins()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult a01Ins(Employee emp)
        {
            Employee _emp = new Employee();
            _emp.EmpID = emp.EmpID;
            _emp.EmpName = emp.EmpName;
            _emp.Tel = emp.Tel;
            _emp.Phone = emp.Phone;
            _emp.ConPerson = emp.ConPerson;
            _emp.ConPersonTel = emp.ConPersonTel;
            _emp.CreateDate = DateTime.Now;
            db.Employee.Add(_emp);
            db.SaveChanges();
            return RedirectToAction("a01");
        }
    }
}