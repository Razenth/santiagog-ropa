using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class InventarioTalla
    {
        public int IdInv { get; set; }
        public Inventario Inventario { get; set; }
        public int IdTalla { get; set; }
        public Talla Talla { get; set; }
    }
}