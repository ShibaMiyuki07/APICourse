using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public partial class CourseContext : DbContext
{
    public CourseContext()
    {
    }

    public CourseContext(DbContextOptions<CourseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Coureur> Coureurs { get; set; }

    public virtual DbSet<Coureurcategory> Coureurcategories { get; set; }

    public virtual DbSet<Equipe> Equipes { get; set; }

    public virtual DbSet<Etape> Etapes { get; set; }

    public virtual DbSet<Etapecoureur> Etapecoureurs { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<Resultat> Resultats { get; set; }

    public virtual DbSet<Resultatspenalite> Resultatspenalites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:Psql");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("btree_gin")
            .HasPostgresExtension("btree_gist")
            .HasPostgresExtension("citext")
            .HasPostgresExtension("cube")
            .HasPostgresExtension("dblink")
            .HasPostgresExtension("dict_int")
            .HasPostgresExtension("dict_xsyn")
            .HasPostgresExtension("earthdistance")
            .HasPostgresExtension("fuzzystrmatch")
            .HasPostgresExtension("hstore")
            .HasPostgresExtension("intarray")
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto")
            .HasPostgresExtension("pgrowlocks")
            .HasPostgresExtension("pgstattuple")
            .HasPostgresExtension("tablefunc")
            .HasPostgresExtension("unaccent")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("xml2");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Idadmin).HasName("admins_pkey");

            entity.ToTable("admins");

            entity.Property(e => e.Idadmin)
                .HasMaxLength(10)
                .HasDefaultValueSql("concat('A00', nextval('idadmin'::regclass))")
                .IsFixedLength()
                .HasColumnName("idadmin");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcategorie).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Idcategorie)
                .HasMaxLength(10)
                .HasDefaultValueSql("concat('CA00', nextval('idcategorie'::regclass))")
                .IsFixedLength()
                .HasColumnName("idcategorie");
            entity.Property(e => e.Categorie)
                .HasMaxLength(50)
                .HasColumnName("categorie");
        });

        modelBuilder.Entity<Coureur>(entity =>
        {
            entity.HasKey(e => e.Idcoureur).HasName("coureurs_pkey");

            entity.ToTable("coureurs");

            entity.Property(e => e.Idcoureur)
                .HasMaxLength(10)
                .HasDefaultValueSql("concat('C00', nextval('idcoureur'::regclass))")
                .IsFixedLength()
                .HasColumnName("idcoureur");
            entity.Property(e => e.Datenaissance).HasColumnName("datenaissance");
            entity.Property(e => e.Idequipe)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idequipe");
            entity.Property(e => e.Idgenre)
                .HasMaxLength(1)
                .HasColumnName("idgenre");
            entity.Property(e => e.Nomcoureur)
                .HasMaxLength(100)
                .HasColumnName("nomcoureur");

            entity.HasOne(d => d.IdequipeNavigation).WithMany(p => p.Coureurs)
                .HasForeignKey(d => d.Idequipe)
                .HasConstraintName("coureurs_idequipe_fkey");

            entity.HasOne(d => d.IdgenreNavigation).WithMany(p => p.Coureurs)
                .HasForeignKey(d => d.Idgenre)
                .HasConstraintName("coureurs_idgenre_fkey");
        });

        modelBuilder.Entity<Coureurcategory>(entity =>
        {
            entity.HasKey(e => e.Idcoureurcategorie).HasName("coureurcategories_pkey");

            entity.ToTable("coureurcategories");

            entity.Property(e => e.Idcoureurcategorie)
                .HasMaxLength(10)
                .HasDefaultValueSql("concat('CC00', nextval('idcoureurcategorie'::regclass))")
                .IsFixedLength()
                .HasColumnName("idcoureurcategorie");
            entity.Property(e => e.Idcategorie)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idcategorie");
            entity.Property(e => e.Idcoureur)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idcoureur");

            entity.HasOne(d => d.IdcategorieNavigation).WithMany(p => p.Coureurcategories)
                .HasForeignKey(d => d.Idcategorie)
                .HasConstraintName("coureurcategories_idcategorie_fkey");

            entity.HasOne(d => d.IdcoureurNavigation).WithMany(p => p.Coureurcategories)
                .HasForeignKey(d => d.Idcoureur)
                .HasConstraintName("coureurcategories_idcoureur_fkey");
        });

        modelBuilder.Entity<Equipe>(entity =>
        {
            entity.HasKey(e => e.Idequipe).HasName("equipes_pkey");

            entity.ToTable("equipes");

            entity.Property(e => e.Idequipe)
                .HasMaxLength(10)
                .HasDefaultValueSql("concat('E00', nextval('idequipe'::regclass))")
                .IsFixedLength()
                .HasColumnName("idequipe");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("login");
            entity.Property(e => e.Nomequipe)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nomequipe");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("password");
        });

        modelBuilder.Entity<Etape>(entity =>
        {
            entity.HasKey(e => e.Idetape).HasName("etapes_pkey");

            entity.ToTable("etapes");

            entity.Property(e => e.Idetape)
                .HasMaxLength(10)
                .HasDefaultValueSql("concat('ET00', nextval('idetape'::regclass))")
                .IsFixedLength()
                .HasColumnName("idetape");
            entity.Property(e => e.Datedepart).HasColumnName("datedepart");
            entity.Property(e => e.Heuredepart).HasColumnName("heuredepart");
            entity.Property(e => e.Longueur).HasColumnName("longueur");
            entity.Property(e => e.Nombrecoureur).HasColumnName("nombrecoureur");
            entity.Property(e => e.Nometape)
                .HasMaxLength(100)
                .HasColumnName("nometape");
            entity.Property(e => e.Rang).HasColumnName("rang");
        });

        modelBuilder.Entity<Etapecoureur>(entity =>
        {
            entity.HasKey(e => e.Idetapecoureur).HasName("etapecoureurs_pkey");

            entity.ToTable("etapecoureurs");

            entity.Property(e => e.Idetapecoureur)
                .HasMaxLength(10)
                .HasDefaultValueSql("concat('EC00', nextval('idetapecoureur'::regclass))")
                .IsFixedLength()
                .HasColumnName("idetapecoureur");
            entity.Property(e => e.Idcoureur)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idcoureur");
            entity.Property(e => e.Idetape)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idetape");

            entity.HasOne(d => d.IdcoureurNavigation).WithMany(p => p.Etapecoureurs)
                .HasForeignKey(d => d.Idcoureur)
                .HasConstraintName("etapecoureurs_idcoureur_fkey");

            entity.HasOne(d => d.IdetapeNavigation).WithMany(p => p.Etapecoureurs)
                .HasForeignKey(d => d.Idetape)
                .HasConstraintName("etapecoureurs_idetape_fkey");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Idgenre).HasName("genres_pkey");

            entity.ToTable("genres");

            entity.Property(e => e.Idgenre)
                .HasMaxLength(1)
                .ValueGeneratedNever()
                .HasColumnName("idgenre");
            entity.Property(e => e.Genre1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("genre");
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.HasKey(e => e.Idpoint).HasName("points_pkey");

            entity.ToTable("points");

            entity.Property(e => e.Idpoint)
                .HasMaxLength(6)
                .HasDefaultValueSql("concat('P00', nextval('idpoint'::regclass))")
                .IsFixedLength()
                .HasColumnName("idpoint");
            entity.Property(e => e.Point1).HasColumnName("point");
            entity.Property(e => e.Rang).HasColumnName("rang");
        });

        modelBuilder.Entity<Resultat>(entity =>
        {
            entity.HasKey(e => e.Idresultat).HasName("resultats_pkey");

            entity.ToTable("resultats");

            entity.Property(e => e.Idresultat)
                .HasMaxLength(10)
                .HasDefaultValueSql("concat('R00', nextval('idresultat'::regclass))")
                .IsFixedLength()
                .HasColumnName("idresultat");
            entity.Property(e => e.Heurearrive).HasColumnName("heurearrive");
            entity.Property(e => e.Heuredepart).HasColumnName("heuredepart");
            entity.Property(e => e.Idetapecoureur)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idetapecoureur");

            entity.HasOne(d => d.IdetapecoureurNavigation).WithMany(p => p.Resultats)
                .HasForeignKey(d => d.Idetapecoureur)
                .HasConstraintName("resultats_idetapecoureur_fkey");
        });

        modelBuilder.Entity<Resultatspenalite>(entity =>
        {
            entity.HasKey(e => e.Idresultatpenalite).HasName("resultatspenalites_pkey");

            entity.ToTable("resultatspenalites");

            entity.Property(e => e.Idresultatpenalite)
                .HasMaxLength(10)
                .HasDefaultValueSql("concat('RP00', nextval('idresultatpenalite'::regclass))")
                .IsFixedLength()
                .HasColumnName("idresultatpenalite");
            entity.Property(e => e.Heurearrive).HasColumnName("heurearrive");
            entity.Property(e => e.Heuredepart).HasColumnName("heuredepart");
            entity.Property(e => e.Idresultat)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idresultat");

            entity.HasOne(d => d.IdresultatNavigation).WithMany(p => p.Resultatspenalites)
                .HasForeignKey(d => d.Idresultat)
                .HasConstraintName("resultatspenalites_idresultat_fkey");
        });
        modelBuilder.HasSequence("idadmin");
        modelBuilder.HasSequence("idcategorie");
        modelBuilder.HasSequence("idcoureur");
        modelBuilder.HasSequence("idcoureurcategorie");
        modelBuilder.HasSequence("idequipe");
        modelBuilder.HasSequence("idetape");
        modelBuilder.HasSequence("idetapecoureur");
        modelBuilder.HasSequence("idpoint");
        modelBuilder.HasSequence("idresultat");
        modelBuilder.HasSequence("idresultatpenalite");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
