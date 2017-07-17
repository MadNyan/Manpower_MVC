
namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class ViewMonSalary
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public int TotalSalary { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> Month { get; set; }
    }
}