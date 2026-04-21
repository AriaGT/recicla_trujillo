using admin.Components;

namespace admin.Views;

partial class LoginView
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblDni;
    private Label lblStatus;

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
        lblStatus = new Label();
        btnLogin = new PrimaryButton();
        txtDni = new Input();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Anchor = AnchorStyles.None;
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.DarkSlateBlue;
        lblTitle.Location = new Point(100, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(121, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Identificarse";
        // 
        // lblDni
        // 
        lblDni.AutoSize = true;
        lblDni.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblDni.ForeColor = Color.DarkSlateBlue;
        lblDni.Location = new Point(23, 68);
        lblDni.Margin = new Padding(4, 2, 4, 2);
        lblDni.Name = "lblDni";
        lblDni.Size = new Size(34, 19);
        lblDni.TabIndex = 1;
        lblDni.Text = "DNI";
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(23, 117);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(0, 15);
        lblStatus.TabIndex = 4;
        // 
        // btnLogin
        // 
        btnLogin.BackColor = Color.DarkSlateBlue;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLogin.ForeColor = Color.White;
        btnLogin.HoverColor = Color.SlateBlue;
        btnLogin.Location = new Point(23, 152);
        btnLogin.Name = "btnLogin";
        btnLogin.NormalColor = Color.DarkSlateBlue;
        btnLogin.Size = new Size(274, 45);
        btnLogin.TabIndex = 5;
        btnLogin.TabStop = false;
        btnLogin.Text = "Ingresar";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += btnLogin_Click;
        // 
        // txtDni
        // 
        txtDni.BackColor = Color.White;
        txtDni.Location = new Point(23, 91);
        txtDni.Margin = new Padding(4, 2, 4, 2);
        txtDni.Name = "txtDni";
        txtDni.Size = new Size(274, 24);
        txtDni.TabIndex = 6;
        // 
        // LoginView
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        Controls.Add(txtDni);
        Controls.Add(btnLogin);
        Controls.Add(lblStatus);
        Controls.Add(lblDni);
        Controls.Add(lblTitle);
        Margin = new Padding(0);
        Name = "LoginView";
        Padding = new Padding(20);
        Size = new Size(320, 220);
        ViewSize = new Size(320, 220);
        ViewTitle = "Recicla Trujillo";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PrimaryButton btnLogin;
    private Input txtDni;
}
