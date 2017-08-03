using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manpower_MVC.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set;}
        public bool isAdmin { get; set; }
    }
}