
namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ViewPrintMonthWork
    {
        public int ID { get; set; }
        [Display(Name = "工號")]
        public string EmpID { get; set; }
        [Display(Name = "姓名")]
        public string EmpName { get; set; }
        [Display(Name = "工種")]
        public string Worktime { get; set; }
        public int[] Date { get; set; }
        [Display(Name = "合計")]
        public int Sum { get; set; }
    }
}