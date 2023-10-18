using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<Anio> Anios { get; set; }

    public virtual DbSet<AnioCurso> AnioCursos { get; set; }

    public virtual DbSet<Coordenada> Coordenadas { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<EstudiaEn> EstudiaEns { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<HorarioCmUbicacione> HorarioCmUbicaciones { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Plano> Planos { get; set; }

    public virtual DbSet<Ubicacione> Ubicaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=apheleondb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

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

            entity.HasOne(d => d.AnioNavigation).WithMany()
                .HasForeignKey(d => d.Anio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_anioCurso_anio");
        });

        modelBuilder.Entity<Coordenada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("coordenadas");

            entity.Property(e => e.Id)
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
            entity
                .HasNoKey()
                .ToTable("curso");

            entity.HasIndex(e => e.IdC, "FK_materia_idx");

            entity.Property(e => e.Anio)
                .HasColumnType("int(5)")
                .HasColumnName("anio");
            entity.Property(e => e.Generacion)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnName("generacion");
            entity.Property(e => e.IdC)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("id_c");
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

            entity.HasIndex(e => e.Cedula, "docente_ibfk_1_idx");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");

            entity.HasOne(d => d.CedulaNavigation).WithMany()
                .HasForeignKey(d => d.Cedula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("docente_ibfk_1");
        });

        modelBuilder.Entity<EstudiaEn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("estudia_en");

            entity.HasIndex(e => e.IdC, "estudia_en_curso_idx");

            entity.HasIndex(e => e.Cedula, "estudia_en_ibfk_1");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
            entity.Property(e => e.IdC)
                .HasColumnType("int(11)")
                .HasColumnName("id_c");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("estudiante");

            entity.HasIndex(e => e.Cedula, "estudiante_usuario_idx");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");

            entity.HasOne(d => d.CedulaNavigation).WithMany()
                .HasForeignKey(d => d.Cedula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estudiante_usuario");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdH).HasName("PRIMARY");

            entity.ToTable("horario");

            entity.Property(e => e.IdH)
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

            entity.HasIndex(e => new { e.IdM, e.IdC }, "FK_horariocm_ubicaciones_idx");

            entity.HasIndex(e => e.Codigo, "codigo");

            entity.HasIndex(e => e.IdH, "id_H");

            entity.HasIndex(e => e.IdC, "id_c");

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
                .HasColumnName("id_H");
            entity.Property(e => e.IdM)
                .HasColumnType("int(11)")
                .HasColumnName("id_m");

            entity.HasOne(d => d.CodigoNavigation).WithMany()
                .HasForeignKey(d => d.Codigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ubicaciones");

            entity.HasOne(d => d.IdHNavigation).WithMany()
                .HasForeignKey(d => d.IdH)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_horarios");

            entity.HasOne(d => d.IdMNavigation).WithMany()
                .HasForeignKey(d => d.IdM)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_horariocm_ubicaciones");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.IdM).HasName("PRIMARY");

            entity.ToTable("materia");

            entity.HasIndex(e => e.IdM, "FK_horariocm_idx");

            entity.HasIndex(e => e.Cedula, "cedula");

            entity.HasIndex(e => e.IdC, "id_c");

            entity.Property(e => e.IdM)
                .HasColumnType("int(11)")
                .HasColumnName("id_m");
            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
            entity.Property(e => e.IdC)
                .HasColumnType("int(11)")
                .HasColumnName("id_c");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Plano>(entity =>
        {
            entity.HasKey(e => new { e.CodigoP, e.PlanoImg })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("planos");

            entity.Property(e => e.CodigoP)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("codigo_p");
            entity.Property(e => e.PlanoImg)
                .HasColumnType("int(11)")
                .HasColumnName("plano_img");
        });

        modelBuilder.Entity<Ubicacione>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PRIMARY");

            entity.ToTable("ubicaciones");

            entity.HasIndex(e => new { e.CodigoP, e.PlanoImg }, "FK_ubicacion_planos_idx");

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
            entity.Property(e => e.PlanoImg)
                .HasColumnType("int(11)")
                .HasColumnName("plano_img");
            entity.Property(e => e.Privado)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.Publico)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");

            entity.HasOne(d => d.Plano).WithMany(p => p.Ubicaciones)
                .HasForeignKey(d => new { d.CodigoP, d.PlanoImg })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ubicacion_planos");

            entity.HasMany(d => d.Ids).WithMany(p => p.Codigos)
                .UsingEntity<Dictionary<string, object>>(
                    "Tiene",
                    r => r.HasOne<Coordenada>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tiene_Coo"),
                    l => l.HasOne<Ubicacione>().WithMany()
                        .HasForeignKey("Codigo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tiene_ubi"),
                    j =>
                    {
                        j.HasKey("Codigo", "Id")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("tiene");
                        j.HasIndex(new[] { "Codigo" }, "codigo");
                        j.HasIndex(new[] { "Id" }, "id");
                        j.IndexerProperty<string>("Codigo")
                            .HasMaxLength(5)
                            .HasColumnName("codigo");
                        j.IndexerProperty<int>("Id")
                            .HasColumnType("int(5)")
                            .HasColumnName("id");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Cedula).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.Cedula)
                .ValueGeneratedNever()
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
            entity.Property(e => e.Administrador)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)");
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
            entity.Property(e => e.Operador)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)");
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
