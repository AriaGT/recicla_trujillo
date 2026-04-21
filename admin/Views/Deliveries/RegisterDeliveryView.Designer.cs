using admin.Components;

namespace admin.Views;

partial class RegisterDeliveryView
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblUser;
    private Label lblWasteType;
    private Label lblKg;
    private Label lblStatus;
    private SelectMenu selectUsers;
    private SelectMenu selectWasteType;
    private NumericInput numKg;
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
        lblUser = new Label();
        lblWasteType = new Label();
        lblKg = new Label();
        lblStatus = new Label();
        selectUsers = new SelectMenu();
        selectWasteType = new SelectMenu();
        numKg = new NumericInput();
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
        lblTitle.Size = new Size(166, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Registrar entrega";
        // 
        // lblUser
        // 
        lblUser.AutoSize = true;
        lblUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblUser.ForeColor = Color.DarkSlateBlue;
        lblUser.Location = new Point(23, 57);
        lblUser.Name = "lblUser";
        lblUser.Size = new Size(60, 19);
        lblUser.TabIndex = 1;
        lblUser.Text = "Usuario";
        // 
        // lblWasteType
        // 
        lblWasteType.AutoSize = true;
        lblWasteType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblWasteType.ForeColor = Color.DarkSlateBlue;
        lblWasteType.Location = new Point(23, 127);
        lblWasteType.Name = "lblWasteType";
        lblWasteType.Size = new Size(96, 19);
        lblWasteType.TabIndex = 3;
        lblWasteType.Text = "Tipo Residuo";
        // 
        // lblKg
        // 
        lblKg.AutoSize = true;
        lblKg.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblKg.ForeColor = Color.DarkSlateBlue;
        lblKg.Location = new Point(23, 197);
        lblKg.Name = "lblKg";
        lblKg.Size = new Size(100, 19);
        lblKg.TabIndex = 5;
        lblKg.Text = "Cantidad (kg)";
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 9F);
        lblStatus.ForeColor = Color.Gray;
        lblStatus.Location = new Point(23, 250);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(0, 15);
        lblStatus.TabIndex = 7;
        // 
        // selectUsers
        // 
        selectUsers.BackColor = Color.White;
        selectUsers.DataSource = null;
        selectUsers.DisplayMember = "";
        selectUsers.Location = new Point(23, 78);
        selectUsers.Margin = new Padding(4, 2, 4, 2);
        selectUsers.Name = "selectUsers";
        selectUsers.SelectedIndex = -1;
        selectUsers.SelectedValue = null;
        selectUsers.Size = new Size(253, 30);
        selectUsers.TabIndex = 2;
        selectUsers.TextColor = Color.DarkSlateBlue;
        selectUsers.UnderlineColor = Color.DarkSlateBlue;
        selectUsers.ValueMember = "";
        // 
        // selectWasteType
        // 
        selectWasteType.BackColor = Color.White;
        selectWasteType.DataSource = null;
        selectWasteType.DisplayMember = "";
        selectWasteType.Location = new Point(23, 148);
        selectWasteType.Margin = new Padding(4, 2, 4, 2);
        selectWasteType.Name = "selectWasteType";
        selectWasteType.SelectedIndex = -1;
        selectWasteType.SelectedValue = null;
        selectWasteType.Size = new Size(253, 30);
        selectWasteType.TabIndex = 4;
        selectWasteType.TextColor = Color.DarkSlateBlue;
        selectWasteType.UnderlineColor = Color.DarkSlateBlue;
        selectWasteType.ValueMember = "";
        // 
        // numKg
        // 
        numKg.BackColor = Color.White;
        numKg.DecimalPlaces = 2;
        numKg.Location = new Point(23, 218);
        numKg.Margin = new Padding(4, 2, 4, 2);
        numKg.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numKg.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numKg.Name = "numKg";
        numKg.ReadOnly = false;
        numKg.Size = new Size(253, 30);
        numKg.TabIndex = 6;
        numKg.TextColor = Color.DarkSlateBlue;
        numKg.UnderlineColor = Color.DarkSlateBlue;
        numKg.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
        btnRegister.TabIndex = 8;
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
        btnBack.TabIndex = 10;
        btnBack.TabStop = false;
        btnBack.Text = "Volver";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += btnBack_Click;
        // 
        // RegisterDeliveryView
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        Controls.Add(btnBack);
        Controls.Add(btnRegister);
        Controls.Add(lblStatus);
        Controls.Add(numKg);
        Controls.Add(lblKg);
        Controls.Add(selectWasteType);
        Controls.Add(lblWasteType);
        Controls.Add(selectUsers);
        Controls.Add(lblUser);
        Controls.Add(lblTitle);
        Margin = new Padding(0);
        Name = "RegisterDeliveryView";
        Padding = new Padding(20);
        Size = new Size(300, 360);
        ViewSize = new Size(300, 360);
        ViewTitle = "Entrega de residuos";
        Load += RegisterDeliveryView_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
