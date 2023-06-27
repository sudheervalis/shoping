using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAxisLayer.Models
{
    public partial class RaoneContext : DbContext
    {
        public RaoneContext()
        {
        }

        public RaoneContext(DbContextOptions<RaoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmpTable> EmpTables { get; set; } = null!;
        public virtual DbSet<JwtSetting> JwtSettings { get; set; } = null!;
        public virtual DbSet<MrefreshToken> MrefreshTokens { get; set; } = null!;
        public virtual DbSet<Mtask> Mtasks { get; set; } = null!;
        public virtual DbSet<Muser> Musers { get; set; } = null!;
        public virtual DbSet<SudentTable> SudentTables { get; set; } = null!;
        public virtual DbSet<UserDatum> UserData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8RH3PUM;Database=Raone;Integrated Security=True;trustservercertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpTable>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("EmpTable");

                entity.Property(e => e.EmpBranch)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JwtSetting>(entity =>
            {
                entity.Property(e => e.IssuerSigningKey).IsUnicode(false);

                entity.Property(e => e.RequireExpirationTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ValidAudience).IsUnicode(false);

                entity.Property(e => e.ValidIssuer).IsUnicode(false);

                entity.Property(e => e.ValidateAudience)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ValidateIssuer)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ValidateIssuerSigningKey)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ValidateLifetime).HasMaxLength(10);
            });

            modelBuilder.Entity<MrefreshToken>(entity =>
            {
                entity.ToTable("MRefreshToken");

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TokenHash).HasMaxLength(1000);

                entity.Property(e => e.TokenSalt).HasMaxLength(50);

                entity.Property(e => e.Ts)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("TS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MrefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MRefreshToken_MUser");
            });

            modelBuilder.Entity<Mtask>(entity =>
            {
                entity.ToTable("MTask");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Ts)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("TS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Mtasks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MTask_MUser");
            });

            modelBuilder.Entity<Muser>(entity =>
            {
                entity.ToTable("MUser");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PasswordSalt).HasMaxLength(255);

                entity.Property(e => e.Ts)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("TS");
            });

            modelBuilder.Entity<SudentTable>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("SudentTable");

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDatum>(entity =>
            {
                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiredTime).HasColumnType("datetime");

                entity.Property(e => e.GuidId).IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RefreshToken).IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserRole)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Validaty).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
