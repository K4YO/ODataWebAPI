using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebAPI.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public int NumeroPessoa { get; set; }
        public int IdOcorrencia { get; set; }
        public int? IdVeiculo { get; set; }
        public string TipoVeiculo { get; set; }
        public string Marca { get; set; }
        public int? AnoFrabricacaoVeiculo { get; set; }
        public string TipoEnvolvido { get; set; }
        public string EstadoFisico { get; set; }
        public int? Idade { get; set; }
        public string Sexo { get; set; }
        public Boolean? Ileso { get; set; }
        public Boolean? FeridoLeve { get; set; }
        public Boolean? FeridoGrave { get; set; }
        public Boolean? Morto { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
    }
}
