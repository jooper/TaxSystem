using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.CPlatform.Support.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Support;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;

namespace Tax.ICompanyModuleService
{
    [ServiceBundle("api/{Service}")]
    public interface ICompanyService : IServiceKey
    {
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm, ExecutionTimeoutInMilliseconds = 2500, BreakerRequestVolumeThreshold = 3, Injection = @"return  new TbCompany();", RequestCacheEnabled = false)]
        Task<TbCompany> GetCompany(int id);
    }
}