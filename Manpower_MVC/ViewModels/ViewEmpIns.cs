
namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Manpower_MVC.Models;

    public partial class ViewEmpIns
    {
        public int ID { get; set; }
        public string InsID { get; set; }
        public string InsName { get; set; }
        public string PosOrNeg { get; set; }
        public int Price { get; set; }
        public string Remark { get; set; }
    }
}