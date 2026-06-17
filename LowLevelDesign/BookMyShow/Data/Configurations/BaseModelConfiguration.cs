using BookMyShow.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMyShow.Data.Configurations
{
    public static class BaseModelConfiguration
    {
        public static void ConfigureBaseModel<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseModel
        {
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now() at time zone 'UTC'");

            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now() at time zone 'UTC'");

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
