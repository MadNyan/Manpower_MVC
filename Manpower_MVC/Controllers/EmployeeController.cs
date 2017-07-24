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
            foreach(EmpInsurance _empIns in getAllEmpIns(id))
            {
                db.EmpInsurance.Remove(_empIns);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Print()
        {
            return View(getAllEmp());
        }
        // ViewEmpIns
        /*************************************************************************************************/
        public ActionResult ListEmpIns(int? id)
        {
            if (id > 0)
            {
                ViewBag.empId = id.Value;
                return View(getAllViewEmpIns(id.Value));
            }
            return RedirectToAction("Index");
        }
        public ActionResult CreateEmpIns(int? id)
        {
            if (id > 0)
            {
                Session["empID"] = id.ToString();
                ViewBag.empId = id.Value;
                ViewBag.InsCate = getAllInsCate();
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmpIns(EmpInsurance empIns)
        {
            EmpInsurance _empIns = new EmpInsurance() {
                EmpID = Convert.ToInt32(Session["empID"].ToString()),
                InsID = empIns.InsID,
                Price = empIns.Price,
                Remark = empIns.Remark
            };
            Session["empID"] = null;
            db.EmpInsurance.Add(_empIns);
            db.SaveChanges();
            return RedirectToAction("ListEmpIns", new { id = _empIns.EmpID });
        }
        public ActionResult EditEmpIns(int id)
        {
            EmpInsurance _empIns = getOneEmpIns(id);
            ViewBag.empId = _empIns.EmpID;
            ViewBag.InsCate = getAllInsCate();
            return View(_empIns);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmpIns(int id, EmpInsurance empIns)
        {
            EmpInsurance _empIns = getOneEmpIns(id);
            _empIns.InsID = empIns.InsID;
            _empIns.Price = empIns.Price;
            _empIns.Remark = empIns.Remark;
            db.SaveChanges();
            return RedirectToAction("ListEmpIns", new { id = _empIns.EmpID });
        }
        public ActionResult DeleteEmpIns(int id)
        {
            EmpInsurance _empIns = getOneEmpIns(id);
            db.EmpInsurance.Remove(_empIns);
            db.SaveChanges();
            return RedirectToAction("ListEmpIns", new { id = _empIns.EmpID });
        }
    }
}