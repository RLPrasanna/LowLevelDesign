using BookMyShow.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMyShow.Data.Configurations
{
    public class ShowSeatConfiguration : IEntityTypeConfiguration<ShowSeat>
    {
        public void Configure(EntityTypeBuilder<ShowSeat> builder)
        {
            BaseModelConfiguration.ConfigureBaseModel(builder);

            builder.Property(ss => ss.ShowSeatStatus)
                .HasConversion<int>();

            builder.HasOne(ss => ss.Show)
                .WithMany();

            builder.HasOne(ss => ss.Seat)
                .WithMany();
        }
    }
}
