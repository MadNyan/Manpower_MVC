namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ViewWorkList
    {
        public int ID { get; set; }
        [Display(Name = "流水號")]
        public string SerialNum { get; set; }
        [Display(Name = "單號")]
        public string SingleNum { get; set; }
        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime CreateDate { get; set; }
        [Display(Name = "工地")]
        public string BuildName { get; set; }
        [Display(Name = "連絡人")]
        public string ConPerson { get; set; }
        [Display(Name = "業主")]
        public string OwnerName { get; set; }
    }
}