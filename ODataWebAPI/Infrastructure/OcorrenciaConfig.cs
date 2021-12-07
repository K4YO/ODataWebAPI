using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebAPI.Infrastructure
{
    public class OcorrenciaConfig : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.ToTable("Ocorrencias");
            builder.HasKey(o => new { o.Id });
            builder.HasMany(o => o.Pessoas).WithOne(o => o.Ocorrencia).HasForeignKey(o => o.IdOcorrencia);

            builder.Property(o => o.Id).HasColumnName("id").HasColumnType("int");
            builder.Property(o => o.NumeroOcorrencia).HasColumnName("ocorrencia").IsRequired().HasColumnType("int");
            builder.Property(o => o.DataHora).HasColumnName("data_hora").HasColumnType("getdate()");
            builder.Property(o => o.DiaSemana).HasColumnName("dia_semana").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.Horario).HasColumnName("horario").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.Uf).HasColumnName("uf").HasColumnType("vachar(2)").HasMaxLength(2);
            builder.Property(o => o.Br).HasColumnName("br").HasColumnType("int");
            builder.Property(o => o.Km).HasColumnName("km").HasColumnType("decimal(5,1)");
            builder.Property(o => o.Municipio).HasColumnName("municipio").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.CausaAcidente).HasColumnName("causa_acidente").HasColumnType("vachar(100)").HasMaxLength(100);
            builder.Property(o => o.TipoAcidente).HasColumnName("tipo_acidente").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.ClassificacaoAcidente).HasColumnName("classificacao_acidente").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.FaseDia).HasColumnName("fase_dia").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.SentidoVia).HasColumnName("sentido_via").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.CondicaoMetereologica).HasColumnName("condicao_metereologica").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.TipoPista).HasColumnName("tipo_pista").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.TracadoVia).HasColumnName("tracado_via").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.UsoSolo).HasColumnName("uso_solo").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.TotalPessoas).HasColumnName("pessoas").HasColumnType("int");
            builder.Property(o => o.TotalMortos).HasColumnName("mortos").HasColumnType("int");
            builder.Property(o => o.TotalFeridosLeves).HasColumnName("feridos_leves").HasColumnType("int");
            builder.Property(o => o.TotalFeridosGrave).HasColumnName("feridos_graves").HasColumnType("int");
            builder.Property(o => o.TotalIlesos).HasColumnName("ilesos").HasColumnType("int");
            builder.Property(o => o.TotalIgnorados).HasColumnName("ignorados").HasColumnType("int");
            builder.Property(o => o.TotalFeridos).HasColumnName("feridos").HasColumnType("int");
            builder.Property(o => o.TotalVeiculos).HasColumnName("veiculos").HasColumnType("int");
            builder.Property(o => o.Latitude).HasColumnName("latitude").HasColumnType("decimal(7, 5)");
            builder.Property(o => o.Longitude).HasColumnName("longitude").HasColumnType("decimal(7, 5)");
            builder.Property(o => o.Regional).HasColumnName("regional").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.Delegacia).HasColumnName("delegacia").HasColumnType("vachar(50)").HasMaxLength(50);
            builder.Property(o => o.Uop).HasColumnName("uop").HasColumnType("vachar(50)").HasMaxLength(50);
        }
    }
}
