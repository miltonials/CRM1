using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRM.Models
{
    public partial class CRMContext : DbContext
    {
        public CRMContext()
        {
        }

        public CRMContext(DbContextOptions<CRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividads { get; set; } = null!;
        public virtual DbSet<Caso> Casos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Contacto> Contactos { get; set; } = null!;
        public virtual DbSet<Cotizacion> Cotizacions { get; set; } = null!;
        public virtual DbSet<CotizacionActividad> CotizacionActividads { get; set; } = null!;
        public virtual DbSet<Cuentum> Cuenta { get; set; } = null!;
        public virtual DbSet<Denegacion> Denegacions { get; set; } = null!;
        public virtual DbSet<Ejecucion> Ejecucions { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Familium> Familia { get; set; } = null!;
        public virtual DbSet<Inflacion> Inflacions { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ProductoCotizacion> ProductoCotizacions { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Tarea> Tareas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost; database=CRM; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.ToTable("Actividad");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaFinalizacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_finalizacion");
            });

            modelBuilder.Entity<Caso>(entity =>
            {
                entity.ToTable("Caso");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Asunto)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("asunto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Dirrecion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("dirrecion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.NombreContacto)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombreContacto");

                entity.Property(e => e.NombreCuenta)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombreCuenta");

                entity.Property(e => e.OrigenCaso)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("origenCaso");

                entity.Property(e => e.PropietarioCaso)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("propietarioCaso");

                entity.Property(e => e.ProyectoAsociado).HasColumnName("proyectoAsociado");

                entity.Property(e => e.TipoCaso)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipoCaso");

                entity.HasOne(d => d.PropietarioCasoNavigation)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.PropietarioCaso)
                    .HasConstraintName("fk_Caso_Usuario");

                entity.HasOne(d => d.ProyectoAsociadoNavigation)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.ProyectoAsociado)
                    .HasConstraintName("fk_Caso_Ejecucion");

                entity.HasMany(d => d.IdActividads)
                    .WithMany(p => p.IdCasos)
                    .UsingEntity<Dictionary<string, object>>(
                        "CasosActividad",
                        l => l.HasOne<Actividad>().WithMany().HasForeignKey("IdActividad").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_casosActividad_Actividad"),
                        r => r.HasOne<Caso>().WithMany().HasForeignKey("IdCaso").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_CasosActividad_Caso"),
                        j =>
                        {
                            j.HasKey("IdCaso", "IdActividad").HasName("PK__CasosAct__EAD2EFF361C80FCA");

                            j.ToTable("CasosActividad");

                            j.IndexerProperty<int>("IdCaso").HasColumnName("id_caso");

                            j.IndexerProperty<int>("IdActividad").HasColumnName("id_actividad");
                        });

                entity.HasMany(d => d.IdTareas)
                    .WithMany(p => p.IdCasos)
                    .UsingEntity<Dictionary<string, object>>(
                        "CasosTarea",
                        l => l.HasOne<Tarea>().WithMany().HasForeignKey("IdTarea").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_CasosTarea_Tarea"),
                        r => r.HasOne<Caso>().WithMany().HasForeignKey("IdCaso").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_CasosTarea_Caso"),
                        j =>
                        {
                            j.HasKey("IdCaso", "IdTarea").HasName("PK__CasosTar__AB11140B20DC924A");

                            j.ToTable("CasosTarea");

                            j.IndexerProperty<int>("IdCaso").HasColumnName("id_caso");

                            j.IndexerProperty<int>("IdTarea").HasColumnName("id_tarea");
                        });
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => new { e.Cedula, e.ContactoPrincipal })
                    .HasName("PK__Cliente__685471942080D0D7");

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Cedula, "UQ__Cliente__415B7BE532B1C694")
                    .IsUnique();

                entity.Property(e => e.Cedula)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.ContactoPrincipal).HasColumnName("contacto_principal");

                entity.Property(e => e.Celular)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("celular");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.InformacionAdicional)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("informacion_adicional");

                entity.Property(e => e.Sector)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sector");

                entity.Property(e => e.SitioWeb)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("sitio_web");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Zona)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("zona");

                entity.HasOne(d => d.ContactoPrincipalNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.ContactoPrincipal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cliente_Contacto");

                entity.HasMany(d => d.CedulaUsuarios)
                    .WithMany(p => p.CedulaClientes)
                    .UsingEntity<Dictionary<string, object>>(
                        "Asesorium",
                        l => l.HasOne<Usuario>().WithMany().HasForeignKey("CedulaUsuario").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_Asesoria_Usuario"),
                        r => r.HasOne<Cliente>().WithMany().HasPrincipalKey("Cedula").HasForeignKey("CedulaCliente").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_Asesoria_Cliente"),
                        j =>
                        {
                            j.HasKey("CedulaCliente", "CedulaUsuario").HasName("PK__Asesoria__25B1CBFCC8934420");

                            j.ToTable("Asesoria");

                            j.IndexerProperty<string>("CedulaCliente").HasMaxLength(30).IsUnicode(false).HasColumnName("cedula_cliente");

                            j.IndexerProperty<string>("CedulaUsuario").HasMaxLength(30).IsUnicode(false).HasColumnName("cedula_usuario");
                        });
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.ToTable("Contacto");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CedulaCliente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cedula_cliente");

                entity.Property(e => e.CedulaUsuario)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cedula_usuario");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Dirreccion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("dirreccion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Medio)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("medio");

                entity.Property(e => e.Motivo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("motivo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sector)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("sector");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Zona)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("zona");

                entity.HasOne(d => d.CedulaClienteNavigation)
                    .WithMany(p => p.Contactos)
                    .HasPrincipalKey(p => p.Cedula)
                    .HasForeignKey(d => d.CedulaCliente)
                    .HasConstraintName("fk_Contacto_Cliente");

                entity.HasOne(d => d.CedulaUsuarioNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.CedulaUsuario)
                    .HasConstraintName("fk_Contacto_Usuario");

                entity.HasMany(d => d.IdActividads)
                    .WithMany(p => p.IdContactos)
                    .UsingEntity<Dictionary<string, object>>(
                        "ContactoActividad",
                        l => l.HasOne<Actividad>().WithMany().HasForeignKey("IdActividad").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ContactoActividad_Actividad"),
                        r => r.HasOne<Contacto>().WithMany().HasForeignKey("IdContacto").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ContactoActividad_Contacto"),
                        j =>
                        {
                            j.HasKey("IdContacto", "IdActividad").HasName("PK__Contacto__24576630EC579A1F");

                            j.ToTable("ContactoActividad");

                            j.IndexerProperty<int>("IdContacto").HasColumnName("id_contacto");

                            j.IndexerProperty<int>("IdActividad").HasColumnName("id_actividad");
                        });

                entity.HasMany(d => d.IdTareas)
                    .WithMany(p => p.IdContactos)
                    .UsingEntity<Dictionary<string, object>>(
                        "ContactoTarea",
                        l => l.HasOne<Tarea>().WithMany().HasForeignKey("IdTarea").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ContactoTarea_Tarea"),
                        r => r.HasOne<Contacto>().WithMany().HasForeignKey("IdContacto").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ContactoTarea_Contacto"),
                        j =>
                        {
                            j.HasKey("IdContacto", "IdTarea").HasName("PK__Contacto__65949DC8229C41B3");

                            j.ToTable("ContactoTarea");

                            j.IndexerProperty<int>("IdContacto").HasColumnName("id_contacto");

                            j.IndexerProperty<int>("IdTarea").HasColumnName("id_tarea");
                        });
            });

            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.HasKey(e => new { e.NumeroCotizacion, e.IdFactura, e.IdContacto })
                    .HasName("PK__Cotizaci__007B5A89FE7BD235");

                entity.ToTable("Cotizacion");

                entity.HasIndex(e => e.NumeroCotizacion, "UQ__Cotizaci__9FB24E0F0D6FE3C6")
                    .IsUnique();

                entity.Property(e => e.NumeroCotizacion).HasColumnName("numero_cotizacion");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.IdContacto).HasColumnName("id_contacto");

                entity.Property(e => e.Asesor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("asesor");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Etapa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("etapa");

                entity.Property(e => e.FechaCierre)
                    .HasColumnType("date")
                    .HasColumnName("fecha_cierre");

                entity.Property(e => e.FechaCotizacion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fecha_cotizacion");

                entity.Property(e => e.FechaProyeccionCierre)
                    .HasColumnType("date")
                    .HasColumnName("fecha_proyeccion_cierre");

                entity.Property(e => e.MonedaOportunidad)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("moneda_oportunidad");

                entity.Property(e => e.NombreCuenta)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cuenta");

                entity.Property(e => e.NombreOportunidad)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_oportunidad");

                entity.Property(e => e.OrdenCompra)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("orden_compra");

                entity.Property(e => e.Probabilidades)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("probabilidades");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.Zona)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("zona");

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.IdContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cotizacion_Contacto");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasPrincipalKey(p => p.Consecutivo)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cotizacion_Factura");

                entity.HasMany(d => d.IdTareas)
                    .WithMany(p => p.IdCotizacions)
                    .UsingEntity<Dictionary<string, object>>(
                        "CotizacionTarea",
                        l => l.HasOne<Tarea>().WithMany().HasForeignKey("IdTarea").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_CotizacionTarea_Tarea"),
                        r => r.HasOne<Cotizacion>().WithMany().HasPrincipalKey("NumeroCotizacion").HasForeignKey("IdCotizacion").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_CotizacionTarea_Cotizacion"),
                        j =>
                        {
                            j.HasKey("IdCotizacion", "IdTarea").HasName("PK__Cotizaci__FB1D1E043A46A94D");

                            j.ToTable("CotizacionTarea");

                            j.IndexerProperty<int>("IdCotizacion").HasColumnName("id_cotizacion");

                            j.IndexerProperty<int>("IdTarea").HasColumnName("id_tarea");
                        });
            });

            modelBuilder.Entity<CotizacionActividad>(entity =>
            {
                entity.HasKey(e => new { e.IdCotizacion, e.IdActividad })
                    .HasName("PK__Cotizaci__BADEE5FC31693183");

                entity.ToTable("CotizacionActividad");

                entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");

                entity.Property(e => e.IdActividad).HasColumnName("id_actividad");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.CotizacionActividads)
                    .HasPrincipalKey(p => p.NumeroCotizacion)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CotizacionActividad_Cotizacion");
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CedulaCliente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cedula_cliente");

                entity.Property(e => e.ModedaCuenta)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("modeda_cuenta");

                entity.Property(e => e.NombreCuenta)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cuenta");

                entity.HasOne(d => d.CedulaClienteNavigation)
                    .WithMany()
                    .HasPrincipalKey(p => p.Cedula)
                    .HasForeignKey(d => d.CedulaCliente)
                    .HasConstraintName("fk_Cuenta_Cliente");
            });

            modelBuilder.Entity<Denegacion>(entity =>
            {
                entity.HasKey(e => e.IdCotizacion)
                    .HasName("PK__Denegaci__9713D1746A6516E3");

                entity.ToTable("Denegacion");

                entity.Property(e => e.IdCotizacion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_cotizacion");

                entity.Property(e => e.Competidor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("competidor");

                entity.Property(e => e.Motivo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("motivo");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithOne(p => p.Denegacion)
                    .HasPrincipalKey<Cotizacion>(p => p.NumeroCotizacion)
                    .HasForeignKey<Denegacion>(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Denegacion_Cotizacion");
            });

            modelBuilder.Entity<Ejecucion>(entity =>
            {
                entity.ToTable("Ejecucion");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Asesor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("asesor");

                entity.Property(e => e.AñoProyectadoCierre).HasColumnName("añoProyectadoCierre");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.FechaCierre)
                    .HasColumnType("date")
                    .HasColumnName("fechaCierre");

                entity.Property(e => e.FechaEjecucion)
                    .HasColumnType("date")
                    .HasColumnName("fechaEjecucion");

                entity.Property(e => e.MesProyectadoCierre).HasColumnName("mesProyectadoCierre");

                entity.Property(e => e.NombreCuenta)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombreCuenta");

                entity.Property(e => e.NombreEjecucion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombreEjecucion");

                entity.Property(e => e.NumeroCotizacion).HasColumnName("numeroCotizacion");

                entity.Property(e => e.PropietarioEjecucion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("propietarioEjecucion");

                entity.HasMany(d => d.IdActividads)
                    .WithMany(p => p.IdEjecucions)
                    .UsingEntity<Dictionary<string, object>>(
                        "EjecucionActividad",
                        l => l.HasOne<Actividad>().WithMany().HasForeignKey("IdActividad").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_EjecucionActividad_Actividad"),
                        r => r.HasOne<Ejecucion>().WithMany().HasForeignKey("IdEjecucion").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_EjecucionActividad_Ejecucion"),
                        j =>
                        {
                            j.HasKey("IdEjecucion", "IdActividad").HasName("PK__Ejecucio__83237523BF498CB3");

                            j.ToTable("EjecucionActividad");

                            j.IndexerProperty<int>("IdEjecucion").HasColumnName("id_ejecucion");

                            j.IndexerProperty<int>("IdActividad").HasColumnName("id_actividad");
                        });

                entity.HasMany(d => d.IdTareas)
                    .WithMany(p => p.IdEjecucions)
                    .UsingEntity<Dictionary<string, object>>(
                        "EjecucionTarea",
                        l => l.HasOne<Tarea>().WithMany().HasForeignKey("IdTarea").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_EjecucionTarea_tarea"),
                        r => r.HasOne<Ejecucion>().WithMany().HasForeignKey("IdEjecucion").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_EjecucionTarea_Ejecucion"),
                        j =>
                        {
                            j.HasKey("IdEjecucion", "IdTarea").HasName("PK__Ejecucio__C2E08EDBE5A8AE41");

                            j.ToTable("EjecucionTarea");

                            j.IndexerProperty<int>("IdEjecucion").HasColumnName("id_ejecucion");

                            j.IndexerProperty<int>("IdTarea").HasColumnName("id_tarea");
                        });
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => new { e.Consecutivo, e.IdCotizacion })
                    .HasName("PK__Factura__AF98B930F4AF40EE");

                entity.ToTable("Factura");

                entity.HasIndex(e => e.Consecutivo, "UQ__Factura__F6E98426D8240A39")
                    .IsUnique();

                entity.Property(e => e.Consecutivo).HasColumnName("consecutivo");

                entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.Facturas)
                    .HasPrincipalKey(p => p.NumeroCotizacion)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Factura_Cotizacion");
            });

            modelBuilder.Entity<Familium>(entity =>
            {
                entity.HasKey(e => e.CodigoFamilia)
                    .HasName("PK__Familia__54451DFA14069498");

                entity.Property(e => e.CodigoFamilia)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoFamilia");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.NombreFamilia)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombreFamilia");
            });

            modelBuilder.Entity<Inflacion>(entity =>
            {
                entity.HasKey(e => new { e.Anno, e.NumeroCotizacion })
                    .HasName("PK__Inflacio__9849E43D6AA6E469");

                entity.ToTable("Inflacion");

                entity.HasIndex(e => e.NumeroCotizacion, "UQ__Inflacio__9FB24E0FDD494956")
                    .IsUnique();

                entity.Property(e => e.Anno).HasColumnName("anno");

                entity.Property(e => e.NumeroCotizacion).HasColumnName("numero_cotizacion");

                entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");

                entity.HasOne(d => d.NumeroCotizacionNavigation)
                    .WithOne(p => p.Inflacion)
                    .HasPrincipalKey<Cotizacion>(p => p.NumeroCotizacion)
                    .HasForeignKey<Inflacion>(d => d.NumeroCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Inflacion_Cotizacion");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => new { e.Codigo, e.CodigoFamilia })
                    .HasName("PK__Producto__15F6490FDC1DA96E");

                entity.ToTable("Producto");

                entity.HasIndex(e => e.Codigo, "UQ__Producto__40F9A206ADF5F704")
                    .IsUnique();

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.CodigoFamilia).HasColumnName("codigo_Familia");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioEstandar).HasColumnName("precio_estandar");

                entity.HasOne(d => d.CodigoFamiliaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodigoFamilia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_Familia");
            });

            modelBuilder.Entity<ProductoCotizacion>(entity =>
            {
                entity.HasKey(e => new { e.CodigoProducto, e.NumeroCotizacion })
                    .HasName("PK__Producto__E9AA2349F8F34217");

                entity.ToTable("ProductoCotizacion");

                entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");

                entity.Property(e => e.NumeroCotizacion).HasColumnName("numero_cotizacion");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.ProductoCotizacions)
                    .HasPrincipalKey(p => p.Codigo)
                    .HasForeignKey(d => d.CodigoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProductoCotizacion_Producto");

                entity.HasOne(d => d.NumeroCotizacionNavigation)
                    .WithMany(p => p.ProductoCotizacions)
                    .HasPrincipalKey(p => p.NumeroCotizacion)
                    .HasForeignKey(d => d.NumeroCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProductoCotizacion_Cotizacion");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasMany(d => d.CedulaUsuarios)
                    .WithMany(p => p.IdRols)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsuarioRole",
                        l => l.HasOne<Usuario>().WithMany().HasForeignKey("CedulaUsuario").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_UsuarioRoles_Usuario"),
                        r => r.HasOne<Rol>().WithMany().HasForeignKey("IdRol").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_UsuarioRoles_Rol"),
                        j =>
                        {
                            j.HasKey("IdRol", "CedulaUsuario").HasName("PK__UsuarioR__85D09449275FE84E");

                            j.ToTable("UsuarioRoles");

                            j.IndexerProperty<int>("IdRol").HasColumnName("id_rol");

                            j.IndexerProperty<string>("CedulaUsuario").HasMaxLength(30).IsUnicode(false).HasColumnName("cedula_usuario");
                        });
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("Tarea");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaFinalizacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_Finalizacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__Usuario__415B7BE43C3B521C");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Cedula, "UQ__Usuario__415B7BE58BA9327B")
                    .IsUnique();

                entity.Property(e => e.Cedula)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Clave)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Departemento)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("departemento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
