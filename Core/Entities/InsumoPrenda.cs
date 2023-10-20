using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class InsumoPrenda
    {
        public int IdInsumo { get; set; }
        public Insumo Insumo { get; set; }
        public int IdPrenda { get; set; }
        public Prenda Prenda { get; set; }
        // modelBuilder.Entity<Department>().HasKey(t => new { t.DepartmentID, t.Name });
    }
}