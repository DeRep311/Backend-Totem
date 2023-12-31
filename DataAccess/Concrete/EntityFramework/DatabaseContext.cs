﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Base.Models;

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

    public virtual DbSet<AnioGrupo> AnioGrupos { get; set; }

    public virtual DbSet<Cm> Cms { get; set; }

    public virtual DbSet<Coordenada> Coordenadas { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<CursoHorarioUbicacion> CursoHorarioUbicacions { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<EstudiaEn> EstudiaEns { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<GrupoCursoMaterium> GrupoCursoMateria { get; set; }

    public virtual DbSet<Horarios> Horarios { get; set; }

    public virtual DbSet<HorarioGrupoCurso> HorarioGrupoCursos { get; set; }

    public virtual DbSet<Imparte> Impartes { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Operador> Operadors { get; set; }

    public virtual DbSet<Plano> Planos { get; set; }

    public virtual DbSet<Tiene> Tienes { get; set; }

    public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }

    public virtual DbSet<UbicacionesDependiente> UbicacionesDependientes { get; set; }

    public virtual DbSet<Up> Ups { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=apheleondb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

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

            // entity.HasOne(d => d.CedulaNavigation).WithMany()
            //     .HasForeignKey(d => d.Cedula)
            //     .HasConstraintName("FK_administrador_usuario");
        });

        modelBuilder.Entity<Anio>(entity =>
        {
            entity.HasKey(e => e.anio).HasName("PRIMARY");

            entity.ToTable("anio");

            entity.Property(e => e.anio)
                .ValueGeneratedNever()
                .HasColumnType("int(5)")
                .HasColumnName("anio");
        });

        modelBuilder.Entity<AnioGrupo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("anio-grupo");

            entity.HasIndex(e => e.anio, "FK_anio-grupo_anio");

            entity.HasIndex(e => e.nombre_grupo, "FK_anio-grupo_grupo");

            entity.Property(e => e.anio)
                .HasColumnType("int(5)")
                .HasColumnName("anio");
            entity.Property(e => e.nombre_grupo)
                .HasMaxLength(10)
                .HasColumnName("nombre_grupo");

            //     entity.HasOne(d => d.AnioNavigation).WithMany()
            //         .HasForeignKey(d => d.Anio)
            //         .HasConstraintName("FK_anio-grupo_anio");

            //     entity.HasOne(d => d.NombreGrupoNavigation).WithMany()
            //         .HasForeignKey(d => d.NombreGrupo)
            //         .HasConstraintName("a");
        });

        modelBuilder.Entity<Cm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cm");

            entity.HasIndex(e => e.id_c, "FK__curso");

            entity.HasIndex(e => e.nombre_materia, "FK__materia");

            entity.Property(e => e.id_c)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(255)")
                .HasColumnName("id_c");
            entity.Property(e => e.nombre_materia)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("nombre_materia");

            // entity.HasOne(d => d.IdCNavigation).WithMany()
            //     .HasForeignKey(d => d.IdC)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("FK_cm_curso");

            // entity.HasOne(d => d.NombreMateriaNavigation).WithMany()
            //     .HasForeignKey(d => d.NombreMateria)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("FK_cm_materia");
        });

        modelBuilder.Entity<Coordenada>(entity =>
        {
            entity.HasKey(e => e.id_c).HasName("PRIMARY");

            entity.ToTable("coordenadas");

            entity.Property(e => e.id_c)
                .HasColumnType("int(11)")
                .HasColumnName("id_c");
            entity.Property(e => e.coo_x).HasColumnName("coo_x");
            entity.Property(e => e.coo_y).HasColumnName("coo_y");
            entity.Property(e => e.Final)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.foto)
                .HasMaxLength(50)
                .HasColumnName("foto");
            entity.Property(e => e.Inicio)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.id_c).HasName("PRIMARY");

            entity.ToTable("curso");

            entity.Property(e => e.id_c)
                .HasColumnType("int(255)")
                .HasColumnName("id_c");
            entity.Property(e => e.nombre_curso)
                .HasMaxLength(7)
                .HasColumnName("nombre_curso");
        });

        modelBuilder.Entity<CursoHorarioUbicacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("curso-horario-ubicacion");

            entity.HasIndex(e => new { e.nombre_grupo, e.nombre_materia, e.id_h, e.id_c }, "Horario-Grupo-curso_idx");

            entity.HasIndex(e => e.codigo_ubicaciones, "Ubicacion_idx");

            entity.HasIndex(e => e.id_c, "id_c");

            entity.HasIndex(e => e.id_h, "id_h");

            entity.HasIndex(e => e.nombre_materia, "nombre_materia");

            entity.Property(e => e.codigo_ubicaciones)
                .HasMaxLength(5)
                .HasColumnName("codigo_ubicaciones");
            entity.Property(e => e.id_c)
                .HasColumnType("int(255)")
                .HasColumnName("id_c");
            entity.Property(e => e.id_h)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(255)")
                .HasColumnName("id_h");
            entity.Property(e => e.nombre_grupo)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("nombre_grupo");
            entity.Property(e => e.nombre_materia)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("nombre_materia");

            // entity.HasOne(d => d.CodigoUbicacionesNavigation).WithMany()
            //     .HasForeignKey(d => d.CodigoUbicaciones)
            //     .HasConstraintName("Ubicacion");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("docente");

            entity.HasIndex(e => e.Cedula, "FK__usuario");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");

            // entity.HasOne(d => d.CedulaNavigation).WithMany()
            //     .HasForeignKey(d => d.Cedula)
            //     .HasConstraintName("FK_docente_usuario");
        });

        modelBuilder.Entity<EstudiaEn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("estudia_en");

            entity.HasIndex(e => e.Cedula, "FK__usuario");

            entity.HasIndex(e => e.nombre_grupo, "FK_estudia_en_grupo");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(8)")
                .HasColumnName("cedula");
            entity.Property(e => e.nombre_grupo)
                .HasMaxLength(10)
                .HasColumnName("nombre_grupo");

            // entity.HasOne(d => d.NombreGrupoNavigation).WithMany()
            //     .HasForeignKey(d => d.NombreGrupo)
            //     .HasConstraintName("FK_estudia_en_grupo");
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

            // entity.HasOne(d => d.CedulaNavigation).WithMany()
            //     .HasForeignKey(d => d.Cedula)
            //     .HasConstraintName("FK_estudiante_usuario");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            // entity.HasKey(e => e.NombreGrupo).HasName("PRIMARY");

            // entity.ToTable("grupo");

            // entity.Property(e => e.NombreGrupo)
            //     .HasMaxLength(10)
            //     .HasColumnName("nombre_grupo");
        });

        // modelBuilder.Entity<GrupoCursoMaterium>(entity =>
        // {
        //     entity
        //         .HasNoKey()
        //         .ToTable("grupo-curso-materia");

        //     entity.HasIndex(e => e.IdC, "FK_grupo-curso-materia_curso");

        //     entity.HasIndex(e => e.NombreGrupo, "FK_grupo-curso-materia_grupo");

        //     entity.HasIndex(e => e.NombreMateria, "FK_grupo-curso-materia_materia");

        //     entity.Property(e => e.IdC)
        //         .ValueGeneratedOnAdd()
        //         .HasColumnType("int(255)")
        //         .HasColumnName("id_c");
        //     entity.Property(e => e.NombreGrupo)
        //         .HasMaxLength(10)
        //         .HasColumnName("nombre_grupo");
        //     entity.Property(e => e.NombreMateria)
        //         .HasMaxLength(30)
        //         .HasColumnName("nombre_materia");

        //     // entity.HasOne(d => d.NombreGrupoNavigation).WithMany()
        //     //     .HasForeignKey(d => d.NombreGrupo)
        //     //     .HasConstraintName("FK_grupo-curso-materia_grupo");
        // });

        modelBuilder.Entity<Horarios>(entity =>
        {
            entity.HasKey(e => e.id_h).HasName("PRIMARY");

            entity.ToTable("horarios");

            entity.Property(e => e.id_h)
                .HasColumnType("int(255)")
                .HasColumnName("id_h");
            entity.Property(e => e.hora_final)
                .HasMaxLength(5)
                .HasColumnName("hora_final");
            entity.Property(e => e.hora_inicio)
                .HasMaxLength(5)
                .HasColumnName("hora_inicio");
            entity.Property(e => e.nombre_del_dia)
                .HasMaxLength(9)
                .HasColumnName("nombre_del_dia");
        });

        modelBuilder.Entity<HorarioGrupoCurso>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("horario-grupo-curso");

            entity.HasIndex(e => new { e.nombre_grupo, e.nombre_materia, e.id_c }, "Grupo-Curso_idx");

            entity.HasIndex(e => e.id_h, "Horario_idx");

            entity.HasIndex(e => e.id_c, "id_c");

            entity.HasIndex(e => e.nombre_materia, "nombre_materia");

            entity.Property(e => e.id_c)
                .HasColumnType("int(255)")
                .HasColumnName("id_c");
            entity.Property(e => e.id_h)
                .HasColumnType("int(255)")
                .HasColumnName("id_h");
            entity.Property(e => e.nombre_grupo)
                .HasMaxLength(10)
                .HasColumnName("nombre_grupo");
            entity.Property(e => e.nombre_materia)
                .HasMaxLength(30)
                .HasColumnName("nombre_materia");

            // entity.HasOne(d => d.IdHNavigation).WithMany()
            //     .HasForeignKey(d => d.IdH)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("Horario");
        });

        modelBuilder.Entity<Imparte>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("imparte");

            entity.HasIndex(e => e.Cedula, "FK_imparte_docente");

            entity.HasIndex(e => new { e.nombre_materia, e.nombre_grupo, e.id_c, e.id_h }, "FK_imparte_grupo-curso-materia_idx");

            entity.HasIndex(e => e.id_c, "id_c");

            entity.HasIndex(e => e.id_h, "id_h");

            entity.HasIndex(e => e.nombre_grupo, "nombre_grupo");

            entity.Property(e => e.Cedula)
                .HasColumnType("int(11)")
                .HasColumnName("cedula");
            entity.Property(e => e.id_c)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(255)")
                .HasColumnName("id_c");
            entity.Property(e => e.id_h)
                .HasColumnType("int(11)")
                .HasColumnName("id_h");
            entity.Property(e => e.nombre_grupo)
                .HasMaxLength(10)
                .HasColumnName("nombre_grupo");
            entity.Property(e => e.nombre_materia)
                .HasMaxLength(30)
                .HasColumnName("nombre_materia");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.nombre_materia).HasName("PRIMARY");

            entity.ToTable("materia");

            entity.Property(e => e.nombre_materia)
                .HasMaxLength(30)
                .HasColumnName("nombre_materia");
        });

        modelBuilder.Entity<Operador>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("operador");

            entity.HasIndex(e => e.Cedula, "FK__usuario");

            entity.Property(e => e.Cedula).HasColumnType("int(8)");

            // entity.HasOne(d => d.CedulaNavigation).WithMany()
            //     .HasForeignKey(d => d.Cedula)
            //     .HasConstraintName("FK_operador_usuario");
        });

        modelBuilder.Entity<Plano>(entity =>
        {
            entity.HasKey(e => e.codigo_p).HasName("PRIMARY");

            entity.ToTable("planos");

            entity.Property(e => e.codigo_p)
                .HasMaxLength(10)
                .HasColumnName("codigo_p");
            entity.Property(e => e.plano_img)
                .HasMaxLength(50)
                .HasColumnName("plano_img");
        });

        modelBuilder.Entity<Tiene>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tiene");

            entity.HasIndex(e => e.id_c, "FK_Coordenadas_idx");
            entity.HasIndex(t => t.codigo_ubicaciones, "codigo_ubicaciones");

            entity.Property(e => e.codigo_ubicaciones)
                .HasColumnType("varchar(5)")
                .HasColumnName("codigo_ubicaciones");

            entity.Property(e => e.id_c)
                .HasColumnType("int(11)")
                .HasColumnName("id_c");

            // entity.HasOne(d => d.CodigoUbicacionesNavigation).WithMany()
            //     .HasForeignKey(d => d.CodigoUbicaciones)
            //     .HasConstraintName("FK_tiene_ubicaciones");

            // entity.HasOne(d => d.IdCNavigation).WithMany()
            //     .HasForeignKey(d => d.IdC)
            //     .HasConstraintName("FK_Coordenadas");
        });

        modelBuilder.Entity<Ubicaciones>(entity =>
        {
            entity.HasKey(e => e.codigo_ubicaciones).HasName("PRIMARY");

            entity.ToTable("ubicaciones");

            entity.Property(e => e.codigo_ubicaciones)
                .HasMaxLength(5)
                .HasColumnName("codigo_ubicaciones");
            entity.Property(e => e.nombre)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("nombre");
            entity.Property(e => e.privado)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("privado");
            entity.Property(e => e.publico)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("publico");

        });

        modelBuilder.Entity<UbicacionesDependiente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ubicaciones_dependiente");

            entity.HasIndex(e => new { e.CodigoUbicaciones, e.codigo_ubicaciones_dep }, "FK__ubicaciones");

            entity.HasIndex(e => e.codigo_ubicaciones_dep, "codigo_ubicaciones-dep");

            entity.Property(e => e.CodigoUbicaciones)
                .HasMaxLength(5)
                .HasColumnName("codigo_ubicaciones");
            entity.Property(e => e.codigo_ubicaciones_dep)
                .HasMaxLength(5)
                .HasColumnName("codigo_ubicaciones-dep");

            // entity.HasOne(d => d.CodigoUbicacionesNavigation).WithMany()
            //     .HasForeignKey(d => d.CodigoUbicaciones)
            //     .HasConstraintName("FK_ubicaciones_dependiente_ubicaciones");

            // entity.HasOne(d => d.CodigoUbicacionesDepNavigation).WithMany()
            //     .HasForeignKey(d => d.CodigoUbicacionesDep)
            //     .HasConstraintName("ubicaciones_dependiente_ibfk_1");
        });

        modelBuilder.Entity<Up>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("up");

            entity.HasIndex(e => e.codigo_p, "FK__planos");

            entity.HasIndex(e => e.codigo_ubicaciones, "FK__ubicaciones");

            entity.Property(e => e.codigo_p)
                .HasMaxLength(10)
                .HasColumnName("codigo_p");
            entity.Property(e => e.codigo_ubicaciones)
                .HasMaxLength(5)
                .HasColumnName("codigo_ubicaciones");

            // entity.HasOne(d => d.CodigoPNavigation).WithMany()
            //     .HasForeignKey(d => d.CodigoP)
            //     .HasConstraintName("FK_up_planos");

            // entity.HasOne(d => d.CodigoUbicacionesNavigation).WithMany()
            //     .HasForeignKey(d => d.CodigoUbicaciones)
            //     .HasConstraintName("FK_up_ubicaciones");
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
                .HasDefaultValueSql("''")
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasColumnType("int(10)")
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
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
