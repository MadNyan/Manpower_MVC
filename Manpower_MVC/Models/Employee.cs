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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        [Required]
        public int ID { get; set; }
        [DisplayName("工號")]
        [Required]
        public string EmpID { get; set; }
        [DisplayName("姓名")]
        [Required]
        public string EmpName { get; set; }
        [DisplayName("電話")]
        public string Tel { get; set; }
        [DisplayName("手機")]
        public string Phone { get; set; }
        [DisplayName("連絡人")]
        public string ConPerson { get; set; }
        [DisplayName("緊急連絡電話")]
        public string ConPersonTel { get; set; }
        [DisplayName("建立日期")]
        [Required]
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
