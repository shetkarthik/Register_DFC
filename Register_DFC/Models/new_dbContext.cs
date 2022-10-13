using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Register_DFC.Models
{
    public partial class new_dbContext : DbContext
    {
        public new_dbContext()
        {
        }

        public new_dbContext(DbContextOptions<new_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Registration> Registrations { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=ELW5133\\SQLEXPRESS;Database=new_db;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Pname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pname");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("registration");

                //entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Useremail)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("useremail");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("Worker");

                entity.Property(e => e.WorkerId)
                    .ValueGeneratedNever()
                    .HasColumnName("WORKER_ID");

                entity.Property(e => e.Department)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT")
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME")
                    .IsFixedLength();

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("JOINING_DATE");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME")
                    .IsFixedLength();

                entity.Property(e => e.Salary).HasColumnName("SALARY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
