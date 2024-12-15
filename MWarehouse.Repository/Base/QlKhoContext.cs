using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MWarehouse.Repository.Models;

public partial class QlKhoContext : DbContext
{

    public QlKhoContext()
    {
    }

    public QlKhoContext(DbContextOptions<QlKhoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthCode> AuthCodes { get; set; }

    public virtual DbSet<DmManHinh> DmManHinhs { get; set; }

    public virtual DbSet<QlNguoiDung> QlNguoiDungs { get; set; }

    public virtual DbSet<QlNguoiDungNhomNguoiDung> QlNguoiDungNhomNguoiDungs { get; set; }

    public virtual DbSet<QlNhomNguoiDung> QlNhomNguoiDungs { get; set; }

    public virtual DbSet<QlPhanQuyen> QlPhanQuyens { get; set; }

    public virtual DbSet<TblDmDonViTinh> TblDmDonViTinhs { get; set; }

    public virtual DbSet<TblDmKho> TblDmKhos { get; set; }

    public virtual DbSet<TblDmLoaiSanPham> TblDmLoaiSanPhams { get; set; }

    public virtual DbSet<TblDmNcc> TblDmNccs { get; set; }

    public virtual DbSet<TblDmSanPham> TblDmSanPhams { get; set; }

    public virtual DbSet<TblXnkNhapKho> TblXnkNhapKhos { get; set; }

    public virtual DbSet<TblXnkNhapKhoRawDatum> TblXnkNhapKhoRawData { get; set; }

    public virtual DbSet<TblXnkXuatKho> TblXnkXuatKhos { get; set; }

    public virtual DbSet<TblXnkXuatKhoRawDatum> TblXnkXuatKhoRawData { get; set; }

    public virtual DbSet<TheoDoi> TheoDois { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=QL_KHO;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Vietnamese_CI_AS");

        modelBuilder.Entity<AuthCode>(entity =>
        {
            entity.ToTable("Auth_Code");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KeyValue)
                .HasMaxLength(100)
                .HasColumnName("Key_value");
        });

        modelBuilder.Entity<DmManHinh>(entity =>
        {
            entity.HasKey(e => e.MaManHinh).HasName("PK__DM_ManHi__D8493922AE90B568");

            entity.ToTable("DM_ManHinh");

            entity.Property(e => e.MaManHinh).HasMaxLength(100);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.TenManHinh).HasMaxLength(100);
        });

        modelBuilder.Entity<QlNguoiDung>(entity =>
        {
            entity.HasKey(e => e.TenDangNhap).HasName("PK__QL_Nguoi__55F68FC13144BF93");

            entity.ToTable("QL_NguoiDung");

            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(0);
        });

        modelBuilder.Entity<QlNguoiDungNhomNguoiDung>(entity =>
        {
            entity.HasKey(e => new { e.TenDangNhap, e.MaNhomNguoiDung }).HasName("PK__QL_Nguoi__77F599D80B763FDF");

            entity.ToTable("QL_NguoiDungNhomNguoiDung");

            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.MaNhomNguoiDung).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
        });

        modelBuilder.Entity<QlNhomNguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNhom).HasName("PK__QL_NhomN__234F91CD06C0B240");

            entity.ToTable("QL_NhomNguoiDung");

            entity.Property(e => e.MaNhom).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.TenNhom).HasMaxLength(100);
        });

        modelBuilder.Entity<QlPhanQuyen>(entity =>
        {
            entity.HasKey(e => new {e.MaNhomNguoiDung, e.MaManHinh}).HasName("PK_QL_PhanQuyen");
            entity.Property(e => e.CoQuyen).HasDefaultValue(0);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.MaManHinh).HasMaxLength(100);
            entity.Property(e => e.MaNhomNguoiDung).HasMaxLength(100);
        });

        modelBuilder.Entity<TblDmDonViTinh>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_D__F82B8823088D17B4");

            entity.ToTable("tbl_DM_Don_Vi_Tinh");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.MaDvt)
                .HasMaxLength(100)
                .HasColumnName("Ma_DVT");
            entity.Property(e => e.TenDvt)
                .HasMaxLength(100)
                .HasColumnName("Ten_DVT");
        });

        modelBuilder.Entity<TblDmKho>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_K__F82B882312216FBE");

            entity.ToTable("tbl_DM_Kho");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.MaKho)
                .HasMaxLength(100)
                .HasColumnName("Ma_Kho");
            entity.Property(e => e.TenKho)
                .HasMaxLength(100)
                .HasColumnName("Ten_Kho");
        });

        modelBuilder.Entity<TblDmLoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_L__F82B88233A455A65");

            entity.ToTable("tbl_DM_Loai_San_Pham");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.MaLsp)
                .HasMaxLength(100)
                .HasColumnName("Ma_LSP");
            entity.Property(e => e.TenLsp)
                .HasMaxLength(100)
                .HasColumnName("Ten_LSP");
        });

        modelBuilder.Entity<TblDmNcc>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_N__F82B8823836C0C81");

            entity.ToTable("tbl_DM_NCC");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.MaNcc)
                .HasMaxLength(100)
                .HasColumnName("Ma_NCC");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(100)
                .HasColumnName("Ten_NCC");
        });

        modelBuilder.Entity<TblDmSanPham>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_S__F82B882346416F78");

            entity.ToTable("tbl_DM_San_Pham");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(100)
                .HasColumnName("Ma_San_Pham");
            entity.Property(e => e.TenSanPham)
                .HasMaxLength(100)
                .HasColumnName("Ten_San_Pham");

            entity.HasOne(d => d.DonViTinh).WithMany(p => p.TblDmSanPhams)
                .HasForeignKey(d => d.DonViTinhId)
                .HasConstraintName("FK__tbl_DM_Sa__DonVi__1332DBDC");

            entity.HasOne(d => d.LoaiSanPham).WithMany(p => p.TblDmSanPhams)
                .HasForeignKey(d => d.LoaiSanPhamId)
                .HasConstraintName("FK__tbl_DM_Sa__LoaiS__123EB7A3");
        });

        modelBuilder.Entity<TblXnkNhapKho>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_XNK___F82B88233FE629C9");

            entity.ToTable("tbl_XNK_Nhap_Kho");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.KhoId).HasColumnName("Kho_ID");
            entity.Property(e => e.NccId).HasColumnName("NCC_ID");
            entity.Property(e => e.NgayNhapKho).HasColumnName("Ngay_Nhap_Kho");
            entity.Property(e => e.SoPhieuNhap)
                .HasMaxLength(100)
                .HasColumnName("So_Phieu_Nhap");
            entity.Property(e => e.TrangThai).HasDefaultValue(0);

            entity.HasOne(d => d.Kho).WithMany(p => p.TblXnkNhapKhos)
                .HasForeignKey(d => d.KhoId)
                .HasConstraintName("FK__tbl_XNK_N__Kho_I__14270015");

            entity.HasOne(d => d.Ncc).WithMany(p => p.TblXnkNhapKhos)
                .HasForeignKey(d => d.NccId)
                .HasConstraintName("FK__tbl_XNK_N__NCC_I__151B244E");
        });

        modelBuilder.Entity<TblXnkNhapKhoRawDatum>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_XNK___F82B8823EE67EA95");

            entity.ToTable("tbl_XNK_Nhap_Kho_Raw_Data");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.DonGiaNhap)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Don_Gia_Nhap");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.NhapKhoId).HasColumnName("Nhap_Kho_ID");
            entity.Property(e => e.SanPhamId).HasColumnName("San_Pham_ID");
            entity.Property(e => e.SlNhap)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SL_Nhap");

            entity.HasOne(d => d.NhapKho).WithMany(p => p.TblXnkNhapKhoRawData)
                .HasForeignKey(d => d.NhapKhoId)
                .HasConstraintName("FK__tbl_XNK_N__Nhap___160F4887");

            entity.HasOne(d => d.SanPham).WithMany(p => p.TblXnkNhapKhoRawData)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__tbl_XNK_N__San_P__17036CC0");
        });

        modelBuilder.Entity<TblXnkXuatKho>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_XNK___F82B882330525671");

            entity.ToTable("tbl_XNK_Xuat_Kho");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.KhoId).HasColumnName("Kho_ID");
            entity.Property(e => e.NgayXuatKho).HasColumnName("Ngay_Xuat_Kho");
            entity.Property(e => e.SoPhieuXuat)
                .HasMaxLength(100)
                .HasColumnName("So_Phieu_Xuat");
            entity.Property(e => e.TrangThai).HasDefaultValue(0);

            entity.HasOne(d => d.Kho).WithMany(p => p.TblXnkXuatKhos)
                .HasForeignKey(d => d.KhoId)
                .HasConstraintName("FK__tbl_XNK_X__Kho_I__17F790F9");
        });

        modelBuilder.Entity<TblXnkXuatKhoRawDatum>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_XNK___F82B8823BFF253AA");

            entity.ToTable("tbl_XNK_Xuat_Kho_Raw_Data");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.DonGiaXuat)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Don_Gia_Xuat");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.SanPhamId).HasColumnName("San_Pham_ID");
            entity.Property(e => e.SlXuat)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SL_Xuat");
            entity.Property(e => e.XuatKhoId).HasColumnName("Xuat_Kho_ID");

            entity.HasOne(d => d.SanPham).WithMany(p => p.TblXnkXuatKhoRawData)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__tbl_XNK_X__San_P__19DFD96B");

            entity.HasOne(d => d.XuatKho).WithMany(p => p.TblXnkXuatKhoRawData)
                .HasForeignKey(d => d.XuatKhoId)
                .HasConstraintName("FK__tbl_XNK_X__Xuat___18EBB532");
        });

        modelBuilder.Entity<TheoDoi>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__TheoDoi__F82B8823464B9E92");

            entity.ToTable("TheoDoi");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.Lenh)
                .HasMaxLength(100)
                .HasColumnName("lenh");
            entity.Property(e => e.NgayThucHien).HasColumnType("datetime");
            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.ThongTin).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(0);

            entity.HasOne(d => d.TenDangNhapNavigation).WithMany(p => p.TheoDois)
                .HasForeignKey(d => d.TenDangNhap)
                .HasConstraintName("FK__TheoDoi__TenDang__1AD3FDA4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
