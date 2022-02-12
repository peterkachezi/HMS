using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMS.Data.Models
{
    public partial class Patient
    {
        public Guid Id { get; set; }
        public string VisitCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
    }
}
