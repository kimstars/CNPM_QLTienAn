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
using System.Data.Entity;


namespace CNPM_QLTienAn.GUI
{
    public partial class DaiDoi_QuanLyDanhSach : DevExpress.XtraEditors.XtraUserControl
    {
        public DaiDoi_QuanLyDanhSach(int MaCB)
        {
            InitializeComponent();

            MaDV = (int)db.CanBoes.Where(m => m.MaCanBo == MaCB).FirstOrDefault().MaDonVi;
        }

        int MaDV = 0;

        Model_QLTA db = new Model_QLTA();

        private void DaiDoi_QuanLyDanhSach_Load(object sender, EventArgs e)
        {
            dtpNgayC.EditValue = DateTime.Now;

            LoadQuanSoC();

            LoadDBDaiDoi();



        }

        private int LoadQuanSoC()
        {
            List<DonVi> lstDonVi = db.DonVis.ToList();
            int quansoC = db.HocViens.Where(s => s.MaDonVi == MaDV).ToList().Count;
            textEdit7.Text = quansoC.ToString();
            textEdit8.Text = quansoC.ToString();
            textEdit9.Text = quansoC.ToString();

            return quansoC;

        }

        private void LoadDBDaiDoi()
        {
            ClearGridControl();

            var thisDate = dtpNgayC.DateTime.Date;

            List<DonVi> lstDonVi = db.DonVis.ToList();

            List<NhaBep_ListCatCom> lstCatCom = db.NhaBep_ListCatCom.Where(s => DbFunctions.TruncateTime(s.NgayNghi) == thisDate.Date && s.MaDonVi == MaDV).ToList();

            gridView1.Columns[3].Visible = false;
            gridControl1.DataSource = lstCatCom;
            gridControl1.Refresh();

            int sobuoisang = lstCatCom.Count(s => s.SoBuoiSang == 1);
            int sobuoitrua = lstCatCom.Count(s => s.SoBuoiTrua == 1);
            int sobuoitoi = lstCatCom.Count(s => s.SoBuoiToi == 1);
            int quansoC = LoadQuanSoC();
            textEdit1.Text = (quansoC - sobuoisang).ToString();
            textEdit2.Text = (quansoC - sobuoitrua).ToString();
            textEdit3.Text = (quansoC - sobuoitoi).ToString();


        }

        private void ClearGridControl()
        {
            gridControl1.BeginUpdate();
            try
            {
                gridControl1.DataSource = null;
                gridControl1.Refresh();
            }
            finally
            {
                gridControl1.EndUpdate();
            }
        }

        private void dtpNgayC_EditValueChanged(object sender, EventArgs e)
        {
            LoadDBDaiDoi();
        }
    }
}
