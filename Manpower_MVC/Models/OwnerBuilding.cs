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

    public partial class OwnerBuilding
    {
        public int ID { get; set; }
        [Display(Name = "工程名稱")]
        public string BuildingName { get; set; }
        [Display(Name = "連絡人")]
        public string ConPerson { get; set; }
        [Display(Name = "連絡電話")]
        public string ConPersonTel { get; set; }
        public int OwnerID { get; set; }
        [Display(Name = "地址")]
        public string Address { get; set; }
    }
}
