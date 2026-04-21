using admin.Components;

namespace admin.Views;

partial class RegisterUserView
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblDni;
    private Label lblFullName;
    private Label lblRole;
    private Input txtDni;
    private Input txtFullName;
    private SelectMenu selectRole;
    private PrimaryButton btnRegister;
    private PrimaryButton btnBack;

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
        lblTitle = new Label();
        lblDni = new Label();
        lblFullName = new Label();
        lblRole = new Label();
        txtDni = new Input();
        txtFullName = new Input();
        selectRole = new SelectMenu();
        btnRegister = new PrimaryButton();
        btnBack = new PrimaryButton();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.DarkSlateBlue;
        lblTitle.Location = new Point(20, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(163, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Registrar usuario";
        // 
        // lblDni
        // 
        lblDni.AutoSize = true;
        lblDni.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblDni.ForeColor = Color.DarkSlateBlue;
        lblDni.Location = new Point(23, 57);
        lblDni.Name = "lblDni";
        lblDni.Size = new Size(33, 19);
        lblDni.TabIndex = 1;
        lblDni.Text = "DNI";
        // 
        // lblFullName
        // 
        lblFullName.AutoSize = true;
        lblFullName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblFullName.ForeColor = Color.DarkSlateBlue;
        lblFullName.Location = new Point(23, 127);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(142, 19);
        lblFullName.TabIndex = 3;
        lblFullName.Text = "Nombre completo";
        // 
        // lblRole
        // 
        lblRole.AutoSize = true;
        lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblRole.ForeColor = Color.DarkSlateBlue;
        lblRole.Location = new Point(23, 197);
        lblRole.Name = "lblRole";
        lblRole.Size = new Size(31, 19);
        lblRole.TabIndex = 5;
        lblRole.Text = "Rol";
        // 
        // txtDni
        // 
        txtDni.BackColor = Color.White;
        txtDni.Location = new Point(23, 78);
        txtDni.Margin = new Padding(4, 2, 4, 2);
        txtDni.Name = "txtDni";
        txtDni.Size = new Size(253, 30);
        txtDni.TabIndex = 2;
        txtDni.Text = "";
        // 
        // txtFullName
        // 
        txtFullName.BackColor = Color.White;
        txtFullName.Location = new Point(23, 148);
        txtFullName.Margin = new Padding(4, 2, 4, 2);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(253, 30);
        txtFullName.TabIndex = 4;
        txtFullName.Text = "";
        // 
        // selectRole
        // 
        selectRole.BackColor = Color.White;
        selectRole.DataSource = null;
        selectRole.DisplayMember = "";
        selectRole.Location = new Point(23, 218);
        selectRole.Margin = new Padding(4, 2, 4, 2);
        selectRole.Name = "selectRole";
        selectRole.SelectedIndex = -1;
        selectRole.SelectedValue = null;
        selectRole.Size = new Size(253, 30);
        selectRole.TabIndex = 6;
        selectRole.TextColor = Color.DarkSlateBlue;
        selectRole.UnderlineColor = Color.DarkSlateBlue;
        selectRole.ValueMember = "";
        // 
        // btnRegister
        // 
        btnRegister.BackColor = Color.DarkSlateBlue;
        btnRegister.FlatAppearance.BorderSize = 0;
        btnRegister.FlatStyle = FlatStyle.Flat;
        btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRegister.ForeColor = Color.White;
        btnRegister.HoverColor = Color.SlateBlue;
        btnRegister.Location = new Point(125, 297);
        btnRegister.Name = "btnRegister";
        btnRegister.NormalColor = Color.DarkSlateBlue;
        btnRegister.Size = new Size(152, 40);
        btnRegister.TabIndex = 7;
        btnRegister.TabStop = false;
        btnRegister.Text = "Registrar";
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
        btnBack.Location = new Point(23, 297);
        btnBack.Name = "btnBack";
        btnBack.NormalColor = Color.IndianRed;
        btnBack.Size = new Size(96, 40);
        btnBack.TabIndex = 8;
        btnBack.TabStop = false;
        btnBack.Text = "Volver";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += btnBack_Click;
        // 
        // RegisterUserView
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        Controls.Add(btnBack);
        Controls.Add(btnRegister);
        Controls.Add(selectRole);
        Controls.Add(txtFullName);
        Controls.Add(txtDni);
        Controls.Add(lblRole);
        Controls.Add(lblFullName);
        Controls.Add(lblDni);
        Controls.Add(lblTitle);
        Margin = new Padding(0);
        Name = "RegisterUserView";
        Padding = new Padding(20);
        Size = new Size(300, 360);
        ViewSize = new Size(300, 360);
        ViewTitle = "Registro de usuario";
        Load += RegisterUserView_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
