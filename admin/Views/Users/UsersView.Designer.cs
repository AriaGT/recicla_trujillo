namespace admin.Views;

partial class UsersView
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

    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        lblTitle = new Label();
        btnRegister = new admin.Components.PrimaryButton();
        btnBack = new admin.Components.PrimaryButton();
        btnRefresh = new admin.Components.PrimaryButton();
        txtSearch = new admin.Components.Input();
        btnSearch = new admin.Components.PrimaryButton();
        lblSearchResult = new Label();
        dgvUsers = new admin.Components.Table();
        Id = new DataGridViewTextBoxColumn();
        Dni = new DataGridViewTextBoxColumn();
        FullName = new DataGridViewTextBoxColumn();
        Role = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
        SuspendLayout();
        //
        // lblTitle
        //
        lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.DarkSlateBlue;
        lblTitle.Location = new Point(401, 29);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(84, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Usuarios";
        //
        // btnRegister
        //
        btnRegister.BackColor = Color.DarkSlateBlue;
        btnRegister.FlatAppearance.BorderSize = 0;
        btnRegister.FlatStyle = FlatStyle.Flat;
        btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRegister.ForeColor = Color.White;
        btnRegister.HoverColor = Color.SlateBlue;
        btnRegister.Location = new Point(702, 23);
        btnRegister.Name = "btnRegister";
        btnRegister.NormalColor = Color.DarkSlateBlue;
        btnRegister.Size = new Size(195, 40);
        btnRegister.TabIndex = 1;
        btnRegister.TabStop = false;
        btnRegister.Text = "Registrar usuario";
        btnRegister.UseVisualStyleBackColor = false;
        btnRegister.Click += btnRegister_Click;
        //
        // btnBack
        //
        btnBack.BackColor = Color.IndianRed;
        btnBack.FlatAppearance.BorderSize = 0;
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnBack.ForeColor = Color.White;
        btnBack.HoverColor = Color.LightCoral;
        btnBack.Location = new Point(23, 23);
        btnBack.Name = "btnBack";
        btnBack.NormalColor = Color.IndianRed;
        btnBack.Size = new Size(120, 40);
        btnBack.TabIndex = 2;
        btnBack.TabStop = false;
        btnBack.Text = "Volver";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += btnBack_Click;
        //
        // btnRefresh
        //
        btnRefresh.BackColor = Color.DarkSlateBlue;
        btnRefresh.FlatAppearance.BorderSize = 0;
        btnRefresh.FlatStyle = FlatStyle.Flat;
        btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRefresh.ForeColor = Color.White;
        btnRefresh.HoverColor = Color.SlateBlue;
        btnRefresh.Location = new Point(577, 23);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.NormalColor = Color.DarkSlateBlue;
        btnRefresh.Size = new Size(120, 40);
        btnRefresh.TabIndex = 3;
        btnRefresh.TabStop = false;
        btnRefresh.Text = "Refrescar";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += btnRefresh_Click;
        //
        // txtSearch
        //
        txtSearch.BackColor = Color.White;
        txtSearch.Location = new Point(24, 80);
        txtSearch.Margin = new Padding(4, 2, 4, 2);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(250, 30);
        txtSearch.TabIndex = 4;
        //
        // btnSearch
        //
        btnSearch.BackColor = Color.DarkSlateBlue;
        btnSearch.FlatAppearance.BorderSize = 0;
        btnSearch.FlatStyle = FlatStyle.Flat;
        btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSearch.ForeColor = Color.White;
        btnSearch.HoverColor = Color.SlateBlue;
        btnSearch.Location = new Point(285, 75);
        btnSearch.Name = "btnSearch";
        btnSearch.NormalColor = Color.DarkSlateBlue;
        btnSearch.Size = new Size(120, 40);
        btnSearch.TabIndex = 5;
        btnSearch.TabStop = false;
        btnSearch.Text = "Buscar";
        btnSearch.UseVisualStyleBackColor = false;
        btnSearch.Click += btnSearch_Click;
        //
        // lblSearchResult
        //
        lblSearchResult.AutoSize = true;
        lblSearchResult.Font = new Font("Segoe UI", 10F);
        lblSearchResult.ForeColor = Color.Gray;
        lblSearchResult.Location = new Point(420, 86);
        lblSearchResult.Name = "lblSearchResult";
        lblSearchResult.Size = new Size(0, 19);
        lblSearchResult.TabIndex = 6;
        //
        // dgvUsers
        //
        dgvUsers.AllowUserToAddRows = false;
        dgvUsers.AllowUserToResizeRows = false;
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvUsers.BackgroundColor = Color.White;
        dgvUsers.BorderStyle = BorderStyle.None;
        dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.DarkSlateBlue;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.White;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvUsers.Columns.AddRange(new DataGridViewColumn[] { Id, Dni, FullName, Role });
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(232, 240, 254);
        dataGridViewCellStyle2.SelectionForeColor = Color.Black;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
        dgvUsers.EnableHeadersVisualStyles = false;
        dgvUsers.GridColor = Color.FromArgb(235, 235, 235);
        dgvUsers.Location = new Point(24, 130);
        dgvUsers.Margin = new Padding(4, 20, 4, 4);
        dgvUsers.MultiSelect = false;
        dgvUsers.Name = "dgvUsers";
        dgvUsers.ReadOnly = true;
        dgvUsers.RowHeadersVisible = false;
        dgvUsers.RowTemplate.Height = 40;
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvUsers.Size = new Size(874, 346);
        dgvUsers.TabIndex = 7;
        //
        // Id
        //
        Id.FillWeight = 30F;
        Id.HeaderText = "ID";
        Id.Name = "Id";
        Id.ReadOnly = true;
        //
        // Dni
        //
        Dni.FillWeight = 80F;
        Dni.HeaderText = "DNI";
        Dni.Name = "Dni";
        Dni.ReadOnly = true;
        //
        // FullName
        //
        FullName.FillWeight = 160F;
        FullName.HeaderText = "Nombre";
        FullName.Name = "FullName";
        FullName.ReadOnly = true;
        //
        // Role
        //
        Role.FillWeight = 80F;
        Role.HeaderText = "Rol";
        Role.Name = "Role";
        Role.ReadOnly = true;
        //
        // UsersView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(dgvUsers);
        Controls.Add(lblSearchResult);
        Controls.Add(btnSearch);
        Controls.Add(txtSearch);
        Controls.Add(btnRefresh);
        Controls.Add(btnBack);
        Controls.Add(btnRegister);
        Controls.Add(lblTitle);
        Name = "UsersView";
        Padding = new Padding(20);
        Size = new Size(920, 500);
        ViewSize = new Size(920, 500);
        ViewTitle = "Gestión de usuarios";
        Load += UsersView_Load;
        ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Components.PrimaryButton btnRegister;
    private Components.PrimaryButton btnBack;
    private Components.PrimaryButton btnRefresh;
    private Components.Input txtSearch;
    private Components.PrimaryButton btnSearch;
    private Label lblSearchResult;
    private Components.Table dgvUsers;
    private DataGridViewTextBoxColumn Id;
    private DataGridViewTextBoxColumn Dni;
    private DataGridViewTextBoxColumn FullName;
    private DataGridViewTextBoxColumn Role;
}
