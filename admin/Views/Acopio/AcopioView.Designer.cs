using admin.Components;

namespace admin.Views;

partial class AcopioView
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
        lblTitle = new Label();
        lblOrigin = new Label();
        cboOrigin = new ComboBox();
        btnAnalyze = new PrimaryButton();
        btnBack = new PrimaryButton();
        lblOutput = new Label();
        SuspendLayout();
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.DarkSlateBlue;
        lblTitle.Location = new Point(157, 29);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(180, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Puntos de Acopio";
        //
        // lblOrigin
        //
        lblOrigin.AutoSize = true;
        lblOrigin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblOrigin.ForeColor = Color.DarkSlateBlue;
        lblOrigin.Location = new Point(23, 85);
        lblOrigin.Name = "lblOrigin";
        lblOrigin.Size = new Size(120, 19);
        lblOrigin.TabIndex = 1;
        lblOrigin.Text = "Punto de acopio";
        //
        // cboOrigin
        //
        cboOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
        cboOrigin.Font = new Font("Segoe UI", 10F);
        cboOrigin.Location = new Point(23, 108);
        cboOrigin.Name = "cboOrigin";
        cboOrigin.Size = new Size(253, 28);
        cboOrigin.TabIndex = 2;
        //
        // btnAnalyze
        //
        btnAnalyze.BackColor = Color.DarkSlateBlue;
        btnAnalyze.FlatAppearance.BorderSize = 0;
        btnAnalyze.FlatStyle = FlatStyle.Flat;
        btnAnalyze.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnAnalyze.ForeColor = Color.White;
        btnAnalyze.HoverColor = Color.SlateBlue;
        btnAnalyze.Location = new Point(292, 102);
        btnAnalyze.Name = "btnAnalyze";
        btnAnalyze.NormalColor = Color.DarkSlateBlue;
        btnAnalyze.Size = new Size(160, 40);
        btnAnalyze.TabIndex = 3;
        btnAnalyze.TabStop = false;
        btnAnalyze.Text = "Analizar red";
        btnAnalyze.UseVisualStyleBackColor = false;
        btnAnalyze.Click += btnAnalyze_Click;
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
        btnBack.TabIndex = 4;
        btnBack.TabStop = false;
        btnBack.Text = "Volver";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += btnBack_Click;
        //
        // lblOutput
        //
        lblOutput.BackColor = Color.FromArgb(245, 245, 250);
        lblOutput.BorderStyle = BorderStyle.FixedSingle;
        lblOutput.Font = new Font("Segoe UI", 10F);
        lblOutput.ForeColor = Color.DarkSlateBlue;
        lblOutput.Location = new Point(23, 160);
        lblOutput.Name = "lblOutput";
        lblOutput.Padding = new Padding(12);
        lblOutput.Size = new Size(429, 300);
        lblOutput.TabIndex = 5;
        lblOutput.Text = "Selecciona un punto y presiona \"Analizar red\".";
        //
        // AcopioView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(lblOutput);
        Controls.Add(btnBack);
        Controls.Add(btnAnalyze);
        Controls.Add(cboOrigin);
        Controls.Add(lblOrigin);
        Controls.Add(lblTitle);
        Name = "AcopioView";
        Padding = new Padding(20);
        Size = new Size(500, 500);
        ViewSize = new Size(500, 500);
        ViewTitle = "Red de puntos de acopio";
        Load += AcopioView_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblOrigin;
    private ComboBox cboOrigin;
    private PrimaryButton btnAnalyze;
    private PrimaryButton btnBack;
    private Label lblOutput;
}
