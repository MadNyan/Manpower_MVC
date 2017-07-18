
namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ViewEmpIns
    {
        public int ID { get; set; }
        [Display(Name = "代號")]
        public string InsID { get; set; }
        [Display(Name = "名稱")]
        public string InsName { get; set; }
        [Display(Name = "加項/減項")]
        public string PosOrNeg { get; set; }
        [Display(Name = "金額")]
        public int Price { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }
    }
}