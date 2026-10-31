namespace BTTH8
{
    partial class FrmQuanLySach
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblCopyCount = new System.Windows.Forms.Label();
            this.txtCopies = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.grpBooks = new System.Windows.Forms.GroupBox();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.grpCopies = new System.Windows.Forms.GroupBox();
            this.lblCopies = new System.Windows.Forms.Label();
            this.dgvCopies = new System.Windows.Forms.DataGridView();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnCopyAdd = new System.Windows.Forms.Button();
            this.btnCopyUpdate = new System.Windows.Forms.Button();
            this.btnCopyDelete = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlHeader.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.grpBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.grpCopies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopies)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(222, 238, 250);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 72);
            this.pnlHeader.TabIndex = 0;
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 100, 160);
            this.lblTitle.Location = new System.Drawing.Point(14, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "QUẢN LÝ ĐẦU SÁCH VÀ BẢN SAO";
            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(70, 90, 110);
            this.lblSubtitle.Location = new System.Drawing.Point(16, 44);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Tra cứu, cập nhật thông tin đầu sách và quản lý bản sao";

            // lblKeyword
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKeyword.Location = new System.Drawing.Point(12, 90);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Text = "Từ khóa tra";
            // txtKeyword
            this.txtKeyword.Location = new System.Drawing.Point(110, 86);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.PlaceholderText = "Mã sách, tên sách, tác giả...";
            this.txtKeyword.Size = new System.Drawing.Size(300, 25);
            this.txtKeyword.TabIndex = 1;
            // lblFilter
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilter.Location = new System.Drawing.Point(440, 90);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Text = "Thể loại";
            // cboFilter
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.Location = new System.Drawing.Point(510, 86);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(220, 25);
            this.cboFilter.TabIndex = 2;
            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 120, 190);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(740, 83);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(850, 83);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 32);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;

            // grpInfo
            this.grpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpInfo.Location = new System.Drawing.Point(8, 125);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(340, 535);
            this.grpInfo.TabIndex = 5;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông tin đầu sách";
            this.grpInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblId, this.txtId, this.lblBookTitle, this.txtTitle, this.lblAuthor, this.txtAuthor,
                this.lblPublisher, this.txtPublisher, this.lblCategory, this.cboCategory,
                this.lblPrice, this.numPrice, this.lblYear, this.numYear, this.lblCopyCount, this.txtCopies,
                this.btnAdd, this.btnSave, this.btnDelete, this.btnClear, this.btnImport });

            // Hàng nhập liệu
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblId.Location = new System.Drawing.Point(12, 34);
            this.lblId.Name = "lblId";
            this.lblId.Text = "Mã sách (*):";
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtId.Location = new System.Drawing.Point(125, 30);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(200, 25);
            this.txtId.TabIndex = 10;
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBookTitle.Location = new System.Drawing.Point(12, 76);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Text = "Tên sách (*):";
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitle.Location = new System.Drawing.Point(125, 72);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 25);
            this.txtTitle.TabIndex = 11;
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAuthor.Location = new System.Drawing.Point(12, 118);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Text = "Tác giả (*):";
            this.txtAuthor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAuthor.Location = new System.Drawing.Point(125, 114);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 25);
            this.txtAuthor.TabIndex = 12;
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPublisher.Location = new System.Drawing.Point(12, 160);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Text = "Nhà xuất bản:";
            this.txtPublisher.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPublisher.Location = new System.Drawing.Point(125, 156);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(200, 25);
            this.txtPublisher.TabIndex = 13;
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCategory.Location = new System.Drawing.Point(12, 202);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "Thể loại (*):";
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.Location = new System.Drawing.Point(125, 198);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 25);
            this.cboCategory.TabIndex = 14;
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(12, 244);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Giá sách:";
            this.numPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPrice.Location = new System.Drawing.Point(125, 240);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(200, 25);
            this.numPrice.TabIndex = 15;
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblYear.Location = new System.Drawing.Point(12, 286);
            this.lblYear.Name = "lblYear";
            this.lblYear.Text = "Năm xuất bản:";
            this.numYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numYear.Location = new System.Drawing.Point(125, 282);
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(200, 25);
            this.numYear.TabIndex = 16;
            this.lblCopyCount.AutoSize = true;
            this.lblCopyCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCopyCount.Location = new System.Drawing.Point(12, 328);
            this.lblCopyCount.Name = "lblCopyCount";
            this.lblCopyCount.Text = "Số bản sao:";
            this.txtCopies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCopies.Location = new System.Drawing.Point(125, 324);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(200, 25);
            this.txtCopies.TabIndex = 17;

            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(30, 160, 80);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(12, 385);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 40);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Thêm đầu sách";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(225, 125, 15);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(172, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Lưu chỉnh sửa";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 40, 40);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(12, 433);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 40);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Xóa đầu sách";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(172, 433);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 40);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Làm trống";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(0, 120, 190);
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(12, 483);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(310, 42);
            this.btnImport.TabIndex = 22;
            this.btnImport.Text = "NHẬP BỔ SUNG BẢN SAO";
            this.btnImport.UseVisualStyleBackColor = false;

            // grpBooks
            this.grpBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBooks.Controls.Add(this.dgvBooks);
            this.grpBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpBooks.Location = new System.Drawing.Point(356, 125);
            this.grpBooks.Name = "grpBooks";
            this.grpBooks.Size = new System.Drawing.Size(736, 290);
            this.grpBooks.TabIndex = 6;
            this.grpBooks.TabStop = false;
            this.grpBooks.Text = "Danh sách đầu sách";
            // dgvBooks
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvBooks.Location = new System.Drawing.Point(3, 25);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.Size = new System.Drawing.Size(730, 262);
            this.dgvBooks.TabIndex = 0;

            // grpCopies
            this.grpCopies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCopies.Controls.Add(this.lblCopies);
            this.grpCopies.Controls.Add(this.dgvCopies);
            this.grpCopies.Controls.Add(this.lblHint);
            this.grpCopies.Controls.Add(this.btnCopyAdd);
            this.grpCopies.Controls.Add(this.btnCopyUpdate);
            this.grpCopies.Controls.Add(this.btnCopyDelete);
            this.grpCopies.Location = new System.Drawing.Point(356, 422);
            this.grpCopies.Name = "grpCopies";
            this.grpCopies.Size = new System.Drawing.Size(736, 238);
            this.grpCopies.TabIndex = 7;
            this.grpCopies.TabStop = false;
            // lblCopies
            this.lblCopies.AutoSize = true;
            this.lblCopies.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCopies.Location = new System.Drawing.Point(10, 14);
            this.lblCopies.Name = "lblCopies";
            this.lblCopies.Text = "Danh sách bản sao";
            // dgvCopies
            this.dgvCopies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCopies.BackgroundColor = System.Drawing.Color.White;
            this.dgvCopies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvCopies.Location = new System.Drawing.Point(10, 40);
            this.dgvCopies.Name = "dgvCopies";
            this.dgvCopies.Size = new System.Drawing.Size(716, 115);
            this.dgvCopies.TabIndex = 0;
            // lblHint
            this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(10, 164);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "Chọn một bản sao để cập nhật trạng thái, tình trạng hoặc xóa.";
            // 3 nút bản sao
            this.btnCopyAdd.BackColor = System.Drawing.Color.White;
            this.btnCopyAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCopyAdd.ForeColor = System.Drawing.Color.FromArgb(30, 140, 70);
            this.btnCopyAdd.Location = new System.Drawing.Point(10, 195);
            this.btnCopyAdd.Name = "btnCopyAdd";
            this.btnCopyAdd.Size = new System.Drawing.Size(165, 32);
            this.btnCopyAdd.TabIndex = 1;
            this.btnCopyAdd.Text = "Nhập thêm bản sao";
            this.btnCopyAdd.UseVisualStyleBackColor = false;
            this.btnCopyUpdate.BackColor = System.Drawing.Color.White;
            this.btnCopyUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCopyUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnCopyUpdate.Location = new System.Drawing.Point(183, 195);
            this.btnCopyUpdate.Name = "btnCopyUpdate";
            this.btnCopyUpdate.Size = new System.Drawing.Size(140, 32);
            this.btnCopyUpdate.TabIndex = 2;
            this.btnCopyUpdate.Text = "Cập nhật bản";
            this.btnCopyUpdate.UseVisualStyleBackColor = false;
            this.btnCopyDelete.BackColor = System.Drawing.Color.White;
            this.btnCopyDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCopyDelete.ForeColor = System.Drawing.Color.FromArgb(200, 30, 30);
            this.btnCopyDelete.Location = new System.Drawing.Point(331, 195);
            this.btnCopyDelete.Name = "btnCopyDelete";
            this.btnCopyDelete.Size = new System.Drawing.Size(140, 32);
            this.btnCopyDelete.TabIndex = 3;
            this.btnCopyDelete.Text = "Xóa bản sao";
            this.btnCopyDelete.UseVisualStyleBackColor = false;
            this.btnCopyAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));

            // statusStrip1
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1100, 22);
            // lblStatus
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Sẵn sàng";

            // FrmQuanLySach
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 246, 252);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpCopies);
            this.Controls.Add(this.grpBooks);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.lblKeyword);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FrmQuanLySach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đầu sách và bản sao";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.grpBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.grpCopies.ResumeLayout(false);
            this.grpCopies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopies)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblSubtitle, lblKeyword, lblFilter;
        private System.Windows.Forms.Label lblId, lblBookTitle, lblAuthor, lblPublisher, lblCategory, lblPrice, lblYear, lblCopyCount;
        private System.Windows.Forms.TextBox txtKeyword, txtId, txtTitle, txtAuthor, txtPublisher, txtCopies;
        private System.Windows.Forms.ComboBox cboFilter, cboCategory;
        private System.Windows.Forms.NumericUpDown numPrice, numYear;
        private System.Windows.Forms.Button btnSearch, btnRefresh, btnAdd, btnSave, btnDelete, btnClear, btnImport;
        private System.Windows.Forms.Button btnCopyAdd, btnCopyUpdate, btnCopyDelete;
        private System.Windows.Forms.GroupBox grpInfo, grpBooks, grpCopies;
        private System.Windows.Forms.DataGridView dgvBooks, dgvCopies;
        private System.Windows.Forms.Label lblCopies, lblHint;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
