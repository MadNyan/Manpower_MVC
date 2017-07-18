
namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class ViewMonthSal
    {
		public int ID { get; set; }
        [Display(Name = "工號")]
        public string EmpID { get; set; }
        [Display(Name = "姓名")]
        public string EmpName { get; set; }
        [Display(Name = "工資")]
        public int Salary { get; set; }
        [Display(Name = "津貼")]
        public int Allowance { get; set; }
        [Display(Name = "車馬費")]
        public int TraCost { get; set; }
        [Display(Name = "應支金額")]
        public int PosPrice { get; set; }
        [Display(Name = "勞保費")]
        public int LaborIns { get; set; }
        [Display(Name = "健保費")]
        public int HealIns { get; set; }
        [Display(Name = "提撥金")]
        public int PenStatute { get; set; }
        [Display(Name = "稅金")]
        public int Tax { get; set; }
        [Display(Name = "團保")]
        public int GroupIns { get; set; }
        [Display(Name = "其他")]
        public int Other { get; set; }
        [Display(Name = "借支")]
        public int Borrowed { get; set; }
        [Display(Name = "應扣薪資")]
        public int NegPrice { get; set; }
        [Display(Name = "實支薪資")]
        public int SumPrice { get; set; }
    }
}