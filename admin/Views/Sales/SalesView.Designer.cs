using admin.Components;

namespace admin.Views;

partial class SalesView
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
        lblCode = new Label();
        txtCode = new Input();
        btnValidate = new PrimaryButton();
        btnBack = new PrimaryButton();
        btnRefresh = new PrimaryButton();
        btnAttend = new PrimaryButton();
        lblQueue = new Label();
        dgvSales = new Table();
        Id = new DataGridViewTextBoxColumn();
        UserId = new DataGridViewTextBoxColumn();
        RewardId = new DataGridViewTextBoxColumn();
        Amount = new DataGridViewTextBoxColumn();
        Code = new DataGridViewTextBoxColumn();
        CreatedAt = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
        SuspendLayout();
        //
        // lblTitle
        //
        lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.DarkSlateBlue;
        lblTitle.Location = new Point(407, 29);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(81, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Ventas";
        //
        // lblCode
        //
        lblCode.AutoSize = true;
        lblCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCode.ForeColor = Color.DarkSlateBlue;
        lblCode.Location = new Point(651, 12);
        lblCode.Name = "lblCode";
        lblCode.Size = new Size(58, 19);
        lblCode.TabIndex = 1;
        lblCode.Text = "Código";
        //
        // txtCode
        //
        txtCode.BackColor = Color.White;
        txtCode.Location = new Point(588, 33);
        txtCode.Margin = new Padding(4, 2, 4, 2);
        txtCode.Name = "txtCode";
        txtCode.Size = new Size(182, 30);
        txtCode.TabIndex = 2;
        //
        // btnValidate
        //
        btnValidate.BackColor = Color.DarkSlateBlue;
        btnValidate.FlatAppearance.BorderSize = 0;
        btnValidate.FlatStyle = FlatStyle.Flat;
        btnValidate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnValidate.ForeColor = Color.White;
        btnValidate.HoverColor = Color.SlateBlue;
        btnValidate.Location = new Point(777, 23);
        btnValidate.Name = "btnValidate";
        btnValidate.NormalColor = Color.DarkSlateBlue;
        btnValidate.Size = new Size(120, 40);
        btnValidate.TabIndex = 3;
        btnValidate.TabStop = false;
        btnValidate.Text = "Validar";
        btnValidate.UseVisualStyleBackColor = false;
        btnValidate.Click += btnValidate_Click;
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
        // btnRefresh
        //
        btnRefresh.BackColor = Color.DarkSlateBlue;
        btnRefresh.FlatAppearance.BorderSize = 0;
        btnRefresh.FlatStyle = FlatStyle.Flat;
        btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRefresh.ForeColor = Color.White;
        btnRefresh.HoverColor = Color.SlateBlue;
        btnRefresh.Location = new Point(157, 23);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.NormalColor = Color.DarkSlateBlue;
        btnRefresh.Size = new Size(120, 40);
        btnRefresh.TabIndex = 5;
        btnRefresh.TabStop = false;
        btnRefresh.Text = "Refrescar";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += btnRefresh_Click;
        //
        // btnAttend
        //
        btnAttend.BackColor = Color.SeaGreen;
        btnAttend.FlatAppearance.BorderSize = 0;
        btnAttend.FlatStyle = FlatStyle.Flat;
        btnAttend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnAttend.ForeColor = Color.White;
        btnAttend.HoverColor = Color.MediumSeaGreen;
        btnAttend.Location = new Point(291, 23);
        btnAttend.Name = "btnAttend";
        btnAttend.NormalColor = Color.SeaGreen;
        btnAttend.Size = new Size(160, 40);
        btnAttend.TabIndex = 6;
        btnAttend.TabStop = false;
        btnAttend.Text = "Atender siguiente";
        btnAttend.UseVisualStyleBackColor = false;
        btnAttend.Click += btnAttend_Click;
        //
        // lblQueue
        //
        lblQueue.AutoSize = true;
        lblQueue.Font = new Font("Segoe UI", 10F);
        lblQueue.ForeColor = Color.Gray;
        lblQueue.Location = new Point(465, 33);
        lblQueue.Name = "lblQueue";
        lblQueue.Size = new Size(0, 19);
        lblQueue.TabIndex = 7;
        //
        // dgvSales
        //
        dgvSales.AllowUserToAddRows = false;
        dgvSales.AllowUserToResizeRows = false;
        dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvSales.BackgroundColor = Color.White;
        dgvSales.BorderStyle = BorderStyle.None;
        dgvSales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvSales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.DarkSlateBlue;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.White;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvSales.Columns.AddRange(new DataGridViewColumn[] { Id, UserId, RewardId, Amount, Code, CreatedAt });
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(232, 240, 254);
        dataGridViewCellStyle2.SelectionForeColor = Color.Black;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvSales.DefaultCellStyle = dataGridViewCellStyle2;
        dgvSales.EnableHeadersVisualStyles = false;
        dgvSales.GridColor = Color.FromArgb(235, 235, 235);
        dgvSales.Location = new Point(24, 86);
        dgvSales.Margin = new Padding(4, 20, 4, 4);
        dgvSales.MultiSelect = false;
        dgvSales.Name = "dgvSales";
        dgvSales.ReadOnly = true;
        dgvSales.RowHeadersVisible = false;
        dgvSales.RowTemplate.Height = 40;
        dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvSales.Size = new Size(874, 390);
        dgvSales.TabIndex = 8;
        //
        // Id
        //
        Id.FillWeight = 25F;
        Id.HeaderText = "ID";
        Id.Name = "Id";
        Id.ReadOnly = true;
        //
        // UserId
        //
        UserId.FillWeight = 50F;
        UserId.HeaderText = "Usuario";
        UserId.Name = "UserId";
        UserId.ReadOnly = true;
        //
        // RewardId
        //
        RewardId.FillWeight = 50F;
        RewardId.HeaderText = "Reward";
        RewardId.Name = "RewardId";
        RewardId.ReadOnly = true;
        //
        // Amount
        //
        Amount.FillWeight = 60F;
        Amount.HeaderText = "Monto (S/)";
        Amount.Name = "Amount";
        Amount.ReadOnly = true;
        //
        // Code
        //
        Code.FillWeight = 70F;
        Code.HeaderText = "Código";
        Code.Name = "Code";
        Code.ReadOnly = true;
        //
        // CreatedAt
        //
        CreatedAt.HeaderText = "Fecha";
        CreatedAt.Name = "CreatedAt";
        CreatedAt.ReadOnly = true;
        //
        // SalesView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(dgvSales);
        Controls.Add(lblQueue);
        Controls.Add(btnAttend);
        Controls.Add(btnRefresh);
        Controls.Add(btnBack);
        Controls.Add(btnValidate);
        Controls.Add(txtCode);
        Controls.Add(lblCode);
        Controls.Add(lblTitle);
        Name = "SalesView";
        Padding = new Padding(20);
        Size = new Size(920, 500);
        ViewSize = new Size(920, 500);
        ViewTitle = "Gestión de ventas";
        Load += SalesView_Load;
        ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblCode;
    private Input txtCode;
    private PrimaryButton btnValidate;
    private PrimaryButton btnBack;
    private PrimaryButton btnRefresh;
    private PrimaryButton btnAttend;
    private Label lblQueue;
    private Components.Table dgvSales;
    private DataGridViewTextBoxColumn Id;
    private DataGridViewTextBoxColumn UserId;
    private DataGridViewTextBoxColumn RewardId;
    private DataGridViewTextBoxColumn Amount;
    private DataGridViewTextBoxColumn Code;
    private DataGridViewTextBoxColumn CreatedAt;
}
