using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class InsumoProveedor
    {
        public int IdInsumo { get; set; }
        public Insumo Insumo { get; set; }
        public int IdProveedor { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}