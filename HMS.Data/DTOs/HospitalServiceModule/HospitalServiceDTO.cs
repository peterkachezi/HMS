using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Data.DTOs.HospitalServiceModule
{
   public class HospitalServiceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        public string NewCreateDate { get { return CreateDate.ToShortDateString(); } }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
    }
}
