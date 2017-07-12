
namespace Manpower_MVC.ViewModels
{

    using System;
    using System.Collections.Generic;
    
    public partial class ViewOwnerPayWork
    {
        public int ID { get; set; }
        public int SalaryDay { get; set; }
        public int OvertimeHr { get; set; }
        public int OverOvertimeHr { get; set; }
        public string WorkCareName { get; set; }
        public int Salary { get; set; }
        public int OvertimeSal { get; set; }
        public int OverOvertimeSal { get; set; }
    }
}