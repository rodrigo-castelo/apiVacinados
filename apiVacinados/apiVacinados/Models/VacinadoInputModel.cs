using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiVacinados.Models
{
    public class VacinadoInputModel
    {
        public VacinadoInputModel(Guid id, DateTime dataNascimento, string sexo, string vacina, string statusPrimeiraDose, DateTime dataPrimeiraDose, string statusSegundaDose, DateTime dataSegundaDose, string situacao, double latitude, double longitude)
        {
            this.Id = id;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Vacina = vacina;
            this.StatusPrimeiraDose = statusPrimeiraDose;
            this.DataPrimeiraDose = dataPrimeiraDose;
            this.StatusSegundaDose = statusSegundaDose;
            this.DataSegundaDose = dataSegundaDose;
            this.Situacao = situacao;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        public Guid Id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Vacina { get; set; }
        public string StatusPrimeiraDose { get; set; }
        public DateTime DataPrimeiraDose { get; set; }
        public string StatusSegundaDose { get; set; }
        public DateTime DataSegundaDose { get; set; }
        public string Situacao { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}
