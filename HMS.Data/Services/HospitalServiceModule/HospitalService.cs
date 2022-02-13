using HMS.Data.DTOs.HospitalServiceModule;
using HMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data.Services.HospitalServiceModule
{
  public  class HospitalService : IHospitalService
    {
        private readonly ApplicationDbContext context;

        public HospitalService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<HospitalServiceDTO> Create(HospitalServiceDTO hospitalServiceDTO)
        {
            try
            {
                var s = new Service
                {
                    Id = Guid.NewGuid(),

                    Name = hospitalServiceDTO.Name.Trim(),

                    CreateDate = DateTime.Now,

                    CreatedBy = hospitalServiceDTO.CreatedBy,

                };

                context.Services.Add(s);

                await context.SaveChangesAsync();

                return hospitalServiceDTO;
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

                var s = await context.Services.FindAsync(Id);

                if (s != null)
                {
                    context.Services.Remove(s);

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

        public async Task<List<HospitalServiceDTO>> GetAll()
        {
            try
            {
                var department = (from d in context.Services

                                  join u in context.AppUser on d.CreatedBy equals u.Id

                                  select new HospitalServiceDTO
                                  {
                                      Id = d.Id,

                                      Name = d.Name,

                                      CreateDate = d.CreateDate,

                                      CreatedBy = d.CreatedBy,

                                      CreatedByName = u.FirstName + " " + u.LastName

                                  }).ToListAsync();

                return await department;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<HospitalServiceDTO> GetById(Guid Id)
        {
            try
            {
                var department = await context.Services.FindAsync(Id);

                return new HospitalServiceDTO
                {
                    Id = department.Id,

                    Name = department.Name,

                    CreateDate = department.CreateDate,

                    CreatedBy = department.CreatedBy,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<HospitalServiceDTO> Update(HospitalServiceDTO hospitalServiceDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Services.FindAsync(hospitalServiceDTO.Id);
                    {
                        s.Name = hospitalServiceDTO.Name.Trim();
                    };

                    transaction.Commit();
                }

                await context.SaveChangesAsync();

                return hospitalServiceDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
