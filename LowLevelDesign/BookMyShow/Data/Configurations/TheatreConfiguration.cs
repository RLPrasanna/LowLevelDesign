using BookMyShow.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMyShow.Data.Configurations
{
    public class TheatreConfiguration : IEntityTypeConfiguration<Theatre>
    {
        public void Configure(EntityTypeBuilder<Theatre> builder)
        {
            BaseModelConfiguration.ConfigureBaseModel(builder);

            builder.HasOne(t => t.City)
                .WithMany();

            builder.HasMany(t => t.Screens)
                .WithOne();
        }
    }
}
