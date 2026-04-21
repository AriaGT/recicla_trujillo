using admin.Components;
using admin.Services;
using shared;
using shared.Enums;
using shared.Services;

namespace admin.Views;

internal partial class LoginView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    public LoginView(
        ApiClient apiClient,
        INavigationService navigationService,
        ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;
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

            _sessionService.SaveSession(session);
            _navigationService.NavigateTo<HomeView>();
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
