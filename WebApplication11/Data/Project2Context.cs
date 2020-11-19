using System;
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
        public virtual DbSet<Cost> Cost { get; set; }
        public virtual DbSet<Dataset> Dataset { get; set; }
        public virtual DbSet<EducationField> EducationField { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetail { get; set; }
        public virtual DbSet<EmployeeEducationInfo> EmployeeEducationInfo { get; set; }
        public virtual DbSet<EmployeeHistory> EmployeeHistory { get; set; }
        public virtual DbSet<JobInfo> JobInfo { get; set; }
        public virtual DbSet<JobRole> JobRole { get; set; }
        public virtual DbSet<LookupEducation> LookupEducation { get; set; }
        public virtual DbSet<LookupJob> LookupJob { get; set; }
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

            modelBuilder.Entity<Cost>(entity =>
            {
                entity.Property(e => e.CostId).HasColumnName("CostID");

                entity.HasOne(d => d.EmployeeNumberNavigation)
                    .WithMany(p => p.Cost)
                    .HasForeignKey(d => d.EmployeeNumber)
                    .HasConstraintName("FK__Cost__EmployeeNu__5FB337D6");
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

            modelBuilder.Entity<EducationField>(entity =>
            {
                entity.HasKey(e => e.EducationCode)
                    .HasName("PK__Educatio__E2D8B715A40E657B");

                entity.Property(e => e.EducationDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber)
                    .HasName("PK__Employee__8D663599E9302488");

                entity.Property(e => e.EmployeeNumber).ValueGeneratedNever();

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeEducationInfo>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeNumber, e.EducationCode })
                    .HasName("PK_Education");

                entity.HasOne(d => d.EducationCodeNavigation)
                    .WithMany(p => p.EmployeeEducationInfo)
                    .HasForeignKey(d => d.EducationCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Educa__6B24EA82");

                entity.HasOne(d => d.EmployeeNumberNavigation)
                    .WithMany(p => p.EmployeeEducationInfo)
                    .HasForeignKey(d => d.EmployeeNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeE__Emplo__6A30C649");
            });

            modelBuilder.Entity<EmployeeHistory>(entity =>
            {
                entity.Property(e => e.Attrition).HasMaxLength(50);

                entity.Property(e => e.BusinessTravel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Over18)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OverTime).HasMaxLength(50);

                entity.HasOne(d => d.EmployeeNumberNavigation)
                    .WithMany(p => p.EmployeeHistory)
                    .HasForeignKey(d => d.EmployeeNumber)
                    .HasConstraintName("FK__EmployeeH__Emplo__6E01572D");
            });

            modelBuilder.Entity<JobInfo>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeNumber, e.JobRoleCode })
                    .HasName("PK_Job");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.EmployeeNumberNavigation)
                    .WithMany(p => p.JobInfo)
                    .HasForeignKey(d => d.EmployeeNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobInfo__Employe__6477ECF3");

                entity.HasOne(d => d.JobRoleCodeNavigation)
                    .WithMany(p => p.JobInfo)
                    .HasForeignKey(d => d.JobRoleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobInfo__JobRole__656C112C");
            });

            modelBuilder.Entity<JobRole>(entity =>
            {
                entity.HasKey(e => e.JobRoleCode)
                    .HasName("PK__JobRole__D9D29CA192BA34BF");

                entity.Property(e => e.Job)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LookupEducation>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.EmployeeNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LookupJob>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.EmployeeNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobInvolvement).HasMaxLength(50);

                entity.Property(e => e.JobLevel).HasMaxLength(50);

                entity.Property(e => e.JobSatisfaction).HasMaxLength(50);
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
