using System.Threading.Tasks;
using Tax.CompanyModuleService.UnitOfWork;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class CompanyRespository : EfBaseRespository<Company>, ICompanyRespository
    {
        public Task<string> GetCompanyNmae()
        {
//            UnitOfWork.Context.Update()
            return Task.FromResult(string.Empty);
        }


        public async Task<int> DeleteShareholderAsync(int id)
        {
            var shareholder = UnitOfWork.Context.Find<Shareholder>(id);
            shareholder.IsValied = false;
            UnitOfWork.Context.Update(shareholder);
            var result = UnitOfWork.Context.SaveChanges();
            return await Task.FromResult(result);
        }

        public async Task<int> UpdateShareholderAsync(Shareholder model)
        {
            UnitOfWork.Context.DetachLocal(model, x => x.CompanyId == model.CompanyId);
            UnitOfWork.Context.Update(model);
            var result = UnitOfWork.Context.SaveChanges();
            return await Task.FromResult(result);
        }
    }
}