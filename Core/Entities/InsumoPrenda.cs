using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class InsumoPrenda
    {
        public int IdInsumo { get; set; }
        public Insumo Consumo { get; set; }
        public int IdPrenda { get; set; }
        public Prenda Prenda { get; set; }
    }
}