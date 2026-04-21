using System.ComponentModel;

namespace admin.Components;

internal class PrimaryButton : Button
{
    private Color _normalColor = Color.DarkSlateBlue;
    private Color _hoverColor = Color.SlateBlue;

    // 2. Exponemos propiedades personalizadas para el Diseñador Visual
    [Category("Diseño Pro")]
    [Description("El color de fondo cuando el mouse pasa por encima.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color HoverColor
    {
        get => _hoverColor;
        set => _hoverColor = value;
    }

    [Category("Diseño Pro")]
    [Description("El color de fondo normal del botón.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color NormalColor
    {
        get => _normalColor;
        set
        {
            _normalColor = value;
            BackColor = _normalColor; // Actualizamos el color actual si lo cambian
        }
    }

    // 3. El Constructor: Aquí inyectamos los estilos por defecto
    public PrimaryButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        BackColor = _normalColor;
        ForeColor = Color.White;
        Font = new Font("Segoe UI", 10F, FontStyle.Bold); // Fuente moderna
        Cursor = Cursors.Hand;
        Size = new Size(150, 45);

        // Opcional: Quitar el borde de foco (la línea punteada fea al hacer clic)
        TabStop = false;
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        BackColor = HoverColor;
    }

    private void InitializeComponent()
    {

    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        BackColor = NormalColor;
    }
}
