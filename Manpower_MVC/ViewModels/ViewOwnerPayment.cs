
namespace Manpower_MVC.ViewModels
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ViewOwnerPayment
    {
        public int ID { get; set; }
        [Display(Name = "單號")]
        public string PayID { get; set; }
        [Display(Name = "業主")]
        public string OwnerName { get; set; }
    }
}