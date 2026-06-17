using BookMyShow.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BookMyShow.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            BaseModelConfiguration.ConfigureBaseModel(builder);

            builder.Property(b => b.BookingStatus)
                .HasConversion<int>(); // Stores enum as ordinal (integer)

            builder.HasOne(b => b.Show)
               .WithMany();

            builder.HasOne(b => b.CreatedBy)
              .WithMany();

            builder.HasMany(b => b.ShowSeats)
              .WithMany();

            builder.HasOne(b => b.Payment)
              .WithMany();
        }
    }
}
