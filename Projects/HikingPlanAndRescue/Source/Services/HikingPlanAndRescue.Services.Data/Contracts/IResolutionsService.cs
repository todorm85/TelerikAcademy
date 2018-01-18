namespace HikingPlanAndRescue.Services.Data.Contracts
{
    using Common.Contracts;
    using HikingPlanAndRescue.Data.Models;

    public interface IResolutionsService : IBaseDataWithCreatorService<Resolution>
    {
        void AddResolution(Resolution resolution);
    }
}
