using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;

namespace Manpower_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        ManpowerDBEntities db = new ManpowerDBEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var Get = from p in db.Employee orderby p.ID descending select p;
            return View(Get.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
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
            return RedirectToAction("Index");
        }
    }
}