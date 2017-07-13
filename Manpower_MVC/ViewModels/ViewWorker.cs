namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class ViewWorker
    {
        public int ID { get; set; }
        public int SalaryDay { get; set; }
        public int OvertimeHr { get; set; }
        public int OverOvertimeHr { get; set; }
        public string ListSerialNum { get; set; }
        public string EmpID { get; set; }
		public string EmpName { get; set; }
        public string WorkCareID { get; set; }
		public string WorkCareName { get; set; }
        public string Remark { get; set; }
    }
}