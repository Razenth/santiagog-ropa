using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RopaApi.Dtos
{
    public class InsumoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnit { get; set; }
        public int stockMin{ get; set; }
        public int stockMax{ get; set; }

    }
}