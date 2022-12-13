﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM_QLTienAn.Models;
using System.Windows.Forms;


namespace CNPM_QLTienAn.GUI
{
    public partial class Admin_DonVi : DevExpress.XtraEditors.XtraUserControl
    {
        public Model_QLTA db = new Model_QLTA();
        public Admin_DonVi()
        {
            InitializeComponent();
        }
        public int madv;

        private void Admin_DonVi_Load(object sender, EventArgs e)
        {
            var dv = db.DonVis.ToList();
            dgvDV.DataSource = dv;
            LoadChiTietDonVi();
        }
        private void LoadChiTietDonVi()
        {
            try
            {
                madv = (int)dgvDV_View.GetFocusedRowCellValue("MaDonVi");
            }
            catch { }
            txtSuaMaDV.EditValue = madv;
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            DonVi dv1 = new DonVi();
            if (txtThemTenDV.Text == "")
            {
                MessageBox.Show("Tên học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dv1.TenDonVi = txtThemTenDV.Text;
                db.DonVis.Add(dv1);
                db.SaveChanges();
                dgvDV.DataSource = null;
                var dv = db.DonVis.ToList();
                dgvDV.DataSource = dv;
                txtThemTenDV.Text = "";
            }
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            DonVi dv1 = db.DonVis.Where(p => p.MaDonVi == madv).FirstOrDefault();
            if (txtSuaTenDV.Text != "") dv1.TenDonVi = txtSuaTenDV.Text;
            db.SaveChanges();
            dgvDV.DataSource = null;
            var dv = db.DonVis.ToList();
            dgvDV.DataSource = dv;
            LoadChiTietDonVi();
            txtSuaTenDV.Text = "";
        }

        private void dgvDV_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietDonVi();

        }
    }
}
