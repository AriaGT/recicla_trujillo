namespace admin.Views;

partial class RewardsView
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        lblTitle = new Label();
        btnRegister = new admin.Components.PrimaryButton();
        btnBack = new admin.Components.PrimaryButton();
        btnRefresh = new admin.Components.PrimaryButton();
        dgvRewards = new admin.Components.Table();
        Id = new DataGridViewTextBoxColumn();
        RewardName = new DataGridViewTextBoxColumn();
        RequiredPoints = new DataGridViewTextBoxColumn();
        Stock = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvRewards).BeginInit();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.DarkSlateBlue;
        lblTitle.Location = new Point(408, 29);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(80, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Rewards";
        // 
        // btnRegister
        // 
        btnRegister.BackColor = Color.DarkSlateBlue;
        btnRegister.FlatAppearance.BorderSize = 0;
        btnRegister.FlatStyle = FlatStyle.Flat;
        btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRegister.ForeColor = Color.White;
        btnRegister.HoverColor = Color.SlateBlue;
        btnRegister.Location = new Point(702, 23);
        btnRegister.Name = "btnRegister";
        btnRegister.NormalColor = Color.DarkSlateBlue;
        btnRegister.Size = new Size(195, 40);
        btnRegister.TabIndex = 1;
        btnRegister.TabStop = false;
        btnRegister.Text = "Registrar reward";
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
        btnBack.Location = new Point(23, 23);
        btnBack.Name = "btnBack";
        btnBack.NormalColor = Color.IndianRed;
        btnBack.Size = new Size(120, 40);
        btnBack.TabIndex = 2;
        btnBack.TabStop = false;
        btnBack.Text = "Volver";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += btnBack_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.BackColor = Color.DarkSlateBlue;
        btnRefresh.FlatAppearance.BorderSize = 0;
        btnRefresh.FlatStyle = FlatStyle.Flat;
        btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRefresh.ForeColor = Color.White;
        btnRefresh.HoverColor = Color.SlateBlue;
        btnRefresh.Location = new Point(577, 23);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.NormalColor = Color.DarkSlateBlue;
        btnRefresh.Size = new Size(120, 40);
        btnRefresh.TabIndex = 3;
        btnRefresh.TabStop = false;
        btnRefresh.Text = "Refrescar";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += btnRefresh_Click;
        // 
        // dgvRewards
        // 
        dgvRewards.AllowUserToAddRows = false;
        dgvRewards.AllowUserToResizeRows = false;
        dgvRewards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvRewards.BackgroundColor = Color.White;
        dgvRewards.BorderStyle = BorderStyle.None;
        dgvRewards.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvRewards.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.DarkSlateBlue;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.White;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvRewards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvRewards.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvRewards.Columns.AddRange(new DataGridViewColumn[] { Id, RewardName, RequiredPoints, Stock });
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(232, 240, 254);
        dataGridViewCellStyle2.SelectionForeColor = Color.Black;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvRewards.DefaultCellStyle = dataGridViewCellStyle2;
        dgvRewards.EnableHeadersVisualStyles = false;
        dgvRewards.GridColor = Color.FromArgb(235, 235, 235);
        dgvRewards.Location = new Point(24, 92);
        dgvRewards.Margin = new Padding(4, 20, 4, 4);
        dgvRewards.MultiSelect = false;
        dgvRewards.Name = "dgvRewards";
        dgvRewards.ReadOnly = true;
        dgvRewards.RowHeadersVisible = false;
        dgvRewards.RowTemplate.Height = 40;
        dgvRewards.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRewards.Size = new Size(874, 384);
        dgvRewards.TabIndex = 4;
        // 
        // Id
        // 
        Id.FillWeight = 30F;
        Id.HeaderText = "ID";
        Id.Name = "Id";
        Id.ReadOnly = true;
        // 
        // RewardName
        // 
        RewardName.FillWeight = 180F;
        RewardName.HeaderText = "Nombre";
        RewardName.Name = "RewardName";
        RewardName.ReadOnly = true;
        // 
        // RequiredPoints
        // 
        RequiredPoints.FillWeight = 90F;
        RequiredPoints.HeaderText = "Puntos";
        RequiredPoints.Name = "RequiredPoints";
        RequiredPoints.ReadOnly = true;
        // 
        // Stock
        // 
        Stock.FillWeight = 70F;
        Stock.HeaderText = "Stock";
        Stock.Name = "Stock";
        Stock.ReadOnly = true;
        // 
        // RewardsView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(dgvRewards);
        Controls.Add(btnRefresh);
        Controls.Add(btnBack);
        Controls.Add(btnRegister);
        Controls.Add(lblTitle);
        Name = "RewardsView";
        Padding = new Padding(20);
        Size = new Size(920, 500);
        ViewSize = new Size(920, 500);
        ViewTitle = "Gestión de rewards";
        Load += RewardsView_Load;
        ((System.ComponentModel.ISupportInitialize)dgvRewards).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Components.PrimaryButton btnRegister;
    private Components.PrimaryButton btnBack;
    private Components.PrimaryButton btnRefresh;
    private Components.Table dgvRewards;
    private DataGridViewTextBoxColumn Id;
    private DataGridViewTextBoxColumn RewardName;
    private DataGridViewTextBoxColumn RequiredPoints;
    private DataGridViewTextBoxColumn Stock;
}
