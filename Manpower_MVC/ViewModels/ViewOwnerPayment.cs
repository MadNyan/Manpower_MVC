
namespace Manpower_MVC.ViewModels
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ViewOwnerPayment
    {
        public int ID { get; set; }
        public string PayID { get; set; }
        [Display(Name = "業主代碼")]
        public string OwnerID { get; set; }
        [Display(Name = "業主名稱")]
        public string OwnerName { get; set; }
        [Display(Name = "電話")]
        public string OwnerTel { get; set; }
        [Display(Name = "連絡人")]
        public string ConPerson { get; set; }
        [Display(Name = "連絡人手機")]
        public string ConPersonTel { get; set; }

    }
}