using HMS.Data.Models;
using Manager.Data.DTOs.DepartmentModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data.Services.DepartmentModule
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext context;

        public DepartmentService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<DepartmentDTO> Create(DepartmentDTO departmentDTO)
        {
            try
            {
                var s = new Department
                {
                    Id = Guid.NewGuid(),

                    Name = departmentDTO.Name.Trim(),

                    CreateDate = DateTime.Now,

                    CreatedBy = departmentDTO.CreatedBy,

                };

                context.Departments.Add(s);

                await context.SaveChangesAsync();

                return departmentDTO;
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

                var s = await context.Departments.FindAsync(Id);

                if (s != null)
                {
                    context.Departments.Remove(s);

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

        public async Task<List<DepartmentDTO>> GetAll()
        {
            try
            {
                var department = (from d in context.Departments

                                  join u in context.AppUser on d.CreatedBy equals u.Id

                                  select new DepartmentDTO
                                  {
                                      Id = d.Id,

                                      Name = d.Name,

                                      CreateDate = d.CreateDate,

                                      CreatedBy = d.CreatedBy,

                                      CreatedByName=u.FirstName +" "+ u.LastName

                                  }).ToListAsync();

                return await department;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<DepartmentDTO> GetById(Guid Id)
        {
            try
            {
                var department = await context.Departments.FindAsync(Id);

                return new DepartmentDTO
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
        public async Task<DepartmentDTO> Update(DepartmentDTO departmentDTO)
        {
            try
            {
                using(var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Departments.FindAsync(departmentDTO.Id);
                    {
                        s.Name = departmentDTO.Name.Trim();  
                    };

                    transaction.Commit();
                }

                await context.SaveChangesAsync();

                return departmentDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
