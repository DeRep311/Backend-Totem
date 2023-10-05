using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Entities;
namespace DataAccess.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Anio> Anios { get; set; }

    public virtual DbSet<AnioCurso> AnioCursos { get; set; }

    public virtual DbSet<Cm> Cms { get; set; }

    public virtual DbSet<Codigo> Codigos { get; set; }

    public virtual DbSet<Coordenada> Coordenadas { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<EstudiaEn> EstudiaEns { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<HorarioCmUbicacione> HorarioCmUbicaciones { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Operador> Operadors { get; set; }

    public virtual DbSet<Plano> Planos { get; set; }

    public virtual DbSet<Privado> Privados { get; set; }

    public virtual DbSet<Publico> Publicos { get; set; }

    public virtual DbSet<Tiene> Tienes { get; set; }

    public virtual DbSet<Ubicacione> Ubicaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=190.135.204.178;database=apheleondb;user=root;password=789874506082005", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.5-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Administrador>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("administrador");

            entity.HasIndex(e => e.Cedula, "FK_administrador_usuario");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
        });

        modelBuilder.Entity<Anio>(entity =>
        {
            entity.HasKey(e => e.Anio1).HasName("PRIMARY");

            entity.ToTable("anio");

            entity.Property(e => e.Anio1)
                .ValueGeneratedNever()
                .HasColumnType("int(5)")
                .HasColumnName("anio");
        });

        modelBuilder.Entity<AnioCurso>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("anio-curso");

            entity.HasIndex(e => e.Anio, "anio");

            entity.HasIndex(e => e.IdC, "id_c");

            entity.Property(e => e.Anio)
                .HasColumnType("int(5)")
                .HasColumnName("anio");
            entity.Property(e => e.IdC)
                .HasColumnType("int(11)")
                .HasColumnName("id_c");
        });

        modelBuilder.Entity<Cm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cm");

            entity.HasIndex(e => e.IdC, "id_c");

            entity.HasIndex(e => e.IdM, "id_m");

            entity.Property(e => e.IdC)
                .HasColumnType("int(11)")
                .HasColumnName("id_c");
            entity.Property(e => e.IdM)
                .HasColumnType("int(11)")
                .HasColumnName("id_m");
        });

        modelBuilder.Entity<Codigo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("codigo");

            entity.Property(e => e.Codigo1)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnName("codigo");
        });

        modelBuilder.Entity<Coordenada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("coordenadas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(5)")
                .HasColumnName("id");
            entity.Property(e => e.CooX).HasColumnName("coo_x");
            entity.Property(e => e.CooY).HasColumnName("coo_y");
            entity.Property(e => e.Foto)
                .HasColumnType("int(11)")
                .HasColumnName("foto");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdC).HasName("PRIMARY");

            entity.ToTable("curso");

            entity.HasIndex(e => e.Cedula, "cedula");

            entity.Property(e => e.IdC)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_c");
            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
            entity.Property(e => e.Generacion)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnName("generacion");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(7)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("docente");

            entity.HasIndex(e => e.Cedula, "cedula_id");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
        });

        modelBuilder.Entity<EstudiaEn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("estudia_en");

            entity.HasIndex(e => e.Cedula, "cedula_id");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("estudiante");

            entity.HasIndex(e => e.Cedula, "FK__usuario");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdH).HasName("PRIMARY");

            entity.ToTable("horario");

            entity.Property(e => e.IdH)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_h");
            entity.Property(e => e.HoraFinal)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnName("hora_final");
            entity.Property(e => e.HoraInicio)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnName("hora_inicio");
            entity.Property(e => e.NombreDia)
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnName("nombre_dia");
        });

        modelBuilder.Entity<HorarioCmUbicacione>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("horario_cm_ubicaciones");

            entity.HasIndex(e => e.Codigo, "codigo");

            entity.HasIndex(e => e.IdC, "id_c");

            entity.HasIndex(e => e.IdH, "id_h");

            entity.HasIndex(e => e.IdM, "id_m");

            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(5)
                .HasDefaultValueSql("''")
                .HasColumnName("codigo");
            entity.Property(e => e.IdC)
                .HasColumnType("int(11)")
                .HasColumnName("id_c");
            entity.Property(e => e.IdH)
                .HasColumnType("int(11)")
                .HasColumnName("id_h");
            entity.Property(e => e.IdM)
                .HasColumnType("int(11)")
                .HasColumnName("id_m");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.IdM).HasName("PRIMARY");

            entity.ToTable("materia");

            entity.HasIndex(e => e.Cedula, "cedula");

            entity.Property(e => e.IdM)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_m");
            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Operador>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("operador");

            entity.HasIndex(e => e.Cedula, "cedula_id");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
        });

        modelBuilder.Entity<Plano>(entity =>
        {
            entity.HasKey(e => e.CodigoP).HasName("PRIMARY");

            entity.ToTable("planos");

            entity.Property(e => e.CodigoP)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("codigo_p");
            entity.Property(e => e.PlanoImg)
                .HasColumnType("int(11)")
                .HasColumnName("plano_img");
        });

        modelBuilder.Entity<Privado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("privado");

            entity.HasIndex(e => e.Codigo, "codigo");

            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnName("codigo");
        });

        modelBuilder.Entity<Publico>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("publico");

            entity.HasIndex(e => e.Codigo, "codigo");

            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .HasColumnName("codigo");
        });

        modelBuilder.Entity<Tiene>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tiene");

            entity.HasIndex(e => e.Codigo, "codigo");

            entity.HasIndex(e => e.Id, "id");

            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnName("codigo");
            entity.Property(e => e.Id)
                .HasColumnType("int(5)")
                .HasColumnName("id");
        });

        modelBuilder.Entity<Ubicacione>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PRIMARY");

            entity.ToTable("ubicaciones");

            entity.HasIndex(e => e.CodigoP, "codigo_p");

            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .HasColumnName("codigo");
            entity.Property(e => e.CodigoP)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("codigo_p");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Cedula).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.Cedula)
                .ValueGeneratedNever()
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("nombre");
            entity.Property(e => e.Pin)
                .HasColumnType("int(4)")
                .HasColumnName("pin");
            entity.Property(e => e.Telefono)
                .HasColumnType("int(10)")
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
