using BookMyShow.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMyShow.Data.Configurations
{
    public class ShowConfiguration : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            BaseModelConfiguration.ConfigureBaseModel(builder);

            builder.HasOne(s => s.Movie)
                .WithMany();

            builder.HasOne(s => s.Screen)
                .WithMany();

            builder.Property(s => s.Features)
                .HasConversion<int>();
        }
    }
}
