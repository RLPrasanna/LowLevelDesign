using BookMyShow.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMyShow.Data.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            BaseModelConfiguration.ConfigureBaseModel(builder);

            builder.Property(s => s.SeatType)
                .HasConversion<int>();
        }
    }
}
