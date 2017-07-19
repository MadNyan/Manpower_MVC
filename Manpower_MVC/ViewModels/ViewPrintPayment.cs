
namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class ViewPrintPayment
    {
        public int ID { get; set; }
        [Display(Name = "帳款年月")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM}")]
        public DateTime Date { get; set; }
        [Display(Name = "業主代碼")]
        public string OwnerID { get; set; }
        [Display(Name = "業主名稱")]
        public string OwnerName { get; set; }
        [Display(Name = "工程名稱")]
        public string BuildName { get; set; }
        [Display(Name = "連絡人")]
        public string ConPerson { get; set; }
        [Display(Name = "連絡人電話")]
        public string ConPersonTel { get; set; }
    }
}