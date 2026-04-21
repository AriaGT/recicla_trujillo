using System.ComponentModel;

namespace admin.Components;

public class BaseView: UserControl
{
    [Category("Navegación")]
    [Description("El título que se mostrará en la barra superior de la ventana principal.")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual string ViewTitle { get; set; } = "";
    
    [Category("Navegación")]
    [Description("Las dimensiones que el contenedor principal adoptará al abrir esta vista.")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual Size ViewSize { get; set; } = new(400, 600);
}
