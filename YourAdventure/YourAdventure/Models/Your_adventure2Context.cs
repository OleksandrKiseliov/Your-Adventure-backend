using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YourAdventure.Models
{
    public partial class Your_adventure2Context : DbContext
    {
        public Your_adventure2Context()
        {
        }

        public Your_adventure2Context(DbContextOptions<Your_adventure2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; } = null!;
        public virtual DbSet<AchievementStatus> AchievementStatuses { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<InterfaceLanguage> InterfaceLanguages { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
        public virtual DbSet<VisitedCountry> VisitedCountries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=Your_adventure-2; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.ToTable("Achievement");

                entity.Property(e => e.AchievementId).ValueGeneratedNever();

                entity.Property(e => e.AchievementName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonFid).HasColumnName("PersonFId");

                entity.Property(e => e.StatusFid).HasColumnName("StatusFId");

                entity.HasOne(d => d.PersonF)
                    .WithMany(p => p.Achievements)
                    .HasForeignKey(d => d.PersonFid)
                    .HasConstraintName("FK__Achieveme__Perso__3F466844");

                entity.HasOne(d => d.StatusF)
                    .WithMany(p => p.Achievements)
                    .HasForeignKey(d => d.StatusFid)
                    .HasConstraintName("FK__Achieveme__Statu__3E52440B");
            });

            modelBuilder.Entity<AchievementStatus>(entity =>
            {
                entity.ToTable("AchievementStatus");

                entity.Property(e => e.AchievementStatusId).ValueGeneratedNever();

                entity.Property(e => e.AchievementStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.ColorId).ValueGeneratedNever();

                entity.Property(e => e.ColorName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InterfaceLanguage>(entity =>
            {
                entity.ToTable("InterfaceLanguage");

                entity.Property(e => e.InterfaceLanguageId).ValueGeneratedNever();

                entity.Property(e => e.InterfaceLanguage1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("InterfaceLanguage");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.Property(e => e.Bday).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Profilepicture).HasColumnType("image");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo");

                entity.Property(e => e.PhotoId).ValueGeneratedNever();

                entity.Property(e => e.CountryFid).HasColumnName("CountryFID");

                entity.Property(e => e.Photo1)
                    .HasColumnType("image")
                    .HasColumnName("Photo");

                entity.HasOne(d => d.CountryF)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.CountryFid)
                    .HasConstraintName("FK__Photo__CountryFI__5070F446");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.SettingsId)
                    .HasName("PK__Settings__991B19FCBC2CD438");

                entity.Property(e => e.SettingsId).ValueGeneratedNever();

                entity.Property(e => e.ColorFid).HasColumnName("ColorFId");

                entity.Property(e => e.InterfaceLanguageFid).HasColumnName("InterfaceLanguageFID");

                entity.Property(e => e.PersonFid).HasColumnName("PersonFId");

                entity.HasOne(d => d.ColorF)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.ColorFid)
                    .HasConstraintName("FK__Settings__ColorF__46E78A0C");

                entity.HasOne(d => d.InterfaceLanguageF)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.InterfaceLanguageFid)
                    .HasConstraintName("FK__Settings__Interf__45F365D3");

                entity.HasOne(d => d.PersonF)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.PersonFid)
                    .HasConstraintName("FK__Settings__Person__47DBAE45");
            });

            modelBuilder.Entity<VisitedCountry>(entity =>
            {
                entity.HasKey(e => e.VisitedCountries)
                    .HasName("PK__VisitedC__9B4508BD3B80C7C9");

                entity.Property(e => e.VisitedCountries).ValueGeneratedNever();

                entity.Property(e => e.CountryFid).HasColumnName("CountryFID");

                entity.Property(e => e.PersonFid).HasColumnName("PersonFID");

                entity.HasOne(d => d.CountryF)
                    .WithMany(p => p.VisitedCountries)
                    .HasForeignKey(d => d.CountryFid)
                    .HasConstraintName("FK__VisitedCo__Count__4D94879B");

                entity.HasOne(d => d.PersonF)
                    .WithMany(p => p.VisitedCountries)
                    .HasForeignKey(d => d.PersonFid)
                    .HasConstraintName("FK__VisitedCo__Perso__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
