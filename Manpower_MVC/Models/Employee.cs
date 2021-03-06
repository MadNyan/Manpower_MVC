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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "工號")]
        public string EmpID { get; set; }
        [Display(Name = "姓名")]
        public string EmpName { get; set; }
        [Display(Name = "電話")]
        public string Tel { get; set; }
        [Display(Name = "手機")]
        public string Phone { get; set; }
        [Display(Name = "緊急連絡人")]
        public string ConPerson { get; set; }
        [Display(Name = "緊急連絡電話")]
        public string ConPersonTel { get; set; }
        [Display(Name = "建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
