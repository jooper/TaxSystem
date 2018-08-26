namespace Tax.ICompanyModuleService.Domain.BaseModel.Enums
{
    //汇款状态，已收款，未收款
    public enum TaxState
    {
        AlreadyReckoning,//已算账
        Receivables,//已收款
        ChongHongReOpen,//冲红重开
        ChongHongGiveUp,//冲红不收
        Discarded,//废弃
        UnKnown
    }
}