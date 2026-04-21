namespace admin.Components;

partial class MainContainer
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pnlContent = new Panel();
        pnlToolbar = new Panel();
        btnMin = new Button();
        btnExit = new Button();
        pnlToolbar.SuspendLayout();
        SuspendLayout();
        // 
        // pnlContent
        // 
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(0, 32);
        pnlContent.Margin = new Padding(0, 40, 0, 0);
        pnlContent.Name = "pnlContent";
        pnlContent.Size = new Size(300, 268);
        pnlContent.TabIndex = 0;
        // 
        // pnlToolbar
        // 
        pnlToolbar.BackColor = Color.DarkSlateBlue;
        pnlToolbar.Controls.Add(btnMin);
        pnlToolbar.Controls.Add(btnExit);
        pnlToolbar.Dock = DockStyle.Top;
        pnlToolbar.Location = new Point(0, 0);
        pnlToolbar.Margin = new Padding(0);
        pnlToolbar.Name = "pnlToolbar";
        pnlToolbar.Size = new Size(300, 32);
        pnlToolbar.TabIndex = 1;
        pnlToolbar.MouseDown += pnlToolbar_MouseDown;
        // 
        // btnMin
        // 
        btnMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnMin.Cursor = Cursors.Hand;
        btnMin.FlatAppearance.BorderSize = 0;
        btnMin.FlatStyle = FlatStyle.Flat;
        btnMin.Font = new Font("Segoe MDL2 Assets", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnMin.ForeColor = Color.White;
        btnMin.Location = new Point(244, 4);
        btnMin.Margin = new Padding(4, 4, 2, 4);
        btnMin.Name = "btnMin";
        btnMin.Size = new Size(24, 24);
        btnMin.TabIndex = 1;
        btnMin.Text = "";
        btnMin.TextAlign = ContentAlignment.BottomCenter;
        btnMin.UseVisualStyleBackColor = true;
        btnMin.Click += btnMin_Click;
        // 
        // btnExit
        // 
        btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnExit.Cursor = Cursors.Hand;
        btnExit.FlatAppearance.BorderSize = 0;
        btnExit.FlatStyle = FlatStyle.Flat;
        btnExit.Font = new Font("Segoe MDL2 Assets", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnExit.ForeColor = Color.White;
        btnExit.Location = new Point(272, 4);
        btnExit.Margin = new Padding(2, 4, 4, 4);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(24, 24);
        btnExit.TabIndex = 0;
        btnExit.Text = "";
        btnExit.TextAlign = ContentAlignment.BottomCenter;
        btnExit.UseVisualStyleBackColor = true;
        btnExit.Click += btnExit_Click;
        // 
        // MainContainer
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(300, 300);
        ControlBox = false;
        Controls.Add(pnlContent);
        Controls.Add(pnlToolbar);
        FormBorderStyle = FormBorderStyle.None;
        Name = "MainContainer";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "MainContainer";
        pnlToolbar.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlContent;
    private Panel pnlToolbar;
    private Button btnMin;
    public Button btnExit;
}