using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.ViewModels;
using Manpower_MVC.Controllers.Api;

namespace Manpower_MVC.Controllers
{
    public class PrintListController : ApiController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MonthWork()
        {
            return View();
        }
        public ActionResult EmpSal()
        {
            return View();
        }
        public ActionResult PayDetail()
        {
            return View();
        }
        public ActionResult PayWork()
        {
            return View();
        }
        public ActionResult getMonthWork(DateTime? date)
        {
            if (date != null)
            {
                return Json(getViewPrintMonthWork(date.Value.Year, date.Value.Month), JsonRequestBehavior.AllowGet);
            }
            return Json(new ViewPrintMonthWork(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getEmpSal()
        {
            return Json(getViewPrintEmpSal(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getPayment()
        {
            return Json(getViewPrintPayment(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getPayDetail(int? building, int? year, int? month)
        {
            if (building != null && year != null && month != null)
            {
                return Json(getViewPrintPayDetail(building.Value, year.Value, month.Value), JsonRequestBehavior.AllowGet);
            }
            return Json(new List<ViewPrintPayDetail>(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getPayWork(int? building, int? year, int? month)
        {
            if (building != null && year != null && month != null)
            {
                return Json(getViewPrintPayWork(building.Value, year.Value, month.Value), JsonRequestBehavior.AllowGet);
            }
            return Json(new List<ViewPrintPayWork>(), JsonRequestBehavior.AllowGet);
        }

        /***********************************************************/
        // PrintMonthWork

        public ActionResult PrintMonthWork(DateTime? date)
        {
            int year = date.Value.Year;
            int month = date.Value.Month;
            ViewBag.year = year;
            ViewBag.month = month;
            return View(getViewPrintMonthWork(year, month));
        }
        public ActionResult PrintEmpSal()
        {
            List<ViewPrintEmpSal> print = getViewPrintEmpSal().ToList();
            ViewPrintEmpSal sum = new ViewPrintEmpSal()
            {
                EmpID = "",
                EmpName = "合計：",
                ID = 0,
                OverOvertimeHr = 0,
                OverOvertimeSal = 0,
                OvertimeHr = 0,
                OvertimeSal = 0,
                Salary = 0,
                SalaryDay = 0,
                WorkCate = "",
                Sum = 0
            };
            foreach(ViewPrintEmpSal _print in print)
            {
                sum.OverOvertimeHr += _print.OverOvertimeHr;
                sum.OverOvertimeSal += _print.OverOvertimeSal;
                sum.OvertimeHr += _print.OvertimeHr;
                sum.OvertimeSal += _print.OvertimeSal;
                sum.Salary += _print.Salary;
                sum.SalaryDay += _print.SalaryDay;
                sum.Sum += _print.Sum;
            }
            print.Add(sum);
            return View(print);
        }

        // PrintPay
        
        public ActionResult PrintPayWork(int? building, int? year, int? month)
        {
            ViewBag.Date = DateTime.Now.ToString("yyyy-MM-dd");
            if (building != null && year != null && month != null)
            {
                List<ViewPrintPayWork> print = new List<ViewPrintPayWork>();
                ViewBag.Building = getOneOwnerBuilding(building.Value);
                ViewBag.Owner = getOneOwner(getOneOwnerBuilding(building.Value).OwnerID);
                ViewBag.year = year;
                ViewBag.month = month;
                foreach (ViewPrintPayWork _print in getViewPrintPayWork(building.Value, year.Value, month.Value).ToList())
                {
                    if (_print.Sum != 0)
                    {
                        print.Add(_print);
                    }
                }
                int sum = 0;
                foreach (ViewPrintPayWork _print in print)
                {
                    sum += _print.Sum;
                }
                ViewBag.sum = sum;
                return View(print);
            }
            ViewBag.Building = new OwnerBuilding();
            ViewBag.Owner = new Owner();
            return View(new List<ViewPrintPayWork>());
        }
        public ActionResult PrintPayDetail(int? building, int? year, int? month)
        {
            ViewBag.Date = DateTime.Now.ToString("yyyy-MM-dd");
            if (building != null && year != null && month != null)
            {
                List<ViewPrintPayDetail> print = getViewPrintPayDetail(building.Value, year.Value, month.Value);
                ViewBag.Building = getOneOwnerBuilding(building.Value);
                ViewBag.Owner = getOneOwner(getOneOwnerBuilding(building.Value).OwnerID);
                ViewBag.year = year;
                ViewBag.month = month;
                ViewPrintPayDetail sum = new ViewPrintPayDetail()
                {
                    ID = 0,
                    Date = null,
                    WorkCate = "",
                    SerialNum = "",
                    OverOvertimeHr = 0,
                    OverOvertimeSal = 0,
                    OvertimeHr = 0,
                    OvertimeSal = 0,
                    Salary = 0,
                    SalaryDay = 0,
                    Sum = 0
                };
                foreach (ViewPrintPayDetail _print in print)
                {
                    sum.OverOvertimeHr += _print.OverOvertimeHr;
                    sum.OverOvertimeSal += _print.OverOvertimeSal;
                    sum.OvertimeHr += _print.OvertimeHr;
                    sum.OvertimeSal += _print.OvertimeSal;
                    sum.Salary += _print.Salary;
                    sum.SalaryDay += _print.SalaryDay;
                    sum.Sum += _print.Sum;
                }
                print.Add(sum);
                return View(print);
            }
            ViewBag.Building = new OwnerBuilding();
            ViewBag.Owner = new Owner();
            return View(new List<ViewPrintPayDetail>());
        }
    }
}