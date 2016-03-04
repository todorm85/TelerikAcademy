namespace Movies.Data
{
    using System.Data.Entity;
    using Contracts;
    using Models;

    public class SimpleTwitterDbContext : DbContext, ISimpleTwitterDbContext
    {
        public SimpleTwitterDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<Person> People { get; set; }

        public virtual IDbSet<Studio> Studios { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Address> Addresses { get; set; }

        public static SimpleTwitterDbContext Create()
        {
            return new SimpleTwitterDbContext();
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

            //modelBuilder.Entity<EventDay>()
            //            .HasMany(u => u.OptionalRoutes)
            //            .WithMany(e => e.EventDays)
            //            .Map(m =>
            //            {
            //                m.MapRightKey("EventDayId");
            //                m.MapLeftKey("OptionalRouteId");
            //                m.ToTable("EventDaysOptionalRoutes");
            //            });

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Movie>()
                        .HasRequired(m => m.LeadingFemaleRole)
                        .WithMany()
                        .HasForeignKey(m => m.LeadingFemaleRoleId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                        .HasRequired(m => m.LeadingMaleRole)
                        .WithMany()
                        .HasForeignKey(m => m.LeadingMaleRoleId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Studio>()
                        .HasRequired(m => m.Address)
                        .WithMany()
                        .HasForeignKey(m => m.AddressId)
                        .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Route>().HasRequired(c => c.StartPoint).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<EventDay>().HasRequired(c => c.MainRoute).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Playlist>().HasMany(c => c.Videos).WithOptional(x => x.Playlist).WillCascadeOnDelete(true);

            //modelBuilder.Entity<Playlist>().HasMany(c => c.Ratings).WithRequired(x => x.Playlist).WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}