using AutoMapper;
using Microsoft.AspNetCore.Http;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Repository.RepositoryBase;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly IBaseRepository<Domain.Entities.Service, long> _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public ServiceManager(IBaseRepository<Domain.Entities.Service, long> repository, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<IEnumerable<ServiceDto>> GetServices()
        {
            var service = await _repository.GetAll();
            var servicesDto = _mapper.Map<IEnumerable<ServiceDto>>(service);
            return servicesDto;
        }
        public async Task<ServiceDto> GetService(long serviceId)
        {
            var service = await _repository.FindById(serviceId);
            var serviceDto = _mapper.Map<ServiceDto>(service);
            return serviceDto;
        }

        public async Task Create(ServiceDto serviceDto)
        {
            var service = _mapper.Map<Domain.Entities.Service>(serviceDto);

            var serviceName_exists = await _repository.IsExist(s => 
                s.ServiceName.Contains(service.ServiceName) || s.ServiceName == service.ServiceName);

            if (serviceName_exists) throw new Exception("Service name is already exists.");

            var creator = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            if(_httpContext.HttpContext != null)
            {
                service.CreatedByUser= creator;
                service.CreationTime = DateTime.Now;
                service.IsDelete = 0;
            }
            await _repository.InsertAsnyc(service);
        }

        public async Task Update(ServiceDto serviceDto)
        {
            var service = _mapper.Map<Domain.Entities.Service>(serviceDto);

            var updater = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            if (_httpContext.HttpContext != null)
            {
                service.UpdatedByUser= updater;
                service.LastUpdateTime = DateTime.Now;
            }
            await _repository.UpdateAsnyc(service);
        }

        public async Task Delete(long serviceId)
        {
            var serviceExists = await _repository.FindById(serviceId);
            if (serviceExists != null)
            {
                var serviceDto = _mapper.Map<ServiceDto>(serviceExists);
                await Update(serviceDto);
                serviceExists.IsDelete = 1;
                await _repository.DeleteAsnyc(serviceExists);
            }
        }
    }
}
