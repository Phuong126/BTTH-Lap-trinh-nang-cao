namespace QuanLySinhVien
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dtpNgaySinh = new DateTimePicker();
            txtMaSV = new TextBox();
            txtEmail = new TextBox();
            txtDienThoai = new TextBox();
            txtHoTen = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            radNam = new RadioButton();
            radNu = new RadioButton();
            cboLopHoc = new ComboBox();
            cboTrangThai = new ComboBox();
            btnXoa = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnLamMoi = new Button();
            label11 = new Label();
            nudDiem = new NumericUpDown();
            dgvSinhVien = new DataGridView();
            txtTim = new TextBox();
            label12 = new Label();
            cboLop = new ComboBox();
            label13 = new Label();
            nudDiemTu = new NumericUpDown();
            btnHienThiAll = new Button();
            btnTim = new Button();
            label14 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudDiem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDiemTu).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 0;
            label1.Text = "Thong tin sinh vien";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 1;
            label2.Text = "Ma SV";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 2;
            label3.Text = "Ngay sinh";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 104);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(97, 68);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(125, 27);
            dtpNgaySinh.TabIndex = 1;
            dtpNgaySinh.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(97, 37);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(125, 27);
            txtMaSV.TabIndex = 0;
            txtMaSV.TextChanged += textBox1_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(97, 101);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 2;
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(358, 99);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(125, 27);
            txtDienThoai.TabIndex = 6;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(358, 35);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(125, 27);
            txtHoTen.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(273, 102);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 9;
            label5.Text = "Dien thoai";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(273, 71);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 8;
            label6.Text = "Gioi tinh";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(273, 42);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 7;
            label7.Text = "Ho ten";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(537, 102);
            label8.Name = "label8";
            label8.Size = new Size(75, 20);
            label8.TabIndex = 15;
            label8.Text = "Trang thai";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(537, 71);
            label9.Name = "label9";
            label9.Size = new Size(45, 20);
            label9.TabIndex = 14;
            label9.Text = "Diem";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(537, 42);
            label10.Name = "label10";
            label10.Size = new Size(62, 20);
            label10.TabIndex = 13;
            label10.Text = "Lop hoc";
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Location = new Point(358, 71);
            radNam.Name = "radNam";
            radNam.Size = new Size(62, 24);
            radNam.TabIndex = 4;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(434, 71);
            radNu.Name = "radNu";
            radNu.Size = new Size(49, 24);
            radNu.TabIndex = 5;
            radNu.TabStop = true;
            radNu.Text = "Nu";
            radNu.UseVisualStyleBackColor = true;
            // 
            // cboLopHoc
            // 
            cboLopHoc.FormattingEnabled = true;
            cboLopHoc.Location = new Point(622, 35);
            cboLopHoc.Name = "cboLopHoc";
            cboLopHoc.Size = new Size(125, 28);
            cboLopHoc.TabIndex = 7;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(622, 96);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(125, 28);
            cboTrangThai.TabIndex = 9;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(553, 130);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xoa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(353, 130);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 10;
            btnThem.Text = "Them";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(453, 130);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sua";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(653, 130);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 13;
            btnLamMoi.Text = "Lam moi";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 172);
            label11.Name = "label11";
            label11.Size = new Size(61, 20);
            label11.TabIndex = 27;
            label11.Text = "Tu khoa";
            // 
            // nudDiem
            // 
            nudDiem.Location = new Point(622, 66);
            nudDiem.Name = "nudDiem";
            nudDiem.Size = new Size(125, 27);
            nudDiem.TabIndex = 8;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(12, 240);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.Size = new Size(782, 206);
            dgvSinhVien.TabIndex = 29;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(97, 169);
            txtTim.Name = "txtTim";
            txtTim.PlaceholderText = "Ho ten, ma sv, ...";
            txtTim.Size = new Size(170, 27);
            txtTim.TabIndex = 30;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(273, 172);
            label12.Name = "label12";
            label12.Size = new Size(34, 20);
            label12.TabIndex = 31;
            label12.Text = "Lop";
            label12.Click += label12_Click;
            // 
            // cboLop
            // 
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(313, 168);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(125, 28);
            cboLop.TabIndex = 32;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(449, 172);
            label13.Name = "label13";
            label13.Size = new Size(62, 20);
            label13.TabIndex = 33;
            label13.Text = "Diem tu";
            // 
            // nudDiemTu
            // 
            nudDiemTu.Location = new Point(517, 170);
            nudDiemTu.Name = "nudDiemTu";
            nudDiemTu.Size = new Size(41, 27);
            nudDiemTu.TabIndex = 34;
            // 
            // btnHienThiAll
            // 
            btnHienThiAll.Location = new Point(670, 169);
            btnHienThiAll.Name = "btnHienThiAll";
            btnHienThiAll.Size = new Size(94, 29);
            btnHienThiAll.TabIndex = 36;
            btnHienThiAll.Text = "Hien thi tat ca";
            btnHienThiAll.UseVisualStyleBackColor = true;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(570, 169);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 29);
            btnTim.TabIndex = 35;
            btnTim.Text = "Tim kiem";
            btnTim.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(15, 217);
            label14.Name = "label14";
            label14.Size = new Size(138, 20);
            label14.TabIndex = 37;
            label14.Text = "Danh sach sinh vien";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label14);
            Controls.Add(btnHienThiAll);
            Controls.Add(btnTim);
            Controls.Add(nudDiemTu);
            Controls.Add(label13);
            Controls.Add(cboLop);
            Controls.Add(label12);
            Controls.Add(txtTim);
            Controls.Add(dgvSinhVien);
            Controls.Add(nudDiem);
            Controls.Add(label11);
            Controls.Add(btnLamMoi);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(cboTrangThai);
            Controls.Add(cboLopHoc);
            Controls.Add(radNu);
            Controls.Add(radNam);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(txtDienThoai);
            Controls.Add(txtHoTen);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(txtEmail);
            Controls.Add(txtMaSV);
            Controls.Add(dtpNgaySinh);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudDiem).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDiemTu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtMaSV;
        private TextBox txtEmail;
        private TextBox txtDienThoai;
        private TextBox txtHoTen;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private RadioButton radNam;
        private RadioButton radNu;
        private ComboBox cboLopHoc;
        private ComboBox cboTrangThai;
        private Button btnXoa;
        private Button btnThem;
        private Button btnSua;
        private Button btnLamMoi;
        private Label label11;
        private NumericUpDown nudDiem;
        private DataGridView dgvSinhVien;
        private TextBox txtTim;
        private Label label12;
        private ComboBox cboLop;
        private Label label13;
        private NumericUpDown nudDiemTu;
        private Button btnHienThiAll;
        private Button btnTim;
        private Label label14;
    }
}
