using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Data.DTOs.AppointmentModule
{
   public class AppointmentDTO
    {

        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? ServiceId { get; set; }
        public byte RegistrationStatus { get; set; }
        public byte TriageStatus { get; set; }
        public byte DoctorStatus { get; set; }
        public DateTime VisitDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string PatientName { get; set; }
        public string RegistrationCode { get; set; }
    }
}
