﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication11.Models;

namespace WebApplication11.Data
{
    public partial class Project2Context : DbContext
    {
        public Project2Context()
        {
        }

        public Project2Context(DbContextOptions<Project2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Dataset> Dataset { get; set; }
        public virtual DbSet<Table1> Table1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Initial Catalog=Project2;Data Source=LAPTOP-AG8P98SR\\SQLEXPRESS;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Dataset>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber);

                entity.ToTable("dataset");

                entity.Property(e => e.EmployeeNumber).HasMaxLength(50);

                entity.Property(e => e.Attrition).HasMaxLength(50);

                entity.Property(e => e.BusinessTravel).HasMaxLength(50);

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.DistanceFromHome).HasMaxLength(50);

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.EducationField).HasMaxLength(50);

                entity.Property(e => e.EmployeeCount).HasMaxLength(50);

                entity.Property(e => e.EnvironmentSatisfaction).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.JobInvolvement).HasMaxLength(50);

                entity.Property(e => e.JobLevel).HasMaxLength(50);

                entity.Property(e => e.JobRole).HasMaxLength(50);

                entity.Property(e => e.JobSatisfaction).HasMaxLength(50);

                entity.Property(e => e.MaritalStatus).HasMaxLength(50);

                entity.Property(e => e.NumCompaniesWorked).HasMaxLength(50);

                entity.Property(e => e.Over18).HasMaxLength(50);

                entity.Property(e => e.OverTime).HasMaxLength(50);

                entity.Property(e => e.RelationshipSatisfaction).HasMaxLength(50);

                entity.Property(e => e.StockOptionLevel).HasMaxLength(50);

                entity.Property(e => e.TotalWorkingYears).HasMaxLength(50);

                entity.Property(e => e.TrainingTimesLastYear).HasMaxLength(50);

                entity.Property(e => e.WorkLifeBalance).HasMaxLength(50);

                entity.Property(e => e.YearsAtCompany).HasMaxLength(50);

                entity.Property(e => e.YearsInCurrentRole).HasMaxLength(50);

                entity.Property(e => e.YearsSinceLastPromotion).HasMaxLength(50);

                entity.Property(e => e.YearsWithCurrManager).HasMaxLength(50);
            });

            modelBuilder.Entity<Table1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Table_1");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}