using System.Threading.Tasks;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;
using Tax.ICompanyModuleService.Services;

namespace Tax.CompanyModuleService.Services
{
    public class CompanyService : ProxyServiceBase, ICompanyService
    {
        private readonly CompanyRespository _repository;

        public CompanyService(CompanyRespository repository)
        {
            _repository = repository;
        }

        public Task<TbCompany> GetCompany(int id)
        {
            return Task.FromResult(_repository.GetByKey(0));
        }
    }
}