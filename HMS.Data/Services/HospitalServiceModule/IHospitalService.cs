using HMS.Data.DTOs.HospitalServiceModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS.Data.Services.HospitalServiceModule
{
    public interface IHospitalService
    {
        Task<HospitalServiceDTO> Create(HospitalServiceDTO hospitalServiceDTO);
        Task<HospitalServiceDTO> Update(HospitalServiceDTO hospitalServiceDTO);
        Task<HospitalServiceDTO> GetById(Guid Id);
        Task<bool> Delete(Guid Id);
        Task<List<HospitalServiceDTO>> GetAll();
    }
}