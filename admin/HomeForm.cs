using Microsoft.Extensions.DependencyInjection;
using shared;

namespace admin;

public class HomeForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Label _lblWelcome;

    public HomeForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        Text = "Admin - Inicio";
        StartPosition = FormStartPosition.CenterParent;
        Size = new Size(540, 380);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        _lblWelcome = new Label
        {
            AutoSize = true,
            Location = new Point(20, 20),
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            Text = "Bienvenido"
        };

        var btnDeliveries = new Button
        {
            Text = "Registrar Deliveries",
            Location = new Point(20, 70),
            Size = new Size(220, 40)
        };
        btnDeliveries.Click += (_, _) => OpenDialog<DeliveriesForm>();

        var btnRewards = new Button
        {
            Text = "Tienda de Rewards",
            Location = new Point(20, 125),
            Size = new Size(220, 40)
        };
        btnRewards.Click += (_, _) => OpenDialog<RewardsForm>();

        var btnRedeemValidator = new Button
        {
            Text = "Validar Canje por Código",
            Location = new Point(20, 180),
            Size = new Size(220, 40)
        };
        btnRedeemValidator.Click += (_, _) => OpenDialog<RedemptionFlowForm>();

        var btnUsers = new Button
        {
            Text = "Crear Usuario (Admin/Citizen)",
            Location = new Point(20, 235),
            Size = new Size(220, 40)
        };
        btnUsers.Click += (_, _) => OpenDialog<UserCreateForm>();

        var btnLogout = new Button
        {
            Text = "Cerrar sesión",
            Location = new Point(20, 290),
            Size = new Size(220, 35)
        };
        btnLogout.Click += (_, _) => Close();

        Controls.Add(_lblWelcome);
        Controls.Add(btnDeliveries);
        Controls.Add(btnRewards);
        Controls.Add(btnRedeemValidator);
        Controls.Add(btnUsers);
        Controls.Add(btnLogout);
    }

    public void SetSession(AuthSessionDto session)
    {
        _lblWelcome.Text = $"Bienvenido, {session.FullName} ({session.Role})";
    }

    private void OpenDialog<TForm>() where TForm : Form
    {
        using var form = _serviceProvider.GetRequiredService<TForm>();
        form.ShowDialog(this);
    }
}
