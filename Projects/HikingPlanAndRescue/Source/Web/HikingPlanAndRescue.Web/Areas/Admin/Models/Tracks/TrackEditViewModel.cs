namespace HikingPlanAndRescue.Web.Areas.Admin.Models.Tracks
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class TrackEditViewModel : IMap<Track>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Length { get; set; }

        public double Ascent { get; set; }

        public double AscentLength { get; set; }
    }
}