
namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class ViewPrintPayDetail
    {
		public int ID { get; set; }
        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}")]
        public DateTime Date { get; set; }
        [Display(Name = "單號")]
        public string SerialNum { get; set; }
        [Display(Name = "工種")]
        public string WorkCate { get; set; }
        [Display(Name = "數量")]
        public int SalaryDay { get; set; }
        [Display(Name = "金額")]
        public int Salary { get; set; }
        [Display(Name = "數量")]
        public int OvertimeHr { get; set; }
        [Display(Name = "金額")]
        public int OvertimeSal { get; set; }
        [Display(Name = "數量")]
        public int OverOvertimeHr { get; set; }
        [Display(Name = "金額")]
        public int OverOvertimeSal { get; set; }
        [Display(Name = "合計")]
        public int Sum { get; set; }
    }
}