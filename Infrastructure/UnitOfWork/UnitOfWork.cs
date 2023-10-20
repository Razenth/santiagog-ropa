using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SantiagoRopaContext _context;

        public UnitOfWork(SantiagoRopaContext context)
        {
            _context = context;
        }

        private CargoRepository _cargo;  //CiudadRepository _ciudad
        public ICargo Cargos
        {
            get
            {
                if (_cargo == null)
                {
                    _cargo = new CargoRepository(_context);
                }
                return _cargo;
            }
        }

        private ClienteRepository _cliente;  //CiudadRepository _ciudad
        public ICliente Clientes
        {
            get
            {
                if (_cliente == null)
                {
                    _cliente = new ClienteRepository(_context);
                }
                return _cliente;
            }
        }

        private ColorRepository _color;  //CiudadRepository _ciudad
        public IColor Colores
        {
            get
            {
                if (_color == null)
                {
                    _color = new ColorRepository(_context);
                }
                return _color;
            }
        }

        private DepartamentoRepository _departamento;  //CiudadRepository _ciudad
        public IDepartamento Departamentos
        {
            get
            {
                if (_departamento == null)
                {
                    _departamento = new DepartamentoRepository(_context);
                }
                return _departamento;
            }
        }

        private DetalleOrdenRepository _detalleOrden;  //CiudadRepository _ciudad
        public IDetalleOrden DetalleOrdenes
        {
            get
            {
                if (_detalleOrden == null)
                {
                    _detalleOrden = new DetalleOrdenRepository(_context);
                }
                return _detalleOrden;
            }
        }

        private DetalleVentaRepository _detalleVenta;  //CiudadRepository _ciudad
        public IDetalleVenta DetalleVentas
        {
            get
            {
                if (_detalleVenta == null)
                {
                    _detalleVenta = new DetalleVentaRepository(_context);
                }
                return _detalleVenta;
            }
        }

        private EmpleadoRepository _empleado;  //CiudadRepository _ciudad
        public IEmpleado Empleados
        {
            get
            {
                if (_empleado == null)
                {
                    _empleado = new EmpleadoRepository(_context);
                }
                return _empleado;
            }
        }

        private EmpresaRepository _empresa;  //CiudadRepository _ciudad
        public IEmpresa Empresas
        {
            get
            {
                if (_empresa == null)
                {
                    _empresa = new EmpresaRepository(_context);
                }
                return _empresa;
            }
        }

        private EstadoRepository _estado;  //CiudadRepository _ciudad
        public IEstado Estados
        {
            get
            {
                if (_estado == null)
                {
                    _estado = new EstadoRepository(_context);
                }
                return _estado;
            }
        }

        private FormaPagoRepository _formaPago;  //CiudadRepository _ciudad
        public IFormaPago FormaPagos
        {
            get
            {
                if (_formaPago == null)
                {
                    _formaPago = new FormaPagoRepository(_context);
                }
                return _formaPago;
            }
        }

        private GeneroRepository _genero;  //CiudadRepository _ciudad
        public IGenero Generos
        {
            get
            {
                if (_genero == null)
                {
                    _genero = new GeneroRepository(_context);
                }
                return _genero;
            }
        }

        private InsumoRepository _insumo;  //CiudadRepository _ciudad
        public IInsumo Insumos
        {
            get
            {
                if (_insumo == null)
                {
                    _insumo = new InsumoRepository(_context);
                }
                return _insumo;
            }
        }

        private InventarioRepository _inventario;  //CiudadRepository _ciudad
        public IInventario Inventarios
        {
            get
            {
                if (_inventario == null)
                {
                    _inventario = new InventarioRepository(_context);
                }
                return _inventario;
            }
        }

        private MunicipioRepository _municipio;  //CiudadRepository _ciudad
        public IMunicipio Municipios
        {
            get
            {
                if (_municipio == null)
                {
                    _municipio = new MunicipioRepository(_context);
                }
                return _municipio;
            }
        }

        private OrdenRepository _orden;  //CiudadRepository _ciudad
        public IOrden Ordenes
        {
            get
            {
                if (_orden == null)
                {
                    _orden = new OrdenRepository(_context);
                }
                return _orden;
            }
        }

        private PaisRepository _pais;  //CiudadRepository _ciudad
        public IPais Paises
        {
            get
            {
                if (_pais == null)
                {
                    _pais = new PaisRepository(_context);
                }
                return _pais;
            }
        }

        private PrendaRepository _prenda;  //CiudadRepository _ciudad
        public IPrenda Prendas
        {
            get
            {
                if (_prenda == null)
                {
                    _prenda = new PrendaRepository(_context);
                }
                return _prenda;
            }
        }

        private ProveedorRepository _proveedor;  //CiudadRepository _ciudad
        public IProveedor Proveedores
        {
            get
            {
                if (_proveedor == null)
                {
                    _proveedor = new ProveedorRepository(_context);
                }
                return _proveedor;
            }
        }

        private TallaRepository _talla;  //CiudadRepository _ciudad
        public ITalla Tallas
        {
            get
            {
                if (_talla == null)
                {
                    _talla = new TallaRepository(_context);
                }
                return _talla;
            }
        }

        private TipoEstadoRepository _tipoEstado;  //CiudadRepository _ciudad
        public ITipoEstado TipoEstados
        {
            get
            {
                if (_tipoEstado == null)
                {
                    _tipoEstado = new TipoEstadoRepository(_context);
                }
                return _tipoEstado;
            }
        }

        private TipoPersonaRepository _tipoPersona;  //CiudadRepository _ciudad
        public ITipoPersona TipoPersonas
        {
            get
            {
                if (_tipoPersona == null)
                {
                    _tipoPersona = new TipoPersonaRepository(_context);
                }
                return _tipoPersona;
            }
        }

        private TipoProteccionRepository _tipoProteccion;  //CiudadRepository _ciudad
        public ITipoProteccion TipoProtecciones
        {
            get
            {
                if (_tipoProteccion == null)
                {
                    _tipoProteccion = new TipoProteccionRepository(_context);
                }
                return _tipoProteccion;
            }
        }

        private VentaRepository _venta;  //CiudadRepository _ciudad
        public IVenta Ventas
        {
            get
            {
                if (_venta == null)
                {
                    _venta = new VentaRepository(_context);
                }
                return _venta;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}