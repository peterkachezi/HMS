using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Data.DTOs.PatientService
{
  public  class PatientDTO
    {
        public Guid Id { get; set; }
        public string VisitCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime CreateDate { get; set; } 
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
    }
}
