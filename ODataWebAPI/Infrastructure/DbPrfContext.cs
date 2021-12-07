using Microsoft.EntityFrameworkCore;
using ODataWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebAPI.Infrastructure
{
    public class DbPrfContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbPrfContext(DbContextOptions<DbPrfContext> options) : base(options)
        {

        }

        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OcorrenciaConfig());
            modelBuilder.ApplyConfiguration(new PessoaConfig());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING_DB"), sqlServerOptions => sqlServerOptions.CommandTimeout(120));
            }
        }
    }
}
