using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.Controllers.Api;

namespace Manpower_MVC.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(getAllEmp());
        }
        public ActionResult Create()
        {
            return View();
        }

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
        public ActionResult Edit(int id)
        {
            return View(getOneEmp(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee emp)
        {
            Employee _emp = getOneEmp(id);
            _emp.EmpID = emp.EmpID;
            _emp.EmpName = emp.EmpName;
            _emp.Tel = emp.Tel;
            _emp.Phone = emp.Phone;
            _emp.ConPerson = emp.ConPerson;
            _emp.ConPersonTel = emp.ConPersonTel;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            db.Employee.Remove(getOneEmp(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}