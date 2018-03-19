namespace SistemaDemoServicios
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SistemaEjemploEntities : DbContext
    {
        public SistemaEjemploEntities()
            : base("name=SistemaVentas")
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Agente> Agente { get; set; }
        public virtual DbSet<AgenteCliente> AgenteCliente { get; set; }
        public virtual DbSet<Alarma> Alarma { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<HorarioTrabajo> HorarioTrabajo { get; set; }
        public virtual DbSet<Informe> Informe { get; set; }
        public virtual DbSet<LogPosition> LogPosition { get; set; }
        public virtual DbSet<Supervisor> Supervisor { get; set; }
        public virtual DbSet<Visita> Visita { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Administrador>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Administrador>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Administrador>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Administrador>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Agente>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Agente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Agente>()
                .HasMany(e => e.AgenteCliente)
                .WithOptional(e => e.Agente)
                .HasForeignKey(e => e.IdAgente);

            modelBuilder.Entity<Agente>()
                .HasMany(e => e.LogPosition)
                .WithOptional(e => e.Agente)
                .HasForeignKey(e => e.idAgente);

            modelBuilder.Entity<Agente>()
                .HasMany(e => e.Visita)
                .WithOptional(e => e.Agente)
                .HasForeignKey(e => e.IdAgente);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Ruc)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.PersonaContacto)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.AgenteCliente)
                .WithOptional(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Visita)
                .WithOptional(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente);

            modelBuilder.Entity<HorarioTrabajo>()
                .Property(e => e.HoraInicio)
                .IsUnicode(false);

            modelBuilder.Entity<HorarioTrabajo>()
                .Property(e => e.HoraFinal)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.PendienteComercial)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.SolucionComercial)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.PendienteServicio)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.SolucionServicio)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.NuevoNegocio)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.Otros)
                .IsUnicode(false);

            modelBuilder.Entity<Informe>()
                .Property(e => e.UrlFirma)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .HasMany(e => e.Agente)
                .WithOptional(e => e.Supervisor)
                .HasForeignKey(e => e.IdSupervisor);

            modelBuilder.Entity<Visita>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<Visita>()
                .HasMany(e => e.Informe)
                .WithOptional(e => e.Visita)
                .HasForeignKey(e => e.IdVisita);
        }
    }
}
