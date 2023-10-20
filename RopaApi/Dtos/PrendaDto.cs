using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RopaApi.Dtos
{
    public class PrendaDto
    {
        public int Id { get; set; }
        public int IdPrenda { get; set; }
        public string Nombre { get; set; }
        public double valorVtaCop { get; set; }
        public double valorVtaUsd { get; set; }
        public int IdEstado { get; set; }
        public int IdTipoProteccion { get; set; }
        public int IdGenero { get; set; }

    }
}