using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RopaApi.Dtos
{
    public class InventarioDto
    {
        public int Id { get; set; }
        public int CodInv { get; set; }
        public double valorVtaCop { get; set; }
        public double valorVtaUsd { get; set; }
        public int IdPrenda { get; set; }
    }
}