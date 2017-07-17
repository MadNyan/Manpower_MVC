
namespace Manpower_MVC.ViewModels
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ViewMonSalDetail
    {
        [Display(Name = "工號")]
        public string EmpID { get; set; }
        [Display(Name = "姓名")]
        public string EmpName { get; set; }
        [Display(Name = "工種")]
        public string WorkCateName { get; set; }
        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> Date { get; set; }
        [Display(Name = "")]
        public int Salary { get; set; }
        public int Overtime { get; set; }
        public int OverOvertime { get; set; }
        public int TotalSalary { get; set; }
    }
}