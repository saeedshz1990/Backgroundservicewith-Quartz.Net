using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailsManagements.infrastructure.EFCore.Mapping
{
    public class EmailMapping : IEntityTypeConfiguration<EmailMapping>
    {
        public void Configure(EntityTypeBuilder<EmailMapping> builder)
        {
            builder.ToTable("Email");
            builder.HasNoKey();
        }
    }
}
