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
    public partial class NhaBep_LSThanhToan : DevExpress.XtraEditors.XtraUserControl
    {
        public NhaBep_LSThanhToan()
        {
            InitializeComponent();
        }


        Model_QLTA db = new Model_QLTA();
        private void NhaBep_LSThanhToan_Load(object sender, EventArgs e)
        {
            dateStart.DateTime = DateTime.Today.AddDays(-30);
            dateEnd.DateTime = DateTime.Today;

            LoadLS_Base();

        }

            List<Models.NhaBep_LSThanhToan> dsLsTT = new List<Models.NhaBep_LSThanhToan>();

        void LoadLS_Base()
        {
            List<ThanhToan> dsTT = db.ThanhToans.OrderBy(m => m.NgayTT).Where(m => m.TrangThaiTT == 1).ToList();


            for (int i = 0; i < dsTT.Count; i++)
            {
                Models.NhaBep_LSThanhToan newObj = new Models.NhaBep_LSThanhToan();
                int MaTT = dsTT[i].MaThanhToan;
                DangKyNghi thisDKN = db.DangKyNghis.Where(m => m.MaThanhToan == MaTT).FirstOrDefault();
                DanhSachNghi thisDSN = db.DanhSachNghis.Where(m => m.MaDS == thisDKN.MaDS).FirstOrDefault();
                newObj.TenCBBep = db.CanBoes.Where(m => m.MaCanBo == thisDSN.MaCBNhaBep).FirstOrDefault().HoTen;
                newObj.TenHocVien = db.HocViens.Where(m => m.MaHocVien == thisDKN.MaHocVien).FirstOrDefault().HoTen;
                HocVien thisHV = db.HocViens.Where(m => m.MaHocVien == thisDKN.MaHocVien).FirstOrDefault();
                newObj.TenDonVi = db.DonVis.Where(m => m.MaDonVi == thisHV.MaDonVi).FirstOrDefault().TenDonVi;

                newObj.TongTien = dsTT[i].TongTien;
                newObj.NgayThanhToan = (DateTime)dsTT[i].NgayTT;

                dsLsTT.Add(newObj);
            }

            gridControl1.DataSource = dsLsTT;
        }


        void Load_LSThanhToan()
        {
            gridControl1.DataSource = null;
            DateTime start = dateStart.DateTime;
            DateTime end = dateEnd.DateTime;


            gridControl1.DataSource =  dsLsTT.Where(m => DateTime.Compare(m.NgayThanhToan.Date, start.Date) >= 0 && DateTime.Compare(m.NgayThanhToan.Date,end.Date) <= 0);


        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            Load_LSThanhToan();
        }
    }
}
