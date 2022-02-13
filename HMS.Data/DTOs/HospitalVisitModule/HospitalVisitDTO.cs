using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Data.DTOs.HospitalVisitModule
{
  public  class HospitalVisitDTO
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? ServiceId { get; set; }
        public byte VisitStatus { get; set; }
        public DateTime VisitDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
