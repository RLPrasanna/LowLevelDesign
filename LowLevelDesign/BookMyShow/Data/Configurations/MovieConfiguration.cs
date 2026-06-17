using BookMyShow.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMyShow.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            BaseModelConfiguration.ConfigureBaseModel(builder);

            builder.Property(b => b.Features)
                .HasConversion<int>();

            builder.HasMany(b => b.Actors)
               .WithMany();

        }
    }
}
