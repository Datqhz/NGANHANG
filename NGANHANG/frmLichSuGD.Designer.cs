namespace NGANHANG
{
    partial class frmLichSuGD
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbSTK = new System.Windows.Forms.ComboBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.dteDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.dteTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvLSGD = new System.Windows.Forms.DataGridView();
            this.SDDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiGD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTienGD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDCuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSDC = new System.Windows.Forms.Label();
            this.lblSDD = new System.Windows.Forms.Label();
            this.txtSDC = new DevExpress.XtraEditors.TextEdit();
            this.txtSDD = new DevExpress.XtraEditors.TextEdit();
            this.label_1 = new System.Windows.Forms.Label();
            this.label_2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSGD)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số tài khoản";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmbSTK);
            this.panelControl1.Controls.Add(this.btnXem);
            this.panelControl1.Controls.Add(this.dteDenNgay);
            this.panelControl1.Controls.Add(this.dteTuNgay);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1226, 156);
            this.panelControl1.TabIndex = 1;
            // 
            // cmbSTK
            // 
            this.cmbSTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSTK.FormattingEnabled = true;
            this.cmbSTK.Location = new System.Drawing.Point(360, 45);
            this.cmbSTK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSTK.Name = "cmbSTK";
            this.cmbSTK.Size = new System.Drawing.Size(570, 24);
            this.cmbSTK.TabIndex = 7;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.White;
            this.btnXem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Location = new System.Drawing.Point(998, 64);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(94, 45);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dteDenNgay
            // 
            this.dteDenNgay.EditValue = null;
            this.dteDenNgay.Location = new System.Drawing.Point(732, 106);
            this.dteDenNgay.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dteDenNgay.Name = "dteDenNgay";
            this.dteDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDenNgay.Properties.Appearance.Options.UseFont = true;
            this.dteDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDenNgay.Size = new System.Drawing.Size(199, 24);
            this.dteDenNgay.TabIndex = 4;
            // 
            // dteTuNgay
            // 
            this.dteTuNgay.EditValue = null;
            this.dteTuNgay.Location = new System.Drawing.Point(360, 108);
            this.dteTuNgay.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dteTuNgay.Name = "dteTuNgay";
            this.dteTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTuNgay.Properties.Appearance.Options.UseFont = true;
            this.dteTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteTuNgay.Size = new System.Drawing.Size(215, 24);
            this.dteTuNgay.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(610, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(212, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvLSGD);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1226, 598);
            this.panel1.TabIndex = 2;
            // 
            // dgvLSGD
            // 
            this.dgvLSGD.BackgroundColor = System.Drawing.Color.White;
            this.dgvLSGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLSGD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SDDau,
            this.NgayGD,
            this.LoaiGD,
            this.SoTienGD,
            this.SDCuoi});
            this.dgvLSGD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLSGD.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvLSGD.Location = new System.Drawing.Point(0, 64);
            this.dgvLSGD.Name = "dgvLSGD";
            this.dgvLSGD.RowHeadersWidth = 50;
            this.dgvLSGD.RowTemplate.Height = 24;
            this.dgvLSGD.Size = new System.Drawing.Size(1226, 534);
            this.dgvLSGD.TabIndex = 2;
            // 
            // SDDau
            // 
            this.SDDau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SDDau.FillWeight = 200F;
            this.SDDau.HeaderText = "Số dư đầu";
            this.SDDau.MinimumWidth = 6;
            this.SDDau.Name = "SDDau";
            this.SDDau.ReadOnly = true;
            // 
            // NgayGD
            // 
            this.NgayGD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayGD.FillWeight = 200F;
            this.NgayGD.HeaderText = "Ngày giao dịch";
            this.NgayGD.MinimumWidth = 6;
            this.NgayGD.Name = "NgayGD";
            this.NgayGD.ReadOnly = true;
            // 
            // LoaiGD
            // 
            this.LoaiGD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LoaiGD.FillWeight = 200F;
            this.LoaiGD.HeaderText = "Loại giao dịch";
            this.LoaiGD.MinimumWidth = 6;
            this.LoaiGD.Name = "LoaiGD";
            this.LoaiGD.ReadOnly = true;
            // 
            // SoTienGD
            // 
            this.SoTienGD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoTienGD.FillWeight = 200F;
            this.SoTienGD.HeaderText = "Số tiền";
            this.SoTienGD.MinimumWidth = 6;
            this.SoTienGD.Name = "SoTienGD";
            this.SoTienGD.ReadOnly = true;
            // 
            // SDCuoi
            // 
            this.SDCuoi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SDCuoi.FillWeight = 200F;
            this.SDCuoi.HeaderText = "Số dư cuối";
            this.SDCuoi.MinimumWidth = 6;
            this.SDCuoi.Name = "SDCuoi";
            this.SDCuoi.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblSDC);
            this.panel2.Controls.Add(this.lblSDD);
            this.panel2.Controls.Add(this.txtSDC);
            this.panel2.Controls.Add(this.txtSDD);
            this.panel2.Controls.Add(this.label_1);
            this.panel2.Controls.Add(this.label_2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1226, 64);
            this.panel2.TabIndex = 1;
            // 
            // lblSDC
            // 
            this.lblSDC.AutoSize = true;
            this.lblSDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDC.Location = new System.Drawing.Point(690, 22);
            this.lblSDC.Name = "lblSDC";
            this.lblSDC.Size = new System.Drawing.Size(0, 18);
            this.lblSDC.TabIndex = 5;
            // 
            // lblSDD
            // 
            this.lblSDD.AutoSize = true;
            this.lblSDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDD.Location = new System.Drawing.Point(195, 22);
            this.lblSDD.Name = "lblSDD";
            this.lblSDD.Size = new System.Drawing.Size(0, 18);
            this.lblSDD.TabIndex = 4;
            // 
            // txtSDC
            // 
            this.txtSDC.Location = new System.Drawing.Point(798, 21);
            this.txtSDC.Name = "txtSDC";
            this.txtSDC.Properties.DisplayFormat.FormatString = "n0";
            this.txtSDC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSDC.Properties.ReadOnly = true;
            this.txtSDC.Size = new System.Drawing.Size(229, 22);
            this.txtSDC.TabIndex = 3;
            // 
            // txtSDD
            // 
            this.txtSDD.Location = new System.Drawing.Point(309, 19);
            this.txtSDD.Name = "txtSDD";
            this.txtSDD.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDD.Properties.Appearance.Options.UseFont = true;
            this.txtSDD.Properties.DisplayFormat.FormatString = "n0";
            this.txtSDD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSDD.Properties.ReadOnly = true;
            this.txtSDD.Size = new System.Drawing.Size(208, 24);
            this.txtSDD.TabIndex = 2;
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_1.Location = new System.Drawing.Point(602, 22);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(82, 18);
            this.label_1.TabIndex = 1;
            this.label_1.Text = "Số dư ngày";
            // 
            // label_2
            // 
            this.label_2.AutoSize = true;
            this.label_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_2.Location = new System.Drawing.Point(107, 22);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(82, 18);
            this.label_2.TabIndex = 0;
            this.label_2.Text = "Số dư ngày";
            // 
            // frmLichSuGD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 754);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmLichSuGD";
            this.Text = "Thống kê giao dịch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongKeGD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSGD)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDD.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnXem;
        private DevExpress.XtraEditors.DateEdit dteDenNgay;
        private DevExpress.XtraEditors.DateEdit dteTuNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvLSGD;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit txtSDC;
        private DevExpress.XtraEditors.TextEdit txtSDD;
        private System.Windows.Forms.Label label_1;
        private System.Windows.Forms.Label label_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiGD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTienGD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDCuoi;
        private System.Windows.Forms.Label lblSDC;
        private System.Windows.Forms.Label lblSDD;
        private System.Windows.Forms.ComboBox cmbSTK;
    }
}