using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tax.ICompanyModuleService.Domain.BaseModel.Enums;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    public class TaxList : AggregateRoot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { set; get; }

        [MaxLength(50)] public int LinkManId { set; get; }
        [StringLength(50)] public string LinkMan { set; get; }
        [StringLength(50)] public string BuyParty { get; set; }
        [StringLength(3)] public TaxState State { set; get; } //交税状态
        [StringLength(3)] public TaxType TaxType { set; get; }
        [StringLength(50)] public string SalesParty { get; set; }
        [MaxLength(20)] public DateTime OpenTaxDateTime { set; get; } //开票日期
        [MaxLength(20)] public DateTime? OverTaxDateTime { set; get; } //结算日期可空
        [MaxLength(30)] public decimal Account { set; get; } //金额(价税合计)
        [MaxLength(10)] public double TaxPercent { set; get; } //专票,普票税率
        [MaxLength(80)] public decimal TaxAccount { set; get; } //税后金额,已结算金额
        [StringLength(100)] public string Remark { get; set; } //备注

        [MaxLength(3)] public ChannelType Channel { set; get; } //渠道
        [MaxLength(10)] public double InvoiceTax { set; get; } = TaxTypeVal.InvoiceTaxPercent;// 发票税
        [MaxLength(50)] public decimal TaxAndAccount { set; get; } //价税合计

        [MaxLength(3)] public decimal ValueAddedTax { set; get; } //增值税  3%
        [MaxLength(3)] public decimal IncomeTax { set; get; } //所得税 1%
        [MaxLength(3)] public decimal LandTax { set; get; } //地税 0.36%,0.12
        [MaxLength(50)] public decimal GovernmentShouldRealReceiveAccount { set; get; } //政府实际应收
        [MaxLength(50)] public decimal ShouldReceiveAccount { set; get; } //应收
        [MaxLength(50)] public decimal RealReceiveAccount { set; get; } //实收
        [MaxLength(50)] public decimal RealToGovernmentAccount { set; get; } //实交政府
        [MaxLength(50)] public decimal DiffAccount { get; set; } //差额
        [MaxLength(150)] public string OpenTaxCompnayName { set; get; } //开票单位
        [MaxLength(100)] public int OpenTaxCompnayId { set; get; }


        /// <summary>
        ///     计算增值税
        /// </summary>
        /// <returns></returns>
        public decimal CalcValueAddedTaxAccountAsync()
        {
            if (Account == 0)
                return 0;
            //（价税合计*发票税）/ （1+发票税）
            var invoiceTaxPercent = InvoiceTax / 100;
            var total = decimal.Multiply(Account, (decimal)invoiceTaxPercent); //（价税合计*发票税）
            var baseTotal = 1 + invoiceTaxPercent; // （1+发票税）
            var result = decimal.Divide(total, (decimal) baseTotal);
            ValueAddedTax = result;
            return result;
        }

        //计算所得税
        public decimal CalcIncomeTaxAccount()
        {
            if (Account == 0)
                return 0;
            //(价税合计-增值税)*0.01
            var diffAccount = Account - ValueAddedTax;
            var result = decimal.Multiply(diffAccount, (decimal)TaxTypeVal.IncomeTaxPercent);
            IncomeTax = result;
            return result;
        }

        //计算地税
        public decimal CalcLandTaxAccount()
        {
            if (ValueAddedTax == 0)
                return 0;
            //增值税*0.12
            var result = decimal.Multiply(ValueAddedTax, (decimal) TaxTypeVal.LandTaxPercernt);
            LandTax = result;
            return result;
        }


        //计算政府实际所收
        public decimal CalcGovernmentRealReceiveAccount()
        {
            //增值税+所得税+地税  然后保留两位小数
            var taxTotalAccount = ValueAddedTax + IncomeTax + LandTax;
            var result = Math.Round(taxTotalAccount, 2, MidpointRounding.AwayFromZero);
            GovernmentShouldRealReceiveAccount = result;
            return result;
        }

        ///计算应收
        public decimal CalcShouldReceiveAccount()
        {
            //税率*价税合计
            var result = decimal.Multiply(Account, (decimal) TaxPercent/100);
            ShouldReceiveAccount = result;
            return result;
        }

        //计算差额
        public decimal CalcDiffAccount()
        {
            if (this.RealToGovernmentAccount == 0)
                return this.RealToGovernmentAccount;
            //实际缴政府-政府实际应收，  然后四舍五入保留两位小数
            var diffAccount = RealToGovernmentAccount - GovernmentShouldRealReceiveAccount;
            var result = Math.Round(diffAccount, 2, MidpointRounding.AwayFromZero);
            DiffAccount = result;
            return result;
        }
    }
}