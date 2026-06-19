using BookMyShow.Model;
using Microsoft.EntityFrameworkCore;

namespace BookMyShow.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowSeat> ShowSeats { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // table name
            // modelBuilder.Entity<User>().ToTable("Users"); // Or we can use Annotations in the Model class itself

            //modelBuilder.Entity<User>(b =>
            //{
            //    b.Property(u => u.Email)
            //        .HasColumnName("email_address")
            //        .HasColumnType("text")
            //        .HasMaxLength(200)
            //        .IsRequired();

            //    b.Property(u => u.Password)
            //        .HasColumnName("password_hash")
            //        .HasColumnType("text")
            //        .IsRequired();

            //    // default value (Postgres: now())
            //    b.Property<DateTime>("CreatedAt")
            //        .HasDefaultValueSql("now()");
            //});

            // One line of code registers ALL configuration files automatically!
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        }

    }
}
