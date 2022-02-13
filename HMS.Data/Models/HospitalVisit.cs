using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMS.Data.Models
{
 public partial   class HospitalVisit
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        //public Guid? DepartmentId { get; set; }
        //public Guid? ServiceId { get; set; }
        public byte VisitStatus { get; set; }
        public DateTime VisitDate { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
    }
}
