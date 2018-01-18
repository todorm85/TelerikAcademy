namespace Teleimot.Services.Data.Contracts
{
    using System.Linq;
    using Teleimot.Data.Models;

    public interface IEstatesService
    {
        void CreateEstate(Estate estate);

        Estate GetEstateDetails(int estateId);

        IQueryable<Estate> GetPublicEstates(int skip, int take = 10);
    }
}