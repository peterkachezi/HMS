using HMS.Data.DTOs.DiseaseModule;
using HMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data.Services.DiseaseModule
{
    public class DiseaseService : IDiseaseService
    {
        private readonly ApplicationDbContext context;

        public DiseaseService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<DiseaseDTO> Create(DiseaseDTO diseaseDTO)
        {
            try
            {
                var s = new Disease
                {
                    Id = Guid.NewGuid(),

                    Name = diseaseDTO.Name.Trim(),

                    CreateDate = DateTime.Now,

                    CreatedBy = diseaseDTO.CreatedBy,

                };

                context.Diseases.Add(s);

                await context.SaveChangesAsync();

                return diseaseDTO;
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

                var s = await context.Diseases.FindAsync(Id);

                if (s != null)
                {
                    context.Diseases.Remove(s);

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

        public async Task<List<DiseaseDTO>> GetAll()
        {
            try
            {
                var department = (from d in context.Diseases

                                  join u in context.AppUser on d.CreatedBy equals u.Id

                                  select new DiseaseDTO
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

        public async Task<DiseaseDTO> GetById(Guid Id)
        {
            try
            {
                var department = await context.Diseases.FindAsync(Id);

                return new DiseaseDTO
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
        public async Task<DiseaseDTO> Update(DiseaseDTO diseaseDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Diseases.FindAsync(diseaseDTO.Id);
                    {
                        s.Name = diseaseDTO.Name.Trim();
                    };

                    transaction.Commit();
                }

                await context.SaveChangesAsync();

                return diseaseDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
