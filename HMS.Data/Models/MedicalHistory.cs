using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMS.Data.Models
{
  public partial  class MedicalHistory
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public bool Diabetes { get; set; }
        public bool Hypertension { get; set; }
        public bool Respiratory { get; set; }
        public bool Cardiac { get; set; }
        public bool Renal { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
    }
}
