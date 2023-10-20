using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Prenda : BaseEntity
    {
        public int IdPrenda { get; set; }
        public string Nombre { get; set; }
        public double valorVtaCop { get; set; }
        public double valorVtaUsd { get; set; }
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }
        public int IdTipoProteccion { get; set; }
        public TipoProteccion TipoProteccion { get; set; }
        public int IdGenero { get; set; }
        public Genero Genero { get; set; }
        public ICollection<DetalleOrden> DetallerOrdenes { get; set; }
        public ICollection<InsumoPrenda> InsumoPrendas { get; set; }
        public ICollection<Inventario> Inventarios { get; set; }
    }
}