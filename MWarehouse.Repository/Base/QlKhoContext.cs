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

    public virtual DbSet<DmManHinh> DmManHinhs { get; set; }

    public virtual DbSet<QlNguoiDung> QlNguoiDungs { get; set; }

    public virtual DbSet<QlNguoiDungNhomNguoiDung> QlNguoiDungNhomNguoiDungs { get; set; }

    public virtual DbSet<QlNhomNguoiDung> QlNhomNguoiDungs { get; set; }

    public virtual DbSet<QlPhanQuyen> QlPhanQuyens { get; set; }

    public virtual DbSet<TblDmDonViTinh> TblDmDonViTinhs { get; set; }

    public virtual DbSet<TblDmKho> TblDmKhos { get; set; }

    public virtual DbSet<TblDmKhoUser> TblDmKhoUsers { get; set; }

    public virtual DbSet<TblDmLoaiSanPham> TblDmLoaiSanPhams { get; set; }

    public virtual DbSet<TblDmNcc> TblDmNccs { get; set; }

    public virtual DbSet<TblDmSanPham> TblDmSanPhams { get; set; }

    public virtual DbSet<TblXnkNhapKho> TblXnkNhapKhos { get; set; }

    public virtual DbSet<TblXnkNhapKhoRawDatum> TblXnkNhapKhoRawData { get; set; }

    public virtual DbSet<TblXnkXuatKho> TblXnkXuatKhos { get; set; }

    public virtual DbSet<TblXnkXuatKhoRawDatum> TblXnkXuatKhoRawData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=QL_Kho;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmManHinh>(entity =>
        {
            entity.HasKey(e => e.MaManHinh).HasName("PK__DM_ManHi__D84939223C4F834C");

            entity.ToTable("DM_ManHinh");

            entity.Property(e => e.MaManHinh).HasMaxLength(100);
            entity.Property(e => e.TenManHinh).HasMaxLength(100);
        });

        modelBuilder.Entity<QlNguoiDung>(entity =>
        {
            entity.HasKey(e => e.TenDangNhap).HasName("PK__QL_Nguoi__55F68FC1DECCDAE7");

            entity.ToTable("QL_NguoiDung");

            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(0);
        });

        modelBuilder.Entity<QlNguoiDungNhomNguoiDung>(entity =>
        {
            entity.HasKey(e => new { e.TenDangNhap, e.MaNhomNguoiDung }).HasName("PK__QL_Nguoi__77F599D82B75C7C7");

            entity.ToTable("QL_NguoiDungNhomNguoiDung");

            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.MaNhomNguoiDung).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
        });

        modelBuilder.Entity<QlNhomNguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNhom).HasName("PK__QL_NhomN__234F91CDC2E46656");

            entity.ToTable("QL_NhomNguoiDung");

            entity.Property(e => e.MaNhom).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.TenNhom).HasMaxLength(100);
        });

        modelBuilder.Entity<QlPhanQuyen>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("QL_PhanQuyen");

            entity.Property(e => e.CoQuyen).HasDefaultValue(0);
            entity.Property(e => e.MaManHinh).HasMaxLength(100);
            entity.Property(e => e.MaNhomNguoiDung).HasMaxLength(100);
        });

        modelBuilder.Entity<TblDmDonViTinh>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_D__F82B8823737A5D70");

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
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_K__F82B8823CBA6D63D");

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

        modelBuilder.Entity<TblDmKhoUser>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_K__F82B88231A5016C9");

            entity.ToTable("tbl_DM_Kho_User");

            entity.Property(e => e.AutoId).HasColumnName("Auto_ID");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.KhoId).HasColumnName("Kho_ID");
            entity.Property(e => e.MaDangNhap)
                .HasMaxLength(50)
                .HasColumnName("Ma_Dang_Nhap");

            entity.HasOne(d => d.Kho).WithMany(p => p.TblDmKhoUsers)
                .HasForeignKey(d => d.KhoId)
                .HasConstraintName("FK__tbl_DM_Kh__Kho_I__3E52440B");
        });

        modelBuilder.Entity<TblDmLoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_L__F82B88231628643D");

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
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_N__F82B8823346379D7");

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
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_DM_S__F82B882313FA479B");

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
                .HasConstraintName("FK__tbl_DM_Sa__DonVi__48CFD27E");

            entity.HasOne(d => d.LoaiSanPham).WithMany(p => p.TblDmSanPhams)
                .HasForeignKey(d => d.LoaiSanPhamId)
                .HasConstraintName("FK__tbl_DM_Sa__LoaiS__47DBAE45");
        });

        modelBuilder.Entity<TblXnkNhapKho>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_XNK___F82B88236130D508");

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

            entity.HasOne(d => d.Kho).WithMany(p => p.TblXnkNhapKhos)
                .HasForeignKey(d => d.KhoId)
                .HasConstraintName("FK__tbl_XNK_N__Kho_I__5535A963");

            entity.HasOne(d => d.Ncc).WithMany(p => p.TblXnkNhapKhos)
                .HasForeignKey(d => d.NccId)
                .HasConstraintName("FK__tbl_XNK_N__NCC_I__5629CD9C");
        });

        modelBuilder.Entity<TblXnkNhapKhoRawDatum>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_XNK___F82B882316E450C0");

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
                .HasConstraintName("FK__tbl_XNK_N__Nhap___59FA5E80");

            entity.HasOne(d => d.SanPham).WithMany(p => p.TblXnkNhapKhoRawData)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__tbl_XNK_N__San_P__5AEE82B9");
        });

        modelBuilder.Entity<TblXnkXuatKho>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_XNK___F82B8823153C1D0E");

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

            entity.HasOne(d => d.Kho).WithMany(p => p.TblXnkXuatKhos)
                .HasForeignKey(d => d.KhoId)
                .HasConstraintName("FK__tbl_XNK_X__Kho_I__4CA06362");
        });

        modelBuilder.Entity<TblXnkXuatKhoRawDatum>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PK__tbl_XNK___F82B88234FE6A596");

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
                .HasConstraintName("FK__tbl_XNK_X__San_P__5165187F");

            entity.HasOne(d => d.XuatKho).WithMany(p => p.TblXnkXuatKhoRawData)
                .HasForeignKey(d => d.XuatKhoId)
                .HasConstraintName("FK__tbl_XNK_X__Xuat___5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
