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
    public partial class DaiDoi_NhapDanhSach : DevExpress.XtraEditors.XtraUserControl
    {
        List<HocVien_DangKyNghi> listDK = new List<HocVien_DangKyNghi>();

        public Model_QLTA db = new Model_QLTA();
        int MaHVCurrent = 0;

        public DaiDoi_NhapDanhSach()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            radioGroup1.SelectedIndex = 0;
            SetDefaultState();
        }

        private void DaiDoi_NhapDanhSach_Load(object sender, EventArgs e)
        {
            gridControl2.DataSource = listDK;
            CanBo cb = db.CanBoes.Where(s => s.MaCanBo == FormMain.maCB).FirstOrDefault();
            DonVi dv = db.DonVis.Where(s => s.MaDonVi == cb.MaDonVi).FirstOrDefault();
            gridControl1.DataSource = db.HocViens.Where(s => s.DonVi.TenDonVi == dv.TenDonVi).ToList();
        }

        private void SetDefaultState()
        {
            listDK.Clear();

            tbRN_HoTen.Text = "";
            tbRN_Lop.Text = "";
            tbTT_HoTen.Text = "";
            tbTT_Lop.Text = "";

            if((int)DateTime.Today.DayOfWeek < 5 && (int)DateTime.Today.DayOfWeek > 0)
            {
                dtpTT_NgayNghi.EditValue = GetNextWeekday(DateTime.Today, DayOfWeek.Friday);
                dtpTT_NgayTra.EditValue = GetNextWeekday(DateTime.Today, DayOfWeek.Sunday);

            }
            else
            {
                dtpTT_NgayNghi.EditValue = DateTime.Today;
                dtpTT_NgayTra.EditValue = DateTime.Today;
            }

            dtpRN_NgayNghi.EditValue = GetNextWeekday(DateTime.Today, DayOfWeek.Saturday);

            chbRN_Sang.Checked = false;
            chbRN_Trua.Checked = false;
            chbRN_Toi.Checked = false;
            chbTT_SangNghi.Checked = false;
            chbTT_TruaNghi.Checked = false;
            chbTT_ToiNghi.Checked = true;
            chbTT_SangTra.Checked = true;
            chbTT_TruaTra.Checked = true;
            chbTT_ToiTra.Checked = false;

            gridControl2.DataSource = null;
        }
        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //MessageBox.Show(((int)DateTime.Today.DayOfWeek).ToString());
            if((int)day - (int)start.DayOfWeek > 0)
            { 
                int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
                return start.AddDays(daysToAdd);
            }
            else { return start; }
        }



        private void btnSendList_Click(object sender, EventArgs e)
        {
            // check danh sacsh co phan tu hay khog
            if (listDK.Count <= 0)
            {
                MessageBox.Show("Chưa có học viên nào được thêm");
                return;
            }

            DanhSachNghi ds = new DanhSachNghi();
            ds.NgayDK = DateTime.Now;
            ds.PheDuyet = -1;
            ds.MaCBDaiDoi = FormMain.maCB;
            db.DanhSachNghis.Add(ds);
            db.SaveChanges();

            var unique_HocVien = listDK.Select(o => o.MaHocVien).Distinct();

            foreach (var i in unique_HocVien)
            {
                DangKyNghi dk = new DangKyNghi();
                dk.MaDS = ds.MaDS;
                dk.MaHocVien = i;
                db.DangKyNghis.Add(dk);
                db.SaveChanges();

                foreach (var j in listDK)
                {
                    if (j.MaHocVien == i)
                    {
                        ChiTietNghi ctn = new ChiTietNghi();
                        ctn.NgayNghi = j.NgayNghi;
                        ctn.SoBuoiSang = j.Sang;
                        ctn.SoBuoiTrua = j.Trua;
                        ctn.SoBuoiToi = j.Toi;
                        ctn.MaDangKy = dk.MaDangKy;
                        db.ChiTietNghis.Add(ctn);
                        db.SaveChanges();
                    }
                }
            }

            db.SaveChanges();
            MessageBox.Show("Gửi danh sách thành công");

            SetDefaultState();
        }


        bool IsNotDupDate(HocVien_DangKyNghi hv)
        {
            for (int i = 0; i < listDK.Count; i++)
            {

                if (listDK[i].MaHocVien == hv.MaHocVien)
                {
                    if (listDK[i].NgayNghi == hv.NgayNghi)
                    {
                        MessageBox.Show($"Đã tồn tại đăng ký tại ngày {hv.NgayNghi.ToString("dd-MM-yyyy")}", "Lỗi");
                        return false;
                    }
                }
            }

            var isDupInDB = db.ChiTietNghis.Where(x => x.NgayNghi == hv.NgayNghi && x.DangKyNghi.MaHocVien == hv.MaHocVien).FirstOrDefault();

            if(isDupInDB != null)
            {
                MessageBox.Show($"Đã tồn tại đăng ký tại ngày {hv.NgayNghi.ToString("dd-MM-yyyy")}", "Thông báo !");

                HocVien_DangKyNghi hv_dk = new HocVien_DangKyNghi();
                hv_dk.MaHocVien = MaHVCurrent;
                hv_dk.HoTen = tbRN_HoTen.Text;
                hv_dk.Lop = tbRN_Lop.Text;
                hv_dk.NgayNghi = Convert.ToDateTime(dtpRN_NgayNghi.EditValue);
                hv_dk.Sang = chbRN_Sang.Checked ? 1 : 0;
                hv_dk.Trua = chbRN_Trua.Checked ? 1 : 0;
                hv_dk.Toi = chbRN_Toi.Checked ? 1 : 0;


                return false;
            }


            return true;
        }

        private void btnRN_Them_Click(object sender, EventArgs e)
        {
            if (MaHVCurrent == 0)
            {
                MessageBox.Show("Chưa chọn học viên");
                return;
            }

            if (chbRN_Sang.Checked == false && chbRN_Trua.Checked == false && chbRN_Toi.Checked == false)
            {
                MessageBox.Show("Chưa chọn buổi cắt cơm");
                return;
            }

            HocVien_DangKyNghi hv_dk = new HocVien_DangKyNghi();
            hv_dk.MaHocVien = MaHVCurrent;
            hv_dk.HoTen = tbRN_HoTen.Text;
            hv_dk.Lop = tbRN_Lop.Text;
            hv_dk.NgayNghi = Convert.ToDateTime(dtpRN_NgayNghi.EditValue);
            hv_dk.Sang = chbRN_Sang.Checked ? 1 : 0;
            hv_dk.Trua = chbRN_Trua.Checked ? 1 : 0;
            hv_dk.Toi = chbRN_Toi.Checked ? 1 : 0;

            if (IsNotDupDate(hv_dk))
            {
                listDK.Add(hv_dk);
                gridControl2.DataSource = null;
                gridControl2.DataSource = listDK;
            }
        }

        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            int row = gridView2.FocusedRowHandle;
            string colname = gridView2.Columns[gridView2.FocusedColumn.VisibleIndex].FieldName;
            int currVal = (int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[colname]);
            switch (colname)
            {
                case "Sang":
                    listDK[row].Sang = currVal == 0 ? 1 : 0;
                    break;
                case "Trua":
                    listDK[row].Trua = currVal == 0 ? 1 : 0;
                    break;
                case "Toi":
                    listDK[row].Toi = currVal == 0 ? 1 : 0;
                    break;
                default:
                    break;
            }
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                MaHVCurrent = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaHocVien"));
                tbTT_HoTen.Text = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
                tbTT_Lop.Text = gridView1.GetRowCellValue(e.RowHandle, "Lop").ToString();
            }
            else
            {
                MaHVCurrent = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaHocVien"));
                tbRN_HoTen.Text = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
                tbRN_Lop.Text = gridView1.GetRowCellValue(e.RowHandle, "Lop").ToString();
            }
        }


        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup edit = sender as RadioGroup;
            if (edit.SelectedIndex == 0)
            {
                pnRaNgoai.Visible = false;
                pnTranhThu.Visible = true;
            }
            else
            {
                pnRaNgoai.Visible = true;
                pnTranhThu.Visible = false;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int index = gridView2.FocusedRowHandle;
            listDK.RemoveAt(index);
            gridControl2.DataSource = null;
            gridControl2.DataSource = listDK;

        }

        private void btnTT_Them_Click(object sender, EventArgs e)
        {
            if (MaHVCurrent == 0)
            {
                MessageBox.Show("Chưa chọn học viên");
                return;
            }

            if (chbTT_SangNghi.Checked == false && chbTT_TruaNghi.Checked == false && chbTT_ToiNghi.Checked == false && chbTT_SangTra.Checked == false && chbTT_TruaTra.Checked == false && chbTT_ToiTra.Checked == false)
            {
                MessageBox.Show("Chưa chọn buổi cắt cơm");
                return;
            }

            HocVien_DangKyNghi hv_dk1 = new HocVien_DangKyNghi();
            hv_dk1.MaHocVien = MaHVCurrent;
            hv_dk1.HoTen = tbTT_HoTen.Text;
            hv_dk1.Lop = tbTT_Lop.Text;

            hv_dk1.NgayNghi = Convert.ToDateTime(dtpTT_NgayNghi.EditValue);
            hv_dk1.Sang = chbTT_SangNghi.Checked ? 1 : 0;
            hv_dk1.Trua = chbTT_TruaNghi.Checked ? 1 : 0;
            hv_dk1.Toi = chbTT_ToiNghi.Checked ? 1 : 0;

            if (IsNotDupDate(hv_dk1) && checkDateTT()) listDK.Add(hv_dk1); else return;

            DateTime ngayTemp = hv_dk1.NgayNghi;
            while (DateTime.Compare(ngayTemp.AddDays(1), Convert.ToDateTime(dtpTT_NgayTra.EditValue)) < 0)
            {
                ngayTemp = ngayTemp.AddDays(1);
                HocVien_DangKyNghi temp = new HocVien_DangKyNghi();
                temp.MaHocVien = MaHVCurrent;
                temp.HoTen = tbTT_HoTen.Text;
                temp.Lop = tbTT_Lop.Text;
                temp.NgayNghi = ngayTemp;
                temp.Sang = 1;
                temp.Trua = 1;
                temp.Toi = 1;
                if (IsNotDupDate(temp) && checkDateTT()) listDK.Add(temp); else return;
            }

            HocVien_DangKyNghi hv_dk2 = new HocVien_DangKyNghi();
            hv_dk2.MaHocVien = MaHVCurrent;
            hv_dk2.HoTen = tbTT_HoTen.Text;
            hv_dk2.Lop = tbTT_Lop.Text;

            hv_dk2.NgayNghi = Convert.ToDateTime(dtpTT_NgayTra.EditValue);
            hv_dk2.Sang = chbTT_SangTra.Checked ? 1 : 0;
            hv_dk2.Trua = chbTT_TruaTra.Checked ? 1 : 0;
            hv_dk2.Toi = chbTT_ToiTra.Checked ? 1 : 0;


            if (IsNotDupDate(hv_dk2) && checkDateTT())
            {
                listDK.Add(hv_dk2);
                gridControl2.DataSource = null;
                gridControl2.DataSource = listDK;
            }

            else return;

        }

        bool checkDateTT()
        {
            DateTime start = dtpTT_NgayNghi.DateTime;
            DateTime end = dtpTT_NgayTra.DateTime;
            if (DateTime.Compare(start, end) > 0)
            {
                MessageBox.Show("Ngày trả phép phải sau hoặc bằng ngày đăng ký nghỉ !", "Lỗi");
                return false;
            }
            return true;
        }

        private void dtpTT_NgayTra_EditValueChanged(object sender, EventArgs e)
        {
            checkDateTT();
        }
    }
}
