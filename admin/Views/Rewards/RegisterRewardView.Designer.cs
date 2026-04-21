using admin.Components;

namespace admin.Views;

partial class RegisterRewardView
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblName;
    private Label lblPoints;
    private Label lblStock;
    private Input txtName;
    private NumericInput numPoints;
    private NumericInput numStock;
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
        lblName = new Label();
        lblPoints = new Label();
        lblStock = new Label();
        txtName = new Input();
        numPoints = new NumericInput();
        numStock = new NumericInput();
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
        lblTitle.Size = new Size(167, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Registrar reward";
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblName.ForeColor = Color.DarkSlateBlue;
        lblName.Location = new Point(23, 57);
        lblName.Name = "lblName";
        lblName.Size = new Size(64, 19);
        lblName.TabIndex = 1;
        lblName.Text = "Nombre";
        // 
        // lblPoints
        // 
        lblPoints.AutoSize = true;
        lblPoints.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPoints.ForeColor = Color.DarkSlateBlue;
        lblPoints.Location = new Point(23, 127);
        lblPoints.Name = "lblPoints";
        lblPoints.Size = new Size(55, 19);
        lblPoints.TabIndex = 3;
        lblPoints.Text = "Puntos";
        // 
        // lblStock
        // 
        lblStock.AutoSize = true;
        lblStock.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblStock.ForeColor = Color.DarkSlateBlue;
        lblStock.Location = new Point(23, 197);
        lblStock.Name = "lblStock";
        lblStock.Size = new Size(44, 19);
        lblStock.TabIndex = 5;
        lblStock.Text = "Stock";
        // 
        // txtName
        // 
        txtName.BackColor = Color.White;
        txtName.Location = new Point(23, 78);
        txtName.Margin = new Padding(4, 2, 4, 2);
        txtName.Name = "txtName";
        txtName.Size = new Size(253, 30);
        txtName.TabIndex = 2;
        txtName.Text = "";
        // 
        // numPoints
        // 
        numPoints.BackColor = Color.White;
        numPoints.DecimalPlaces = 0;
        numPoints.Location = new Point(23, 148);
        numPoints.Margin = new Padding(4, 2, 4, 2);
        numPoints.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        numPoints.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numPoints.Name = "numPoints";
        numPoints.ReadOnly = false;
        numPoints.Size = new Size(253, 30);
        numPoints.TabIndex = 4;
        numPoints.TextColor = Color.DarkSlateBlue;
        numPoints.UnderlineColor = Color.DarkSlateBlue;
        numPoints.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // numStock
        // 
        numStock.BackColor = Color.White;
        numStock.DecimalPlaces = 0;
        numStock.Location = new Point(23, 218);
        numStock.Margin = new Padding(4, 2, 4, 2);
        numStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        numStock.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
        numStock.Name = "numStock";
        numStock.ReadOnly = false;
        numStock.Size = new Size(253, 30);
        numStock.TabIndex = 6;
        numStock.TextColor = Color.DarkSlateBlue;
        numStock.UnderlineColor = Color.DarkSlateBlue;
        numStock.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
        // RegisterRewardView
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        Controls.Add(btnBack);
        Controls.Add(btnRegister);
        Controls.Add(numStock);
        Controls.Add(numPoints);
        Controls.Add(txtName);
        Controls.Add(lblStock);
        Controls.Add(lblPoints);
        Controls.Add(lblName);
        Controls.Add(lblTitle);
        Margin = new Padding(0);
        Name = "RegisterRewardView";
        Padding = new Padding(20);
        Size = new Size(300, 360);
        ViewSize = new Size(300, 360);
        ViewTitle = "Registro de reward";
        Load += RegisterRewardView_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
