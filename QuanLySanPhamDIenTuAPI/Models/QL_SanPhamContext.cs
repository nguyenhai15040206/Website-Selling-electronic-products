using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuanLySanPhamDIenTuAPI.Models
{
    public partial class QL_SanPhamContext : DbContext
    {
        public QL_SanPhamContext()
        {
        }

        public QL_SanPhamContext(DbContextOptions<QL_SanPhamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<CthoaDon> CthoaDon { get; set; }
        public virtual DbSet<CtphieuNhap> CtphieuNhap { get; set; }
        public virtual DbSet<CungUng> CungUng { get; set; }
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<DanhMucManHinh> DanhMucManHinh { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiTinTuc> LoaiTinTuc { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuat { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhap { get; set; }
        public virtual DbSet<QlNguoiDungNhomNguoiDung> QlNguoiDungNhomNguoiDung { get; set; }
        public virtual DbSet<QlNhomNguoiDung> QlNhomNguoiDung { get; set; }
        public virtual DbSet<QlPhanQuyen> QlPhanQuyen { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<TinTuc> TinTuc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ADMIN\\SQLEXPRESS;Database=QL_SanPham;User ID=sa;Password=tanhai123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasKey(e => e.MaBanner)
                    .HasName("PK__Banner__B4D053AA956C9958");

                entity.Property(e => e.MaBanner).HasColumnName("maBanner");

                entity.Property(e => e.FileBanner)
                    .HasColumnName("fileBanner")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(500);

                entity.Property(e => e.KichHoat).HasColumnName("kichHoat");
            });

            modelBuilder.Entity<CthoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDon, e.MaSanPham })
                    .HasName("PK__CTHoaDon__27DF745EE60CA1E3");

                entity.ToTable("CTHoaDon");

                entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");

                entity.Property(e => e.MaSanPham).HasColumnName("maSanPham");

                entity.Property(e => e.DonGia)
                    .HasColumnName("donGia")
                    .HasColumnType("money");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(500);

                entity.Property(e => e.GiamGia).HasColumnName("giamGia");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.ThanhTien)
                    .HasColumnName("thanhTien")
                    .HasColumnType("money");

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.CthoaDon)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CTHoaDon_HoaDon");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.CthoaDon)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CTHoaDon_SanPham");
            });

            modelBuilder.Entity<CtphieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaPhieuNhap)
                    .HasName("PK__CTPhieuN__E27639341B236B94");

                entity.ToTable("CTPhieuNhap");

                entity.Property(e => e.MaPhieuNhap)
                    .HasColumnName("maPhieuNhap")
                    .ValueGeneratedNever();

                entity.Property(e => e.GiaNhap)
                    .HasColumnName("giaNhap")
                    .HasColumnType("money");

                entity.Property(e => e.MaSanPham).HasColumnName("maSanPham");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.HasOne(d => d.MaPhieuNhapNavigation)
                    .WithOne(p => p.CtphieuNhap)
                    .HasForeignKey<CtphieuNhap>(d => d.MaPhieuNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CTPhieuNhap_PhieuNhap");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.CtphieuNhap)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("fk_CTPhieuNhap_SanPham");
            });

            modelBuilder.Entity<CungUng>(entity =>
            {
                entity.HasKey(e => new { e.MaNhaCungCap, e.MaSanPham })
                    .HasName("PK__CungUng__F500EF1AE2657402");

                entity.Property(e => e.MaNhaCungCap).HasColumnName("maNhaCungCap");

                entity.Property(e => e.MaSanPham).HasColumnName("maSanPham");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.CungUng)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CungUng_NhaCungCap");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.CungUng)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CungUng_SanPham");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDanhMuc)
                    .HasName("PK__DanhMuc__6B0F914C303557AA");

                entity.Property(e => e.MaDanhMuc).HasColumnName("maDanhMuc");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogoTungDanhMucSp)
                    .HasColumnName("logoTungDanhMucSP")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MaNhaSanXuat).HasColumnName("maNhaSanXuat");

                entity.Property(e => e.TenDanhMuc)
                    .HasColumnName("tenDanhMuc")
                    .HasMaxLength(500);

                entity.HasOne(d => d.MaNhaSanXuatNavigation)
                    .WithMany(p => p.DanhMuc)
                    .HasForeignKey(d => d.MaNhaSanXuat)
                    .HasConstraintName("fk_DanhMuc_NhaSanXuat");
            });

            modelBuilder.Entity<DanhMucManHinh>(entity =>
            {
                entity.HasKey(e => e.MaManHinh)
                    .HasName("PK__DanhMucM__E681ADAB679C2244");

                entity.Property(e => e.MaManHinh)
                    .HasColumnName("maManHinh")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.TenManHinh)
                    .HasColumnName("tenManHinh")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK__HoaDon__026B4D9A51D29386");

                entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(500);

                entity.Property(e => e.GiamGia).HasColumnName("giamGia");

                entity.Property(e => e.MaKhachHang).HasColumnName("maKhachHang");

                entity.Property(e => e.MaNguoiDung).HasColumnName("maNguoiDung");

                entity.Property(e => e.NgayBan)
                    .HasColumnName("ngayBan")
                    .HasColumnType("date");

                entity.Property(e => e.NgayGiao)
                    .HasColumnName("ngayGiao")
                    .HasColumnType("date");

                entity.Property(e => e.TienBan)
                    .HasColumnName("tienBan")
                    .HasColumnType("money");

                entity.Property(e => e.TongTien)
                    .HasColumnName("tongTien")
                    .HasColumnType("money");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("fk_HoaDon_KhachHang");

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("fk_HoaDon_NguoiDung");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang)
                    .HasName("PK__KhachHan__0CCB3D49D510FAE3");

                entity.Property(e => e.MaKhachHang).HasColumnName("maKhachHang");

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .HasColumnName("matKhau")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TenDangNhap)
                    .HasColumnName("tenDangNhap")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.TenKhachHang)
                    .HasColumnName("tenKhachHang")
                    .HasMaxLength(51);
            });

            modelBuilder.Entity<LoaiTinTuc>(entity =>
            {
                entity.HasKey(e => e.MaLoaiTin)
                    .HasName("PK__LoaiTinT__4450F0E08710F8C1");

                entity.Property(e => e.MaLoaiTin).HasColumnName("maLoaiTin");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(500);

                entity.Property(e => e.TenLoaiTin)
                    .HasColumnName("tenLoaiTin")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung)
                    .HasName("PK__NguoiDun__446439EA3C7BBFAC");

                entity.Property(e => e.MaNguoiDung).HasColumnName("maNguoiDung");

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.HoatDong).HasColumnName("hoatDong");

                entity.Property(e => e.MatKhau)
                    .HasColumnName("matKhau")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.NgayVaoLam)
                    .HasColumnName("ngayVaoLam")
                    .HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TenDangNhap)
                    .HasColumnName("tenDangNhap")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.TenNguoiDung)
                    .HasColumnName("tenNguoiDung")
                    .HasMaxLength(51);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNhaCungCap)
                    .HasName("PK__NhaCungC__D0B4D6DE359CC47E");

                entity.Property(e => e.MaNhaCungCap).HasColumnName("maNhaCungCap");

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhaCungCap)
                    .HasColumnName("tenNhaCungCap")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<NhaSanXuat>(entity =>
            {
                entity.HasKey(e => e.MaNhaSanXuat)
                    .HasName("PK__NhaSanXu__2CEBE44D1E2B3DA3");

                entity.Property(e => e.MaNhaSanXuat).HasColumnName("maNhaSanXuat");

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(71)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhaSanXuat)
                    .HasColumnName("tenNhaSanXuat")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<PhieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaPhieuNhap)
                    .HasName("PK__PhieuNha__E276393410BE3BA4");

                entity.Property(e => e.MaPhieuNhap).HasColumnName("maPhieuNhap");

                entity.Property(e => e.MaNguoiDung).HasColumnName("maNguoiDung");

                entity.Property(e => e.MaNhaCungCap).HasColumnName("maNhaCungCap");

                entity.Property(e => e.NgayNhap)
                    .HasColumnName("ngayNhap")
                    .HasColumnType("date");

                entity.Property(e => e.TienNhap)
                    .HasColumnName("tienNhap")
                    .HasColumnType("money");

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.PhieuNhap)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("fk_PhieuNhap_NguoiDung");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.PhieuNhap)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .HasConstraintName("fk_PhieuNhap_NhaCungCap");
            });

            modelBuilder.Entity<QlNguoiDungNhomNguoiDung>(entity =>
            {
                entity.HasKey(e => new { e.TenDangNhap, e.MaNhomNguoiDung })
                    .HasName("PK__QL_Nguoi__C73BC0438D68B3E0");

                entity.ToTable("QL_NguoiDungNhomNguoiDung");

                entity.Property(e => e.TenDangNhap)
                    .HasColumnName("tenDangNhap")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.MaNhomNguoiDung).HasColumnName("maNhomNguoiDung");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(101);
            });

            modelBuilder.Entity<QlNhomNguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaNhom)
                    .HasName("PK__QL_NhomN__8316C8AF0C26BE93");

                entity.ToTable("QL_NhomNguoiDung");

                entity.Property(e => e.MaNhom)
                    .HasColumnName("maNhom")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(101);

                entity.Property(e => e.TenNhom)
                    .HasColumnName("tenNhom")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<QlPhanQuyen>(entity =>
            {
                entity.HasKey(e => new { e.MaNhomNguoiDung, e.MaManHinh })
                    .HasName("PK__QL_PhanQ__4FB3CA5203464159");

                entity.ToTable("QL_PhanQuyen");

                entity.Property(e => e.MaNhomNguoiDung)
                    .HasColumnName("maNhomNguoiDung")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.MaManHinh)
                    .HasColumnName("maManHinh")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.CoQuyen).HasColumnName("coQuyen");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham)
                    .HasName("PK__SanPham__5B439C438E99E888");

                entity.Property(e => e.MaSanPham).HasColumnName("maSanPham");

                entity.Property(e => e.DonGia)
                    .HasColumnName("donGia")
                    .HasColumnType("money");

                entity.Property(e => e.DsHinh)
                    .HasColumnName("dsHinh")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GiamGia)
                    .HasColumnName("giamGia")
                    .HasColumnType("money");

                entity.Property(e => e.HinhMinhHoa)
                    .HasColumnName("hinhMinhHoa")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.KhuyenMai)
                    .HasColumnName("khuyenMai")
                    .HasMaxLength(800);

                entity.Property(e => e.MaDanhMuc).HasColumnName("maDanhMuc");

                entity.Property(e => e.MoTa)
                    .HasColumnName("moTa")
                    .HasMaxLength(800);

                entity.Property(e => e.MoTaChiTiet)
                    .HasColumnName("moTaChiTiet")
                    .HasMaxLength(800);

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnName("ngayCapNhat")
                    .HasColumnType("date");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.TenSanPham)
                    .HasColumnName("tenSanPham")
                    .HasMaxLength(500);

                entity.Property(e => e.TinhTrang).HasColumnName("tinhTrang");

                entity.Property(e => e.XuatXu)
                    .HasColumnName("xuatXu")
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaDanhMucNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.MaDanhMuc)
                    .HasConstraintName("fk_SanPham_DanhMuc");
            });

            modelBuilder.Entity<TinTuc>(entity =>
            {
                entity.HasKey(e => e.MaTinTuc)
                    .HasName("PK__TinTuc__8AEFE3640B53A680");

                entity.Property(e => e.MaTinTuc).HasColumnName("maTinTuc");

                entity.Property(e => e.AnhMinhHoa)
                    .HasColumnName("anhMinhHoa")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(500);

                entity.Property(e => e.KichHoat).HasColumnName("kichHoat");

                entity.Property(e => e.MaLoaiTin).HasColumnName("maLoaiTin");

                entity.Property(e => e.NgayDang)
                    .HasColumnName("ngayDang")
                    .HasColumnType("date");

                entity.Property(e => e.NoiDung)
                    .HasColumnName("noiDung")
                    .HasMaxLength(600);

                entity.Property(e => e.TenTinTuc)
                    .HasColumnName("tenTinTuc")
                    .HasMaxLength(500);

                entity.HasOne(d => d.MaLoaiTinNavigation)
                    .WithMany(p => p.TinTuc)
                    .HasForeignKey(d => d.MaLoaiTin)
                    .HasConstraintName("fk_TinTuc_LoaiTinTuc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
