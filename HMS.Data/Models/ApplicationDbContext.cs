using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Data.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<Disease>  Diseases { get; set; }
        public virtual DbSet<Department>  Departments { get; set; }
        public virtual DbSet<LabTest> LabTest { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<MedicalHistory>  MedicalHistories { get; set; }
        public virtual DbSet<Triage>  Triages { get; set; }
        public virtual DbSet<County>   Counties { get; set; }
        public virtual DbSet<HospitalVisit> HospitalVisits { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<HospitalVisit>(entity =>
            //{

            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            //});

            //modelBuilder.Entity<Commission>(entity =>
            //{
            //    entity.Property(e => e.CommissionAmount).HasColumnType("decimal(18,2)");
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            //});

            seedCounties(modelBuilder);

        }


        public static void seedCounties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<County>().HasData(
            new County { Id = 1, Name = "Bomet" },
            new County { Id = 2, Name = "Bungoma" },
            new County { Id = 3, Name = "Busia" },
            new County { Id = 4, Name = "Elgeyo-Marakwet" },
            new County { Id = 5, Name = "Embu" },
            new County { Id = 6, Name = "Garissa" },
            new County { Id = 7, Name = "Homa Bay" },
            new County { Id = 8, Name = "Isiolo" },
            new County { Id = 9, Name = "Kajiado" },
            new County { Id = 10, Name = "Kakamega" },
            new County { Id = 11, Name = "Kericho" },
            new County { Id = 12, Name = "Kiambu" },
            new County { Id = 13, Name = "Kilifi" },
            new County { Id = 14, Name = "Kirinyaga" },
            new County { Id = 15, Name = "Kisii" },
            new County { Id = 16, Name = "Kisumu" },
            new County { Id = 17, Name = "Kitui" },
            new County { Id = 18, Name = "Kwale" },
            new County { Id = 19, Name = "Laikipia" },
            new County { Id = 20, Name = "Lamu" },
            new County { Id = 21, Name = "Machakos" },
            new County { Id = 22, Name = "Makueni" },
            new County { Id = 23, Name = "Mandera" },
            new County { Id = 24, Name = "Marsabit" },
            new County { Id = 25, Name = "Meru" },
            new County { Id = 26, Name = "Migori" },
            new County { Id = 27, Name = "Mambasa" },
            new County { Id = 28, Name = "Muranga" },
            new County { Id = 29, Name = "Nairobi" },
            new County { Id = 30, Name = "Nakuru" },
            new County { Id = 31, Name = "Nandi" },
            new County { Id = 32, Name = "Narok" },
            new County { Id = 33, Name = "Nyamira" },
            new County { Id = 34, Name = "Nyandarua" },
            new County { Id = 35, Name = "Nnyeri" },
            new County { Id = 36, Name = "Samburu" },
            new County { Id = 37, Name = "Siaya" },
            new County { Id = 38, Name = "Taita Taveta" },
            new County { Id = 39, Name = "Tana River" },
            new County { Id = 40, Name = "Tharaka-Nithi" },
            new County { Id = 41, Name = "Trans-Nzoia" },
            new County { Id = 42, Name = "Turkana" },
            new County { Id = 43, Name = "Uasin Gishu" },
            new County { Id = 44, Name = "Vihiga" },
            new County { Id = 45, Name = "Wajir" },
            new County { Id = 46, Name = "West Pokot" },
            new County { Id = 47, Name = "Baringo" });
        }
    }
}
