using HMS.Data.DTOs.CountyModule;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS.Data.Services.CountyModule
{
    public interface ICountyService
    {
        Task<List<CountyDTO>> GetAll();
    }
}