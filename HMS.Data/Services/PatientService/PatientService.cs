using HMS.Data.DTOs.PatientService;
using HMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using POS.Data.Utils;

namespace HMS.Data.Services.PatientService
{
    public class PatientService : IPatientService
    {
        private  ApplicationDbContext context;

        public PatientService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<PatientDTO> Create(PatientDTO patientDTO)
        {
            try
            {
                string code = PatientNumber.GenerateUniqueNumber();

                patientDTO.VisitCode = "P" + "" + code;

                var s = new Patient
                {
                    Id = Guid.NewGuid(),

                    VisitCode = patientDTO.VisitCode,

                    FirstName = patientDTO.FirstName,

                    LastName = patientDTO.LastName,

                    IdNumber = patientDTO.IdNumber,

                    PhoneNumber = patientDTO.PhoneNumber,

                    Gender = patientDTO.Gender,

                    CreateDate = DateTime.Now,

                    CreatedBy = patientDTO.CreatedBy,

                    Town = patientDTO.Town,

                    CountyId = patientDTO.CountyId,

                };

                context.Patients.Add(s);

                await context.SaveChangesAsync();

                return patientDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                bool result = false;

                var s = await context.Patients.FindAsync(Id);

                if (s != null)
                {
                    context.Patients.Remove(s);

                    await context.SaveChangesAsync();

                    return true;
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<List<PatientDTO>> GetAll()
        {
            try
            {
                var patients = (from p in context.Patients

                                join u in context.AppUser on p.CreatedBy equals u.Id

                                join c in context.Counties on p.CountyId equals c.Id

                                select new PatientDTO
                                {
                                    Id = p.Id,

                                    VisitCode = p.VisitCode,

                                    FirstName = p.FirstName,

                                    LastName = p.LastName,

                                    IdNumber = p.IdNumber,

                                    PhoneNumber = p.PhoneNumber,

                                    Gender = p.Gender,

                                    CreateDate = p.CreateDate,

                                    CreatedBy = p.CreatedBy,

                                    Town = p.Town,

                                    CountyId = p.CountyId,

                                    countyName = c.Name,

                                    CreatedByName = u.FirstName + " " + u.LastName,

                                }).OrderByDescending(x => x.CreateDate).ToListAsync();

                return await patients;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }

        public async Task<PatientDTO> GetById(Guid Id)
        {
            try
            {
                var patient = (from p in context.Patients

                                join u in context.AppUser on p.CreatedBy equals u.Id

                                where p.Id==Id

                                select new PatientDTO
                                {
                                    Id = p.Id,

                                    VisitCode = p.VisitCode,

                                    FirstName = p.FirstName,

                                    LastName = p.LastName,

                                    IdNumber = p.IdNumber,

                                    PhoneNumber = p.PhoneNumber,

                                    Gender = p.Gender,

                                    CreateDate = p.CreateDate,

                                    CreatedBy = p.CreatedBy,

                                    CreatedByName = u.FirstName + " " + u.LastName,

                                    Town = p.Town,

                                    CountyId = p.CountyId,

                                }).FirstOrDefaultAsync();

                return await patient;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<PatientDTO> Update(PatientDTO patientDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Patients.FindAsync(patientDTO.Id);
                    {
                        s.FirstName = patientDTO.FirstName;

                        s.LastName = patientDTO.LastName;

                        s.IdNumber = patientDTO.IdNumber;

                        s.PhoneNumber = patientDTO.PhoneNumber;

                        s.Gender = patientDTO.Gender;

                        s.Town = patientDTO.Town;

                        s.CountyId = patientDTO.CountyId;

                    };

                    transaction.Commit();

                    await context.SaveChangesAsync();                                       
                }

                return patientDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
