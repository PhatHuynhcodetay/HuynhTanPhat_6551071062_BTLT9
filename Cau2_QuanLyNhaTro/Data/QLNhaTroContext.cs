using Microsoft.EntityFrameworkCore;
using Cau2_QuanLyNhaTro.Config;
using Cau2_QuanLyNhaTro.Models;

namespace Cau2_QuanLyNhaTro.Data
{
    public class QLNhaTroContext : DbContext
    {
        public DbSet<PhongTro> PhongTros => Set<PhongTro>();
        public DbSet<KhachThue> KhachThues => Set<KhachThue>();

        public QLNhaTroContext()
        {
        }

        public QLNhaTroContext(DbContextOptions<QLNhaTroContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connStr = AppConfig.Instance.ConnectionStrings.DefaultConnection;
                optionsBuilder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhongTro>(entity =>
            {
                entity.ToTable("PhongTro");
                entity.HasKey(e => e.MaPhong);
                entity.Property(e => e.TenPhong).HasMaxLength(20);
                entity.Property(e => e.GiaThue).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.TinhTrang).HasMaxLength(20).HasDefaultValue("Trống");
            });

            modelBuilder.Entity<KhachThue>(entity =>
            {
                entity.ToTable("KhachThue");
                entity.HasKey(e => e.MaKhach);
                entity.Property(e => e.HoTen).HasMaxLength(100);
                entity.Property(e => e.GioiTinh).HasMaxLength(5);
                entity.Property(e => e.NgaySinh).HasColumnType("date");
                entity.Property(e => e.SoDienThoai).HasMaxLength(15);
                entity.Property(e => e.TenTinh).HasMaxLength(100);
                entity.Property(e => e.TenPhuongXa).HasMaxLength(100);

                entity.HasOne(e => e.PhongTro)
                      .WithMany(p => p.KhachThues)
                      .HasForeignKey(e => e.MaPhong)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
