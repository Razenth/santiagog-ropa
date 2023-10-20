using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RopaApi.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public int IdTipoPersona { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdMunicipio { get; set; }
    }
}