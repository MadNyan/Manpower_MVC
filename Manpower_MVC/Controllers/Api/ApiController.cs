﻿using System;
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
        //select EmpInsurance
        /*************************************************************************************************/
        public List<EmpInsurance> getAllEmpIns(int id)
        {
            var Get = from p in db.EmpInsurance where p.EmpID == id orderby p.ID ascending select p;
            return Get.ToList();
        }
        public EmpInsurance getOneEmpIns(int id)
        {
            var Get = from p in db.EmpInsurance where p.ID == id select p;
            return Get.FirstOrDefault();
        }
        //select InsCate
        /*************************************************************************************************/
        public List<InsCate> getAllInsCate()
        {
            var Get = from p in db.InsCate orderby p.ID ascending select p;
            return Get.ToList();
        }
        public InsCate getOneInsCate(int id)
        {
            var Get = from p in db.InsCate where p.ID == id select p;
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
        //select ViewEmpIns
        /*************************************************************************************************/
        public List<ViewEmpIns> getAllViewEmpIns(int id)
        {
            var Get = from p in db.EmpInsurance
                      join e in db.InsCate on p.InsID equals e.ID
                      where p.EmpID == id
                      orderby p.ID ascending
                      select new ViewEmpIns()
                      {
                          ID = p.ID,
                          InsID = e.InsID,
                          InsName = e.InsName,
                          PosOrNeg = e.PosOrNeg,
                          Price = p.Price,
                          Remark = p.Remark
                      };
            return Get.ToList();
        }
        public ViewEmpIns getOneViewEmpIns(int id)
        {
            var Get = from p in db.EmpInsurance
                      join e in db.InsCate on p.InsID equals e.ID
                      where p.ID == id
                      select new ViewEmpIns()
                      {
                          ID = p.ID,
                          InsID = e.InsID,
                          InsName = e.InsName,
                          PosOrNeg = e.PosOrNeg,
                          Price = p.Price,
                          Remark = p.Remark
                      };
            return Get.FirstOrDefault();
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
        //select ViewEmpSal
        /*************************************************************************************************/
        public List<ViewEmpSal> getAllViewEmpSal()
        {
            var Get = from p in db.WorkList
                      join e in db.Worker on p.ID equals e.ListID
                      join q in db.Employee on e.EmpID equals q.ID
                      orderby p.CreateDate ascending
                      select new ViewEmpSal
                      {
                          ID = q.ID,
                          EmpID = q.EmpID,
                          EmpName = q.EmpName,
                          Month = p.CreateDate.Month,
                          Year = p.CreateDate.Year
                      };
            return Get.Distinct().ToList().OrderByDescending(p => p.Month).ToList().OrderByDescending(p => p.Year).ToList();
        }
        //select ViewEmpSalDetail
        /*************************************************************************************************/
        public List<ViewEmpSalDetail> getViewEmpSalDetail(int id, int year, int month)
        {
            int salary = 0;
            var GetWoker = from p in db.Worker
                           join e in db.WorkList on p.ListID equals e.ID
                           join c in db.WorkCategory on p.WorkCareID equals c.ID
                           where p.EmpID == id && e.CreateDate.Year == year && e.CreateDate.Month == month
                           select new ViewEmpSalDetail
                           {
                               Name = c.WorkCareName,
                               Price = (c.Salary * p.SalaryDay) + (c.OvertimeSal * p.OvertimeHr) + (c.OverOvertimeSal * p.OverOvertimeHr)
                           };
            foreach (ViewEmpSalDetail detail in GetWoker.ToList())
            {
                salary += detail.Price;
            }
            var Get = from p in db.EmpInsurance
                      join e in db.InsCate on p.InsID equals e.ID
                      where p.EmpID == id
                      select new ViewEmpSalDetail
                      {
                          Name = e.InsName,
                          Price = p.Price,
                          PosOrNeg = e.PosOrNeg
                      };
            ViewEmpSalDetail firstDetail = new ViewEmpSalDetail()
            {
                Name = "工資",
                Price = salary,
                PosOrNeg = "加項"
            };
            List<ViewEmpSalDetail> details = new List<ViewEmpSalDetail>();
            details.Add(firstDetail);
            details.AddRange(Get.ToList());
            return details;
        }
        //select ViewPrintMonthSal
        /*************************************************************************************************/
        public List<ViewPrintMonthSal> getViewPrintMonthSal(int year, int month)
        {
            List<ViewPrintMonthSal> monthSal = new List<ViewPrintMonthSal>();
            var Get = from p in db.Employee
                      orderby p.ID
                      ascending
                      select new ViewPrintMonthSal
                      {
                          ID = p.ID,
                          EmpID = p.EmpID,
                          EmpName = p.EmpName
                      };
            foreach (ViewPrintMonthSal _monthSal in Get.ToList())
            {
                _monthSal.Salary = getSalary(_monthSal.ID, year, month);
                for (int i = 1; i <= getAllInsCate().Count; i++)
                {
                    switch (i)
                    {
                        case 1:
                            _monthSal.Allowance = getInsPrice(_monthSal.ID, i);
                            break;
                        case 2:
                            _monthSal.TraCost = getInsPrice(_monthSal.ID, i);
                            break;
                        case 3:
                            _monthSal.LaborIns = getInsPrice(_monthSal.ID, i);
                            break;
                        case 4:
                            _monthSal.HealIns = getInsPrice(_monthSal.ID, i);
                            break;
                        case 5:
                            _monthSal.PenStatute = getInsPrice(_monthSal.ID, i);
                            break;
                        case 6:
                            _monthSal.Tax = getInsPrice(_monthSal.ID, i);
                            break;
                        case 7:
                            _monthSal.GroupIns = getInsPrice(_monthSal.ID, i);
                            break;
                        case 8:
                            _monthSal.Other = getInsPrice(_monthSal.ID, i);
                            break;
                        case 9:
                            _monthSal.Borrowed = getInsPrice(_monthSal.ID, i);
                            break;
                    }
                }
                _monthSal.PosPrice = _monthSal.Salary + _monthSal.Allowance + _monthSal.TraCost;
                _monthSal.NegPrice = _monthSal.LaborIns + _monthSal.HealIns + _monthSal.PenStatute + _monthSal.Tax + _monthSal.GroupIns + _monthSal.Other + _monthSal.Borrowed;
                _monthSal.SumPrice = _monthSal.PosPrice - _monthSal.NegPrice;
                monthSal.Add(_monthSal);
            }
            ViewPrintMonthSal sum = new ViewPrintMonthSal()
            {
                ID = 0,
                EmpID = "合計",
                EmpName = "",
                Allowance = 0,
                Borrowed = 0,
                GroupIns = 0,
                HealIns = 0,
                LaborIns = 0,
                NegPrice = 0,
                Other = 0,
                PenStatute = 0,
                PosPrice = 0,
                Salary = 0,
                SumPrice = 0,
                Tax = 0,
                TraCost = 0
            };
            foreach (ViewPrintMonthSal _monthSal in monthSal)
            {
                sum.Allowance += _monthSal.Allowance;
                sum.Borrowed += _monthSal.Borrowed;
                sum.GroupIns += _monthSal.GroupIns;
                sum.HealIns += _monthSal.HealIns;
                sum.LaborIns += _monthSal.LaborIns;
                sum.NegPrice += _monthSal.NegPrice;
                sum.Other += _monthSal.Other;
                sum.PenStatute += _monthSal.PenStatute;
                sum.PosPrice += _monthSal.PosPrice;
                sum.Salary += _monthSal.Salary;
                sum.SumPrice += _monthSal.SumPrice;
                sum.Tax += _monthSal.Tax;
                sum.TraCost += _monthSal.TraCost;
            }
            monthSal.Add(sum);
            return monthSal;
        }
        public int getSalary(int id, int year, int month)
        {
            int salary = 0;
            var Get = from p in db.Worker
                      join e in db.WorkList on p.ListID equals e.ID
                      join c in db.WorkCategory on p.WorkCareID equals c.ID
                      where p.EmpID == id && e.CreateDate.Year == year && e.CreateDate.Month == month
                      select (c.Salary * p.SalaryDay) + (c.OvertimeSal * p.OvertimeHr) + (c.OverOvertimeSal * p.OverOvertimeHr);
            foreach (int _salary in Get.ToList())
            {
                salary += _salary;
            }
            return salary;
        }
        public int getInsPrice(int id, int insId)
        {
            int price = 0;
            var Get = from p in db.EmpInsurance
                      where p.EmpID == id && p.InsID == insId
                      select p.Price;
            foreach (int _price in Get.ToList())
            {
                price += _price;
            }
            return price;
        }
        //select ViewPrintMonthWork
        /*************************************************************************************************/
        public List<ViewPrintMonthWork> getViewPrintMonthWork(int year, int month)
        {
            List<ViewPrintMonthWork> monthWork = new List<ViewPrintMonthWork>();
            var Get = from p in db.Worker
                      join e in db.Employee on p.EmpID equals e.ID
                      join q in db.WorkList on p.ListID equals q.ID
                      where q.CreateDate.Year == year && q.CreateDate.Month == month
                      orderby p.EmpID
                      ascending
                      select new ViewPrintMonthWork
                      {
                          ID = e.ID,
                          EmpID = e.EmpID,
                          EmpName = e.EmpName
                      };

            foreach (ViewPrintMonthWork _monthWork in Get.Distinct().ToList())
            {
                ViewPrintMonthWork dayWork = new ViewPrintMonthWork()
                {
                    ID = _monthWork.ID,
                    EmpID = _monthWork.EmpID,
                    EmpName = _monthWork.EmpName,
                    Date = new int[31],
                    Worktime = "正常",
                    Sum = 0
                };
                for (int i = 0; i < dayWork.Date.Length; i++)
                {
                    dayWork.Date[i] = getSalaryDay(dayWork.ID, year, month, i);
                    dayWork.Sum += getSalaryDay(dayWork.ID, year, month, i);
                }
                monthWork.Add(dayWork);

                ViewPrintMonthWork hrWork = new ViewPrintMonthWork()
                {
                    ID = _monthWork.ID,
                    EmpID = _monthWork.EmpID,
                    EmpName = _monthWork.EmpName,
                    Date = new int[31],
                    Worktime = "加班",
                    Sum = 0
                };
                for (int i = 0; i < hrWork.Date.Length; i++)
                {
                    hrWork.Date[i] = getOvertimeHr(hrWork.ID, year, month, i);
                    hrWork.Sum += getOvertimeHr(hrWork.ID, year, month, i);
                }
                monthWork.Add(hrWork);
            }
            ViewPrintMonthWork daySum = new ViewPrintMonthWork()
            {
                ID = 0,
                EmpID = "合計",
                EmpName = "",
                Worktime = "正常",
                Date = new int[31],
                Sum = 0
            };
            ViewPrintMonthWork hrSum = new ViewPrintMonthWork()
            {
                ID = 0,
                EmpID = "合計",
                EmpName = "",
                Worktime = "加班",
                Date = new int[31],
                Sum = 0
            };
            foreach (ViewPrintMonthWork _monthWork in monthWork)
            {
                if (_monthWork.Worktime.Equals(daySum.Worktime))
                {
                    for (int i = 0; i < daySum.Date.Length; i++)
                    {
                        daySum.Date[i] += _monthWork.Date[i];
                    }
                    daySum.Sum += _monthWork.Sum;
                }
                else
                {
                    for (int i = 0; i < hrSum.Date.Length; i++)
                    {
                        hrSum.Date[i] += _monthWork.Date[i];   
                    }
                    hrSum.Sum += _monthWork.Sum;
                }
            }
            monthWork.Add(daySum);
            monthWork.Add(hrSum);
            return monthWork;
        }

        public int getSalaryDay(int id, int year, int month, int day)
        {
            int salDay = 0;
            var Get = from p in db.Worker
                      join e in db.Employee on p.EmpID equals e.ID
                      join q in db.WorkList on p.ListID equals q.ID
                      where p.EmpID == id && q.CreateDate.Year == year && q.CreateDate.Month == month && q.CreateDate.Day == day
                      select p.SalaryDay;
            foreach (int _salDay in Get.ToList())
            {
                salDay += _salDay;
            }
            return salDay;
        }
        public int getOvertimeHr(int id, int year, int month, int day)
        {
            int hr = 0;
            var Get = from p in db.Worker
                      join e in db.Employee on p.EmpID equals e.ID
                      join q in db.WorkList on p.ListID equals q.ID
                      where p.EmpID == id && q.CreateDate.Year == year && q.CreateDate.Month == month && q.CreateDate.Day == day
                      select p.OverOvertimeHr + p.OvertimeHr;
            foreach (int _hr in Get.ToList())
            {
                hr += _hr;
            }
            return hr;
        }
    }
}