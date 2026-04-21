using admin.Components;

namespace admin.Views;

partial class HomeView
{
    private System.ComponentModel.IContainer components = null;
    private Label lblWelcome;
    private Label lblSubtitle;
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
        lblWelcome = new Label();
        lblSubtitle = new Label();
        lblStatus = new Label();
        btnDeliveries = new PrimaryButton();
        btnRewards = new PrimaryButton();
        btnRedeemValidator = new PrimaryButton();
        btnUsers = new PrimaryButton();
        btnLogout = new PrimaryButton();
        SuspendLayout();
        // 
        // lblWelcome
        // 
        lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblWelcome.AutoSize = true;
        lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblWelcome.ForeColor = Color.DarkSlateBlue;
        lblWelcome.Location = new Point(20, 20);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(112, 25);
        lblWelcome.TabIndex = 0;
        lblWelcome.Text = "Bienvenido";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 10F);
        lblSubtitle.ForeColor = Color.Gray;
        lblSubtitle.Location = new Point(20, 45);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(143, 19);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Selecciona una opción";
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(20, 305);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(0, 15);
        lblStatus.TabIndex = 6;
        // 
        // btnDeliveries
        // 
        btnDeliveries.BackColor = Color.DarkSlateBlue;
        btnDeliveries.FlatAppearance.BorderSize = 0;
        btnDeliveries.FlatStyle = FlatStyle.Flat;
        btnDeliveries.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnDeliveries.ForeColor = Color.White;
        btnDeliveries.HoverColor = Color.SlateBlue;
        btnDeliveries.Location = new Point(20, 85);
        btnDeliveries.Name = "btnDeliveries";
        btnDeliveries.NormalColor = Color.DarkSlateBlue;
        btnDeliveries.Size = new Size(220, 45);
        btnDeliveries.TabIndex = 2;
        btnDeliveries.TabStop = false;
        btnDeliveries.Text = "Registrar Deliveries";
        btnDeliveries.UseVisualStyleBackColor = false;
        btnDeliveries.Click += btnDeliveries_Click;
        // 
        // btnRewards
        // 
        btnRewards.BackColor = Color.DarkSlateBlue;
        btnRewards.FlatAppearance.BorderSize = 0;
        btnRewards.FlatStyle = FlatStyle.Flat;
        btnRewards.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRewards.ForeColor = Color.White;
        btnRewards.HoverColor = Color.SlateBlue;
        btnRewards.Location = new Point(257, 85);
        btnRewards.Name = "btnRewards";
        btnRewards.NormalColor = Color.DarkSlateBlue;
        btnRewards.Size = new Size(220, 45);
        btnRewards.TabIndex = 3;
        btnRewards.TabStop = false;
        btnRewards.Text = "Tienda de Rewards";
        btnRewards.UseVisualStyleBackColor = false;
        btnRewards.Click += btnRewards_Click;
        // 
        // btnRedeemValidator
        // 
        btnRedeemValidator.BackColor = Color.DarkSlateBlue;
        btnRedeemValidator.FlatAppearance.BorderSize = 0;
        btnRedeemValidator.FlatStyle = FlatStyle.Flat;
        btnRedeemValidator.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRedeemValidator.ForeColor = Color.White;
        btnRedeemValidator.HoverColor = Color.SlateBlue;
        btnRedeemValidator.Location = new Point(20, 136);
        btnRedeemValidator.Name = "btnRedeemValidator";
        btnRedeemValidator.NormalColor = Color.DarkSlateBlue;
        btnRedeemValidator.Size = new Size(220, 45);
        btnRedeemValidator.TabIndex = 4;
        btnRedeemValidator.TabStop = false;
        btnRedeemValidator.Text = "Validar Canje por Código";
        btnRedeemValidator.UseVisualStyleBackColor = false;
        btnRedeemValidator.Click += btnRedeemValidator_Click;
        // 
        // btnUsers
        // 
        btnUsers.BackColor = Color.DarkSlateBlue;
        btnUsers.FlatAppearance.BorderSize = 0;
        btnUsers.FlatStyle = FlatStyle.Flat;
        btnUsers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnUsers.ForeColor = Color.White;
        btnUsers.HoverColor = Color.SlateBlue;
        btnUsers.Location = new Point(257, 136);
        btnUsers.Name = "btnUsers";
        btnUsers.NormalColor = Color.DarkSlateBlue;
        btnUsers.Size = new Size(220, 45);
        btnUsers.TabIndex = 5;
        btnUsers.TabStop = false;
        btnUsers.Text = "Crear Usuario (Admin/Citizen)";
        btnUsers.UseVisualStyleBackColor = false;
        btnUsers.Click += btnUsers_Click;
        // 
        // btnLogout
        // 
        btnLogout.BackColor = Color.IndianRed;
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.FlatStyle = FlatStyle.Flat;
        btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLogout.ForeColor = Color.White;
        btnLogout.HoverColor = Color.LightCoral;
        btnLogout.Location = new Point(257, 237);
        btnLogout.Name = "btnLogout";
        btnLogout.NormalColor = Color.IndianRed;
        btnLogout.Size = new Size(220, 40);
        btnLogout.TabIndex = 7;
        btnLogout.TabStop = false;
        btnLogout.Text = "Cerrar sesión";
        btnLogout.UseVisualStyleBackColor = false;
        btnLogout.Click += btnLogout_Click;
        // 
        // HomeView
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        Controls.Add(btnLogout);
        Controls.Add(lblStatus);
        Controls.Add(btnUsers);
        Controls.Add(btnRedeemValidator);
        Controls.Add(btnRewards);
        Controls.Add(btnDeliveries);
        Controls.Add(lblSubtitle);
        Controls.Add(lblWelcome);
        Margin = new Padding(0);
        Name = "HomeView";
        Padding = new Padding(20);
        Size = new Size(500, 300);
        ViewSize = new Size(500, 300);
        ViewTitle = "Inicio";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PrimaryButton btnDeliveries;
    private PrimaryButton btnRewards;
    private PrimaryButton btnRedeemValidator;
    private PrimaryButton btnUsers;
    private PrimaryButton btnLogout;
}
