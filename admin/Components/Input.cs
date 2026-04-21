using System.ComponentModel;

namespace admin.Components;

internal partial class Input : UserControl
{
    public Input()
    {
        InitializeComponent();
    }

    private TextBox txtValue;

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text
    {
        get => txtValue.Text;
        set => txtValue.Text = value;
    }

    private Panel panel1;
}
