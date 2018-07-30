using System.ComponentModel.DataAnnotations;
using Tax.ICompanyModuleService.Domain.Entities.Enums;

namespace Tax.ICompanyModuleService.Domain.Entities
{
    //股东--值对象，不需要唯一标识，通过构造函数初始化值
    public class Shareholder : BaseEntity
    {
        [Key]
        public int Id { set; get; }
        public int CompanyId { set; get; }
        public string Name { set; get; }
        public string IDNumber { set; get; } //身份证号
        public double Percent { set; get; } //股份比例
        public virtual TaxpayerType TaxpayerType { set; get; } //纳税人规模
        public string RigsterAddr { set; get; }
        public string NationalTaxState { set; get; } //国税状态
        public string NationalTaxLogoffDes { set; get; } //国税注销情况说明
        public string LandTaxState { set; get; } //地税状态
        public string LandTaxLogoffDes { set; get; } //地税注销情况说明
        public bool HaveElectronicTax { set; get; } //电子税务局
        public bool ElectronicTaxAccount { set; get; } //电子税务局账号
        public bool ElectronicTaxPwd { set; get; } //电子税务局密码

        public Company Company { set; get; } //导航属性  ，一对多关系
    }
}