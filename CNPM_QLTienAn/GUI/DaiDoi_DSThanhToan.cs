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
    public partial class DaiDoi_DSThanhToan : DevExpress.XtraEditors.XtraUserControl
    {
        public DaiDoi_DSThanhToan()
        {
            InitializeComponent();
        }
        Model_QLTA db = new Model_QLTA();

        int MaDonVi = 3;


        List<ThanhToan> lsthanhtoan = new List<ThanhToan>();
        List<Object_ThanhToan> lsObjThanhtoan = new List<Object_ThanhToan>();


        private void DaiDoi_DSThanhToan_Load(object sender, EventArgs e)
        {
            lsthanhtoan = db.ThanhToans.Where(m => m.HocVien.MaDonVi == MaDonVi && m.TrangThaiTT == 1).ToList();
            List<ChiTietNghi> ctn;

            foreach (var item in lsthanhtoan)
            {

                DangKyNghi dkn = db.DangKyNghis.Where(m => m.MaThanhToan == item.MaThanhToan).FirstOrDefault();

                ctn = db.ChiTietNghis.Where(m => m.MaDangKy == dkn.MaDangKy).ToList();

                int bsang, btrua, btoi; bsang = 0; btrua = 0; btoi = 0;
                DateTime start = DateTime.Today;
                for (int i = 0; i < ctn.Count; i++)
                {
                    if (DateTime.Compare(start, ctn[i].NgayNghi) < 0) start = ctn[i].NgayNghi;
                    bsang += (int)ctn[i].SoBuoiSang;
                    btrua += (int)ctn[i].SoBuoiTrua;
                    btoi += (int)ctn[i].SoBuoiToi;

                }

                Object_ThanhToan temp = new Object_ThanhToan
                {
                    maHV = (int)item.MaHocVien,
                    HoTen = db.HocViens.Where(m => m.MaHocVien == (int)item.MaHocVien).First().HoTen,
                    maThanhToan = item.MaThanhToan,
                    sang = bsang,
                    trua = btrua,
                    toi = btoi,
                    TienCuaCTN = item.TongTien,
                    ngayNghi = start

                };

                lsObjThanhtoan.Add(temp);


            }
            gridControl1.DataSource = lsObjThanhtoan;



            //test 1 thang cb

            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);

            //MessageBox.Show(first.ToString("dd-MM-yyyy"));






        }
    }
}
