namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ViewWorkList
    {
        public int ID { get; set; }
        [Display(Name = "�y����")]
        public string SerialNum { get; set; }
        [Display(Name = "�渹")]
        public string SingleNum { get; set; }
        [Display(Name = "���")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime CreateDate { get; set; }
        [Display(Name = "�u�a")]
        public string BuildName { get; set; }
        [Display(Name = "�s���H")]
        public string ConPerson { get; set; }
        [Display(Name = "�~�D")]
        public string OwnerName { get; set; }
    }
}