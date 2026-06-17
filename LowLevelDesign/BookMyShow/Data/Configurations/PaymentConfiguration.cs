using BookMyShow.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMyShow.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            BaseModelConfiguration.ConfigureBaseModel(builder);

            builder.Property(p => p.PaymentStatus)
                .HasConversion<int>();

            builder.Property(p => p.PaymentType)
                .HasConversion<int>();
        }
    }
}
