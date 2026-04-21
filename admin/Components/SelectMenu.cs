using shared.Structures.Simple;
using System.ComponentModel;

namespace admin.Components;

internal partial class SelectMenu : UserControl
{

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public object DataSource
    {
        get => cmbValue.DataSource;
        set => cmbValue.DataSource = value;
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string DisplayMember
    {
        get => cmbValue.DisplayMember;
        set => cmbValue.DisplayMember = value;
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string ValueMember
    {
        get => cmbValue.ValueMember;
        set => cmbValue.ValueMember = value;
    }

    public void LoadItems<T>(NodeList<T> list)
    {
        if (list == null) return;

        cmbValue.BeginUpdate();
        try
        {
            cmbValue.Items.Clear();
            Node<T>? current = list.Head;
            while (current != null && current.Data != null)
            {
                cmbValue.Items.Add(current.Data);
                current = current.Next;
            }

            if (cmbValue.Items.Count > 0) cmbValue.SelectedIndex = 0;
        }
        finally
        {
            cmbValue.EndUpdate();
        }
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public object? SelectedItem => cmbValue.SelectedItem;

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object? SelectedValue
    {
        get
        {
            var selected = cmbValue.SelectedItem;
            if (selected == null) return null;
            if (string.IsNullOrEmpty(ValueMember)) return selected;
            try
            {
                var property = selected.GetType().GetProperty(ValueMember);

                return property?.GetValue(selected);
            }
            catch { return null; }
        }
        set
        {
            cmbValue.SelectedValue = value;
        }
    }

    [Category("Diseño")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int SelectedIndex
    {
        get => cmbValue.SelectedIndex;
        set => cmbValue.SelectedIndex = value;
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
        get => cmbValue.ForeColor;
        set => cmbValue.ForeColor = value;
    }
    public SelectMenu()
    {
        InitializeComponent();
    }

    public event EventHandler SelectedIndexChanged;

    private void CmbValue_SelectedIndexChanged(object? sender, EventArgs e)
    {
        SelectedIndexChanged?.Invoke(this, e);
    }
}
