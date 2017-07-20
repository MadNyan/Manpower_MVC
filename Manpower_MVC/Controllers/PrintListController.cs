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
        // PrintMonthWork
        public ActionResult MonthWork()
        {
            DateTime _date = DateTime.Now;
            ViewBag.year = _date.Year;
            ViewBag.month = _date.Month;
            return View(getViewPrintMonthWork(_date.Year, _date.Month));
        }
        [HttpPost]
        public ActionResult MonthWork(DateTime? date)
        {
            if (date != null)
            {
                ViewBag.year = date.Value.Year;
                ViewBag.month = date.Value.Month;
                return View(getViewPrintMonthWork(date.Value.Year, date.Value.Month));
            }
            return MonthWork();
        }
        public ActionResult PrintMonthWork(int year, int month)
        {
            ViewBag.year = year;
            ViewBag.month = month;
            return View(getViewPrintMonthWork(year, month));
        }

        // PrintEmpSal
        public ActionResult EmpSal()
        {
            return View(getViewPrintEmpSal());
        }
        public ActionResult PrintEmpSal()
        {
            return View(getViewPrintEmpSal());
        }

        // PrintPay
        public ActionResult Payment()
        {
            return View(getViewPrintPayment());
        }
        public ActionResult PayWork(int? building, int? year, int? month)
        {
            ViewBag.Pay = getViewPrintPayment();
            if (building != null && year != null && month != null)
            {
                ViewBag.building = building;
                ViewBag.year = year;
                ViewBag.month = month;
                return View(getViewPrintPayWork(building.Value, year.Value, month.Value));
            }
            return View(new List<ViewPrintPayWork>());
        }
        public ActionResult PayDetail(int? building, int? year, int? month)
        {
            ViewBag.Pay = getViewPrintPayment();
            if (building != null && year != null && month != null)
            {
                ViewBag.building = building;
                ViewBag.year = year;
                ViewBag.month = month;
                return View(getViewPrintPayDetail(building.Value, year.Value, month.Value));
            }
            return View(new List<ViewPrintPayDetail>());
        }
        public ActionResult PrintPayWork(int? building, int? year, int? month)
        {
            ViewBag.Date = DateTime.Now.ToShortDateString();
            if (building != null && year != null && month != null)
            {
                List<ViewPrintPayWork> print = getViewPrintPayWork(building.Value, year.Value, month.Value);
                ViewBag.Building = getOneOwnerBuilding(building.Value);
                ViewBag.Owner = getOneOwner(getOneOwnerBuilding(building.Value).OwnerID);
                ViewBag.year = year;
                ViewBag.month = month;
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
            ViewBag.Date = DateTime.Now.ToShortDateString();
            if (building != null && year != null && month != null)
            {
                List<ViewPrintPayDetail> print = getViewPrintPayDetail(building.Value, year.Value, month.Value);
                ViewBag.Building = getOneOwnerBuilding(building.Value);
                ViewBag.Owner = getOneOwner(getOneOwnerBuilding(building.Value).OwnerID);
                ViewBag.year = year;
                ViewBag.month = month;
                int sum = 0;
                foreach (ViewPrintPayDetail _print in print)
                {
                    sum += _print.Sum;
                }
                ViewBag.sum = sum;
                return View(print);
            }
            ViewBag.Building = new OwnerBuilding();
            ViewBag.Owner = new Owner();
            return View(new List<ViewPrintPayDetail>());
        }
    }
}