﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace entity_framework_in_class
{
    public partial class MemberdbContext : DbContext
    {
        public MemberdbContext()
        {
        }

        public MemberdbContext(DbContextOptions<MemberdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Member> Member { get; set; } = null!;
        public virtual DbSet<Membership> Membership { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=RASMUS-BÆRBAR;Initial Catalog=MemberDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.MemberId).HasColumnName("memberID");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.MemberAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("member_address");

                entity.Property(e => e.MemberName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("member_name");

                entity.Property(e => e.MembershipType).HasColumnName("membership_type");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("zip");

                entity.HasOne(d => d.MembershipTypeNavigation)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.MembershipType)
                    .HasConstraintName("FK__Member__membersh__267ABA7A");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasKey(e => e.MembershipType)
                    .HasName("PK__Membersh__BC1B39D302FBE630");

                entity.Property(e => e.MembershipType)
                    .ValueGeneratedNever()
                    .HasColumnName("membership_type");

                entity.Property(e => e.MembershipName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("membership_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}