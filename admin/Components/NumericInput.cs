using System.ComponentModel;

namespace admin.Components;

public class NumericInput : UserControl
{
    private NumericUpDown numValue;
    private Panel pnlUnderline;

    public NumericInput()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        numValue = new NumericUpDown();
        pnlUnderline = new Panel();
        ((ISupportInitialize)numValue).BeginInit();
        SuspendLayout();
        // 
        // numValue
        // 
        numValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        numValue.BackColor = Color.White;
        numValue.BorderStyle = BorderStyle.None;
        numValue.Font = new Font("Segoe UI", 10F);
        numValue.ForeColor = Color.DarkSlateBlue;
        numValue.Location = new Point(6, 4);
        numValue.Margin = new Padding(6, 4, 6, 4);
        numValue.Name = "numValue";
        numValue.Size = new Size(288, 21);
        numValue.TabIndex = 0;
        numValue.ValueChanged += NumValue_ValueChanged;
        // 
        // pnlUnderline
        // 
        pnlUnderline.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnlUnderline.BackColor = Color.DarkSlateBlue;
        pnlUnderline.Location = new Point(0, 28);
        pnlUnderline.Name = "pnlUnderline";
        pnlUnderline.Size = new Size(300, 2);
        pnlUnderline.TabIndex = 1;
        // 
        // NumericInput
        // 
        BackColor = Color.White;
        Controls.Add(pnlUnderline);
        Controls.Add(numValue);
        Margin = new Padding(4, 2, 4, 2);
        Name = "NumericInput";
        Size = new Size(300, 30);
        ((ISupportInitialize)numValue).EndInit();
        ResumeLayout(false);
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public decimal Value
    {
        get => numValue.Value;
        set => numValue.Value = value;
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public decimal Minimum
    {
        get => numValue.Minimum;
        set => numValue.Minimum = value;
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public decimal Maximum
    {
        get => numValue.Maximum;
        set => numValue.Maximum = value;
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int DecimalPlaces
    {
        get => numValue.DecimalPlaces;
        set => numValue.DecimalPlaces = value;
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color UnderlineColor
    {
        get => pnlUnderline.BackColor;
        set => pnlUnderline.BackColor = value;
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color TextColor
    {
        get => numValue.ForeColor;
        set => numValue.ForeColor = value;
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool ReadOnly
    {
        get => numValue.ReadOnly;
        set => numValue.ReadOnly = value;
    }

    public event EventHandler ValueChanged;

    private void NumValue_ValueChanged(object? sender, EventArgs e)
    {
        ValueChanged?.Invoke(this, e);
    }
}
