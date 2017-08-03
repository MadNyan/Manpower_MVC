using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Manpower_MVC.REST.Models;

namespace Manpower_MVC.REST.ViewModels
{
    public class ViewEmp
    {
        public List<Emp> EmpList { get; set; }

        public List<EmpInsurance> InsList { get; set; }

        public List<InsCate> InsCateList { get; set; }

    }
}