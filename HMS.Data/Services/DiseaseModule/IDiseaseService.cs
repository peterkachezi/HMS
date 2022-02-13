using HMS.Data.DTOs.DiseaseModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS.Data.Services.DiseaseModule
{
    public interface IDiseaseService
    {
        Task<DiseaseDTO> Create(DiseaseDTO diseaseDTO);
        Task<DiseaseDTO> Update(DiseaseDTO diseaseDTO);
        Task<DiseaseDTO> GetById(Guid Id);
        Task<bool> Delete(Guid Id);
        Task<List<DiseaseDTO>> GetAll();
    }
}