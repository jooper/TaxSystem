using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
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

        public CustomerService(CustomerRespository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = _customerRepository.GetByKey(id);
            return Task.FromResult(customer);
        }

        public async Task<int> GetAllCustomerCountAsync()
        {
            var count = _customerRepository.Entities.Count(w => w.IsValied);
            return await Task.FromResult(count);
        }

        public async Task<IList<Customer>> GetCustomersAsync(int offSet, int take)
        {
            var companies = await _customerRepository.Entities.Where(w => w.IsValied)
                .OrderByDescending(o => o.UpdateTime).Skip(offSet).Take(take)
                .ToListAsync();
            return companies;
        }

        public async Task<int> AddCustomerAsync(DCustomer customer)
        {
            var entity = customer.MapTo<Customer, DCustomer>();
            var result = _customerRepository.Insert(entity);
            return await Task.FromResult(result);
        }

        public async Task<int> UpdateCustomerAsync(DCustomer customer)
        {
            var entity = customer.MapTo<Customer, DCustomer>();
            var result = _customerRepository.Update(entity);
            return await Task.FromResult(result);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            var customer = _customerRepository.Find(x => x.Id == id).FirstOrDefault();
            if (customer == null)
                return await Task.FromResult(0);
            customer.IsValied = false;
            var result = _customerRepository.Update(customer);
            return await Task.FromResult(result);
        }

        public async Task<int> BatchCalcCustomerTotalTaxAccountAsync(List<(int, decimal)> list)
        {
            if (!list.Any())
                return await Task.FromResult(0);
            var uids = list.Select(x => x.Item1).Distinct();
            var customers = _customerRepository.Find(x => uids.Contains(x.Id) && x.IsValied).ToList();

            customers.ForEach(x => { x.TotalAmmout = (double) list.FirstOrDefault(f => f.Item1 == x.Id).Item2; });

            var result = _customerRepository.Update(customers);
            return  result;
        }
    }
}