using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.ViewModels;

namespace Manpower_MVC.Controllers.Api
{
    public class ApiController : Controller
    {
        protected ManpowerDBEntities db = new ManpowerDBEntities();
        //select Employee
        /*************************************************************************************************/
        public List<Employee> getAllEmp()
        {
            var Get = from p in db.Employee orderby p.ID ascending select p;
            return Get.ToList();
        }
        public Employee getOneEmp(int id)
        {
            var Get = from p in db.Employee where p.ID == id select p;
            return Get.FirstOrDefault();
        }
        //select Owner
        /*************************************************************************************************/
        public List<Owner> getAllOwner()
        {
            var Get = from p in db.Owner orderby p.ID ascending select p;
            return Get.ToList();
        }
        public Owner getOneOwner(int id)
        {
            var Get = from p in db.Owner where p.ID == id select p;
            return Get.FirstOrDefault();
        }
        //select OwnerPayment
        /*************************************************************************************************/
        public OwnerPayment getOneOwnerPay(int id)
        {
            var Get = from p in db.OwnerPayment where p.ID == id select p;
            return Get.FirstOrDefault();
        }
        //select OwnerPayWork
        /*************************************************************************************************/
        public List<OwnerPayWork> getSomeOwnerPayWork(int id)
        {
            var Get = from p in db.OwnerPayWork where p.PayID == id select p;
            return Get.ToList();
        }
        public OwnerPayWork getOneOwnerPayWork(int id)
        {
            var Get = from p in db.OwnerPayWork where p.ID == id select p;
            return Get.FirstOrDefault();
        }
        //select WorkCategory
        /*************************************************************************************************/
        public List<WorkCategory> getAllWorkCate()
        {
            var Get = from p in db.WorkCategory orderby p.ID ascending select p;
            return Get.ToList();
        }
        public WorkCategory getOneWorkCate(int id)
        {
            var Get = from p in db.WorkCategory where p.ID == id select p;
            return Get.FirstOrDefault();
        }
        //select WorkList
        /*************************************************************************************************/
        public List<WorkList> getAllWorkList()
        {
            var Get = from p in db.WorkList orderby p.ID ascending select p;
            return Get.ToList();
        }
        public WorkList getOneWorkList(int id)
        {
            var Get = from p in db.WorkList where p.ID == id select p;
            return Get.FirstOrDefault();
        }
        //select Worker
        /*************************************************************************************************/
        public Worker getOneWorker(int id)
        {
            var Get = from p in db.Worker where p.ID == id select p;
            return Get.FirstOrDefault();
        }
        public List<Worker> getSomeWorker(int id)
        {
            var Get = from p in db.Worker where p.ListID == id select p;
            return Get.ToList();
        }
        //select ViewOwnerPayment
        /*************************************************************************************************/
        public List<ViewOwnerPayment> getViewOwnerPayment()
        {
            var Get = from p in db.OwnerPayment
                      join e in db.Owner on p.OwnerID equals e.ID
                      select new ViewOwnerPayment
                      {
                          ID = p.ID,
                          OwnerID = e.OwnerID,
                          OwnerName = e.OwnerName,
                          ConPerson = e.ConPerson,
                          ConPersonTel = e.ConPersonTel,
                          OwnerTel = e.Tel
                      };
            return Get.ToList();
        }
        //select ViewOwnerPayWork
        /*************************************************************************************************/
        public List<ViewOwnerPayWork> getViewOwnerPayWork(int payId)
        {
            var Get = from p in db.OwnerPayWork
                      join e in db.WorkCategory on p.WorkCareID equals e.ID
                      where p.PayID == payId
                      select new ViewOwnerPayWork
                      {
                          ID = p.ID,
                          SalaryDay = p.SalaryDay,
                          OvertimeHr = p.OvertimeHr,
                          OverOvertimeHr = p.OverOvertimeHr,
                          WorkCareID = e.WorkCareID,
                          WorkCareName = e.WorkCareName,
                          Salary = e.Salary,
                          OvertimeSal = e.OvertimeSal,
                          OverOvertimeSal = e.OverOvertimeSal
                      };
            return Get.ToList();
        }
        //select ViewWorkList
        /*************************************************************************************************/
        public List<ViewWorkList> getAllViewWorkList()
        {
            var Get = from p in db.WorkList
                      join e in db.Owner on p.OwnerID equals e.ID
                      select new ViewWorkList
                      {
                          ID = p.ID,
                          BuildName = p.BuildName,
                          ConPerson = p.ConPerson,
                          CreateDate = p.CreateDate,
                          OwnerName = e.OwnerName,
                          SerialNum = p.SerialNum,
                          SingleNum = p.SingleNum
                      };
            return Get.ToList();
        }
        //select ViewWorker
        /*************************************************************************************************/
        public List<ViewWorker> getSomeViewWorker(int id)
        {
            var Get = from p in db.Worker
                      join e in db.WorkList on p.ListID equals e.ID
                      join q in db.Employee on p.EmpID equals q.ID
                      join c in db.WorkCategory on p.WorkCareID equals c.ID
                      where p.ListID == id
                      select new ViewWorker
                      {
                          ID = p.ID,
                          EmpID = q.EmpID,
                          EmpName = q.EmpName,
                          ListSerialNum = e.SerialNum,
                          OverOvertimeHr = p.OverOvertimeHr,
                          OvertimeHr = p.OvertimeHr,
                          Remark = p.Remark,
                          SalaryDay = p.SalaryDay,
                          WorkCareID = c.WorkCareID,
                          WorkCareName = c.WorkCareName
                      };
            return Get.ToList();
        }
    }
}