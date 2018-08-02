using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Ext;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.IRepositories;
using Tax.ICompanyModuleService.Services;

namespace Tax.CompanyModuleService.Services
{
    public class CustomerService : ProxyServiceBase, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IList<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.Entities.ToListAsync();
        }

        public async Task<int> AddCustomer(DCustomer customer)
        {
            var entity = customer.MapTo<Customer, DCustomer>();
            var result = _customerRepository.Insert(entity);
            return await Task.FromResult(result);
        }

        public async Task<int> UpdateCustomer(DCustomer customer)
        {
            var entity = customer.MapTo<Customer, DCustomer>();
            var result = _customerRepository.Update(entity);
            return await Task.FromResult(result);
        }
    }
}