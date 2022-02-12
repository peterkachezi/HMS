using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.Data.Models
{
    public partial class Triage
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal BMI { get; set; }
        public decimal Respiartion { get; set; }
        public decimal Pulse { get; set; }
        public string FoodAllergy { get; set; }
        public string DrugAllergy { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal Temprature { get; set; }
        public decimal BloodPressureSystolic { get; set; }
        public decimal BloodPressureDiastolic { get; set; }
    }
}
