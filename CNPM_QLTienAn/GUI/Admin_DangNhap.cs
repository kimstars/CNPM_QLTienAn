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
    public partial class Admin_DangNhap : DevExpress.XtraEditors.XtraUserControl
    {
        public Admin_DangNhap()
        {
            InitializeComponent();
        }
        public Model_QLTA db = new Model_QLTA();
        public TTDangNhap ttdn = new TTDangNhap();
        private void Admin_DangNhap_Load(object sender, EventArgs e)
        {
            var tkdn = db.TTDangNhaps.ToList();
            dgvTKDN.DataSource = tkdn;
            LoadChiTietTk();
        }

        public void LoadChiTietTk()
        {
            try
            {
                int madn = (int)dgvTKDN_View.GetFocusedRowCellValue("MaDangNhap");
                ttdn = db.TTDangNhaps.Where(p => p.MaDangNhap == madn).FirstOrDefault();
                txtTenTK_CT.EditValue = ttdn.TaiKhoan;
                txtQuyenTruyCap_CT.EditValue = ttdn.QuyenTruyCap;
                txtMatKhau_CT.EditValue = ttdn.MatKhau;

                txtXoaMK.EditValue = ttdn.MatKhau;
                txtXoaQTC.EditValue = ttdn.QuyenTruyCap;
                txtXoaTK.EditValue = ttdn.TaiKhoan;

                txtSuaMaDN.EditValue = ttdn.MaDangNhap;
            }
            catch { }
        }

        private void dgvTKDN_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietTk();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            db.TTDangNhaps.Remove(ttdn);
            db.SaveChanges();
            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ///

            dgvTKDN.DataSource = null;
            var tkdn = db.TTDangNhaps.ToList();
            dgvTKDN.DataSource = tkdn;
            LoadChiTietTk();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TTDangNhap tt = new TTDangNhap();
            if (txtEditThemTK.Text != "" && txtEditMK.Text != "" && txtEditQTC.Text != "")
            {
                tt.TaiKhoan = txtEditThemTK.Text;
                tt.MatKhau = FormLogin.HashPass(txtEditMK.Text);
                tt.QuyenTruyCap = txtEditQTC.Text;
                db.TTDangNhaps.Add(tt);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTKDN.DataSource = null;
                var t = db.TTDangNhaps.ToList();
                dgvTKDN.DataSource = t;
                LoadChiTietTk();
                txtEditThemTK.Text = "";
                txtEditMK.Text = "";
                txtEditQTC.Text = "";
            }
            else
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TTDangNhap t2 = db.TTDangNhaps.Where(p => p.MaDangNhap == ttdn.MaDangNhap).FirstOrDefault();
            if (txtSuaTK.Text != "") t2.TaiKhoan = txtSuaTK.Text;
            if (txtSuaMK.Text != "") t2.MatKhau = FormLogin.HashPass(txtSuaMK.Text);
            if (txtSuaQTC.Text != "") t2.QuyenTruyCap = txtSuaQTC.Text;
            db.SaveChanges();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //

            dgvTKDN.DataSource = null;
            var t = db.TTDangNhaps.ToList();
            dgvTKDN.DataSource = t;
            LoadChiTietTk();
            txtSuaTK.Text = "";
            txtSuaMK.Text = "";
            txtSuaQTC.Text = "";
        }
    }
}
