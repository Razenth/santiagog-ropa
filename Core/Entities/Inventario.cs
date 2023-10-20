using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Inventario : BaseEntity
    {
        public int CodInv { get; set; }
        public int IdPrenda { get; set; }
        public Prenda Prenda { get; set; }
        public double valorVtaCop { get; set; }
        public double valorVtaUsd { get; set; }

    }
}