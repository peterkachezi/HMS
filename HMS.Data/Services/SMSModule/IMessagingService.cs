using HMS.Data.DTOs.ApplicationUsersModule;
using HMS.Data.DTOs.PatientService;

using System.Threading.Tasks;

namespace HMS.Data.Services.SMSModule
{
    public interface IMessagingService
    {
        Task<RegisterDTO> usersAccount(RegisterDTO registerDTO);
        Task<PatientDTO> PatientInfo(PatientDTO  patientDTO);
 
    }
}