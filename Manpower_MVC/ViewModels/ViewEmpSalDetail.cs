
namespace Manpower_MVC.ViewModels
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ViewEmpSalDetail
    {
        [Display(Name = "薪資項目")]
        public string WorkCateName { get; set; }
        [Display(Name = "日薪")]
        public int Salary { get; set; }
        [Display(Name = "加班時薪")]
        public int OvertimeSal { get; set; }
        [Display(Name = "超時時薪")]
        public int OverOvertimeSal { get; set; }
        [Display(Name = "天數")]
        public int SalaryDay { get; set; }
        [Display(Name = "加班時數")]
        public int OvertimeHr { get; set; }
        [Display(Name = "超時時數")]
        public int OverOvertimeHr { get; set; }
        [Display(Name = "金額")]
        public int TotalSalary { get; set; }
    }
}