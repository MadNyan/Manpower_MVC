namespace Manpower_MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ViewWorker
    {
        public int ID { get; set; }
        [Display(Name = "�Ѽ�")]
        public int SalaryDay { get; set; }
        [Display(Name = "�[�Z�ɼ�")]
        public int OvertimeHr { get; set; }
        [Display(Name = "�W�ɮɼ�")]
        public int OverOvertimeHr { get; set; }
        [Display(Name = "�y���s��")]
        public string ListSerialNum { get; set; }
        [Display(Name = "�u��")]
        public string EmpID { get; set; }
        [Display(Name = "���u�m�W")]
        public string EmpName { get; set; }
        [Display(Name = "�u�إN�X")]
        public string WorkCareID { get; set; }
        [Display(Name = "�u�ئW��")]
        public string WorkCareName { get; set; }
        [Display(Name = "�Ƶ�")]
        public string Remark { get; set; }
    }
}