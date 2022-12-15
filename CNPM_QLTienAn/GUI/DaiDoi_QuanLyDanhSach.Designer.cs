﻿
namespace CNPM_QLTienAn.GUI
{
    partial class DaiDoi_QuanLyDanhSach
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNghi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoBuoiSang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colSoBuoiTrua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoBuoiToi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaHocVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtpNgayC = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit7 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit8 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit9 = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayC.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // colHoTen
            // 
            this.colHoTen.Caption = "Họ tên";
            this.colHoTen.FieldName = "HoTen";
            this.colHoTen.MinWidth = 25;
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.Visible = true;
            this.colHoTen.VisibleIndex = 0;
            this.colHoTen.Width = 94;
            // 
            // colTenDonVi
            // 
            this.colTenDonVi.Caption = "Đơn vị";
            this.colTenDonVi.FieldName = "TenDonVi";
            this.colTenDonVi.MinWidth = 25;
            this.colTenDonVi.Name = "colTenDonVi";
            this.colTenDonVi.Width = 94;
            // 
            // colNgayNghi
            // 
            this.colNgayNghi.FieldName = "NgayNghi";
            this.colNgayNghi.MinWidth = 25;
            this.colNgayNghi.Name = "colNgayNghi";
            this.colNgayNghi.Width = 94;
            // 
            // colSoBuoiSang
            // 
            this.colSoBuoiSang.Caption = "Nghỉ sáng";
            this.colSoBuoiSang.ColumnEdit = this.chkEdit;
            this.colSoBuoiSang.FieldName = "SoBuoiSang";
            this.colSoBuoiSang.MinWidth = 25;
            this.colSoBuoiSang.Name = "colSoBuoiSang";
            this.colSoBuoiSang.Visible = true;
            this.colSoBuoiSang.VisibleIndex = 1;
            this.colSoBuoiSang.Width = 94;
            // 
            // chkEdit
            // 
            this.chkEdit.AutoHeight = false;
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.ValueChecked = 1;
            this.chkEdit.ValueUnchecked = 0;
            // 
            // colSoBuoiTrua
            // 
            this.colSoBuoiTrua.Caption = "Nghỉ trưa";
            this.colSoBuoiTrua.ColumnEdit = this.chkEdit;
            this.colSoBuoiTrua.FieldName = "SoBuoiTrua";
            this.colSoBuoiTrua.MinWidth = 25;
            this.colSoBuoiTrua.Name = "colSoBuoiTrua";
            this.colSoBuoiTrua.Visible = true;
            this.colSoBuoiTrua.VisibleIndex = 2;
            this.colSoBuoiTrua.Width = 94;
            // 
            // colSoBuoiToi
            // 
            this.colSoBuoiToi.Caption = "Nghỉ tối";
            this.colSoBuoiToi.ColumnEdit = this.chkEdit;
            this.colSoBuoiToi.FieldName = "SoBuoiToi";
            this.colSoBuoiToi.MinWidth = 25;
            this.colSoBuoiToi.Name = "colSoBuoiToi";
            this.colSoBuoiToi.Visible = true;
            this.colSoBuoiToi.VisibleIndex = 3;
            this.colSoBuoiToi.Width = 94;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 753);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(675, 747);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách cắt cơm";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkEdit});
            this.gridControl1.Size = new System.Drawing.Size(675, 722);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaHocVien,
            this.colHoTen,
            this.colMaDonVi,
            this.colTenDonVi,
            this.colNgayNghi,
            this.colSoBuoiSang,
            this.colSoBuoiTrua,
            this.colSoBuoiToi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMaHocVien
            // 
            this.colMaHocVien.FieldName = "MaHocVien";
            this.colMaHocVien.MinWidth = 25;
            this.colMaHocVien.Name = "colMaHocVien";
            this.colMaHocVien.Width = 94;
            // 
            // colMaDonVi
            // 
            this.colMaDonVi.FieldName = "MaDonVi";
            this.colMaDonVi.MinWidth = 25;
            this.colMaDonVi.Name = "colMaDonVi";
            this.colMaDonVi.Width = 94;
            // 
            // dtpNgayC
            // 
            this.dtpNgayC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpNgayC.EditValue = null;
            this.dtpNgayC.Location = new System.Drawing.Point(28, 107);
            this.dtpNgayC.Name = "dtpNgayC";
            this.dtpNgayC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpNgayC.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpNgayC.Size = new System.Drawing.Size(223, 22);
            this.dtpNgayC.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sáng";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(134, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "/";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(134, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "/";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(134, 291);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "/";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Trưa";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tối";
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEdit1.EditValue = "70";
            this.textEdit1.Location = new System.Drawing.Point(28, 158);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit1.Size = new System.Drawing.Size(100, 22);
            this.textEdit1.TabIndex = 2;
            // 
            // textEdit2
            // 
            this.textEdit2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEdit2.EditValue = "70";
            this.textEdit2.Location = new System.Drawing.Point(28, 223);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.ReadOnly = true;
            this.textEdit2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit2.Size = new System.Drawing.Size(100, 22);
            this.textEdit2.TabIndex = 2;
            // 
            // textEdit7
            // 
            this.textEdit7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEdit7.EditValue = "80";
            this.textEdit7.Location = new System.Drawing.Point(151, 158);
            this.textEdit7.Name = "textEdit7";
            this.textEdit7.Properties.ReadOnly = true;
            this.textEdit7.Size = new System.Drawing.Size(100, 22);
            this.textEdit7.TabIndex = 2;
            // 
            // textEdit8
            // 
            this.textEdit8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEdit8.EditValue = "80";
            this.textEdit8.Location = new System.Drawing.Point(151, 223);
            this.textEdit8.Name = "textEdit8";
            this.textEdit8.Properties.ReadOnly = true;
            this.textEdit8.Size = new System.Drawing.Size(100, 22);
            this.textEdit8.TabIndex = 2;
            // 
            // textEdit3
            // 
            this.textEdit3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEdit3.EditValue = "70";
            this.textEdit3.Location = new System.Drawing.Point(28, 288);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.ReadOnly = true;
            this.textEdit3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit3.Size = new System.Drawing.Size(100, 22);
            this.textEdit3.TabIndex = 2;
            // 
            // textEdit9
            // 
            this.textEdit9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEdit9.EditValue = "80";
            this.textEdit9.Location = new System.Drawing.Point(151, 288);
            this.textEdit9.Name = "textEdit9";
            this.textEdit9.Properties.ReadOnly = true;
            this.textEdit9.Size = new System.Drawing.Size(100, 22);
            this.textEdit9.TabIndex = 2;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.textEdit9);
            this.groupControl2.Controls.Add(this.textEdit3);
            this.groupControl2.Controls.Add(this.textEdit8);
            this.groupControl2.Controls.Add(this.textEdit7);
            this.groupControl2.Controls.Add(this.textEdit2);
            this.groupControl2.Controls.Add(this.textEdit1);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.label11);
            this.groupControl2.Controls.Add(this.label10);
            this.groupControl2.Controls.Add(this.label9);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.dtpNgayC);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(684, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(287, 747);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Quân số ăn đại đội";
            // 
            // DaiDoi_QuanLyDanhSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DaiDoi_QuanLyDanhSach";
            this.Size = new System.Drawing.Size(981, 760);
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayC.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colHoTen;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNghi;
        private DevExpress.XtraGrid.Columns.GridColumn colSoBuoiSang;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colSoBuoiTrua;
        private DevExpress.XtraGrid.Columns.GridColumn colSoBuoiToi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaHocVien;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDonVi;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit textEdit9;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit8;
        private DevExpress.XtraEditors.TextEdit textEdit7;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtpNgayC;
    }
}
