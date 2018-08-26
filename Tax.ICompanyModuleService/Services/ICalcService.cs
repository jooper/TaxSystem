using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.ICompanyModuleService.Services
{
    [ServiceBundle("api/{Service}")]
    public interface ICalcService:IServiceKey
    {
        /// <summary>
        /// 计算增值税
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<decimal> CalcValueAddedTaxAccountAsync(TaxList model);
        /// <summary>
        /// 计算所得税
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<decimal> CalcIncomeTaxAccountAsync(TaxList model);
        /// <summary>
        /// 计算地税
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<decimal> CalcLandTaxAccountAsync(TaxList model);
        /// <summary>
        /// 计算政府实际应收
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<decimal> CalcGovernmentShouldRealReceiveAccountAsync(TaxList model);
        /// <summary>
        /// 应收
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<decimal> CalcShouldReceiveAccountAsync(TaxList model);

        /// <summary>
        /// 计算差额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<decimal> CalcDiffAccountAsync(TaxList model);

    }
}