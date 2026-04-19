namespace admin;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblDni;
    private TextBox txtDni;
    private Button btnLogin;
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
        txtDni = new TextBox();
        btnLogin = new Button();
        lblStatus = new Label();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(30, 24);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(216, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Login de administrador";
        // 
        // lblDni
        // 
        lblDni.AutoSize = true;
        lblDni.Location = new Point(30, 78);
        lblDni.Name = "lblDni";
        lblDni.Size = new Size(27, 15);
        lblDni.TabIndex = 1;
        lblDni.Text = "DNI";
        // 
        // txtDni
        // 
        txtDni.Location = new Point(30, 96);
        txtDni.Name = "txtDni";
        txtDni.Size = new Size(200, 23);
        txtDni.TabIndex = 2;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(30, 136);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(120, 34);
        btnLogin.TabIndex = 3;
        btnLogin.Text = "Iniciar sesión";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(30, 188);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(0, 15);
        lblStatus.TabIndex = 4;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(500, 260);
        Controls.Add(lblStatus);
        Controls.Add(btnLogin);
        Controls.Add(txtDni);
        Controls.Add(lblDni);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Admin - Recicla Trujillo";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
