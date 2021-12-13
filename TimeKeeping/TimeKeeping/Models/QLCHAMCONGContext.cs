using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class QLChamCongContext : DbContext
    {
        public QLChamCongContext()
        {
        }

        public QLChamCongContext(DbContextOptions<QLChamCongContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApDungThamNien> ApDungThamNiens { get; set; }
        public virtual DbSet<CaLamViec> CaLamViecs { get; set; }
        public virtual DbSet<CaNghiPhep> CaNghiPheps { get; set; }
        public virtual DbSet<ChinhSachCheckin> ChinhSachCheckins { get; set; }
        public virtual DbSet<ChinhSachLuong> ChinhSachLuongs { get; set; }
        public virtual DbSet<ChinhSachNghiPhep> ChinhSachNghiPheps { get; set; }
        public virtual DbSet<ChinhSachTheoThamNien> ChinhSachTheoThamNiens { get; set; }
        public virtual DbSet<KhuVucApDungMauNghiPhep> KhuVucApDungMauNghiPheps { get; set; }
        public virtual DbSet<KhuVucNghiepVu> KhuVucNghiepVus { get; set; }
        public virtual DbSet<LichLamViec> LichLamViecs { get; set; }
        public virtual DbSet<LoaiCaLamViec> LoaiCaLamViecs { get; set; }
        public virtual DbSet<LoaiChinhSach> LoaiChinhSaches { get; set; }
        public virtual DbSet<LoaiHinhNhanSu> LoaiHinhNhanSus { get; set; }
        public virtual DbSet<LoaiLichLamViec> LoaiLichLamViecs { get; set; }
        public virtual DbSet<LoaiNghiPhep> LoaiNghiPheps { get; set; }
        public virtual DbSet<LoaiViTri> LoaiViTris { get; set; }
        public virtual DbSet<MauNghiPhep> MauNghiPheps { get; set; }
        public virtual DbSet<NgayNghiPhep> NgayNghiPheps { get; set; }
        public virtual DbSet<NgayTrongTuan> NgayTrongTuans { get; set; }
        public virtual DbSet<NguoiPheDuyetNghiPhep> NguoiPheDuyetNghiPheps { get; set; }
        public virtual DbSet<NguoiTheoDoiNghiPhep> NguoiTheoDoiNghiPheps { get; set; }
        public virtual DbSet<NhanSu> NhanSus { get; set; }
        public virtual DbSet<NhanSuChinhSachNghiPhep> NhanSuChinhSachNghiPheps { get; set; }
        public virtual DbSet<QuyTrinhPheDuyet> QuyTrinhPheDuyets { get; set; }
        public virtual DbSet<SoCaLamViec> SoCaLamViecs { get; set; }
        public virtual DbSet<VanPhong> VanPhongs { get; set; }
        public virtual DbSet<ViTri> ViTris { get; set; }
        public virtual DbSet<YeuCauNghiPhep> YeuCauNghiPheps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ST7\\SQLEXPRESS;Database=QLChamCong;Trusted_Connection=True;");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApDungThamNien>(entity =>
            {
                entity.HasKey(e => new { e.MaChinhSachNghiPhep, e.MaThamNien });

                entity.ToTable("ApDungThamNien");

                entity.Property(e => e.MaChinhSachNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaThamNien)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaChinhSachNghiPhepNavigation)
                    .WithMany(p => p.ApDungThamNiens)
                    .HasForeignKey(d => d.MaChinhSachNghiPhep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_ApDungThamNien_ChinhSachNghiPhep");

                entity.HasOne(d => d.MaThamNienNavigation)
                    .WithMany(p => p.ApDungThamNiens)
                    .HasForeignKey(d => d.MaThamNien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_ApDungThamNien_ThamNien");
            });

            modelBuilder.Entity<CaLamViec>(entity =>
            {
                entity.HasKey(e => e.MaCaLamViec);

                entity.ToTable("CaLamViec");

                entity.Property(e => e.MaCaLamViec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLichLamViec)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLoaiCaLamViec)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaNgayTrongTuan)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayNghi)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TenCaLamViec)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ThoiGianBatDau).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianKetThuc).HasColumnType("datetime");

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaLichLamViecNavigation)
                    .WithMany(p => p.CaLamViecs)
                    .HasForeignKey(d => d.MaLichLamViec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_CaLamViec_LichLamViec");

                entity.HasOne(d => d.MaLoaiCaLamViecNavigation)
                    .WithMany(p => p.CaLamViecs)
                    .HasForeignKey(d => d.MaLoaiCaLamViec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_CaLamViec_LoaiCaLamViec");

                entity.HasOne(d => d.MaNgayTrongTuanNavigation)
                    .WithMany(p => p.CaLamViecs)
                    .HasForeignKey(d => d.MaNgayTrongTuan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_CaLamViec_NgayTrongTuan");
            });

            modelBuilder.Entity<CaNghiPhep>(entity =>
            {
                entity.HasKey(e => new { e.MaNgayNghiPhep, e.MaYeuCauNghiPhep, e.MaCaLamViec });

                entity.ToTable("CaNghiPhep");

                entity.Property(e => e.MaNgayNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaYeuCauNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaCaLamViec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaCaLamViecNavigation)
                    .WithMany(p => p.CaNghiPheps)
                    .HasForeignKey(d => d.MaCaLamViec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_CaNghiPhep_CaLamViec");

                entity.HasOne(d => d.MaNgayNghiPhepNavigation)
                    .WithMany(p => p.CaNghiPheps)
                    .HasForeignKey(d => d.MaNgayNghiPhep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_CaNghiPhep_NgayNghiPhep");

                entity.HasOne(d => d.MaYeuCauNghiPhepNavigation)
                    .WithMany(p => p.CaNghiPheps)
                    .HasForeignKey(d => d.MaYeuCauNghiPhep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_CaNghiPhep_YeuCauNghiPhep");
            });

            modelBuilder.Entity<ChinhSachCheckin>(entity =>
            {
                entity.HasKey(e => e.MaChinhSachCheckin);

                entity.ToTable("ChinhSachCheckin");

                entity.Property(e => e.MaChinhSachCheckin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenChinhSachCheckin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ChinhSachLuong>(entity =>
            {
                entity.HasKey(e => e.MaChinhSachLuong);

                entity.ToTable("ChinhSachLuong");

                entity.Property(e => e.MaChinhSachLuong)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenChinhSachLuong)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ChinhSachNghiPhep>(entity =>
            {
                entity.HasKey(e => e.MaChinhSachNghiPhep);

                entity.ToTable("ChinhSachNghiPhep");

                entity.Property(e => e.MaChinhSachNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLoaiChinhSach)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenChinhSach)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaLoaiChinhSachNavigation)
                    .WithMany(p => p.ChinhSachNghiPheps)
                    .HasForeignKey(d => d.MaLoaiChinhSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_ChinhSachNghiPhep_LoaiChinhSach");
            });

            modelBuilder.Entity<ChinhSachTheoThamNien>(entity =>
            {
                entity.HasKey(e => e.MaThamNien);

                entity.ToTable("ChinhSachTheoThamNien");

                entity.Property(e => e.MaThamNien)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<KhuVucApDungMauNghiPhep>(entity =>
            {
                entity.HasKey(e => new { e.MaKhuVuc, e.MaMauNghiPhep });

                entity.ToTable("KhuVucApDungMauNghiPhep");

                entity.Property(e => e.MaKhuVuc)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaMauNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaKhuVucNavigation)
                    .WithMany(p => p.KhuVucApDungMauNghiPheps)
                    .HasForeignKey(d => d.MaKhuVuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_KhuVucApDungMauNghiPhep_KhuVucNghiepVu");

                entity.HasOne(d => d.MaMauNghiPhepNavigation)
                    .WithMany(p => p.KhuVucApDungMauNghiPheps)
                    .HasForeignKey(d => d.MaMauNghiPhep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_KhuVucApDungMauNghiPhep_MauNghiPhep");
            });

            modelBuilder.Entity<KhuVucNghiepVu>(entity =>
            {
                entity.HasKey(e => e.MaKhuVuc);

                entity.ToTable("KhuVucNghiepVu");

                entity.Property(e => e.MaKhuVuc)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenKhuVuc)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LichLamViec>(entity =>
            {
                entity.HasKey(e => e.MaLichLamViec);

                entity.ToTable("LichLamViec");

                entity.Property(e => e.MaLichLamViec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaChinhSachCheckin)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLoaiLichLamViec)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaSoCaLamViec)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.QuyDinh).HasMaxLength(100);

                entity.Property(e => e.SoGioLamViecMoiNgay).HasDefaultValueSql("((8))");

                entity.Property(e => e.SoPhutDuocTre).HasDefaultValueSql("((15))");

                entity.Property(e => e.SoPhutVeSom).HasDefaultValueSql("((15))");

                entity.Property(e => e.TenLichLamViec)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.Property(e => e.YeuCauCheckout)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaChinhSachCheckinNavigation)
                    .WithMany(p => p.LichLamViecs)
                    .HasForeignKey(d => d.MaChinhSachCheckin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_LichLamViec_ChinhSachCheckin");

                entity.HasOne(d => d.MaLoaiLichLamViecNavigation)
                    .WithMany(p => p.LichLamViecs)
                    .HasForeignKey(d => d.MaLoaiLichLamViec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_LichLamViec_LoaiLichLamViec");

                entity.HasOne(d => d.MaSoCaLamViecNavigation)
                    .WithMany(p => p.LichLamViecs)
                    .HasForeignKey(d => d.MaSoCaLamViec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_LichLamViec_SoCaLamViec");
            });

            modelBuilder.Entity<LoaiCaLamViec>(entity =>
            {
                entity.HasKey(e => e.MaLoaiCaLamViec);

                entity.ToTable("LoaiCaLamViec");

                entity.Property(e => e.MaLoaiCaLamViec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLoaiCaLamViec)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LoaiChinhSach>(entity =>
            {
                entity.HasKey(e => e.MaLoaiChinhSach);

                entity.ToTable("LoaiChinhSach");

                entity.Property(e => e.MaLoaiChinhSach)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLoaiChinhSach)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LoaiHinhNhanSu>(entity =>
            {
                entity.HasKey(e => e.MaLoaiHinhNhanSu);

                entity.ToTable("LoaiHinhNhanSu");

                entity.Property(e => e.MaLoaiHinhNhanSu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenLoaiHinhNhanSu)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LoaiLichLamViec>(entity =>
            {
                entity.HasKey(e => e.MaLoaiLichLamViec);

                entity.ToTable("LoaiLichLamViec");

                entity.Property(e => e.MaLoaiLichLamViec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLoaiLichLamViec)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LoaiNghiPhep>(entity =>
            {
                entity.HasKey(e => e.MaLoaiNghiPhep);

                entity.ToTable("LoaiNghiPhep");

                entity.Property(e => e.MaLoaiNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLoaiNghiPhep)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LoaiViTri>(entity =>
            {
                entity.HasKey(e => e.MaLoaiViTri);

                entity.ToTable("LoaiViTri");

                entity.Property(e => e.MaLoaiViTri)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenLoaiViTri)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<MauNghiPhep>(entity =>
            {
                entity.HasKey(e => e.MaMauNghiPhep);

                entity.ToTable("MauNghiPhep");

                entity.Property(e => e.MaMauNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GioiHanNgayNghi)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GioiHanSoNgayNghi).HasDefaultValueSql("((5))");

                entity.Property(e => e.MaLoaiNghiPhep)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaQuyTrinhPheDuyet)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.QuiDinh).HasMaxLength(100);

                entity.Property(e => e.SoNgayTruocNgayNghi).HasDefaultValueSql("((2))");

                entity.Property(e => e.TenMauNghiPhep)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ThoiHanXuLy).HasDefaultValueSql("((24))");

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.Property(e => e.YeuCauPheDuyet)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaLoaiNghiPhepNavigation)
                    .WithMany(p => p.MauNghiPheps)
                    .HasForeignKey(d => d.MaLoaiNghiPhep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_MauNghiPhep_LoaiNghiPhep");

                entity.HasOne(d => d.MaQuyTrinhPheDuyetNavigation)
                    .WithMany(p => p.MauNghiPheps)
                    .HasForeignKey(d => d.MaQuyTrinhPheDuyet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_MauNghiPhep_QuyTrinhPheDuyet");
            });

            modelBuilder.Entity<NgayNghiPhep>(entity =>
            {
                entity.HasKey(e => e.MaNgayNghiPhep);

                entity.ToTable("NgayNghiPhep");

                entity.Property(e => e.MaNgayNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaYeuCauNghiPhep)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayNghi).HasColumnType("datetime");

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaYeuCauNghiPhepNavigation)
                    .WithMany(p => p.NgayNghiPheps)
                    .HasForeignKey(d => d.MaYeuCauNghiPhep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NgayNghiPhep_YeuCauNghiPhep");
            });

            modelBuilder.Entity<NgayTrongTuan>(entity =>
            {
                entity.HasKey(e => e.MaNgayTrongTuan);

                entity.ToTable("NgayTrongTuan");

                entity.Property(e => e.MaNgayTrongTuan)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenNgayTrongTuan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<NguoiPheDuyetNghiPhep>(entity =>
            {
                entity.HasKey(e => new { e.MaNhanSu, e.MaMauNghiPhep });

                entity.ToTable("NguoiPheDuyetNghiPhep");

                entity.Property(e => e.MaNhanSu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaMauNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaMauNghiPhepNavigation)
                    .WithMany(p => p.NguoiPheDuyetNghiPheps)
                    .HasForeignKey(d => d.MaMauNghiPhep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NguoiPheDuyetNghiPhep_MauNghiPhep");

                entity.HasOne(d => d.MaNhanSuNavigation)
                    .WithMany(p => p.NguoiPheDuyetNghiPheps)
                    .HasForeignKey(d => d.MaNhanSu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NguoiPheDuyetNghiPhep_NhanSu");
            });

            modelBuilder.Entity<NguoiTheoDoiNghiPhep>(entity =>
            {
                entity.HasKey(e => new { e.MaNhanSu, e.MaMauNghiPhep });

                entity.ToTable("NguoiTheoDoiNghiPhep");

                entity.Property(e => e.MaNhanSu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaMauNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaMauNghiPhepNavigation)
                    .WithMany(p => p.NguoiTheoDoiNghiPheps)
                    .HasForeignKey(d => d.MaMauNghiPhep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NguoiTheoDoiNghiPhep_MauNghiPhep");

                entity.HasOne(d => d.MaNhanSuNavigation)
                    .WithMany(p => p.NguoiTheoDoiNghiPheps)
                    .HasForeignKey(d => d.MaNhanSu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NguoiTheoDoiNghiPhep_NhanSu");
            });

            modelBuilder.Entity<NhanSu>(entity =>
            {
                entity.HasKey(e => e.MaNhanSu);

                entity.ToTable("NhanSu");

                entity.Property(e => e.MaNhanSu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ChucDanh).HasMaxLength(100);

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HoVaTenDem)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LuongCoBan).HasColumnType("money");

                entity.Property(e => e.LuongThucNhan).HasColumnType("money");

                entity.Property(e => e.MaChinhSachLuong)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaKhuVuc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLichLamViec)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLoaiHinhNhanSu)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaViTri)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaVp)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaVP");

                entity.Property(e => e.NgayChinhThuc).HasColumnType("datetime");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.NgayVaoLam).HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaChinhSachLuongNavigation)
                    .WithMany(p => p.NhanSus)
                    .HasForeignKey(d => d.MaChinhSachLuong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NhanSu_ChinhSachLuong");

                entity.HasOne(d => d.MaKhuVucNavigation)
                    .WithMany(p => p.NhanSus)
                    .HasForeignKey(d => d.MaKhuVuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NhanSu_KhuVucNghiepVu");

                entity.HasOne(d => d.MaLichLamViecNavigation)
                    .WithMany(p => p.NhanSus)
                    .HasForeignKey(d => d.MaLichLamViec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NhanSu_LichLamViec");

                entity.HasOne(d => d.MaLoaiHinhNhanSuNavigation)
                    .WithMany(p => p.NhanSus)
                    .HasForeignKey(d => d.MaLoaiHinhNhanSu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NhanSu_LoaiHinhNhanSu");

                entity.HasOne(d => d.MaViTriNavigation)
                    .WithMany(p => p.NhanSus)
                    .HasForeignKey(d => d.MaViTri)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NhanSu_ViTri");

                entity.HasOne(d => d.MaVpNavigation)
                    .WithMany(p => p.NhanSus)
                    .HasForeignKey(d => d.MaVp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NhanSu_VanPhong");
            });

            modelBuilder.Entity<NhanSuChinhSachNghiPhep>(entity =>
            {
                entity.HasKey(e => new { e.MaNhanSu, e.MaChinhSachNghiPhep });

                entity.ToTable("NhanSuChinhSachNghiPhep");

                entity.Property(e => e.MaNhanSu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaChinhSachNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.NgayCoHieuLuc).HasColumnType("datetime");

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaChinhSachNghiPhepNavigation)
                    .WithMany(p => p.NhanSuChinhSachNghiPheps)
                    .HasForeignKey(d => d.MaChinhSachNghiPhep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NhanSuChinhSachNghiPhep_ChinhSachNghiPhep");

                entity.HasOne(d => d.MaNhanSuNavigation)
                    .WithMany(p => p.NhanSuChinhSachNghiPheps)
                    .HasForeignKey(d => d.MaNhanSu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_NhanSuChinhSachNghiPhep_NhanSu");
            });

            modelBuilder.Entity<QuyTrinhPheDuyet>(entity =>
            {
                entity.HasKey(e => e.MaQuyTrinhPheDuyet);

                entity.ToTable("QuyTrinhPheDuyet");

                entity.Property(e => e.MaQuyTrinhPheDuyet)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenQuyTrinhPheDuyet)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SoCaLamViec>(entity =>
            {
                entity.HasKey(e => e.MaSoCaLamViec);

                entity.ToTable("SoCaLamViec");

                entity.Property(e => e.MaSoCaLamViec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SoCaLamViec1).HasColumnName("SoCaLamViec");

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<VanPhong>(entity =>
            {
                entity.HasKey(e => e.MaVp);

                entity.ToTable("VanPhong");

                entity.Property(e => e.MaVp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaVP");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenVp)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenVP");

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ViTri>(entity =>
            {
                entity.HasKey(e => e.MaViTri);

                entity.ToTable("ViTri");

                entity.Property(e => e.MaViTri)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaKhuVuc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLoaiViTri)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MucLuongCaoNhat).HasColumnType("money");

                entity.Property(e => e.MucLuongThapNhat).HasColumnType("money");

                entity.Property(e => e.TenViTri)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaKhuVucNavigation)
                    .WithMany(p => p.ViTris)
                    .HasForeignKey(d => d.MaKhuVuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_ViTri_KhuVucNghiepVu");

                entity.HasOne(d => d.MaLoaiViTriNavigation)
                    .WithMany(p => p.ViTris)
                    .HasForeignKey(d => d.MaLoaiViTri)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_ViTri_LoaiViTri");
            });

            modelBuilder.Entity<YeuCauNghiPhep>(entity =>
            {
                entity.HasKey(e => e.MaYeuCauNghiPhep);

                entity.ToTable("YeuCauNghiPhep");

                entity.Property(e => e.MaYeuCauNghiPhep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CacCongViecBanGiao).HasMaxLength(200);

                entity.Property(e => e.LyDoNghiPhep)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MaMauNghiPhep)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaNguoiQuanLy)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaNhanSu)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.PhanHoi).HasMaxLength(100);

                entity.Property(e => e.TaiLieuDinhKem).HasMaxLength(100);

                entity.Property(e => e.TieuDe)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Xoa).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaMauNghiPhepNavigation)
                    .WithMany(p => p.YeuCauNghiPheps)
                    .HasForeignKey(d => d.MaMauNghiPhep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_YeuCauNghiPhep_MauNghiPhep");

                entity.HasOne(d => d.MaNguoiQuanLyNavigation)
                    .WithMany(p => p.YeuCauNghiPhepMaNguoiQuanLyNavigations)
                    .HasForeignKey(d => d.MaNguoiQuanLy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_YeuCauNghiPhep_NguoiQuanLy");

                entity.HasOne(d => d.MaNhanSuNavigation)
                    .WithMany(p => p.YeuCauNghiPhepMaNhanSuNavigations)
                    .HasForeignKey(d => d.MaNhanSu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_YeuCauNghiPhep_NhanSu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
