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

namespace CNPM_QLTienAn
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        Model_QLTA db = new Model_QLTA();

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if(username == "")
            {
                MessageBox.Show("Hãy nhập tên đăng nhập !", "Error");
                return;
            }
            if (password == "")
            {
                MessageBox.Show("Hãy nhập mật khẩu !", "Error");
                return;
            }
            string hashedPass = HashPass(txtPassword.Text);

            if (db.TTDangNhaps.Any(s => s.TaiKhoan == txtUsername.Text && s.MatKhau == hashedPass))
            {
                TTDangNhap acc = db.TTDangNhaps.Where(s => s.TaiKhoan == txtUsername.Text && s.MatKhau == hashedPass).FirstOrDefault();
                CanBo cb = db.CanBoes.Where(s => s.MaDangNhap == acc.MaDangNhap).FirstOrDefault();

                FormMain fm;
                if (cb == null)
                {
                    fm = new FormMain(acc.QuyenTruyCap);
                }
                else fm = new FormMain(cb.MaCanBo, acc.QuyenTruyCap);

                this.Hide();
                fm.ShowDialog();
                if (!fm.IsDisposed)
                {
                    txtPassword.Text = "";
                    txtUsername.Focus();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }

        }


        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        public static string HashPass(string pass)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}