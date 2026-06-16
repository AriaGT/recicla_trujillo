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
        btnSales = new PrimaryButton();
        btnUsers = new PrimaryButton();
        btnCaja = new PrimaryButton();
        btnAcopio = new PrimaryButton();
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
        lblStatus.Location = new Point(20, 360);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(0, 15);
        lblStatus.TabIndex = 9;
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
        btnDeliveries.Text = "Registrar Entregas";
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
        // btnSales
        //
        btnSales.BackColor = Color.DarkSlateBlue;
        btnSales.FlatAppearance.BorderSize = 0;
        btnSales.FlatStyle = FlatStyle.Flat;
        btnSales.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSales.ForeColor = Color.White;
        btnSales.HoverColor = Color.SlateBlue;
        btnSales.Location = new Point(20, 136);
        btnSales.Name = "btnSales";
        btnSales.NormalColor = Color.DarkSlateBlue;
        btnSales.Size = new Size(220, 45);
        btnSales.TabIndex = 4;
        btnSales.TabStop = false;
        btnSales.Text = "Ventas (Ingresos)";
        btnSales.UseVisualStyleBackColor = false;
        btnSales.Click += btnSales_Click;
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
        btnUsers.Text = "Usuarios";
        btnUsers.UseVisualStyleBackColor = false;
        btnUsers.Click += btnUsers_Click;
        //
        // btnCaja
        //
        btnCaja.BackColor = Color.DarkSlateBlue;
        btnCaja.FlatAppearance.BorderSize = 0;
        btnCaja.FlatStyle = FlatStyle.Flat;
        btnCaja.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCaja.ForeColor = Color.White;
        btnCaja.HoverColor = Color.SlateBlue;
        btnCaja.Location = new Point(20, 187);
        btnCaja.Name = "btnCaja";
        btnCaja.NormalColor = Color.DarkSlateBlue;
        btnCaja.Size = new Size(220, 45);
        btnCaja.TabIndex = 6;
        btnCaja.TabStop = false;
        btnCaja.Text = "Caja (Ingresos/Egresos)";
        btnCaja.UseVisualStyleBackColor = false;
        btnCaja.Click += btnCaja_Click;
        //
        // btnAcopio
        //
        btnAcopio.BackColor = Color.DarkSlateBlue;
        btnAcopio.FlatAppearance.BorderSize = 0;
        btnAcopio.FlatStyle = FlatStyle.Flat;
        btnAcopio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnAcopio.ForeColor = Color.White;
        btnAcopio.HoverColor = Color.SlateBlue;
        btnAcopio.Location = new Point(257, 187);
        btnAcopio.Name = "btnAcopio";
        btnAcopio.NormalColor = Color.DarkSlateBlue;
        btnAcopio.Size = new Size(220, 45);
        btnAcopio.TabIndex = 7;
        btnAcopio.TabStop = false;
        btnAcopio.Text = "Puntos de Acopio";
        btnAcopio.UseVisualStyleBackColor = false;
        btnAcopio.Click += btnAcopio_Click;
        //
        // btnLogout
        //
        btnLogout.BackColor = Color.IndianRed;
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.FlatStyle = FlatStyle.Flat;
        btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLogout.ForeColor = Color.White;
        btnLogout.HoverColor = Color.LightCoral;
        btnLogout.Location = new Point(257, 290);
        btnLogout.Name = "btnLogout";
        btnLogout.NormalColor = Color.IndianRed;
        btnLogout.Size = new Size(220, 40);
        btnLogout.TabIndex = 8;
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
        Controls.Add(btnAcopio);
        Controls.Add(btnCaja);
        Controls.Add(btnUsers);
        Controls.Add(btnSales);
        Controls.Add(btnRewards);
        Controls.Add(btnDeliveries);
        Controls.Add(lblSubtitle);
        Controls.Add(lblWelcome);
        Margin = new Padding(0);
        Name = "HomeView";
        Padding = new Padding(20);
        Size = new Size(500, 360);
        ViewSize = new Size(500, 360);
        ViewTitle = "Inicio";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PrimaryButton btnDeliveries;
    private PrimaryButton btnRewards;
    private PrimaryButton btnSales;
    private PrimaryButton btnUsers;
    private PrimaryButton btnCaja;
    private PrimaryButton btnAcopio;
    private PrimaryButton btnLogout;
}
