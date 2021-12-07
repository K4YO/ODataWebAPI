using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebAPI.Infrastructure
{
    public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Acidentes");
            builder.HasKey(o => new { o.Id });
            builder.HasOne(o => o.Ocorrencia).WithMany(o => o.Pessoas).HasForeignKey(o => o.IdOcorrencia);

            builder.Property(o => o.Id).HasColumnName("id").HasColumnType("int");
            builder.Property(o => o.IdOcorrencia).HasColumnName("id_ocorrencia").IsRequired().HasColumnType("int");
            builder.Property(o => o.NumeroPessoa).HasColumnName("pesid").HasColumnType("int");
            builder.Property(o => o.IdVeiculo).HasColumnName("id_veiculo").HasColumnType("int");
            builder.Property(o => o.TipoVeiculo).HasColumnName("tipo_veiculo").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.AnoFrabricacaoVeiculo).HasColumnName("ano_fabricacao_veiculo").HasColumnType("int");
            builder.Property(o => o.TipoEnvolvido).HasColumnName("tipo_envolvido").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.EstadoFisico).HasColumnName("estado_fisico").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.Idade).HasColumnName("idade").HasColumnType("int");
            builder.Property(o => o.Sexo).HasColumnName("sexo").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.Ileso).HasColumnName("ilesos").HasColumnType("bit").HasDefaultValue(false);
            builder.Property(o => o.FeridoLeve).HasColumnName("feridos_leves").HasColumnType("bit").HasDefaultValue(false);
            builder.Property(o => o.FeridoGrave).HasColumnName("feridos_graves").HasColumnType("bit").HasDefaultValue(false);
            builder.Property(o => o.Morto).HasColumnName("mortos").HasColumnType("bit").HasDefaultValue(false);
        }
    }
}
