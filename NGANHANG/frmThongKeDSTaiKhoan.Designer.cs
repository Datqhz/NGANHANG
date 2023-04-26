namespace NGANHANG
{
    partial class frmThongKeDSTaiKhoan
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXem = new System.Windows.Forms.Button();
            this.dteDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.dteTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.robOne = new System.Windows.Forms.RadioButton();
            this.robAll = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlChiNhanh = new System.Windows.Forms.Panel();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDS = new System.Windows.Forms.DataGridView();
            this.stk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.macn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbltest = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlChiNhanh.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbltest);
            this.panel1.Controls.Add(this.btnXem);
            this.panel1.Controls.Add(this.dteDenNgay);
            this.panel1.Controls.Add(this.dteTuNgay);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pnlChiNhanh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 176);
            this.panel1.TabIndex = 0;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.White;
            this.btnXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Location = new System.Drawing.Point(858, 100);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(113, 28);
            this.btnXem.TabIndex = 5;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dteDenNgay
            // 
            this.dteDenNgay.EditValue = null;
            this.dteDenNgay.Location = new System.Drawing.Point(577, 103);
            this.dteDenNgay.Name = "dteDenNgay";
            this.dteDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDenNgay.Properties.Appearance.Options.UseFont = true;
            this.dteDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDenNgay.Size = new System.Drawing.Size(203, 24);
            this.dteDenNgay.TabIndex = 4;
            // 
            // dteTuNgay
            // 
            this.dteTuNgay.EditValue = null;
            this.dteTuNgay.Location = new System.Drawing.Point(242, 104);
            this.dteTuNgay.Name = "dteTuNgay";
            this.dteTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTuNgay.Properties.Appearance.Options.UseFont = true;
            this.dteTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteTuNgay.Size = new System.Drawing.Size(194, 24);
            this.dteTuNgay.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.robOne);
            this.panel3.Controls.Add(this.robAll);
            this.panel3.Location = new System.Drawing.Point(232, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 51);
            this.panel3.TabIndex = 2;
            // 
            // robOne
            // 
            this.robOne.AutoSize = true;
            this.robOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.robOne.Location = new System.Drawing.Point(118, 14);
            this.robOne.Name = "robOne";
            this.robOne.Size = new System.Drawing.Size(122, 22);
            this.robOne.TabIndex = 1;
            this.robOne.TabStop = true;
            this.robOne.Text = "Một chi nhánh";
            this.robOne.UseVisualStyleBackColor = true;
            this.robOne.CheckedChanged += new System.EventHandler(this.robAll_CheckedChanged);
            // 
            // robAll
            // 
            this.robAll.AutoSize = true;
            this.robAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.robAll.Location = new System.Drawing.Point(20, 14);
            this.robAll.Name = "robAll";
            this.robAll.Size = new System.Drawing.Size(70, 22);
            this.robAll.TabIndex = 0;
            this.robAll.TabStop = true;
            this.robAll.Text = "Tất cả";
            this.robAll.UseVisualStyleBackColor = true;
            this.robAll.CheckedChanged += new System.EventHandler(this.robAll_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(492, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Đến ngày";
            // 
            // pnlChiNhanh
            // 
            this.pnlChiNhanh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChiNhanh.Controls.Add(this.cmbChiNhanh);
            this.pnlChiNhanh.Controls.Add(this.label1);
            this.pnlChiNhanh.Location = new System.Drawing.Point(610, 12);
            this.pnlChiNhanh.Name = "pnlChiNhanh";
            this.pnlChiNhanh.Size = new System.Drawing.Size(416, 51);
            this.pnlChiNhanh.TabIndex = 1;
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(119, 14);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(242, 26);
            this.cmbChiNhanh.TabIndex = 1;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(173, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Xem";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1271, 579);
            this.panel2.TabIndex = 1;
            // 
            // dgvDS
            // 
            this.dgvDS.BackgroundColor = System.Drawing.Color.White;
            this.dgvDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stk,
            this.cmnd,
            this.sodu,
            this.macn});
            this.dgvDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDS.Location = new System.Drawing.Point(0, 0);
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.RowHeadersWidth = 51;
            this.dgvDS.RowTemplate.Height = 24;
            this.dgvDS.Size = new System.Drawing.Size(1271, 579);
            this.dgvDS.TabIndex = 0;
            // 
            // stk
            // 
            this.stk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stk.HeaderText = "Số tài khoản";
            this.stk.MinimumWidth = 6;
            this.stk.Name = "stk";
            this.stk.ReadOnly = true;
            // 
            // cmnd
            // 
            this.cmnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnd.HeaderText = "CMND";
            this.cmnd.MinimumWidth = 6;
            this.cmnd.Name = "cmnd";
            this.cmnd.ReadOnly = true;
            // 
            // sodu
            // 
            this.sodu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sodu.HeaderText = "Số dư";
            this.sodu.MinimumWidth = 6;
            this.sodu.Name = "sodu";
            this.sodu.ReadOnly = true;
            // 
            // macn
            // 
            this.macn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.macn.HeaderText = "Mã chi nhánh";
            this.macn.MinimumWidth = 6;
            this.macn.Name = "macn";
            this.macn.ReadOnly = true;
            // 
            // lbltest
            // 
            this.lbltest.AutoSize = true;
            this.lbltest.Location = new System.Drawing.Point(1119, 89);
            this.lbltest.Name = "lbltest";
            this.lbltest.Size = new System.Drawing.Size(44, 16);
            this.lbltest.TabIndex = 6;
            this.lbltest.Text = "label5";
            // 
            // frmThongKeDSTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 755);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmThongKeDSTaiKhoan";
            this.Text = "Thống kê DS tài khoản";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongKeDSTaiKhoan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlChiNhanh.ResumeLayout(false);
            this.pnlChiNhanh.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton robOne;
        private System.Windows.Forms.RadioButton robAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlChiNhanh;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXem;
        private DevExpress.XtraEditors.DateEdit dteDenNgay;
        private DevExpress.XtraEditors.DateEdit dteTuNgay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn stk;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn sodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn macn;
        private System.Windows.Forms.Label lbltest;
    }
}