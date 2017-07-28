using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manpower_MVC.Models
{
    public class Emp
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
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}