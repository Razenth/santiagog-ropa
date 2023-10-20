using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RopaApi.Dtos
{
    public class EmpresaDto
    {
        public int Id { get; set; }
        public int Nit { get; set; }
        public string RazonSocial { get; set; }
        public string RepresentanteLegal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdMun { get; set; }

    }
}