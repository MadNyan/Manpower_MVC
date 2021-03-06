﻿
namespace Manpower_MVC.ViewModels
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ViewOwnerPayWork
    {
        public int ID { get; set; }
        [Display(Name = "天數")]
        public int SalaryDay { get; set; }
        [Display(Name = "加班時數")]
        public int OvertimeHr { get; set; }
        [Display(Name = "超時時數")]
        public int OverOvertimeHr { get; set; }
        [Display(Name = "工種代碼")]
        public string WorkCareID { get; set; }
        [Display(Name = "工種名稱")]
        public string WorkCareName { get; set; }
        [Display(Name = "日薪")]
        public int Salary { get; set; }
        [Display(Name = "加班時薪")]
        public int OvertimeSal { get; set; }
        [Display(Name = "超時時薪")]
        public int OverOvertimeSal { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }

    }
}