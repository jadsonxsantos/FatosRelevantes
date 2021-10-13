using System;
using System.Collections.Generic;
using System.Text;

namespace FatosRelevantes.Models
{
    public class FatoRelevante
    {
        public int FatoRelevanteId { get; set; }
        public bool Disponivel { get; set; }
        public string Empresa { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Link { get; set; }
    }
}
