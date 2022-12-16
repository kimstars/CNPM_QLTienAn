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
    public partial class TieuDoan_ChoPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public TieuDoan_ChoPheDuyet()
        {
            InitializeComponent();
        }
        public Model_QLTA db = new Model_QLTA();

        public TieuDoan_ChoPheDuyet(int maCB)
        {
            InitializeComponent();
            maCBd = maCB;
        }

        static int maCBd;
        public string MaDS_XacNhan;
        private int mads;


     

        public void LoadDS1()
        {
            try
            {
                var ds_ChoPheDuyet = (from ds in db.DanhSachNghis
                                      join cb in db.CanBoes on ds.MaCBDaiDoi equals cb.MaCanBo
                                      join dv in db.DonVis on cb.MaDonVi equals dv.MaDonVi
                                      where ds.PheDuyet == -1
                                      select new
                                      {
                                          MaDS = ds.MaDS,
                                          TenDonVi = dv.TenDonVi,
                                          NgayDK = ds.NgayDK,
                                          HoTen = cb.HoTen
                                      }).ToList();


                ds_ChoPheDuyet.Reverse();
                dgvDSCho.DataSource = ds_ChoPheDuyet;

                mads = ds_ChoPheDuyet[0].MaDS;
                MaDS_XacNhan = mads.ToString();
                var ds_CTChoPheDuyet = (from ds in db.DanhSachNghis
                                        join dkn in db.DangKyNghis on ds.MaDS equals dkn.MaDS
                                        join ctn in db.ChiTietNghis on dkn.MaDangKy equals ctn.MaDangKy
                                        join hv1 in db.HocViens on dkn.MaHocVien equals hv1.MaHocVien

                                        where ds.MaDS == mads
                                        select new
                                        {
                                            HoTen = hv1.HoTen,
                                            Lop = hv1.Lop,
                                            NgayNghi = ctn.NgayNghi,
                                            SoBuoiSang = ctn.SoBuoiSang,
                                            SoBuoiTrua = ctn.SoBuoiTrua,
                                            SoBuoiToi = ctn.SoBuoiToi,

                                        }).ToList();
                ds_CTChoPheDuyet.Reverse();
                //dgvDSCho_View.OptionsBehavior.Editable = false;
                //gridView2.OptionsBehavior.Editable = false;
                dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;
            }
            catch
            { }
        }
       



        private void btnHuy_Click(object sender, EventArgs e)
        {
            var dsn = db.DanhSachNghis.SingleOrDefault(p => p.MaDS.ToString() == MaDS_XacNhan);
            if (dsn != null)
            {
                dsn.PheDuyet = 0;
                dsn.MaCBTieuDoan = maCBd;
                db.SaveChanges();
                MessageBox.Show("Danh sách đã được huỷ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvDSCho.DataSource = null;
            dgvChiTietDS1.DataSource = null;
            LoadDS1();
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            var dsn = db.DanhSachNghis.SingleOrDefault(p => p.MaDS.ToString() == MaDS_XacNhan);
            if (dsn != null)
            {
                dsn.PheDuyet = 1;
                dsn.MaCBTieuDoan = maCBd;
                db.SaveChanges();
                MessageBox.Show("Danh sách đã được xác nhận thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Danh sách không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvDSCho.DataSource = null;
            dgvChiTietDS1.DataSource = null;
            LoadDS1();
        }


      

        private void dgvDSCho_View_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            int maDS = Convert.ToInt32(dgvDSCho_View.GetRowCellValue(e.RowHandle, "MaDS")); ;

            var ds_CTChoPheDuyet = (from ds in db.DanhSachNghis
                                    join dkn in db.DangKyNghis on ds.MaDS equals dkn.MaDS
                                    join ctn in db.ChiTietNghis on dkn.MaDangKy equals ctn.MaDangKy
                                    join hv1 in db.HocViens on dkn.MaHocVien equals hv1.MaHocVien

                                    where ds.MaDS == maDS
                                    select new
                                    {
                                        HoTen = hv1.HoTen,
                                        Lop = hv1.Lop,
                                        NgayNghi = ctn.NgayNghi,
                                        SoBuoiSang = ctn.SoBuoiSang,
                                        SoBuoiTrua = ctn.SoBuoiTrua,
                                        SoBuoiToi = ctn.SoBuoiToi,

                                    }).ToList();
            ds_CTChoPheDuyet.Reverse();
            //dgvDSCho_View.OptionsBehavior.Editable = false;
            //gridView2.OptionsBehavior.Editable = false;
            dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;
        }
    }
}
