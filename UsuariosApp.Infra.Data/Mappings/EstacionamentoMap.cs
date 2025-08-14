using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EstacionamentoApp.Domain.Entities;

namespace EstacionamentoApp.Infra.Data.Mappings
{
    public class EstacionamentoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {

            builder.ToTable("VEICULOS");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("ID");

            builder.Property(v => v.NomeDono)
                .HasColumnName("NOME_DONO")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(v => v.EmailDono)
                .HasColumnName("EMAIL_DONO")
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(v => v.EmailDono)
                .IsUnique();

            builder.Property(v => v.Placa)
                .HasColumnName("PLACA")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(v => v.HorarioEntrada)
                .HasColumnName("HORARIO_ENTRADA")
                .IsRequired();

            builder.Property(v => v.HorarioSaida)
                .HasColumnName("HORARIO_SAIDA")
                .IsRequired(false);

        }

    }
}
