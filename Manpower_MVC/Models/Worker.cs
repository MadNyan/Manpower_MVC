//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Manpower_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Worker
    {
        public int ID { get; set; }
        [Display(Name = "天數")]
        public int SalaryDay { get; set; }
        [Display(Name = "加班時數")]
        public int OvertimeHr { get; set; }
        [Display(Name = "超時時數")]
        public int OverOvertimeHr { get; set; }
        [Display(Name = "單號")]
        public int ListID { get; set; }
        [Display(Name = "員工")]
        public int EmpID { get; set; }
        [Display(Name = "工種")]
        public int WorkCareID { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }
    }
}
