using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XP.Business.Models;

namespace XP.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");
            builder.Property(c => c.Sobrenome)
                .IsRequired()
                .HasColumnType("varchar(150)");
            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(20)");
            
            builder.ToTable("Usuarios");
        }
    }
}
