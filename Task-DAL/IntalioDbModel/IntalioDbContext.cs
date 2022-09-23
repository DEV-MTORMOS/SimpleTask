using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

#nullable disable

namespace Task_DAL.IntalioDbModel
{
    public partial class IntalioDbContext : DbContext
    {
        public IntalioDbContext()
        {
        }

        public IntalioDbContext(DbContextOptions<IntalioDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmployee> TblEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(@"Server=localhost; initial catalog=IntalioDB;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EId);

                entity.ToTable("tblEmployee");

                entity.Property(e => e.EId).HasColumnName("E_Id");

                entity.Property(e => e.EName)
                    .HasMaxLength(100)
                    .HasColumnName("E_Name");

                entity.Property(e => e.EPosition)
                    .HasMaxLength(100)
                    .HasColumnName("E_Position");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
