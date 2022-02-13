using HMS.Data.DTOs.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS.Data.Services.PatientService
{
    public interface IPatientService
    {
        Task<PatientDTO> Create(PatientDTO patientDTO);
        Task<PatientDTO> Update(PatientDTO patientDTO);
        Task<List<PatientDTO>> GetAll();
        Task<bool> Delete(Guid Id);
        Task<PatientDTO> GetById(Guid Id);
        Task<PatientDTO> GetByIdNumber(string IdNumber);
    }
}