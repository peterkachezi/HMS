using HMS.Data.DTOs.AppointmentModule;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS.Data.Services.AppointmentModule
{
    public interface IAppointmentService
    {
        Task<AppointmentDTO> Create(AppointmentDTO appointmentDTO);
        Task<List<AppointmentDTO>> GetAll();
    }
}