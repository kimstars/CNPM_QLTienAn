using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CNPM_QLTienAn.Models;

namespace CNPM_QLTienAn.GUI
{
    public partial class DaiDoi_DaHuy : DevExpress.XtraEditors.XtraUserControl
    {
        public DaiDoi_DaHuy()
        {
            InitializeComponent();

            gridView1.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.Editable = false;


        }
        public Model_QLTA db = new Model_QLTA();

        private void DaiDoi_DaHuy_Load(object sender, EventArgs e)
        {
            CanBo cbo = db.CanBoes.Where(s => s.MaCanBo == FormMain.maCB).FirstOrDefault();
            var danhsach = (from ds in db.DanhSachNghis
                            join cbc in db.CanBoes on ds.MaCBDaiDoi equals cbc.MaCanBo
                            join cbd in db.CanBoes on ds.MaCBTieuDoan equals cbd.MaCanBo
                            join dv in db.DonVis on cbc.MaDonVi equals dv.MaDonVi
                            where cbc.MaDonVi == cbo.MaDonVi && ds.PheDuyet == 0
                            select new
                            {
                                ds.MaDS,
                                NgayDangKy = ds.NgayDK,
                                CanBoDaiDoi = cbc.HoTen,
                                CanBoTieuDoan = cbd.HoTen,
                                //PheDuyet = ds.PheDuyet,
                            }).ToList();
            danhsach.Reverse();
            gridControl1.DataSource = danhsach;
            gridControl2.DataSource = null;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int maDS = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[0]));
            var chitiet = (from ds in db.DanhSachNghis
                           join dk in db.DangKyNghis on ds.MaDS equals dk.MaDS
                           join ct in db.ChiTietNghis on dk.MaDangKy equals ct.MaDangKy
                           join hv in db.HocViens on dk.MaHocVien equals hv.MaHocVien
                           where ds.MaDS == maDS
                           select new
                           {
                               HoTen = hv.HoTen,
                               Lop = hv.Lop,
                               NgayNghi = ct.NgayNghi,
                               Sang = ct.SoBuoiSang,
                               Trua = ct.SoBuoiTrua,
                               Toi = ct.SoBuoiToi
                           }).ToList();
            gridControl2.DataSource = chitiet;
        }
    }
}
