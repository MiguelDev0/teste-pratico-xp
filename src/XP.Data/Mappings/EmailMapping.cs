using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XP.Business.Models;

namespace XP.Data.Mappings
{
    public class EmailMapping : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EmailCadastro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.EmailPrincipal)
                .IsRequired()
                .HasColumnType("int");
        }
    }
}
