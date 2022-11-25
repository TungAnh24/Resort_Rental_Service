using Resort_Rental.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.ServiceManager
{
    public interface IServiceManager
    {
        Task<IEnumerable<ServiceDto>> GetServices();
        Task<ServiceDto> GetService(long serviceId);
        Task Create(ServiceDto serviceDto);
        Task Update(ServiceDto serviceDto);
        Task Delete(long serviceId);
    }
}
