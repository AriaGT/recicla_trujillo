namespace admin.Views;

partial class UserCreateView
{
    private System.ComponentModel.IContainer components = null;
    private Label lblDni;
    private TextBox txtDni;
    private Label lblFullName;
    private TextBox txtFullName;
    private Label lblRole;
    private ComboBox cmbRole;
    private Button btnCreate;
    private Button btnRefresh;
    private Button btnBack;
    private DataGridView gridUsers;
    private Label lblStatus;

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
        lblDni = new Label();
        txtDni = new TextBox();
        lblFullName = new Label();
        txtFullName = new TextBox();
        lblRole = new Label();
        cmbRole = new ComboBox();
        btnCreate = new Button();
        btnRefresh = new Button();
        btnBack = new Button();
        gridUsers = new DataGridView();
        lblStatus = new Label();
        ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
        SuspendLayout();
        // 
        // lblDni
        // 
        lblDni.AutoSize = true;
        lblDni.Location = new Point(15, 18);
        lblDni.Name = "lblDni";
        lblDni.Size = new Size(27, 15);
        lblDni.TabIndex = 0;
        lblDni.Text = "DNI";
        // 
        // txtDni
        // 
        txtDni.Location = new Point(15, 40);
        txtDni.MaxLength = 8;
        txtDni.Name = "txtDni";
        txtDni.Size = new Size(180, 23);
        txtDni.TabIndex = 1;
        // 
        // lblFullName
        // 
        lblFullName.AutoSize = true;
        lblFullName.Location = new Point(210, 18);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(105, 15);
        lblFullName.TabIndex = 2;
        lblFullName.Text = "Nombre completo";
        // 
        // txtFullName
        // 
        txtFullName.Location = new Point(210, 40);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(260, 23);
        txtFullName.TabIndex = 3;
        // 
        // lblRole
        // 
        lblRole.AutoSize = true;
        lblRole.Location = new Point(485, 18);
        lblRole.Name = "lblRole";
        lblRole.Size = new Size(24, 15);
        lblRole.TabIndex = 4;
        lblRole.Text = "Rol";
        // 
        // cmbRole
        // 
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbRole.FormattingEnabled = true;
        cmbRole.Location = new Point(485, 40);
        cmbRole.Name = "cmbRole";
        cmbRole.Size = new Size(130, 23);
        cmbRole.TabIndex = 5;
        // 
        // btnCreate
        // 
        btnCreate.Location = new Point(630, 38);
        btnCreate.Name = "btnCreate";
        btnCreate.Size = new Size(120, 30);
        btnCreate.TabIndex = 6;
        btnCreate.Text = "Crear usuario";
        btnCreate.UseVisualStyleBackColor = true;
        btnCreate.Click += btnCreate_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.Location = new Point(760, 38);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(110, 30);
        btnRefresh.TabIndex = 7;
        btnRefresh.Text = "Refrescar";
        btnRefresh.UseVisualStyleBackColor = true;
        btnRefresh.Click += btnRefresh_Click;
        // 
        // btnBack
        // 
        btnBack.Location = new Point(760, 500);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(110, 30);
        btnBack.TabIndex = 8;
        btnBack.Text = "Volver";
        btnBack.UseVisualStyleBackColor = true;
        btnBack.Click += btnBack_Click;
        // 
        // gridUsers
        // 
        gridUsers.AllowUserToAddRows = false;
        gridUsers.AllowUserToDeleteRows = false;
        gridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridUsers.Location = new Point(15, 90);
        gridUsers.Name = "gridUsers";
        gridUsers.ReadOnly = true;
        gridUsers.Size = new Size(171, 167);
        gridUsers.TabIndex = 9;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(15, 505);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(0, 15);
        lblStatus.TabIndex = 10;
        // 
        // UserCreateView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(lblStatus);
        Controls.Add(gridUsers);
        Controls.Add(btnBack);
        Controls.Add(btnRefresh);
        Controls.Add(btnCreate);
        Controls.Add(cmbRole);
        Controls.Add(lblRole);
        Controls.Add(txtFullName);
        Controls.Add(lblFullName);
        Controls.Add(txtDni);
        Controls.Add(lblDni);
        Name = "UserCreateView";
        Size = new Size(900, 560);
        Load += UserCreateView_Load;
        ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
