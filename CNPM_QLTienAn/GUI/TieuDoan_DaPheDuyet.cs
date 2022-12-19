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
    public partial class TieuDoan_DaPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public TieuDoan_DaPheDuyet()
        {
            InitializeComponent();
        }
        public Model_QLTA db = new Model_QLTA();


        public string MaDS_DaXacNhan;

        public void LoadDSDaPheDuyet()
        {
            try
            {
                var ds_DaXacNhan = (from ds in db.DanhSachNghis
                                    join cbc in db.CanBoes on ds.MaCBDaiDoi equals cbc.MaCanBo
                                    join cbd in db.CanBoes on ds.MaCBTieuDoan equals cbd.MaCanBo
                                    join dv in db.DonVis on cbc.MaDonVi equals dv.MaDonVi
                                    where ds.PheDuyet == 1
                                    select new
                                    {
                                        MaDS = ds.MaDS,
                                        TenDonVi = dv.TenDonVi,
                                        NgayDK = ds.NgayDK,
                                        HoTenc = cbc.HoTen,
                                        HoTend = cbd.HoTen
                                    }).ToList();

                if(ds_DaXacNhan.Count > 0)
                {
                    ds_DaXacNhan.Reverse();
                    dgvDaXacNhan_View.OptionsBehavior.Editable = false;
                    gridView2.OptionsBehavior.Editable = false;
                    dgvDaXacNhan.DataSource = ds_DaXacNhan;
                    LoadDSChiTietDaXacNhan(ds_DaXacNhan[0].MaDS);

                }


            }
            catch
            { }
        }

        public void LoadDSChiTietDaXacNhan(int mads)
        {
            try
            {
                
                var dsCTDaXacNhan = (from ds in db.DanhSachNghis
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
                                         SoBuoiToi = ctn.SoBuoiToi
                                     }).ToList();
                dgvChiTietDaXacNhan.DataSource = dsCTDaXacNhan;

            }
            catch
            { }

        }

        

        private void dgvDaXacNhan_Load(object sender, EventArgs e)
        {
            LoadDSDaPheDuyet();

        }

        private void dgvDaXacNhan_View_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            LoadDSChiTietDaXacNhan(Convert.ToInt32(dgvDaXacNhan_View.GetRowCellValue(e.RowHandle, "MaDS")));
        }
    }


}
