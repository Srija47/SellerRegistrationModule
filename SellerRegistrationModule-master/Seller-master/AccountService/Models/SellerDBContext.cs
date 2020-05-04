using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccountService.Models
{
    public partial class SellerDBContext : DbContext
    {
        public SellerDBContext()
        {
        }

        public SellerDBContext(DbContextOptions<SellerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=WIN8\\SQLEXPRESS;Initial Catalog=SellerDB;Persist Security Info=True;User ID=sa;Password=pass@word1");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.Itemid)
                    .HasName("PK__items__56A22C929398A3B7");

                entity.ToTable("items");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Itemname)
                    .HasColumnName("itemname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Stocknumber).HasColumnName("stocknumber");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Sellerid)
                    .HasConstraintName("FK__items__Sellerid__1273C1CD");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("seller");

                entity.Property(e => e.Sellerid).HasColumnName("sellerid");

                entity.Property(e => e.Briefaboutcompany)
                    .HasColumnName("briefaboutcompany")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Companyname)
                    .HasColumnName("companyname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contactnumber)
                    .HasColumnName("contactnumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Emailid)
                    .HasColumnName("emailid")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Postaladdress)
                    .HasColumnName("postaladdress")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
