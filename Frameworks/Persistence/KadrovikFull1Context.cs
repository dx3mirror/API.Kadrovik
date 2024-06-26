﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entity;

public partial class KadrovikFull1Context : DbContext
{
    public KadrovikFull1Context()
    {
    }

    public KadrovikFull1Context(DbContextOptions<KadrovikFull1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalDocument> AdditionalDocuments { get; set; }

    public virtual DbSet<CommentRezyme> CommentRezymes { get; set; }

    public virtual DbSet<DocumentRezyme> DocumentRezymes { get; set; }

    public virtual DbSet<Doljnost> Doljnosts { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Family> Families { get; set; }

    public virtual DbSet<Obrazovanie> Obrazovanies { get; set; }

    public virtual DbSet<Otpusk> Otpusks { get; set; }

    public virtual DbSet<Passport> Passports { get; set; }

    public virtual DbSet<RequestSite> RequestSites { get; set; }

    public virtual DbSet<Rezyme> Rezymes { get; set; }

    public virtual DbSet<Sotrudnik> Sotrudniks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersSite> UsersSites { get; set; }

    public virtual DbSet<Waruchet> Waruchets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=62.78.81.19;Initial Catalog=KadrovikFULL1;user id=stud;password=123456789;encrypt=False;MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalDocument>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FkSotrudnik)
                .HasMaxLength(255)
                .HasColumnName("FK_Sotrudnik");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Inn)
                .HasMaxLength(255)
                .HasColumnName("INN");
            entity.Property(e => e.Kpp)
                .HasMaxLength(255)
                .HasColumnName("KPP");
            entity.Property(e => e.MedKnikjka).HasMaxLength(255);
            entity.Property(e => e.Polis)
                .HasMaxLength(255)
                .HasColumnName("POLIS");
            entity.Property(e => e.Snils)
                .HasMaxLength(255)
                .HasColumnName("SNILS");
            entity.Property(e => e.TrudKnijka).HasMaxLength(255);
        });

        modelBuilder.Entity<CommentRezyme>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CommentRezyme");

            entity.Property(e => e.Commnet)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<DocumentRezyme>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DocumentRezyme");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Nazvaniy)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Doljnost>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("doljnost");

            entity.Property(e => e.FkSotrudnik).HasColumnName("FK_Sotrudnik");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.KolVo).HasColumnName("kol_vo");
            entity.Property(e => e.NaimenoviyDoljnosti)
                .HasMaxLength(255)
                .HasColumnName("naimenoviy_doljnosti");
            entity.Property(e => e.Otvetstveniy)
                .HasMaxLength(255)
                .HasColumnName("otvetstveniy");
            entity.Property(e => e.PoKokoe)
                .HasMaxLength(255)
                .HasColumnName("po_kokoe");
            entity.Property(e => e.SKogo)
                .HasMaxLength(255)
                .HasColumnName("s_kogo");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Experience");

            entity.Property(e => e.Del).HasColumnName("del");
            entity.Property(e => e.FkSotrudnik).HasColumnName("FK_Sotrudnik");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.NepreryvniyDay)
                .HasMaxLength(255)
                .HasColumnName("nepreryvniy_day");
            entity.Property(e => e.NepreryvniyMonth)
                .HasMaxLength(255)
                .HasColumnName("nepreryvniy_month");
            entity.Property(e => e.NepreryvniyYear)
                .HasMaxLength(255)
                .HasColumnName("nepreryvniy_year");
            entity.Property(e => e.ObchyiDay)
                .HasMaxLength(255)
                .HasColumnName("obchyi_day");
            entity.Property(e => e.ObchyiMonth)
                .HasMaxLength(255)
                .HasColumnName("obchyi_month");
            entity.Property(e => e.ObchyiYear)
                .HasMaxLength(255)
                .HasColumnName("obchyi_year");
            entity.Property(e => e.Stajrabotyposostoyaniyna)
                .HasMaxLength(255)
                .HasColumnName("stajrabotyposostoyaniyna");
            entity.Property(e => e.VislugaletDay)
                .HasMaxLength(255)
                .HasColumnName("vislugalet_day");
            entity.Property(e => e.VislugaletMonth)
                .HasMaxLength(255)
                .HasColumnName("vislugalet_month");
            entity.Property(e => e.VislugaletYear)
                .HasMaxLength(255)
                .HasColumnName("vislugalet_year");
        });

        modelBuilder.Entity<Family>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Family");

            entity.Property(e => e.DataRojdeniya)
                .HasColumnType("datetime")
                .HasColumnName("data_rojdeniya");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .HasColumnName("FIO");
            entity.Property(e => e.FkSotrudnik).HasColumnName("FK_sotrudnik");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.StepenRodstva)
                .HasMaxLength(255)
                .HasColumnName("stepen_rodstva");
        });

        modelBuilder.Entity<Obrazovanie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Obrazovanie");

            entity.Property(e => e.FkSotrudnik).HasColumnName("FK_sotrudnik");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.KvalifikachiyapoObrazovaniyu)
                .HasMaxLength(255)
                .HasColumnName("kvalifikachiyapoObrazovaniyu");
            entity.Property(e => e.KvalifikachiyapoObrazovaniyu2)
                .HasMaxLength(255)
                .HasColumnName("kvalifikachiyapoObrazovaniyu2");
            entity.Property(e => e.Nazvanieuchrejdeniya)
                .HasMaxLength(255)
                .HasColumnName("nazvanieuchrejdeniya");
            entity.Property(e => e.Nazvanieuchrejdeniya2)
                .HasMaxLength(255)
                .HasColumnName("nazvanieuchrejdeniya2");
            entity.Property(e => e.Obrazovanie1)
                .HasMaxLength(255)
                .HasColumnName("obrazovanie1");
            entity.Property(e => e.Poslevuzovoe)
                .HasMaxLength(255)
                .HasColumnName("poslevuzovoe");
            entity.Property(e => e.ProfessiaDopolnitel)
                .HasMaxLength(255)
                .HasColumnName("professiaDopolnitel");
            entity.Property(e => e.ProfessiaOsnova)
                .HasMaxLength(255)
                .HasColumnName("professiaOsnova");
        });

        modelBuilder.Entity<Otpusk>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Otpusk");

            entity.Property(e => e.Day)
                .HasMaxLength(255)
                .HasColumnName("day");
            entity.Property(e => e.FkSotrudnik).HasColumnName("FK_sotrudnik");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.PeriodPo)
                .HasColumnType("datetime")
                .HasColumnName("period_po");
            entity.Property(e => e.PeriodS)
                .HasColumnType("datetime")
                .HasColumnName("period_s");
            entity.Property(e => e.PoKakoe)
                .HasColumnType("datetime")
                .HasColumnName("po_kakoe");
            entity.Property(e => e.Prichina)
                .HasMaxLength(255)
                .HasColumnName("prichina");
            entity.Property(e => e.SKakogo)
                .HasColumnType("datetime")
                .HasColumnName("S_kakogo");
            entity.Property(e => e.VidOtpuska)
                .HasMaxLength(255)
                .HasColumnName("vid_otpuska");
        });

        modelBuilder.Entity<Passport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Passport");

            entity.Property(e => e.AdressjitelstvaPopasportu)
                .HasMaxLength(255)
                .HasColumnName("adressjitelstva_popasportu");
            entity.Property(e => e.AressFakticheskiy)
                .HasMaxLength(255)
                .HasColumnName("aress_fakticheskiy");
            entity.Property(e => e.DataregistrachiiPoMestu)
                .HasColumnType("datetime")
                .HasColumnName("dataregistrachii_po_mestu");
            entity.Property(e => e.Datavidachi)
                .HasColumnType("datetime")
                .HasColumnName("datavidachi");
            entity.Property(e => e.FkSotrudnik).HasColumnName("FK_Sotrudnik");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.NomerPasporta)
                .HasMaxLength(255)
                .HasColumnName("nomer_pasporta");
            entity.Property(e => e.Vidan)
                .HasMaxLength(255)
                .HasColumnName("vidan");
        });

        modelBuilder.Entity<RequestSite>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RequestSite");

            entity.Property(e => e.About)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rezyme>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rezyme");

            entity.Property(e => e.Adress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Brak)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Datarojdeniy).HasColumnType("smalldatetime");
            entity.Property(e => e.Del)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Firstname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.InYz)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("In_yz");
            entity.Property(e => e.Lastname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MestoRojd)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Mesto_rojd");
            entity.Property(e => e.Obrozovaniy)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OpitRaboti)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Patranomic)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sotrudnik>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sotrudnik");

            entity.Property(e => e.Adress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Brak)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Datarojdeniy).HasColumnType("smalldatetime");
            entity.Property(e => e.Del)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Firstname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.IdentityNomer)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.InYz)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("In_yz");
            entity.Property(e => e.Lastname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MestoRojd)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Mesto_rojd");
            entity.Property(e => e.Okin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OKIN");
            entity.Property(e => e.Patranomic)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<UsersSite>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UsersSite");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Login).IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
        });

        modelBuilder.Entity<Waruchet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Waruchet");

            entity.Property(e => e.FkSotrudnik).HasColumnName("FK_Sotrudnik");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Kategoria).HasMaxLength(255);
            entity.Property(e => e.Kategorya).HasMaxLength(255);
            entity.Property(e => e.KodVus)
                .HasMaxLength(255)
                .HasColumnName("kod_VUS");
            entity.Property(e => e.NazvanieKomisariata)
                .HasMaxLength(255)
                .HasColumnName("Nazvanie_komisariata");
            entity.Property(e => e.Sostav).HasMaxLength(255);
            entity.Property(e => e.SostoyanieVoinskogo)
                .HasMaxLength(255)
                .HasColumnName("Sostoyanie_voinskogo");
            entity.Property(e => e.Zvanie).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
