
using HMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HMS.Data.DTOs.AppointmentModule;

namespace HMS.Data.Services.AppointmentModule
{
    public class AppointmentService : IAppointmentService
    {
        private ApplicationDbContext context;

        public AppointmentService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<AppointmentDTO> Create(AppointmentDTO  appointmentDTO)
        {
            try
            {

                var h = new Appointment
                {
                    Id = Guid.NewGuid(),

                    PatientId = appointmentDTO.PatientId,

                    RegistrationStatus = 1,

                    TriageStatus = 0,

                    DoctorStatus = 0,

                    VisitDate = DateTime.Now,

                    CreatedBy = appointmentDTO.CreatedBy,
                };

                context.Appointments.Add(h);

                await context.SaveChangesAsync();

                return appointmentDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }




        public async Task<List<AppointmentDTO>> GetAll()
        {
            try
            {
                var visits = (from h in context.Appointments

                              join p in context.Patients on h.PatientId equals p.Id

                              join u in context.AppUser on p.CreatedBy equals u.Id

                              select new AppointmentDTO
                              {
                                  Id = h.Id,

                                  PatientId = h.Id,

                                  TriageStatus = h.TriageStatus,

                                  RegistrationStatus = h.RegistrationStatus,

                                  DoctorStatus = h.DoctorStatus,

                                  VisitDate = DateTime.Now,

                                  CreatedBy = h.CreatedBy,

                                  CreatedByName = u.FirstName + " " + u.LastName,

                                  PatientName = p.FirstName + " " + p.LastName,

                                  RegistrationCode = p.RegistrationCode,

                              }).OrderBy(x => x.VisitDate).ToListAsync();

                return await visits;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
