using System.Runtime.InteropServices;

namespace admin.Components;

internal partial class MainContainer : Form
{
    // --- CÓDIGO PARA ARRASTRAR LA VENTANA ---
    [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
    private extern static void ReleaseCapture();

    [DllImport("user32.dll", EntryPoint = "SendMessage")]
    private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    // -----------------------------------------

    public MainContainer(IServiceProvider serviceProvider)
    {
        InitializeComponent();
    }

    public void RenderView(BaseView view)
    {
        pnlContent.Controls.Clear();
        view.Dock = DockStyle.Fill;
        pnlContent.Controls.Add(view);

        Size = new Size(view.ViewSize.Width, view.ViewSize.Height + 32);
        
        // Centrar ventana en la pantalla después de cambiar tamaño
        CenterWindowOnScreen();
    }

    private void CenterWindowOnScreen()
    {
        var screen = Screen.FromHandle(this.Handle);
        var centerX = screen.WorkingArea.Left + (screen.WorkingArea.Width - this.Width) / 2;
        var centerY = screen.WorkingArea.Top + (screen.WorkingArea.Height - this.Height) / 2;
        
        this.Location = new Point(centerX, centerY);
    }

    private void pnlToolbar_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnMin_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }
}
