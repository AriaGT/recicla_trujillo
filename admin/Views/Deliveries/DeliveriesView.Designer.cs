namespace admin.Views;

partial class DeliveriesView
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
        dgvDeliveries = new admin.Components.Table();
        Id = new DataGridViewTextBoxColumn();
        UserId = new DataGridViewTextBoxColumn();
        WasteType = new DataGridViewTextBoxColumn();
        QuantityKg = new DataGridViewTextBoxColumn();
        CreatedAt = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvDeliveries).BeginInit();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.DarkSlateBlue;
        lblTitle.Location = new Point(360, 29);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(200, 25);
        lblTitle.TabIndex = 11;
        lblTitle.Text = "Entregas de Residuos";
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
        btnRegister.TabIndex = 12;
        btnRegister.TabStop = false;
        btnRegister.Text = "Registrar entrega";
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
        btnBack.HoverColor = Color.SlateBlue;
        btnBack.Location = new Point(23, 23);
        btnBack.Name = "btnBack";
        btnBack.NormalColor = Color.IndianRed;
        btnBack.Size = new Size(120, 40);
        btnBack.TabIndex = 13;
        btnBack.TabStop = false;
        btnBack.Text = "Volver";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += btnBack_Click;
        // 
        // dgvDeliveries
        // 
        dgvDeliveries.AllowUserToAddRows = false;
        dgvDeliveries.AllowUserToResizeRows = false;
        dgvDeliveries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDeliveries.BackgroundColor = Color.White;
        dgvDeliveries.BorderStyle = BorderStyle.None;
        dgvDeliveries.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvDeliveries.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.DarkSlateBlue;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.White;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvDeliveries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvDeliveries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDeliveries.Columns.AddRange(new DataGridViewColumn[] { Id, UserId, WasteType, QuantityKg, CreatedAt });
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(232, 240, 254);
        dataGridViewCellStyle2.SelectionForeColor = Color.Black;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvDeliveries.DefaultCellStyle = dataGridViewCellStyle2;
        dgvDeliveries.EnableHeadersVisualStyles = false;
        dgvDeliveries.GridColor = Color.FromArgb(235, 235, 235);
        dgvDeliveries.Location = new Point(24, 92);
        dgvDeliveries.Margin = new Padding(4, 20, 4, 4);
        dgvDeliveries.MultiSelect = false;
        dgvDeliveries.Name = "dgvDeliveries";
        dgvDeliveries.ReadOnly = true;
        dgvDeliveries.RowHeadersVisible = false;
        dgvDeliveries.RowTemplate.Height = 40;
        dgvDeliveries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDeliveries.Size = new Size(874, 384);
        dgvDeliveries.TabIndex = 14;
        // 
        // Id
        // 
        Id.FillWeight = 20.30457F;
        Id.HeaderText = "ID";
        Id.Name = "Id";
        Id.ReadOnly = true;
        // 
        // UserId
        // 
        UserId.FillWeight = 119.923866F;
        UserId.HeaderText = "Usuario";
        UserId.Name = "UserId";
        UserId.ReadOnly = true;
        // 
        // WasteType
        // 
        WasteType.FillWeight = 119.923866F;
        WasteType.HeaderText = "Tipo";
        WasteType.Name = "WasteType";
        WasteType.ReadOnly = true;
        // 
        // QuantityKg
        // 
        QuantityKg.FillWeight = 119.923866F;
        QuantityKg.HeaderText = "Cantidad";
        QuantityKg.Name = "QuantityKg";
        QuantityKg.ReadOnly = true;
        // 
        // CreatedAt
        // 
        CreatedAt.FillWeight = 119.923866F;
        CreatedAt.HeaderText = "Fecha";
        CreatedAt.Name = "CreatedAt";
        CreatedAt.ReadOnly = true;
        // 
        // DeliveriesView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(dgvDeliveries);
        Controls.Add(btnBack);
        Controls.Add(btnRegister);
        Controls.Add(lblTitle);
        Name = "DeliveriesView";
        Padding = new Padding(20);
        Size = new Size(920, 500);
        ViewSize = new Size(920, 500);
        Load += DeliveriesView_Load;
        ((System.ComponentModel.ISupportInitialize)dgvDeliveries).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Components.PrimaryButton btnRegister;
    private Components.PrimaryButton btnBack;
    private Components.Table dgvDeliveries;
    private DataGridViewTextBoxColumn Id;
    private DataGridViewTextBoxColumn UserId;
    private DataGridViewTextBoxColumn WasteType;
    private DataGridViewTextBoxColumn QuantityKg;
    private DataGridViewTextBoxColumn CreatedAt;
}
