using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RopaApi.Dtos
{
    public class DetalleVentaDto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnit { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int IdTalla { get; set; }

    }
}