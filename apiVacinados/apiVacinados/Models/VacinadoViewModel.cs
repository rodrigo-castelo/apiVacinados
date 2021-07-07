using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiVacinados.Models
{
    public class VacinadoViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Vacina { get; set; }
        public string StatusPrimeiraDose { get; set; }
        public DateTime DataPrimeiraDose { get; set; }
        public string StatusSegundaDose { get; set; }
        public DateTime DataSegundaDose { get; set; }
        public string Situacao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
