using Manager.Data.DTOs.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS.Data.Services.DepartmentModule
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> Create(DepartmentDTO departmentDTO);
        Task<DepartmentDTO> Update(DepartmentDTO departmentDTO);
        Task<DepartmentDTO> GetById(Guid Id);
        Task<bool> Delete(Guid Id);
        Task<List<DepartmentDTO>> GetAll();
    }
}