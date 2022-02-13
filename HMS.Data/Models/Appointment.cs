using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMS.Data.Models
{
 public partial   class Appointment
    {
        public Guid Id { get; set; }
        public byte RegistrationStatus { get; set; }
        public byte TriageStatus { get; set; }
        public byte DoctorStatus { get; set; }
        public DateTime VisitDate { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
