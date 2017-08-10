
namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Manpower_MVC.Models;
    public partial class ViewEmp
    {
        public Employee Emp { get; set; }
        public List<EmpInsurance> EmpIns { get; set; }
        public List<InsCate> InsCate { get; set; }
    }
}