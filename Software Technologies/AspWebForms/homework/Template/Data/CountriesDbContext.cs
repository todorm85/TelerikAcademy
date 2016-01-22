namespace Template.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Template.Data.Models;

    public class TemplateDbContext : IdentityDbContext<User>
    {
        public TemplateDbContext()
            : base("Template", throwIfV1Schema: false)
        {
        }

        public static TemplateDbContext Create()
        {
            return new TemplateDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //            .HasMany(u => u.Events)
            //            .WithMany(e => e.Participants)
            //            .Map(m =>
            //            {
            //                m.MapRightKey("EventId");
            //                m.MapLeftKey("ParticipantId");
            //                m.ToTable("EventsParticipants");
            //            });

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            //modelBuilder.Entity<User>().HasMany(c => c.Events).WithRequired(x => x.Creator).WillCascadeOnDelete(false);

            //modelBuilder.Entity<Route>().HasRequired(c => c.StartPoint).WithMany().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}