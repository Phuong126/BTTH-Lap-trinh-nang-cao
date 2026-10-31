using BTTH8.Business;

namespace BTTH8
{
    // Code-behind cho form dựng bằng Designer.
    // Các control (txtId, dgvBooks, btnAdd...) khai báo trong FrmQuanLySach.Designer.cs,
    // sự kiện được gắn trong WireEvents() nên KHÔNG cần double-click tạo handler trong Designer.
    public partial class FrmQuanLySach : Form
    {
        private readonly ManageBookBuss _bus = new ManageBookBuss();
        private bool _loading;

        public FrmQuanLySach()
        {
            InitializeComponent();
            SetupControls();
            WireEvents();
            Load += (s, e) => { LoadCategories(); LoadBooks(); };
        }

        // =====================================================================
        //  THIẾT LẬP CONTROL (các thuộc tính đặt bằng code để đỡ chỉnh trong Designer)
        // =====================================================================
        private void SetupControls()
        {
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            numPrice.Minimum = 0;
            numPrice.Maximum = 1000000000;
            numPrice.Increment = 1000;
            numPrice.ThousandsSeparator = true;
            numPrice.TextAlign = HorizontalAlignment.Right;

            numYear.Minimum = 1000;
            numYear.Maximum = DateTime.Now.Year;
            numYear.Value = DateTime.Now.Year;
            numYear.TextAlign = HorizontalAlignment.Right;

            txtCopies.ReadOnly = true;
            txtCopies.TextAlign = HorizontalAlignment.Right;
            txtCopies.Text = "0";

            // Lưới đầu sách
            SetupGrid(dgvBooks);
            dgvBooks.Columns.Clear();
            dgvBooks.Columns.Add(Col("Id", "Mã sách", 80));
            dgvBooks.Columns.Add(Col("Title", "Tên đầu sách", 240));
            dgvBooks.Columns.Add(Col("Category", "Thể loại", 130));
            dgvBooks.Columns.Add(Col("Author", "Tác giả", 150));
            dgvBooks.Columns.Add(Col("Publisher", "Nhà xuất bản", 150));
            var colPrice = Col("Price", "Giá sách", 100);
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBooks.Columns.Add(colPrice);
            dgvBooks.Columns.Add(Col("PublishYear", "Năm XB", 80));
            dgvBooks.Columns.Add(Col("NumberOfCopies", "Số bản sao", 90));

            // Lưới bản sao
            SetupGrid(dgvCopies);
            dgvCopies.Columns.Clear();
            dgvCopies.Columns.Add(Col("BookCopyID", "Mã bản sao", 200));
            dgvCopies.Columns.Add(Col("StatusText", "Trạng thái", 200));
            dgvCopies.Columns.Add(Col("ConditionText", "Tình trạng vật lý", 200));
            foreach (DataGridViewColumn c in dgvCopies.Columns)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private static void SetupGrid(DataGridView g)
        {
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AutoGenerateColumns = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.RowHeadersVisible = false;
        }

        private static DataGridViewTextBoxColumn Col(string prop, string header, int width) =>
            new DataGridViewTextBoxColumn { DataPropertyName = prop, HeaderText = header, Width = width };

        private void WireEvents()
        {
            btnSearch.Click += (s, e) => LoadBooks();
            btnRefresh.Click += (s, e) =>
            {
                txtKeyword.Clear();
                if (cboFilter.Items.Count > 0) cboFilter.SelectedIndex = 0;
                ClearForm();
                LoadBooks();
            };
            txtKeyword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; LoadBooks(); }
            };

            btnAdd.Click += (s, e) => OnAddBook();
            btnSave.Click += (s, e) => OnUpdateBook();
            btnDelete.Click += (s, e) => OnDeleteBook();
            btnClear.Click += (s, e) => ClearForm();
            btnImport.Click += (s, e) => OnAddCopies();

            btnCopyAdd.Click += (s, e) => OnAddCopies();
            btnCopyUpdate.Click += (s, e) => OnUpdateCopy();
            btnCopyDelete.Click += (s, e) => OnDeleteCopy();

            dgvBooks.SelectionChanged += (s, e) => { if (!_loading) ShowSelectedBook(); };
        }

        // =====================================================================
        //  TIỆN ÍCH
        // =====================================================================
        private void SetStatus(string msg) => lblStatus.Text = msg;

        private void Run(Action action)
        {
            try { action(); }
            catch (Exception ex)
            {
                var msg = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show(Translate(msg), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Việt hoá các thông báo lỗi tiếng Anh từ tầng repository
        private static string Translate(string m) => m switch
        {
            "Book is already exists." => "Mã sách đã tồn tại.",
            "Book does not exist." => "Đầu sách không tồn tại.",
            "Category does not exist" => "Thể loại không tồn tại.",
            "Cannot delete: some copies are being borrowed." => "Không thể xóa: có bản sao đang được mượn.",
            "Cannot delete: this copy is being borrowed." => "Không thể xóa: bản sao đang được mượn.",
            "Copy does not exist." => "Bản sao không tồn tại.",
            _ => m
        };

        // =====================================================================
        //  NẠP DỮ LIỆU
        // =====================================================================
        private void LoadCategories()
        {
            Run(() =>
            {
                var names = _bus.GetCategoryNames();

                cboFilter.Items.Clear();
                cboFilter.Items.Add("-- Tất cả thể loại --");
                cboFilter.Items.AddRange(names.Cast<object>().ToArray());
                cboFilter.SelectedIndex = 0;

                cboCategory.Items.Clear();
                cboCategory.Items.AddRange(names.Cast<object>().ToArray());
                if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            });
        }

        private void LoadBooks(string keepId = null)
        {
            Run(() =>
            {
                _loading = true;
                var cat = cboFilter.SelectedIndex > 0 ? cboFilter.Text : null;
                var books = _bus.GetBooks(txtKeyword.Text, cat);
                dgvBooks.DataSource = books;
                _loading = false;

                SetStatus(_bus.LoadedMessage(books.Count));

                int idx = keepId == null ? -1 : books.FindIndex(b => b.Id == keepId);
                if (idx >= 0)
                {
                    dgvBooks.ClearSelection();
                    dgvBooks.Rows[idx].Selected = true;
                    dgvBooks.CurrentCell = dgvBooks.Rows[idx].Cells[0];
                }
                else
                {
                    dgvBooks.ClearSelection();
                    ClearForm();
                }
                ShowSelectedBook();
            });
        }

        private void LoadCopies(string bookId)
        {
            dgvCopies.DataSource = string.IsNullOrEmpty(bookId) ? null : _bus.GetCopies(bookId);
            lblCopies.Text = string.IsNullOrEmpty(bookId) ? "Danh sách bản sao" : _bus.CopiesTitle(bookId);
        }

        // =====================================================================
        //  ĐỒNG BỘ GIỮA LƯỚI VÀ Ô NHẬP
        // =====================================================================
        private Book CurrentBook =>
            dgvBooks.CurrentRow?.Selected == true ? dgvBooks.CurrentRow.DataBoundItem as Book : null;

        private void ShowSelectedBook()
        {
            var b = CurrentBook;
            if (b == null) { LoadCopies(null); return; }

            txtId.Text = b.Id;
            txtId.ReadOnly = true;                       // không cho đổi mã khi đang sửa
            txtTitle.Text = b.Title;
            txtAuthor.Text = b.Author;
            txtPublisher.Text = b.Publisher;
            cboCategory.SelectedItem = b.Category;
            numPrice.Value = Math.Min(Math.Max(b.Price, numPrice.Minimum), numPrice.Maximum);
            numYear.Value = Math.Min(Math.Max(b.PublishYear, numYear.Minimum), numYear.Maximum);
            txtCopies.Text = b.NumberOfCopies.ToString();
            LoadCopies(b.Id);
        }

        private void ClearForm()
        {
            txtId.ReadOnly = false;
            txtId.Clear(); txtTitle.Clear(); txtAuthor.Clear(); txtPublisher.Clear();
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            numPrice.Value = 0;
            numYear.Value = DateTime.Now.Year;
            txtCopies.Text = "0";
            dgvBooks.ClearSelection();
            LoadCopies(null);
            txtId.Focus();
        }

        private Book ReadBook() => new Book
        {
            Id = txtId.Text.Trim(),
            Title = txtTitle.Text.Trim(),
            Author = txtAuthor.Text.Trim(),
            Publisher = txtPublisher.Text.Trim(),
            Category = cboCategory.SelectedItem as string,
            Price = numPrice.Value,
            PublishYear = (int)numYear.Value
        };

        // =====================================================================
        //  XỬ LÝ NÚT - ĐẦU SÁCH
        // =====================================================================
        private void OnAddBook()
        {
            Run(() =>
            {
                var book = ReadBook();
                var n = AskNumber("Thêm đầu sách", "Số bản sao cần tạo:", 1);
                if (n == null) return;
                book.NumberOfCopies = n.Value;

                _bus.AddBook(book);
                LoadBooks(book.Id);
                SetStatus($"Đã thêm đầu sách {book.Id} với {book.NumberOfCopies} bản sao.");
            });
        }

        private void OnUpdateBook()
        {
            Run(() =>
            {
                if (CurrentBook == null) throw new Exception("Hãy chọn một đầu sách trong danh sách để sửa.");
                var book = ReadBook();
                _bus.UpdateBook(book);
                LoadBooks(book.Id);
                SetStatus($"Đã lưu chỉnh sửa đầu sách {book.Id}.");
            });
        }

        private void OnDeleteBook()
        {
            Run(() =>
            {
                var b = CurrentBook;
                if (b == null) throw new Exception("Hãy chọn một đầu sách để xóa.");
                var ask = MessageBox.Show($"Xóa đầu sách \"{b.Title}\" cùng toàn bộ {b.NumberOfCopies} bản sao?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ask != DialogResult.Yes) return;

                _bus.DeleteBook(b.Id);
                LoadBooks();
                SetStatus($"Đã xóa đầu sách {b.Id}.");
            });
        }

        // =====================================================================
        //  XỬ LÝ NÚT - BẢN SAO
        // =====================================================================
        private CopyRow CurrentCopy => dgvCopies.CurrentRow?.DataBoundItem as CopyRow;

        private void OnAddCopies()
        {
            Run(() =>
            {
                var b = CurrentBook;
                if (b == null) throw new Exception("Hãy chọn đầu sách cần nhập thêm bản sao.");
                var n = AskNumber("Nhập bổ sung bản sao", $"Số bản sao nhập thêm cho sách {b.Id}:", 1);
                if (n == null) return;

                _bus.AddCopies(b.Id, n.Value);
                LoadBooks(b.Id);
                SetStatus($"Đã nhập thêm {n.Value} bản sao cho sách {b.Id}.");
            });
        }

        private void OnUpdateCopy()
        {
            Run(() =>
            {
                var c = CurrentCopy;
                if (c == null) throw new Exception("Hãy chọn một bản sao để cập nhật.");
                var r = AskCopyState(c);
                if (r == null) return;

                _bus.UpdateCopy(c.BookCopyID, r.Value.status, r.Value.condition);
                LoadCopies(CurrentBook?.Id);
                SetStatus($"Đã cập nhật bản sao {c.BookCopyID}.");
            });
        }

        private void OnDeleteCopy()
        {
            Run(() =>
            {
                var c = CurrentCopy;
                if (c == null) throw new Exception("Hãy chọn một bản sao để xóa.");
                var ask = MessageBox.Show($"Xóa bản sao {c.BookCopyID}?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ask != DialogResult.Yes) return;

                var bookId = CurrentBook?.Id;
                _bus.DeleteCopy(c.BookCopyID);
                LoadBooks(bookId);
                SetStatus($"Đã xóa bản sao {c.BookCopyID}.");
            });
        }

        // =====================================================================
        //  HỘP THOẠI NHỎ
        // =====================================================================
        private int? AskNumber(string title, string label, int def)
        {
            using var f = NewDialog(title, 340, 150);
            f.Controls.Add(new Label { Text = label, AutoSize = true, Location = new Point(12, 14) });
            var num = new NumericUpDown { Minimum = 1, Maximum = 999, Value = def, Location = new Point(12, 42), Width = 100 };
            f.Controls.Add(num);
            AddOkCancel(f, 12, 80);
            return f.ShowDialog(this) == DialogResult.OK ? (int)num.Value : (int?)null;
        }

        private (string status, string condition)? AskCopyState(CopyRow c)
        {
            using var f = NewDialog($"Cập nhật bản {c.BookCopyID}", 340, 210);

            var statuses = CopyStatus.All.Select(s => new KeyValuePair<string, string>(s, CopyStatus.ToVietnamese(s))).ToList();
            var conds = CopyCondition.All.Select(s => new KeyValuePair<string, string>(s, CopyCondition.ToVietnamese(s))).ToList();

            f.Controls.Add(new Label { Text = "Trạng thái:", AutoSize = true, Location = new Point(12, 14) });
            var cs = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(12, 38),
                Width = 300,
                DataSource = statuses,
                DisplayMember = "Value",
                ValueMember = "Key"
            };
            cs.SelectedValue = c.Status;

            f.Controls.Add(new Label { Text = "Tình trạng vật lý:", AutoSize = true, Location = new Point(12, 74) });
            var cc = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(12, 98),
                Width = 300,
                DataSource = conds,
                DisplayMember = "Value",
                ValueMember = "Key"
            };
            cc.SelectedValue = c.PhysicalCondition;

            f.Controls.Add(cs); f.Controls.Add(cc);
            AddOkCancel(f, 12, 138);

            return f.ShowDialog(this) == DialogResult.OK
                ? ((string)cs.SelectedValue, (string)cc.SelectedValue)
                : ((string, string)?)null;
        }

        private Form NewDialog(string title, int w, int h) => new Form
        {
            Text = title,
            ClientSize = new Size(w, h),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false,
            Font = Font
        };

        private static void AddOkCancel(Form f, int x, int y)
        {
            var ok = new Button { Text = "Đồng ý", DialogResult = DialogResult.OK, Location = new Point(x, y), Size = new Size(100, 32) };
            var cancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(x + 110, y), Size = new Size(100, 32) };
            f.Controls.Add(ok); f.Controls.Add(cancel);
            f.AcceptButton = ok; f.CancelButton = cancel;
        }
    }
}
