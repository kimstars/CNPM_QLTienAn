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
    public partial class DaiDoi_ChoPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public DaiDoi_ChoPheDuyet()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.Editable = false;
        }
        public Model_QLTA db = new Model_QLTA();

        public void ReloadAll()
        {
            DaiDoi_ChoPheDuyet_Load(this, new EventArgs());
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int maDS = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[0]));

            if (gridView1.FocusedColumn == gridView1.Columns["fldXoa"])
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DanhSachNghi temp = db.DanhSachNghis.Where(s => s.MaDS == maDS).FirstOrDefault();
                    db.DanhSachNghis.Remove(temp);
                    db.SaveChanges();
                    ReloadAll();
                }
                return;
            }

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

        private void DaiDoi_ChoPheDuyet_Load(object sender, EventArgs e)
        {
            CanBo cbo = db.CanBoes.Where(s => s.MaCanBo == FormMain.maCB).FirstOrDefault();
            var danhsach = (from ds in db.DanhSachNghis
                            join cb in db.CanBoes on ds.MaCBDaiDoi equals cb.MaCanBo
                            join dv in db.DonVis on cb.MaDonVi equals dv.MaDonVi
                            where dv.MaDonVi == cbo.MaDonVi && ds.PheDuyet == -1
                            select new
                            {
                                MaDS = ds.MaDS,
                                NgayDangKy = ds.NgayDK,
                                CanBoDaiDoi = cb.HoTen,
                                //PheDuyet = ds.PheDuyet,
                            }).ToList();
            danhsach.Reverse();

            gridControl1.DataSource = danhsach;
            gridControl2.DataSource = null;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int maDStoXoa = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]));
            MessageBox.Show(maDStoXoa.ToString());
        }
    }
}
