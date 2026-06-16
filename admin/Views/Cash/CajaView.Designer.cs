using admin.Components;

namespace admin.Views;

partial class CajaView
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
        lblIncome = new Label();
        lblExpense = new Label();
        lblBalance = new Label();
        btnBack = new PrimaryButton();
        btnRefresh = new PrimaryButton();
        dgvMovements = new Table();
        ColDate = new DataGridViewTextBoxColumn();
        ColType = new DataGridViewTextBoxColumn();
        ColAmount = new DataGridViewTextBoxColumn();
        ColConcept = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvMovements).BeginInit();
        SuspendLayout();
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.DarkSlateBlue;
        lblTitle.Location = new Point(157, 29);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(60, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Caja";
        //
        // lblIncome
        //
        lblIncome.AutoSize = true;
        lblIncome.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblIncome.ForeColor = Color.SeaGreen;
        lblIncome.Location = new Point(24, 80);
        lblIncome.Name = "lblIncome";
        lblIncome.Size = new Size(80, 20);
        lblIncome.TabIndex = 1;
        lblIncome.Text = "Ingresos: S/ 0.00";
        //
        // lblExpense
        //
        lblExpense.AutoSize = true;
        lblExpense.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblExpense.ForeColor = Color.IndianRed;
        lblExpense.Location = new Point(280, 80);
        lblExpense.Name = "lblExpense";
        lblExpense.Size = new Size(80, 20);
        lblExpense.TabIndex = 2;
        lblExpense.Text = "Egresos: S/ 0.00";
        //
        // lblBalance
        //
        lblBalance.AutoSize = true;
        lblBalance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblBalance.ForeColor = Color.DarkSlateBlue;
        lblBalance.Location = new Point(536, 80);
        lblBalance.Name = "lblBalance";
        lblBalance.Size = new Size(80, 20);
        lblBalance.TabIndex = 3;
        lblBalance.Text = "Saldo: S/ 0.00";
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
        btnRefresh.Location = new Point(777, 23);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.NormalColor = Color.DarkSlateBlue;
        btnRefresh.Size = new Size(120, 40);
        btnRefresh.TabIndex = 5;
        btnRefresh.TabStop = false;
        btnRefresh.Text = "Refrescar";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += btnRefresh_Click;
        //
        // dgvMovements
        //
        dgvMovements.AllowUserToAddRows = false;
        dgvMovements.AllowUserToResizeRows = false;
        dgvMovements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvMovements.BackgroundColor = Color.White;
        dgvMovements.BorderStyle = BorderStyle.None;
        dgvMovements.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvMovements.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.DarkSlateBlue;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.White;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvMovements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvMovements.Columns.AddRange(new DataGridViewColumn[] { ColDate, ColType, ColAmount, ColConcept });
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(232, 240, 254);
        dataGridViewCellStyle2.SelectionForeColor = Color.Black;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvMovements.DefaultCellStyle = dataGridViewCellStyle2;
        dgvMovements.EnableHeadersVisualStyles = false;
        dgvMovements.GridColor = Color.FromArgb(235, 235, 235);
        dgvMovements.Location = new Point(24, 120);
        dgvMovements.Margin = new Padding(4, 20, 4, 4);
        dgvMovements.MultiSelect = false;
        dgvMovements.Name = "dgvMovements";
        dgvMovements.ReadOnly = true;
        dgvMovements.RowHeadersVisible = false;
        dgvMovements.RowTemplate.Height = 40;
        dgvMovements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMovements.Size = new Size(874, 356);
        dgvMovements.TabIndex = 6;
        //
        // ColDate
        //
        ColDate.FillWeight = 70F;
        ColDate.HeaderText = "Fecha";
        ColDate.Name = "ColDate";
        ColDate.ReadOnly = true;
        //
        // ColType
        //
        ColType.FillWeight = 50F;
        ColType.HeaderText = "Tipo";
        ColType.Name = "ColType";
        ColType.ReadOnly = true;
        //
        // ColAmount
        //
        ColAmount.FillWeight = 50F;
        ColAmount.HeaderText = "Monto (S/)";
        ColAmount.Name = "ColAmount";
        ColAmount.ReadOnly = true;
        //
        // ColConcept
        //
        ColConcept.FillWeight = 160F;
        ColConcept.HeaderText = "Concepto";
        ColConcept.Name = "ColConcept";
        ColConcept.ReadOnly = true;
        //
        // CajaView
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(dgvMovements);
        Controls.Add(btnRefresh);
        Controls.Add(btnBack);
        Controls.Add(lblBalance);
        Controls.Add(lblExpense);
        Controls.Add(lblIncome);
        Controls.Add(lblTitle);
        Name = "CajaView";
        Padding = new Padding(20);
        Size = new Size(920, 500);
        ViewSize = new Size(920, 500);
        ViewTitle = "Caja - Ingresos y Egresos";
        Load += CajaView_Load;
        ((System.ComponentModel.ISupportInitialize)dgvMovements).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblIncome;
    private Label lblExpense;
    private Label lblBalance;
    private PrimaryButton btnBack;
    private PrimaryButton btnRefresh;
    private Components.Table dgvMovements;
    private DataGridViewTextBoxColumn ColDate;
    private DataGridViewTextBoxColumn ColType;
    private DataGridViewTextBoxColumn ColAmount;
    private DataGridViewTextBoxColumn ColConcept;
}
