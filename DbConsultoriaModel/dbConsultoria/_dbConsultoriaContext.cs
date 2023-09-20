using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

public partial class _dbConsultoriaContext : DbContext
{
    public _dbConsultoriaContext()
    {
    }

    public _dbConsultoriaContext(DbContextOptions<_dbConsultoriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Consultor> Consultors { get; set; }

    public virtual DbSet<ContratistaProyecto> ContratistaProyectos { get; set; }

    public virtual DbSet<Contratistum> Contratista { get; set; }

    public virtual DbSet<Cotizacion> Cotizacions { get; set; }

    public virtual DbSet<DetalleCotizacion> DetalleCotizacions { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<HistoricoLogin> HistoricoLogins { get; set; }

    public virtual DbSet<PagoClienteProyecto> PagoClienteProyectos { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Ubigeo> Ubigeos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VisitaConsultor> VisitaConsultors { get; set; }

    public virtual DbSet<VisitaDetalle> VisitaDetalles { get; set; }

    public virtual DbSet<VistaUsuarioRol> VistaUsuarioRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ANGELO;Initial Catalog=dbConsultoria;Integrated Security=True;Trusted_Connection=true;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("XPKCliente");

            entity.HasOne(d => d.IdEmpleadoRegistroNavigation).WithMany(p => p.Clientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_31");

            entity.HasOne(d => d.IdUbigeoNavigation).WithMany(p => p.Clientes).HasConstraintName("FK_Cliente_Ubigeo");
        });

        modelBuilder.Entity<Consultor>(entity =>
        {
            entity.HasKey(e => e.IdConsultor).HasName("XPKConsultor");

            entity.HasOne(d => d.IdEmpleadoRegistroNavigation).WithMany(p => p.Consultors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_33");

            entity.HasOne(d => d.IdUbigeoNavigation).WithMany(p => p.Consultors).HasConstraintName("FK_Consultor_Ubigeo");
        });

        modelBuilder.Entity<ContratistaProyecto>(entity =>
        {
            entity.Property(e => e.IdContratista).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdContratistaNavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContratistaProyecto_Contratista");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContratistaProyecto_Proyecto");
        });

        modelBuilder.Entity<Contratistum>(entity =>
        {
            entity.HasKey(e => e.IdContratista).HasName("XPKContratista");

            entity.HasOne(d => d.IdEmpleadoRegistroNavigation).WithMany(p => p.Contratista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_36");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Contratista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_30");

            entity.HasOne(d => d.IdUbigeoNavigation).WithMany(p => p.Contratista).HasConstraintName("FK_Contratista_Ubigeo");
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.HasKey(e => e.IdCotizacion).HasName("XPKCotizacion");

            entity.HasOne(d => d.IdEmpleadoRegistroNavigation).WithMany(p => p.Cotizacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_38");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Cotizacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_27");
        });

        modelBuilder.Entity<DetalleCotizacion>(entity =>
        {
            entity.HasOne(d => d.IdCotizacionNavigation).WithMany(p => p.DetalleCotizacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCotizacion_Cotizacion");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("XPKEmpleado");

            entity.HasOne(d => d.IdUbigeoNavigation).WithMany(p => p.Empleados).HasConstraintName("FK_Empleado_Ubigeo1");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.Errors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Error_Usuario");
        });

        modelBuilder.Entity<HistoricoLogin>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("XPKLogin");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistoricoLogins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_49");
        });

        modelBuilder.Entity<PagoClienteProyecto>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("XPKPagoClienteProyecto");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.PagoClienteProyectos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_45");

            entity.HasOne(d => d.IdEmpleadoRegistroNavigation).WithMany(p => p.PagoClienteProyectos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_46");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.PagoClienteProyectos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_44");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("XPKProyecto");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_37");

            entity.HasOne(d => d.IdEmpleadoRegistroNavigation).WithMany(p => p.Proyectos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_32");

            entity.HasOne(d => d.IdUbigeoNavigation).WithMany(p => p.Proyectos).HasConstraintName("FK_Proyecto_Ubigeo");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("XPKRol");
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.HasKey(e => e.IdUbigeo).HasName("PK_Hoja1$");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("XPKUsuario");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_47");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_48");
        });

        modelBuilder.Entity<VisitaConsultor>(entity =>
        {
            entity.HasKey(e => e.IdVisitaConsultor).HasName("XPKVisitaConsultor");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.VisitaConsultors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_35");

            entity.HasOne(d => d.IdConsultorNavigation).WithMany(p => p.VisitaConsultors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_34");
        });

        modelBuilder.Entity<VisitaDetalle>(entity =>
        {
            entity.HasOne(d => d.IdVisitaConsultorNavigation).WithMany(p => p.VisitaDetalles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VisitaDetalle_VisitaConsultor");
        });

        modelBuilder.Entity<VistaUsuarioRol>(entity =>
        {
            entity.ToView("VistaUsuarioRol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
