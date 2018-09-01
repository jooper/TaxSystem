using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tax.ICompanyModuleService.Domain.BaseModel.Enums;


namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    //股东--值对象，不需要唯一标识，通过构造函数初始化值
    public class Shareholder : BaseEntity
    {
        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key] public new int Id { set; get; }
        public int CompanyId { set; get; }
        [StringLength(10)]
        public string Name { set; get; }
        public string IDNumber { set; get; } //身份证号
        public double Percent { set; get; } //股份比例
        public virtual TaxpayerType TaxpayerType { set; get; } //纳税人规模
        [StringLength(80)]
        public string RigsterAddr { set; get; }
        [StringLength(10)]
        public string NationalTaxState { set; get; } //国税状态
        [StringLength(80)]
        public string NationalTaxLogoffDes { set; get; } //国税注销情况说明
        [StringLength(10)]
        public string LandTaxState { set; get; } //地税状态
        [StringLength(100)]
        public string LandTaxLogoffDes { set; get; } //地税注销情况说明
        [StringLength(10)]
        public bool HaveElectronicTax { set; get; } //电子税务局
        [StringLength(50)]
        public string ElectronicTaxAccount { set; get; } //电子税务局账号
        [StringLength(80)]
        public string ElectronicTaxPwd { set; get; } //电子税务局密码
    }
}