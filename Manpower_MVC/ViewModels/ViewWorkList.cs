namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class ViewWorkList
    {
        public int ID { get; set; }
        public string SerialNum { get; set; }
        public string SingleNum { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string BuildName { get; set; }
        public string ConPerson { get; set; }
        public string OwnerName { get; set; }
    }
}