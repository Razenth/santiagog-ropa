using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces;
public interface IUnitOfWork
{
    IPais Paises { get; }  //InterfazEntidad EntidadPlural {get;}
    ICargo Cargos { get;}
    ICliente Clientes { get;}
    IColor Colores { get;}
    IMunicipio Municipios { get;}
    IDetalleOrden DetalleOrdenes { get;}
    IDetalleVenta DetalleVentas { get;}
    IEmpleado Empleados { get;}
    IEmpresa Empresas { get;}
    IEstado Estados { get;}
    IDepartamento Departamentos { get;}
    IFormaPago FormaPagos { get;}
    IGenero Generos { get;}
    IInsumo Insumos { get;}
    IInventario Inventarios { get;}
    IOrden Ordenes { get;}
    IPrenda Prendas { get;}
    IProveedor Proveedores { get;}
    ITalla Tallas { get;}
    ITipoEstado TipoEstados { get;}
    ITipoPersona TipoPersonas { get;}
    ITipoProteccion TipoProtecciones { get;}
    IVenta Ventas { get;}
    Task<int> SaveAsync();
}
