using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebAPI.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public int NumeroOcorrencia { get; set; }
        public DateTime? DataHora { get; set; }
        public string DiaSemana { get; set; }
        public string Horario { get; set; }
        public string Uf { get; set; }
        public int? Br { get; set; }
        public Decimal? Km { get; set; }
        public string Municipio { get; set; }
        public string CausaAcidente { get; set; }
        public string TipoAcidente { get; set; }
        public string ClassificacaoAcidente { get; set; }
        public string FaseDia { get; set; }
        public string SentidoVia { get; set; }
        public string CondicaoMetereologica { get; set; }
        public string TipoPista { get; set; }
        public string TracadoVia { get; set; }
        public string UsoSolo { get; set; }
        public int? TotalPessoas { get; set; }
        public int? TotalMortos { get; set; }
        public int? TotalFeridosLeves { get; set; }
        public int? TotalFeridosGrave { get; set; }
        public int? TotalIlesos { get; set; }
        public int? TotalIgnorados { get; set; }
        public int? TotalFeridos { get; set; }
        public int? TotalVeiculos { get; set; }
        public Decimal? Latitude { get; set; }
        public Decimal? Longitude { get; set; }
        public string Regional { get; set; }
        public string Delegacia { get; set; }
        public string Uop { get; set; }
        public ICollection<Pessoa> Pessoas { get; set; }

    }
}
