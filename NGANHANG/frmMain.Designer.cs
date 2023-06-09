﻿namespace NGANHANG
{
    partial class form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.btnCGR = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDSNV = new DevExpress.XtraBars.BarButtonItem();
            this.btnDSKH = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnTKKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongKeGD = new DevExpress.XtraBars.BarButtonItem();
            this.btnDSTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.btnTKNH = new DevExpress.XtraBars.BarButtonItem();
            this.btnBCDSKH = new DevExpress.XtraBars.BarButtonItem();
            this.btnLSGD = new DevExpress.XtraBars.BarButtonItem();
            this.rbHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribNghiepVu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribTienIch = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.stsThongTin = new System.Windows.Forms.StatusStrip();
            this.MANV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HOTEN = new System.Windows.Forms.ToolStripStatusLabel();
            this.NHOM = new System.Windows.Forms.ToolStripStatusLabel();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.stsThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(71);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnDangXuat,
            this.btnCGR,
            this.barButtonItem1,
            this.btnDSNV,
            this.btnDSKH,
            this.btnDangNhap,
            this.btnThoat,
            this.btnTaoLogin,
            this.btnTKKhachHang,
            this.btnThongKeGD,
            this.btnDSTaiKhoan,
            this.btnTKNH,
            this.btnBCDSKH,
            this.btnLSGD});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(8);
            this.ribbon.MaxItemId = 17;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 805;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbHeThong,
            this.ribDanhMuc,
            this.ribNghiepVu,
            this.ribBaoCao,
            this.ribTienIch});
            this.ribbon.Size = new System.Drawing.Size(1378, 195);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Caption = "Đăng xuất";
            this.btnDangXuat.Id = 1;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangXuat_ItemClick);
            // 
            // btnCGR
            // 
            this.btnCGR.Caption = "Chuyển-Gửi rút tiền";
            this.btnCGR.Id = 2;
            this.btnCGR.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCGR.ImageOptions.SvgImage")));
            this.btnCGR.Name = "btnCGR";
            this.btnCGR.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCGR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCGR_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnDSNV
            // 
            this.btnDSNV.Caption = "Danh sách nhân viên";
            this.btnDSNV.Id = 6;
            this.btnDSNV.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDSNV.ImageOptions.SvgImage")));
            this.btnDSNV.Name = "btnDSNV";
            this.btnDSNV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSNV_ItemClick);
            // 
            // btnDSKH
            // 
            this.btnDSKH.Caption = "Danh sách khách hàng";
            this.btnDSKH.Id = 7;
            this.btnDSKH.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDSKH.ImageOptions.SvgImage")));
            this.btnDSKH.Name = "btnDSKH";
            this.btnDSKH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSKH_ItemClick);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Caption = "Đăng nhập";
            this.btnDangNhap.Id = 8;
            this.btnDangNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDangNhap.ImageOptions.SvgImage")));
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangNhap_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 9;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // btnTaoLogin
            // 
            this.btnTaoLogin.Caption = "Tạo tài khoản";
            this.btnTaoLogin.Id = 10;
            this.btnTaoLogin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaoLogin.ImageOptions.SvgImage")));
            this.btnTaoLogin.Name = "btnTaoLogin";
            this.btnTaoLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoLogin_ItemClick);
            // 
            // btnTKKhachHang
            // 
            this.btnTKKhachHang.Caption = "Tài khoản hệ thông";
            this.btnTKKhachHang.Id = 11;
            this.btnTKKhachHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTKKhachHang.ImageOptions.Image")));
            this.btnTKKhachHang.Name = "btnTKKhachHang";
            this.btnTKKhachHang.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTKKhachHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTKKhachHang_ItemClick);
            // 
            // btnThongKeGD
            // 
            this.btnThongKeGD.Caption = "Thống kê giao dịch";
            this.btnThongKeGD.Id = 12;
            this.btnThongKeGD.ImageOptions.SvgImage = global::NGANHANG.Properties.Resources.business_money;
            this.btnThongKeGD.Name = "btnThongKeGD";
            this.btnThongKeGD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongKeGD_ItemClick);
            // 
            // btnDSTaiKhoan
            // 
            this.btnDSTaiKhoan.Caption = "Danh sách tài khoản";
            this.btnDSTaiKhoan.Id = 13;
            this.btnDSTaiKhoan.ImageOptions.SvgImage = global::NGANHANG.Properties.Resources.financial;
            this.btnDSTaiKhoan.Name = "btnDSTaiKhoan";
            this.btnDSTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSTaiKhoan_ItemClick);
            // 
            // btnTKNH
            // 
            this.btnTKNH.Caption = "Tài khoản ngân hàng";
            this.btnTKNH.Id = 14;
            this.btnTKNH.ImageOptions.SvgImage = global::NGANHANG.Properties.Resources.business_bank;
            this.btnTKNH.Name = "btnTKNH";
            this.btnTKNH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTKNH_ItemClick);
            // 
            // btnBCDSKH
            // 
            this.btnBCDSKH.Caption = "Danh sách khách hàng";
            this.btnBCDSKH.Id = 15;
            this.btnBCDSKH.ImageOptions.SvgImage = global::NGANHANG.Properties.Resources.bo_employee;
            this.btnBCDSKH.Name = "btnBCDSKH";
            this.btnBCDSKH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btnLSGD
            // 
            this.btnLSGD.Caption = "Lịch sử giao dịch";
            this.btnLSGD.Id = 16;
            this.btnLSGD.ImageOptions.SvgImage = global::NGANHANG.Properties.Resources.bo_audit_changehistory;
            this.btnLSGD.Name = "btnLSGD";
            this.btnLSGD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLSGD_ItemClick);
            // 
            // rbHeThong
            // 
            this.rbHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.rbHeThong.Name = "rbHeThong";
            this.rbHeThong.Text = "Hệ thống";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnDangNhap);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnThoat);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnTaoLogin);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribDanhMuc
            // 
            this.ribDanhMuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup4});
            this.ribDanhMuc.Name = "ribDanhMuc";
            this.ribDanhMuc.Text = "Danh mục";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPageGroup1.ImageOptions.Image")));
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDSNV);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Nhân viên";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDSKH);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnTKKhachHang);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnTKNH);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Khách hàng";
            // 
            // ribNghiepVu
            // 
            this.ribNghiepVu.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribNghiepVu.AppearanceSelected.Options.UseFont = true;
            this.ribNghiepVu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribNghiepVu.Name = "ribNghiepVu";
            this.ribNghiepVu.Text = "Nghiệp vụ";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCGR);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Giao dịch";
            // 
            // ribBaoCao
            // 
            this.ribBaoCao.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribBaoCao.AppearanceSelected.Options.UseFont = true;
            this.ribBaoCao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup6});
            this.ribBaoCao.Name = "ribBaoCao";
            this.ribBaoCao.Text = "Báo cáo";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnThongKeGD);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDSTaiKhoan);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Tài khoản";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnBCDSKH);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Khách hàng";
            // 
            // ribTienIch
            // 
            this.ribTienIch.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup7});
            this.ribTienIch.Name = "ribTienIch";
            this.ribTienIch.Text = "Tiện ích";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnLSGD);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.btnDangXuat);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 783);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(8);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1378, 30);
            // 
            // stsThongTin
            // 
            this.stsThongTin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsThongTin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MANV,
            this.HOTEN,
            this.NHOM});
            this.stsThongTin.Location = new System.Drawing.Point(0, 757);
            this.stsThongTin.Name = "stsThongTin";
            this.stsThongTin.Size = new System.Drawing.Size(1378, 26);
            this.stsThongTin.TabIndex = 2;
            this.stsThongTin.Text = "statusStrip1";
            // 
            // MANV
            // 
            this.MANV.Name = "MANV";
            this.MANV.Size = new System.Drawing.Size(52, 20);
            this.MANV.Text = "MANV";
            // 
            // HOTEN
            // 
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Size = new System.Drawing.Size(57, 20);
            this.HOTEN.Text = "HOTEN";
            // 
            // NHOM
            // 
            this.NHOM.Name = "NHOM";
            this.NHOM.Size = new System.Drawing.Size(55, 20);
            this.NHOM.Text = "NHOM";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 813);
            this.Controls.Add(this.stsThongTin);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "form";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Ngân hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.stsThongTin.ResumeLayout(false);
            this.stsThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribDanhMuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribNghiepVu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.StatusStrip stsThongTin;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        public System.Windows.Forms.ToolStripStatusLabel MANV;
        public System.Windows.Forms.ToolStripStatusLabel HOTEN;
        public System.Windows.Forms.ToolStripStatusLabel NHOM;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.BarButtonItem btnCGR;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnDSNV;
        private DevExpress.XtraBars.BarButtonItem btnDSKH;
        private DevExpress.XtraBars.BarButtonItem btnDangNhap;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem btnTaoLogin;
        private DevExpress.XtraBars.BarButtonItem btnTKKhachHang;
        private DevExpress.XtraBars.BarButtonItem btnThongKeGD;
        private DevExpress.XtraBars.BarButtonItem btnDSTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btnTKNH;
        private DevExpress.XtraBars.BarButtonItem btnBCDSKH;
        private DevExpress.XtraBars.BarButtonItem btnLSGD;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribTienIch;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
    }
}