using Domain.Models;
using Domain.Models.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public partial class ApplicationContext : IdentityDbContext<ApplicationUser, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {

        public ApplicationContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }


        public virtual DbSet<Domain.Models.Common.ApplicationException> ApplicationExceptions { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<ComplaintNature> ComplaintNatures { get; set; }
        public virtual DbSet<LookUpsDetail> LookUpsDetails { get; set; }
        public virtual DbSet<LookUpsMaster> LookUpsMasters { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Domain.Models.Common.ApplicationException>(entity =>
            {
                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.LoggedInUser).HasMaxLength(50);
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("ApplicationUser");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.ToTable("Complaint");

                entity.Property(e => e.ComplainerEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ComplainerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ComplaintDate).HasColumnType("datetime");

                entity.Property(e => e.ComplaintDetails).IsRequired();

                entity.Property(e => e.ComplaintLocation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DesiredOutcome).IsRequired();

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<ComplaintNature>(entity =>
            {
                entity.ToTable("ComplaintNature");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.HasOne(d => d.Complaint)
                    .WithMany(p => p.ComplaintNatures)
                    .HasForeignKey(d => d.ComplaintId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComplaintNature_Complaint");
            });

            modelBuilder.Entity<LookUpsDetail>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MasterCodeNavigation)
                    .WithMany(p => p.LookUpsDetails)
                    .HasPrincipalKey(p => p.Code)
                    .HasForeignKey(d => d.MasterCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LookUpsDetails_LookUpsMaster");
            });

            modelBuilder.Entity<LookUpsMaster>(entity =>
            {
                entity.ToTable("LookUpsMaster");

                entity.HasIndex(e => e.Code, "UniqueCode_LookUpsMaster")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<RoleClaim>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}