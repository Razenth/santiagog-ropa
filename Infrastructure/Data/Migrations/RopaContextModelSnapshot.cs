﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(SantiagoRopaContext))]
    partial class RopaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("SueldoBase")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Cargo", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("DateTime");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdMunicipio")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPersona")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.HasIndex("IdMunicipio");

                    b.HasIndex("IdTipoPersona");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Color", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("Departamento", (string)null);
                });

            modelBuilder.Entity("Core.Entities.DetalleOrden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadProducida")
                        .HasColumnType("int");

                    b.Property<int>("CantidadProducir")
                        .HasColumnType("int");

                    b.Property<int>("IdColor")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdOrden")
                        .HasColumnType("int");

                    b.Property<int>("IdPrenda")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdColor");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdOrden");

                    b.HasIndex("IdPrenda");

                    b.ToTable("DetalleOrden", (string)null);
                });

            modelBuilder.Entity("Core.Entities.DetalleVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdTalla")
                        .HasColumnType("int");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<double>("ValorUnit")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdTalla");

                    b.HasIndex("IdVenta");

                    b.ToTable("DetalleVenta", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("DateTime");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int");

                    b.Property<int>("IdEmp")
                        .HasColumnType("int");

                    b.Property<int>("IdMunicipio")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdCargo");

                    b.HasIndex("IdEmp")
                        .IsUnique();

                    b.HasIndex("IdMunicipio");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("DateTime");

                    b.Property<int>("IdMun")
                        .HasColumnType("int");

                    b.Property<int>("Nit")
                        .HasColumnType("int");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("RepresentanteLegal")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("IdMun");

                    b.HasIndex("Nit")
                        .IsUnique();

                    b.ToTable("Empresa", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("IdTipoEstado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoEstado");

                    b.ToTable("Estado", (string)null);
                });

            modelBuilder.Entity("Core.Entities.FormaPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("FormaPago", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Genero", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Insumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("ValorUnit")
                        .HasColumnType("double");

                    b.Property<int>("stockMax")
                        .HasColumnType("int");

                    b.Property<int>("stockMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Insumo", (string)null);
                });

            modelBuilder.Entity("Core.Entities.InsumoPrenda", b =>
                {
                    b.Property<int>("IdInsumo")
                        .HasColumnType("int");

                    b.Property<int>("IdPrenda")
                        .HasColumnType("int");

                    b.HasKey("IdInsumo", "IdPrenda");

                    b.HasIndex("IdPrenda");

                    b.ToTable("InsumoPrenda", (string)null);
                });

            modelBuilder.Entity("Core.Entities.InsumoProveedor", b =>
                {
                    b.Property<int>("IdInsumo")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.HasKey("IdInsumo", "IdProveedor");

                    b.HasIndex("IdProveedor");

                    b.ToTable("InsumoProveedor", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CodInv")
                        .HasColumnType("int");

                    b.Property<int>("IdPrenda")
                        .HasColumnType("int");

                    b.Property<double>("valorVtaCop")
                        .HasColumnType("double");

                    b.Property<double>("valorVtaUsd")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CodInv")
                        .IsUnique();

                    b.HasIndex("IdPrenda");

                    b.ToTable("Inventario", (string)null);
                });

            modelBuilder.Entity("Core.Entities.InventarioTalla", b =>
                {
                    b.Property<int>("IdInv")
                        .HasColumnType("int");

                    b.Property<int>("IdTalla")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.HasKey("IdInv", "IdTalla");

                    b.HasIndex("IdTalla");

                    b.ToTable("InventarioTalla", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDep")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdDep");

                    b.ToTable("Municipio", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DateTime");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdEstado");

                    b.ToTable("Orden", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Pais", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Prenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdGenero")
                        .HasColumnType("int");

                    b.Property<int>("IdPrenda")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoProteccion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<double>("valorVtaCop")
                        .HasColumnType("double");

                    b.Property<double>("valorVtaUsd")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdGenero");

                    b.HasIndex("IdPrenda")
                        .IsUnique();

                    b.HasIndex("IdTipoProteccion");

                    b.ToTable("Prenda", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdMunicipio")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPersona")
                        .HasColumnType("int");

                    b.Property<int>("NitProveedor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdMunicipio");

                    b.HasIndex("IdTipoPersona");

                    b.HasIndex("NitProveedor")
                        .IsUnique();

                    b.ToTable("Proveedor", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Talla", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("Descripcion")
                        .IsUnique();

                    b.ToTable("Talla", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoEstado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("TipoEstado", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("TipoPersona", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoProteccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("TipoProteccion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DateTime");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdFormaPago")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdFormaPago");

                    b.ToTable("Venta", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.HasOne("Core.Entities.Municipio", "Municipio")
                        .WithMany("Clientes")
                        .HasForeignKey("IdMunicipio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Clientes")
                        .HasForeignKey("IdTipoPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Core.Entities.Departamento", b =>
                {
                    b.HasOne("Core.Entities.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Core.Entities.DetalleOrden", b =>
                {
                    b.HasOne("Core.Entities.Color", "Color")
                        .WithMany("DetalleOrdenes")
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Estado", "Estado")
                        .WithMany("DetalleOrdenes")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Orden", "Orden")
                        .WithMany("DetalleOrdenes")
                        .HasForeignKey("IdOrden")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Prenda", "Prenda")
                        .WithMany("DetallerOrdenes")
                        .HasForeignKey("IdPrenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Estado");

                    b.Navigation("Orden");

                    b.Navigation("Prenda");
                });

            modelBuilder.Entity("Core.Entities.DetalleVenta", b =>
                {
                    b.HasOne("Core.Entities.Inventario", "Producto")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Talla", "Talla")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("IdTalla")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Venta", "Venta")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Talla");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Core.Entities.Empleado", b =>
                {
                    b.HasOne("Core.Entities.Cargo", "Cargo")
                        .WithMany("Empleados")
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Municipio", "Municipio")
                        .WithMany("Empleados")
                        .HasForeignKey("IdMunicipio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("Core.Entities.Empresa", b =>
                {
                    b.HasOne("Core.Entities.Departamento", null)
                        .WithMany("Empresas")
                        .HasForeignKey("DepartamentoId");

                    b.HasOne("Core.Entities.Municipio", "Municipio")
                        .WithMany("Empresas")
                        .HasForeignKey("IdMun")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.HasOne("Core.Entities.TipoEstado", "TipoEstado")
                        .WithMany("Estados")
                        .HasForeignKey("IdTipoEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoEstado");
                });

            modelBuilder.Entity("Core.Entities.InsumoPrenda", b =>
                {
                    b.HasOne("Core.Entities.Insumo", "Insumos")
                        .WithMany("InsumoPrendas")
                        .HasForeignKey("IdInsumo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Prenda", "Prendas")
                        .WithMany("InsumoPrendas")
                        .HasForeignKey("IdPrenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insumos");

                    b.Navigation("Prendas");
                });

            modelBuilder.Entity("Core.Entities.InsumoProveedor", b =>
                {
                    b.HasOne("Core.Entities.Insumo", "Insumo")
                        .WithMany("InsumoProveedores")
                        .HasForeignKey("IdInsumo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Proveedor", "Proveedor")
                        .WithMany("InsumoProveedores")
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insumo");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Core.Entities.Inventario", b =>
                {
                    b.HasOne("Core.Entities.Prenda", "Prenda")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdPrenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prenda");
                });

            modelBuilder.Entity("Core.Entities.InventarioTalla", b =>
                {
                    b.HasOne("Core.Entities.Inventario", "Inventario")
                        .WithMany("InventarioTallas")
                        .HasForeignKey("IdInv")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Talla", "Talla")
                        .WithMany("InventarioTallas")
                        .HasForeignKey("IdTalla")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventario");

                    b.Navigation("Talla");
                });

            modelBuilder.Entity("Core.Entities.Municipio", b =>
                {
                    b.HasOne("Core.Entities.Departamento", "Departamento")
                        .WithMany("Municipios")
                        .HasForeignKey("IdDep")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Core.Entities.Orden", b =>
                {
                    b.HasOne("Core.Entities.Cliente", "Cliente")
                        .WithMany("Ordenes")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Empleado", "Empleado")
                        .WithMany("Ordenes")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Estado", "Estado")
                        .WithMany("Ordenes")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Core.Entities.Prenda", b =>
                {
                    b.HasOne("Core.Entities.Estado", "Estado")
                        .WithMany("Prendas")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Genero", "Genero")
                        .WithMany("Prendas")
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoProteccion", "TipoProteccion")
                        .WithMany("Prendas")
                        .HasForeignKey("IdTipoProteccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Genero");

                    b.Navigation("TipoProteccion");
                });

            modelBuilder.Entity("Core.Entities.Proveedor", b =>
                {
                    b.HasOne("Core.Entities.Municipio", "Municipio")
                        .WithMany("Proveedores")
                        .HasForeignKey("IdMunicipio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Proveedores")
                        .HasForeignKey("IdTipoPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Core.Entities.Venta", b =>
                {
                    b.HasOne("Core.Entities.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Empleado", "Empleado")
                        .WithMany("Ventas")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.FormaPago", "FormaPago")
                        .WithMany("Ventas")
                        .HasForeignKey("IdFormaPago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");

                    b.Navigation("FormaPago");
                });

            modelBuilder.Entity("Core.Entities.Cargo", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.Navigation("Ordenes");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Core.Entities.Color", b =>
                {
                    b.Navigation("DetalleOrdenes");
                });

            modelBuilder.Entity("Core.Entities.Departamento", b =>
                {
                    b.Navigation("Empresas");

                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("Core.Entities.Empleado", b =>
                {
                    b.Navigation("Ordenes");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Navigation("DetalleOrdenes");

                    b.Navigation("Ordenes");

                    b.Navigation("Prendas");
                });

            modelBuilder.Entity("Core.Entities.FormaPago", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Core.Entities.Genero", b =>
                {
                    b.Navigation("Prendas");
                });

            modelBuilder.Entity("Core.Entities.Insumo", b =>
                {
                    b.Navigation("InsumoPrendas");

                    b.Navigation("InsumoProveedores");
                });

            modelBuilder.Entity("Core.Entities.Inventario", b =>
                {
                    b.Navigation("DetalleVentas");

                    b.Navigation("InventarioTallas");
                });

            modelBuilder.Entity("Core.Entities.Municipio", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Empleados");

                    b.Navigation("Empresas");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("Core.Entities.Orden", b =>
                {
                    b.Navigation("DetalleOrdenes");
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Core.Entities.Prenda", b =>
                {
                    b.Navigation("DetallerOrdenes");

                    b.Navigation("InsumoPrendas");

                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("Core.Entities.Proveedor", b =>
                {
                    b.Navigation("InsumoProveedores");
                });

            modelBuilder.Entity("Core.Entities.Talla", b =>
                {
                    b.Navigation("DetalleVentas");

                    b.Navigation("InventarioTallas");
                });

            modelBuilder.Entity("Core.Entities.TipoEstado", b =>
                {
                    b.Navigation("Estados");
                });

            modelBuilder.Entity("Core.Entities.TipoPersona", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("Core.Entities.TipoProteccion", b =>
                {
                    b.Navigation("Prendas");
                });

            modelBuilder.Entity("Core.Entities.Venta", b =>
                {
                    b.Navigation("DetalleVentas");
                });
#pragma warning restore 612, 618
        }
    }
}
