namespace Cau2_QuanLyNhaTro
{
    partial class FormKhachThue
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnGayLoiThu = new System.Windows.Forms.Button();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaKhach = new System.Windows.Forms.Label();
            this.txtMaKhach = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.grpGioiTinh = new System.Windows.Forms.GroupBox();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblTinh = new System.Windows.Forms.Label();
            this.cboTinh = new System.Windows.Forms.ComboBox();
            this.lblPhuongXa = new System.Windows.Forms.Label();
            this.cboPhuongXa = new System.Windows.Forms.ComboBox();
            this.txtPhuongXaManual = new System.Windows.Forms.TextBox();
            this.chkTamTru = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocPhong = new System.Windows.Forms.Label();
            this.cboLocPhong = new System.Windows.Forms.ComboBox();
            this.lblLocTinh = new System.Windows.Forms.Label();
            this.cboLocTinh = new System.Windows.Forms.ComboBox();
            this.btnBoLoc = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvKhachThue = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.grpGioiTinh.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachThue)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlTop.Controls.Add(this.btnGayLoiThu);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1040, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(436, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ NHÀ TRỌ (TÍCH HỢP OPEN-API)";
            // 
            // btnGayLoiThu
            // 
            this.btnGayLoiThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGayLoiThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnGayLoiThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGayLoiThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGayLoiThu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGayLoiThu.ForeColor = System.Drawing.Color.White;
            this.btnGayLoiThu.Location = new System.Drawing.Point(920, 10);
            this.btnGayLoiThu.Name = "btnGayLoiThu";
            this.btnGayLoiThu.Size = new System.Drawing.Size(108, 30);
            this.btnGayLoiThu.TabIndex = 1;
            this.btnGayLoiThu.Text = "Gây lỗi thử";
            this.btnGayLoiThu.UseVisualStyleBackColor = false;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblMaKhach);
            this.grpThongTin.Controls.Add(this.txtMaKhach);
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.grpGioiTinh);
            this.grpThongTin.Controls.Add(this.lblNgaySinh);
            this.grpThongTin.Controls.Add(this.dtpNgaySinh);
            this.grpThongTin.Controls.Add(this.lblSDT);
            this.grpThongTin.Controls.Add(this.txtSDT);
            this.grpThongTin.Controls.Add(this.lblPhong);
            this.grpThongTin.Controls.Add(this.cboPhong);
            this.grpThongTin.Controls.Add(this.lblTinh);
            this.grpThongTin.Controls.Add(this.cboTinh);
            this.grpThongTin.Controls.Add(this.lblPhuongXa);
            this.grpThongTin.Controls.Add(this.cboPhuongXa);
            this.grpThongTin.Controls.Add(this.txtPhuongXaManual);
            this.grpThongTin.Controls.Add(this.chkTamTru);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnLamMoi);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpThongTin.Location = new System.Drawing.Point(12, 56);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(1016, 205);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin khách thuê";
            // 
            // lblMaKhach
            // 
            this.lblMaKhach.AutoSize = true;
            this.lblMaKhach.Location = new System.Drawing.Point(15, 28);
            this.lblMaKhach.Name = "lblMaKhach";
            this.lblMaKhach.Size = new System.Drawing.Size(66, 17);
            this.lblMaKhach.TabIndex = 0;
            this.lblMaKhach.Text = "Mã khách:";
            // 
            // txtMaKhach
            // 
            this.txtMaKhach.Location = new System.Drawing.Point(88, 25);
            this.txtMaKhach.Name = "txtMaKhach";
            this.txtMaKhach.ReadOnly = true;
            this.txtMaKhach.Size = new System.Drawing.Size(70, 24);
            this.txtMaKhach.TabIndex = 1;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(175, 28);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(50, 17);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(232, 25);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 24);
            this.txtHoTen.TabIndex = 3;
            // 
            // grpGioiTinh
            // 
            this.grpGioiTinh.Controls.Add(this.radNam);
            this.grpGioiTinh.Controls.Add(this.radNu);
            this.grpGioiTinh.Location = new System.Drawing.Point(445, 12);
            this.grpGioiTinh.Name = "grpGioiTinh";
            this.grpGioiTinh.Size = new System.Drawing.Size(130, 42);
            this.grpGioiTinh.TabIndex = 4;
            this.grpGioiTinh.TabStop = false;
            this.grpGioiTinh.Text = "Giới tính";
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Checked = true;
            this.radNam.Location = new System.Drawing.Point(10, 16);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(54, 21);
            this.radNam.TabIndex = 0;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(70, 16);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(43, 21);
            this.radNu.TabIndex = 1;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(590, 28);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(69, 17);
            this.lblNgaySinh.TabIndex = 5;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(665, 25);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(120, 24);
            this.dtpNgaySinh.TabIndex = 6;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(800, 28);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(35, 17);
            this.lblSDT.TabIndex = 7;
            this.lblSDT.Text = "SĐT:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(842, 25);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(155, 24);
            this.txtSDT.TabIndex = 8;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(15, 68);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(68, 17);
            this.lblPhong.TabIndex = 9;
            this.lblPhong.Text = "Phòng trọ:";
            // 
            // cboPhong
            // 
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(88, 65);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(200, 25);
            this.cboPhong.TabIndex = 10;
            // 
            // lblTinh
            // 
            this.lblTinh.AutoSize = true;
            this.lblTinh.Location = new System.Drawing.Point(305, 68);
            this.lblTinh.Name = "lblTinh";
            this.lblTinh.Size = new System.Drawing.Size(73, 17);
            this.lblTinh.TabIndex = 11;
            this.lblTinh.Text = "Tỉnh/Thành:";
            // 
            // cboTinh
            // 
            this.cboTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinh.FormattingEnabled = true;
            this.cboTinh.Location = new System.Drawing.Point(384, 65);
            this.cboTinh.Name = "cboTinh";
            this.cboTinh.Size = new System.Drawing.Size(190, 25);
            this.cboTinh.TabIndex = 12;
            // 
            // lblPhuongXa
            // 
            this.lblPhuongXa.AutoSize = true;
            this.lblPhuongXa.Location = new System.Drawing.Point(590, 68);
            this.lblPhuongXa.Name = "lblPhuongXa";
            this.lblPhuongXa.Size = new System.Drawing.Size(76, 17);
            this.lblPhuongXa.TabIndex = 13;
            this.lblPhuongXa.Text = "Phường/Xã:";
            // 
            // cboPhuongXa
            // 
            this.cboPhuongXa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongXa.FormattingEnabled = true;
            this.cboPhuongXa.Location = new System.Drawing.Point(672, 65);
            this.cboPhuongXa.Name = "cboPhuongXa";
            this.cboPhuongXa.Size = new System.Drawing.Size(180, 25);
            this.cboPhuongXa.TabIndex = 14;
            // 
            // txtPhuongXaManual
            // 
            this.txtPhuongXaManual.Location = new System.Drawing.Point(672, 98);
            this.txtPhuongXaManual.Name = "txtPhuongXaManual";
            this.txtPhuongXaManual.PlaceholderText = "Nhập tay xã nếu mất mạng...";
            this.txtPhuongXaManual.Size = new System.Drawing.Size(180, 24);
            this.txtPhuongXaManual.TabIndex = 15;
            this.txtPhuongXaManual.Visible = false;
            // 
            // chkTamTru
            // 
            this.chkTamTru.AutoSize = true;
            this.chkTamTru.Location = new System.Drawing.Point(865, 67);
            this.chkTamTru.Name = "chkTamTru";
            this.chkTamTru.Size = new System.Drawing.Size(139, 21);
            this.chkTamTru.TabIndex = 16;
            this.chkTamTru.Text = "Đã đăng ký tạm trú";
            this.chkTamTru.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(88, 155);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 34);
            this.btnThem.TabIndex = 17;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(200, 155);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 34);
            this.btnSua.TabIndex = 18;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(312, 155);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 34);
            this.btnXoa.TabIndex = 19;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(424, 155);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 34);
            this.btnLamMoi.TabIndex = 20;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Controls.Add(this.lblTimKiem);
            this.grpTimKiem.Controls.Add(this.txtTimKiem);
            this.grpTimKiem.Controls.Add(this.lblLocPhong);
            this.grpTimKiem.Controls.Add(this.cboLocPhong);
            this.grpTimKiem.Controls.Add(this.lblLocTinh);
            this.grpTimKiem.Controls.Add(this.cboLocTinh);
            this.grpTimKiem.Controls.Add(this.btnBoLoc);
            this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpTimKiem.Location = new System.Drawing.Point(12, 267);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(1016, 65);
            this.grpTimKiem.TabIndex = 2;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm & Lọc dữ liệu";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(15, 28);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(107, 17);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm theo tên/SĐT:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(128, 25);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập họ tên hoặc SĐT...";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 24);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblLocPhong
            // 
            this.lblLocPhong.AutoSize = true;
            this.lblLocPhong.Location = new System.Drawing.Point(350, 28);
            this.lblLocPhong.Name = "lblLocPhong";
            this.lblLocPhong.Size = new System.Drawing.Size(73, 17);
            this.lblLocPhong.TabIndex = 2;
            this.lblLocPhong.Text = "Lọc phòng:";
            // 
            // cboLocPhong
            // 
            this.cboLocPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocPhong.FormattingEnabled = true;
            this.cboLocPhong.Location = new System.Drawing.Point(429, 25);
            this.cboLocPhong.Name = "cboLocPhong";
            this.cboLocPhong.Size = new System.Drawing.Size(160, 25);
            this.cboLocPhong.TabIndex = 3;
            // 
            // lblLocTinh
            // 
            this.lblLocTinh.AutoSize = true;
            this.lblLocTinh.Location = new System.Drawing.Point(610, 28);
            this.lblLocTinh.Name = "lblLocTinh";
            this.lblLocTinh.Size = new System.Drawing.Size(59, 17);
            this.lblLocTinh.TabIndex = 4;
            this.lblLocTinh.Text = "Lọc tỉnh:";
            // 
            // cboLocTinh
            // 
            this.cboLocTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTinh.FormattingEnabled = true;
            this.cboLocTinh.Location = new System.Drawing.Point(675, 25);
            this.cboLocTinh.Name = "cboLocTinh";
            this.cboLocTinh.Size = new System.Drawing.Size(180, 25);
            this.cboLocTinh.TabIndex = 5;
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBoLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBoLoc.ForeColor = System.Drawing.Color.White;
            this.btnBoLoc.Location = new System.Drawing.Point(890, 22);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(90, 30);
            this.btnBoLoc.TabIndex = 6;
            this.btnBoLoc.Text = "Bỏ lọc";
            this.btnBoLoc.UseVisualStyleBackColor = false;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvKhachThue);
            this.pnlGrid.Location = new System.Drawing.Point(12, 338);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1016, 290);
            this.pnlGrid.TabIndex = 3;
            // 
            // dgvKhachThue
            // 
            this.dgvKhachThue.AllowUserToAddRows = false;
            this.dgvKhachThue.AllowUserToDeleteRows = false;
            this.dgvKhachThue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachThue.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhachThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachThue.Location = new System.Drawing.Point(0, 0);
            this.dgvKhachThue.MultiSelect = false;
            this.dgvKhachThue.Name = "dgvKhachThue";
            this.dgvKhachThue.ReadOnly = true;
            this.dgvKhachThue.RowHeadersWidth = 51;
            this.dgvKhachThue.RowTemplate.Height = 29;
            this.dgvKhachThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachThue.Size = new System.Drawing.Size(1016, 290);
            this.dgvKhachThue.TabIndex = 0;
            // 
            // FormKhachThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormKhachThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách thuê phòng trọ";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpGioiTinh.ResumeLayout(false);
            this.grpGioiTinh.PerformLayout();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachThue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnGayLoiThu;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaKhach;
        private System.Windows.Forms.TextBox txtMaKhach;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.GroupBox grpGioiTinh;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblTinh;
        private System.Windows.Forms.ComboBox cboTinh;
        private System.Windows.Forms.Label lblPhuongXa;
        private System.Windows.Forms.ComboBox cboPhuongXa;
        private System.Windows.Forms.TextBox txtPhuongXaManual;
        private System.Windows.Forms.CheckBox chkTamTru;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLocPhong;
        private System.Windows.Forms.ComboBox cboLocPhong;
        private System.Windows.Forms.Label lblLocTinh;
        private System.Windows.Forms.ComboBox cboLocTinh;
        private System.Windows.Forms.Button btnBoLoc;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvKhachThue;
    }
}
