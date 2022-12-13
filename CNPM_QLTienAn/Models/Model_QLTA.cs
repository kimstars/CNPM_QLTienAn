using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CNPM_QLTienAn.Models
{
    public partial class Model_QLTA : DbContext
    {
        public Model_QLTA()
            : base("name=Model_QLTA")
        {
        }

        public virtual DbSet<CanBo> CanBoes { get; set; }
        public virtual DbSet<ChiTietNghi> ChiTietNghis { get; set; }
        public virtual DbSet<DangKyNghi> DangKyNghis { get; set; }
        public virtual DbSet<DanhSachNghi> DanhSachNghis { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<TieuChuanAn> TieuChuanAns { get; set; }
        public virtual DbSet<TTDangNhap> TTDangNhaps { get; set; }
        public virtual DbSet<DS_HocVien> DS_HocVien { get; set; }
        public virtual DbSet<NhaBep_CatComChuaThanhToan> NhaBep_CatComChuaThanhToan { get; set; }
        public virtual DbSet<NhaBep_FindToCreateThanhToan> NhaBep_FindToCreateThanhToan { get; set; }
        public virtual DbSet<NhaBep_LichSuCatComLop> NhaBep_LichSuCatComLop { get; set; }
        public virtual DbSet<NhaBep_ListCatCom> NhaBep_ListCatCom { get; set; }
        public virtual DbSet<View_ChiTietChoPheDuyet> View_ChiTietChoPheDuyet { get; set; }
        public virtual DbSet<View_ChiTietDaHuy> View_ChiTietDaHuy { get; set; }
        public virtual DbSet<View_ChiTietDaXacNhan> View_ChiTietDaXacNhan { get; set; }
        public virtual DbSet<View_ChoPheDuyet> View_ChoPheDuyet { get; set; }
        public virtual DbSet<View_DaHuy> View_DaHuy { get; set; }
        public virtual DbSet<View_DaXacNhan> View_DaXacNhan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachNghis)
                .WithOptional(e => e.CanBo)
                .HasForeignKey(e => e.MaCBDaiDoi);

            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachNghis1)
                .WithOptional(e => e.CanBo1)
                .HasForeignKey(e => e.MaCBNhaBep);

            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachNghis2)
                .WithOptional(e => e.CanBo2)
                .HasForeignKey(e => e.MaCBTieuDoan);

            modelBuilder.Entity<TTDangNhap>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TTDangNhap>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TTDangNhap>()
                .Property(e => e.QuyenTruyCap)
                .IsUnicode(false);
        }
    }
}
