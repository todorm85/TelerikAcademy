namespace Teleimot.Services.Data
{
    using System;
    using System.Linq;
    using Teleimot.Data.Contracts;
    using Teleimot.Data.Models;
    using Contracts;
    using Common.Constants;

    public class EstatesService : IEstatesService
    {
        private ITeleimotData data;

        public EstatesService(ITeleimotData data)
        {
            this.data = data;
        }

        public IQueryable<Estate> GetPublicEstates(int skip = ValidationConstants.SkipDefaultValue, int take = ValidationConstants.TakeDefaultValue)
        {
            if (take > ValidationConstants.TakeMaxValue || skip > ValidationConstants.SkipMaxValue)
            {
                throw new ArgumentException($"Take and skip must be less than {ValidationConstants.TakeDefaultValue} and {ValidationConstants.SkipDefaultValue} respectively.");
            }

            var estates = this.data.Estates.All()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(skip)
                .Take(take);

            return estates;
        }

        public Estate GetEstateDetails(int estateId)
        {
            var estate = this.data.Estates.All()
                .FirstOrDefault(x => x.Id == estateId);

            return estate;
        }

        public void CreateEstate(Estate estate)
        {
            this.data.Estates.Add(estate);
            this.data.SaveChanges();
        }
    }
}