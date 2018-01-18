namespace HikingPlanAndRescue.Services.Data
{
    using System.Linq;
    using Common.Contracts;
    using HikingPlanAndRescue.Data.Models;

    public interface ITracksService : IBaseDataWithCreatorService<Track>
    {
        IQueryable<Track> GetMostPopularWithPaging(int page, int pageSize);
    }
}
