using admin.Components;

namespace admin.Views;

partial class ModalContainer
{
    private System.ComponentModel.IContainer components = null;
    private Label lblIcon;
    private Label lblMessage;
    private PrimaryButton btnPrimary;
    private PrimaryButton btnSecondary;
    private PrimaryButton btnTertiary;

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
        lblIcon = new Label();
        lblMessage = new Label();
        btnPrimary = new PrimaryButton();
        btnSecondary = new PrimaryButton();
        btnTertiary = new PrimaryButton();
        SuspendLayout();
        // 
        // lblIcon
        // 
        lblIcon.AutoSize = true;
        lblIcon.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
        lblIcon.ForeColor = Color.DodgerBlue;
        lblIcon.Location = new Point(23, 20);
        lblIcon.Name = "lblIcon";
        lblIcon.Size = new Size(85, 59);
        lblIcon.TabIndex = 0;
        lblIcon.Text = "ℹ";
        // 
        // lblMessage
        // 
        lblMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblMessage.Font = new Font("Segoe UI", 11F);
        lblMessage.ForeColor = Color.DarkSlateBlue;
        lblMessage.Location = new Point(114, 20);
        lblMessage.MaximumSize = new Size(300, 0);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new Size(263, 94);
        lblMessage.TabIndex = 1;
        lblMessage.Text = "Mensaje";
        // 
        // btnPrimary
        // 
        btnPrimary.BackColor = Color.DarkSlateBlue;
        btnPrimary.FlatAppearance.BorderSize = 0;
        btnPrimary.FlatStyle = FlatStyle.Flat;
        btnPrimary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnPrimary.ForeColor = Color.White;
        btnPrimary.HoverColor = Color.SlateBlue;
        btnPrimary.Location = new Point(255, 117);
        btnPrimary.Name = "btnPrimary";
        btnPrimary.NormalColor = Color.DarkSlateBlue;
        btnPrimary.Size = new Size(122, 40);
        btnPrimary.TabIndex = 3;
        btnPrimary.TabStop = false;
        btnPrimary.Text = "OK";
        btnPrimary.UseVisualStyleBackColor = false;
        btnPrimary.Visible = false;
        // 
        // btnSecondary
        // 
        btnSecondary.BackColor = Color.Gray;
        btnSecondary.FlatAppearance.BorderSize = 0;
        btnSecondary.FlatStyle = FlatStyle.Flat;
        btnSecondary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSecondary.ForeColor = Color.White;
        btnSecondary.HoverColor = Color.DarkGray;
        btnSecondary.Location = new Point(139, 117);
        btnSecondary.Name = "btnSecondary";
        btnSecondary.NormalColor = Color.Gray;
        btnSecondary.Size = new Size(110, 40);
        btnSecondary.TabIndex = 4;
        btnSecondary.TabStop = false;
        btnSecondary.Text = "Cancelar";
        btnSecondary.UseVisualStyleBackColor = false;
        btnSecondary.Visible = false;
        // 
        // btnTertiary
        // 
        btnTertiary.BackColor = Color.LightGray;
        btnTertiary.FlatAppearance.BorderSize = 0;
        btnTertiary.FlatStyle = FlatStyle.Flat;
        btnTertiary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnTertiary.ForeColor = Color.Black;
        btnTertiary.HoverColor = Color.WhiteSmoke;
        btnTertiary.Location = new Point(23, 117);
        btnTertiary.Name = "btnTertiary";
        btnTertiary.NormalColor = Color.LightGray;
        btnTertiary.Size = new Size(110, 40);
        btnTertiary.TabIndex = 5;
        btnTertiary.TabStop = false;
        btnTertiary.Text = "Cancelar";
        btnTertiary.UseVisualStyleBackColor = false;
        btnTertiary.Visible = false;
        // 
        // ModalContainer
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(400, 180);
        Controls.Add(btnTertiary);
        Controls.Add(btnSecondary);
        Controls.Add(lblMessage);
        Controls.Add(btnPrimary);
        Controls.Add(lblIcon);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ModalContainer";
        Padding = new Padding(20);
        StartPosition = FormStartPosition.CenterParent;
        Text = "Notificación";
        TopMost = true;
        ResumeLayout(false);
        PerformLayout();
    }
}
