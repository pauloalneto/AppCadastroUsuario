using AppCadastroUsuario.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCadastroUsuario.Api.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome).IsRequired().HasColumnType("varchar(250)");
            builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(250)");
            builder.Property(u => u.Login).IsRequired().HasColumnType("varchar(100)");
            builder.Property(u => u.Senha).IsRequired().HasColumnType("varchar(100)");

            builder.ToTable("Usuarios");
        }
    }
}
