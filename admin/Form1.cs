using Microsoft.Extensions.DependencyInjection;
using shared;
using shared.Enums;

namespace admin;

public partial class Form1 : Form
{
    private readonly ApiClient _apiClient;
    private readonly IServiceProvider _serviceProvider;

    public Form1(ApiClient apiClient, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _serviceProvider = serviceProvider;
    }

    private async void btnLogin_Click(object? sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;

        var dni = txtDni.Text.Trim();
        if (string.IsNullOrWhiteSpace(dni))
        {
            lblStatus.Text = "Ingresa un DNI";
            return;
        }

        btnLogin.Enabled = false;

        try
        {
            var session = await _apiClient.LoginByDniAsync(dni);
            if (session is null)
            {
                lblStatus.Text = "Credenciales inválidas";
                return;
            }

            if (session.Role != UserRoleEnums.Admin)
            {
                lblStatus.Text = "Acceso denegado: el usuario no es Admin";
                return;
            }

            using var homeForm = _serviceProvider.GetRequiredService<HomeForm>();
            homeForm.SetSession(session);

            Hide();
            homeForm.ShowDialog(this);
            Close();
        }
        catch (InvalidOperationException ex)
        {
            lblStatus.Text = ex.Message;
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error de conexión: {ex.Message}";
        }
        finally
        {
            btnLogin.Enabled = true;
        }
    }
}
