namespace WindowsFormsApp1.SanPham
{
    partial class SanPhamGUI
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grid_SanPham = new System.Windows.Forms.DataGridView();
            this.CotmaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CottenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CotgiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CotsoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cotimg = new System.Windows.Forms.DataGridViewImageColumn();
            this.CotthoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CotmaLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_ThemSanPham = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Tim = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.grid_LoaiSanPham = new System.Windows.Forms.DataGridView();
            this.CotmaLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CottenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Sua2 = new System.Windows.Forms.Button();
            this.btn_Xoa2 = new System.Windows.Forms.Button();
            this.btn_ThemLoaiSanPham = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Tim2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_SanPham)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_LoaiSanPham)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 700);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1192, 662);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sản phẩm";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Controls.Add(this.grid_SanPham, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1192, 662);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grid_SanPham
            // 
            this.grid_SanPham.AllowUserToAddRows = false;
            this.grid_SanPham.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid_SanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_SanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CotmaSP,
            this.CottenSP,
            this.CotgiaBan,
            this.CotsoLuong,
            this.Cotimg,
            this.CotthoiGian,
            this.CotmaLoai});
            this.tableLayoutPanel1.SetColumnSpan(this.grid_SanPham, 2);
            this.grid_SanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_SanPham.Location = new System.Drawing.Point(0, 145);
            this.grid_SanPham.Margin = new System.Windows.Forms.Padding(0);
            this.grid_SanPham.Name = "grid_SanPham";
            this.grid_SanPham.ReadOnly = true;
            this.grid_SanPham.RowHeadersVisible = false;
            this.grid_SanPham.RowHeadersWidth = 51;
            this.grid_SanPham.RowTemplate.Height = 24;
            this.grid_SanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_SanPham.Size = new System.Drawing.Size(1192, 517);
            this.grid_SanPham.TabIndex = 113;
            // 
            // CotmaSP
            // 
            this.CotmaSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CotmaSP.DataPropertyName = "maSP";
            this.CotmaSP.FillWeight = 150F;
            this.CotmaSP.HeaderText = "Mã Sản Phẩm";
            this.CotmaSP.MinimumWidth = 6;
            this.CotmaSP.Name = "CotmaSP";
            this.CotmaSP.ReadOnly = true;
            // 
            // CottenSP
            // 
            this.CottenSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CottenSP.DataPropertyName = "tenSP";
            this.CottenSP.FillWeight = 280F;
            this.CottenSP.HeaderText = "Tên Sản Phẩm";
            this.CottenSP.MinimumWidth = 6;
            this.CottenSP.Name = "CottenSP";
            this.CottenSP.ReadOnly = true;
            // 
            // CotgiaBan
            // 
            this.CotgiaBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CotgiaBan.DataPropertyName = "giaBan";
            this.CotgiaBan.FillWeight = 150F;
            this.CotgiaBan.HeaderText = "Giá Bán";
            this.CotgiaBan.MinimumWidth = 6;
            this.CotgiaBan.Name = "CotgiaBan";
            this.CotgiaBan.ReadOnly = true;
            // 
            // CotsoLuong
            // 
            this.CotsoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CotsoLuong.DataPropertyName = "soLuong";
            this.CotsoLuong.HeaderText = "Số Lượng";
            this.CotsoLuong.MinimumWidth = 6;
            this.CotsoLuong.Name = "CotsoLuong";
            this.CotsoLuong.ReadOnly = true;
            // 
            // Cotimg
            // 
            this.Cotimg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cotimg.DataPropertyName = "img";
            this.Cotimg.FillWeight = 150F;
            this.Cotimg.HeaderText = "Hình Ảnh";
            this.Cotimg.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Cotimg.MinimumWidth = 6;
            this.Cotimg.Name = "Cotimg";
            this.Cotimg.ReadOnly = true;
            // 
            // CotthoiGian
            // 
            this.CotthoiGian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CotthoiGian.DataPropertyName = "thoiGian";
            this.CotthoiGian.HeaderText = "Bảo Hành (tháng)";
            this.CotthoiGian.MinimumWidth = 6;
            this.CotthoiGian.Name = "CotthoiGian";
            this.CotthoiGian.ReadOnly = true;
            // 
            // CotmaLoai
            // 
            this.CotmaLoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CotmaLoai.DataPropertyName = "maLoai";
            this.CotmaLoai.HeaderText = "Mã Loại";
            this.CotmaLoai.MinimumWidth = 6;
            this.CotmaLoai.Name = "CotmaLoai";
            this.CotmaLoai.ReadOnly = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btn_Sua, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_Xoa, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_ThemSanPham, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(798, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(394, 145);
            this.tableLayoutPanel3.TabIndex = 114;
            // 
            // btn_Sua
            // 
            this.btn_Sua.BackColor = System.Drawing.Color.Navy;
            this.btn_Sua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.ForeColor = System.Drawing.Color.White;
            this.btn_Sua.Location = new System.Drawing.Point(0, 72);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(197, 73);
            this.btn_Sua.TabIndex = 2;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = false;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.Navy;
            this.btn_Xoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.Color.White;
            this.btn_Xoa.Location = new System.Drawing.Point(197, 72);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(197, 73);
            this.btn_Xoa.TabIndex = 3;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_ThemSanPham
            // 
            this.btn_ThemSanPham.BackColor = System.Drawing.Color.Navy;
            this.tableLayoutPanel3.SetColumnSpan(this.btn_ThemSanPham, 2);
            this.btn_ThemSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ThemSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemSanPham.ForeColor = System.Drawing.Color.White;
            this.btn_ThemSanPham.Location = new System.Drawing.Point(0, 0);
            this.btn_ThemSanPham.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ThemSanPham.Name = "btn_ThemSanPham";
            this.btn_ThemSanPham.Size = new System.Drawing.Size(394, 72);
            this.btn_ThemSanPham.TabIndex = 1;
            this.btn_ThemSanPham.Text = "Thêm Sản Phẩm";
            this.btn_ThemSanPham.UseVisualStyleBackColor = false;
            this.btn_ThemSanPham.Click += new System.EventHandler(this.btn_ThemSanPham_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tb_Tim, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(798, 145);
            this.tableLayoutPanel2.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 32);
            this.label1.TabIndex = 102;
            this.label1.Text = "Tìm kiếm sản phẩm";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 25);
            this.label2.TabIndex = 103;
            this.label2.Text = "(Nhập tên hoặc mã sản phẩm)";
            // 
            // tb_Tim
            // 
            this.tb_Tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Tim.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Tim.Location = new System.Drawing.Point(199, 88);
            this.tb_Tim.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Tim.Name = "tb_Tim";
            this.tb_Tim.Size = new System.Drawing.Size(399, 38);
            this.tb_Tim.TabIndex = 0;
            this.tb_Tim.TextChanged += new System.EventHandler(this.tb_Tim_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1192, 662);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Loại sản phẩm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.DodgerBlue;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel4.Controls.Add(this.grid_LoaiSanPham, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1192, 662);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // grid_LoaiSanPham
            // 
            this.grid_LoaiSanPham.AllowUserToAddRows = false;
            this.grid_LoaiSanPham.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid_LoaiSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_LoaiSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CotmaLoaiSP,
            this.CottenLoai});
            this.tableLayoutPanel4.SetColumnSpan(this.grid_LoaiSanPham, 2);
            this.grid_LoaiSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_LoaiSanPham.Location = new System.Drawing.Point(0, 145);
            this.grid_LoaiSanPham.Margin = new System.Windows.Forms.Padding(0);
            this.grid_LoaiSanPham.Name = "grid_LoaiSanPham";
            this.grid_LoaiSanPham.ReadOnly = true;
            this.grid_LoaiSanPham.RowHeadersVisible = false;
            this.grid_LoaiSanPham.RowHeadersWidth = 51;
            this.grid_LoaiSanPham.RowTemplate.Height = 24;
            this.grid_LoaiSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_LoaiSanPham.Size = new System.Drawing.Size(1192, 517);
            this.grid_LoaiSanPham.TabIndex = 113;
            // 
            // CotmaLoaiSP
            // 
            this.CotmaLoaiSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CotmaLoaiSP.DataPropertyName = "maLoai";
            this.CotmaLoaiSP.HeaderText = "Mã Loại";
            this.CotmaLoaiSP.MinimumWidth = 6;
            this.CotmaLoaiSP.Name = "CotmaLoaiSP";
            this.CotmaLoaiSP.ReadOnly = true;
            // 
            // CottenLoai
            // 
            this.CottenLoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CottenLoai.DataPropertyName = "tenLoai";
            this.CottenLoai.FillWeight = 400F;
            this.CottenLoai.HeaderText = "Tên Loại";
            this.CottenLoai.MinimumWidth = 6;
            this.CottenLoai.Name = "CottenLoai";
            this.CottenLoai.ReadOnly = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.btn_Sua2, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.btn_Xoa2, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.btn_ThemLoaiSanPham, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(798, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(394, 145);
            this.tableLayoutPanel6.TabIndex = 114;
            // 
            // btn_Sua2
            // 
            this.btn_Sua2.BackColor = System.Drawing.Color.Navy;
            this.btn_Sua2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Sua2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua2.ForeColor = System.Drawing.Color.White;
            this.btn_Sua2.Location = new System.Drawing.Point(0, 72);
            this.btn_Sua2.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Sua2.Name = "btn_Sua2";
            this.btn_Sua2.Size = new System.Drawing.Size(197, 73);
            this.btn_Sua2.TabIndex = 2;
            this.btn_Sua2.Text = "Sửa";
            this.btn_Sua2.UseVisualStyleBackColor = false;
            this.btn_Sua2.Click += new System.EventHandler(this.btn_Sua2_Click);
            // 
            // btn_Xoa2
            // 
            this.btn_Xoa2.BackColor = System.Drawing.Color.Navy;
            this.btn_Xoa2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Xoa2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa2.ForeColor = System.Drawing.Color.White;
            this.btn_Xoa2.Location = new System.Drawing.Point(197, 72);
            this.btn_Xoa2.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Xoa2.Name = "btn_Xoa2";
            this.btn_Xoa2.Size = new System.Drawing.Size(197, 73);
            this.btn_Xoa2.TabIndex = 3;
            this.btn_Xoa2.Text = "Xóa";
            this.btn_Xoa2.UseVisualStyleBackColor = false;
            this.btn_Xoa2.Click += new System.EventHandler(this.btn_Xoa2_Click);
            // 
            // btn_ThemLoaiSanPham
            // 
            this.btn_ThemLoaiSanPham.BackColor = System.Drawing.Color.Navy;
            this.tableLayoutPanel6.SetColumnSpan(this.btn_ThemLoaiSanPham, 2);
            this.btn_ThemLoaiSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ThemLoaiSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemLoaiSanPham.ForeColor = System.Drawing.Color.White;
            this.btn_ThemLoaiSanPham.Location = new System.Drawing.Point(0, 0);
            this.btn_ThemLoaiSanPham.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ThemLoaiSanPham.Name = "btn_ThemLoaiSanPham";
            this.btn_ThemLoaiSanPham.Size = new System.Drawing.Size(394, 72);
            this.btn_ThemLoaiSanPham.TabIndex = 1;
            this.btn_ThemLoaiSanPham.Text = "Thêm Loại Sản Phẩm";
            this.btn_ThemLoaiSanPham.UseVisualStyleBackColor = false;
            this.btn_ThemLoaiSanPham.Click += new System.EventHandler(this.btn_ThemLoaiSanPham_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label4, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.tb_Tim2, 1, 3);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(798, 145);
            this.tableLayoutPanel5.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(242, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(312, 32);
            this.label3.TabIndex = 102;
            this.label3.Text = "Tìm kiếm loại sản phẩm";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(243, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(311, 25);
            this.label4.TabIndex = 103;
            this.label4.Text = "(Nhập tên hoặc mã loại sản phẩm)";
            // 
            // tb_Tim2
            // 
            this.tb_Tim2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Tim2.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Tim2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Tim2.Location = new System.Drawing.Point(199, 88);
            this.tb_Tim2.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Tim2.Name = "tb_Tim2";
            this.tb_Tim2.Size = new System.Drawing.Size(399, 38);
            this.tb_Tim2.TabIndex = 0;
            this.tb_Tim2.TextChanged += new System.EventHandler(this.tb_Tim2_TextChanged);
            // 
            // SanPhamGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl1);
            this.Name = "SanPhamGUI";
            this.Text = "SanPhamGUI";
            this.Load += new System.EventHandler(this.SanPhamGUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_SanPham)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_LoaiSanPham)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView grid_SanPham;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_ThemSanPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Tim;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView grid_LoaiSanPham;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btn_Sua2;
        private System.Windows.Forms.Button btn_Xoa2;
        private System.Windows.Forms.Button btn_ThemLoaiSanPham;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Tim2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CotmaLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn CottenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn CotmaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn CottenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn CotgiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CotsoLuong;
        private System.Windows.Forms.DataGridViewImageColumn Cotimg;
        private System.Windows.Forms.DataGridViewTextBoxColumn CotthoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn CotmaLoai;
    }
}