using System.Dynamic;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Enums
{
    public class TaxTypeVal
    {
        /// <summary>
        /// 增值税
        /// </summary>
        public static double ValueAddedTaxPercent { set; get; } = 0.03;
        /// <summary>
        /// 所得税
        /// </summary>
        public static double IncomeTaxPercent { set; get; } = 0.01;
        /// <summary>
        /// 地税
        /// </summary>
        public static double LandTaxPercernt { set; get; } = 0.12;
        /// <summary>
        /// 发票税
        /// </summary>
        public static double InvoiceTaxPercent { set; get; } = 3;
    }
}