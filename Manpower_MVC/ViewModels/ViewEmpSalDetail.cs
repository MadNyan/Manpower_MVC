
namespace Manpower_MVC.ViewModels
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ViewEmpSalDetail
    {
        [Display(Name = "薪資項目")]
        public string WorkCateName { get; set; }
        [Display(Name = "金額")]
        public int Salary { get; set; }
    }
}