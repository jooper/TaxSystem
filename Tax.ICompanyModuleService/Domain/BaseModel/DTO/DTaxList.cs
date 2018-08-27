using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.ICompanyModuleService.Domain.BaseModel.DTO
{
    public class DTaxList : TaxList
    {
        public new double TaxPercent
        {
            set
            {
                base.TaxPercent = value;
                CalcShouldReceiveAccount();
            }
            get => base.TaxPercent;
        }

        public new decimal Account
        {
            set
            {
                base.Account = value;
                ValueAddedTax = CalcValueAddedTaxAccountAsync();
                IncomeTax = CalcIncomeTaxAccount();
                LandTax = CalcLandTaxAccount();
                CalcGovernmentRealReceiveAccount();
                CalcShouldReceiveAccount();
            }
            get => base.Account;
        }


        //实际政府输入时候才能计算差额
        public new decimal RealToGovernmentAccount
        {
            set
            {
                base.RealToGovernmentAccount = value;
                CalcDiffAccount();
            }
            get => base.RealToGovernmentAccount;
        }
    }
}