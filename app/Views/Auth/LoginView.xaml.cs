using shared;
using shared.Enums;
using app.Views.Home;

namespace app.Views.Auth;

public partial class LoginView : ContentPage
{
    private readonly ApiClient _apiClient;
    private readonly CurrentUserState _currentUserState;
    private readonly HomeView _homeView;
    private readonly RegisterView _registerView;

    public LoginView(ApiClient apiClient, CurrentUserState currentUserState, HomeView homeView, RegisterView registerView)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _currentUserState = currentUserState;
        _homeView = homeView;
        _registerView = registerView;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_currentUserState.Session is null || _currentUserState.User is null)
            return;

        if (_currentUserState.Session.Role != UserRoleEnums.Citizen)
        {
            _currentUserState.Clear();
            return;
        }

        await Navigation.PushAsync(_homeView);
    }

    private async void OnLoginClicked(object? sender, EventArgs e)
    {
        StatusLabel.TextColor = Colors.Red;
        StatusLabel.Text = string.Empty;

        var dni = DniEntry.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(dni))
        {
            StatusLabel.Text = "Ingresa un DNI";
            return;
        }

        LoginButton.IsEnabled = false;

        try
        {
            var session = await _apiClient.LoginByDniAsync(dni);
            if (session is null)
            {
                StatusLabel.Text = "Credenciales inválidas";
                return;
            }

            if (session.Role != UserRoleEnums.Citizen)
            {
                StatusLabel.Text = "Acceso denegado: solo Citizens";
                return;
            }

            var user = await _apiClient.GetUserByIdAsync(session.UserId);
            if (user is null)
            {
                StatusLabel.Text = "No se pudo obtener el usuario actual";
                return;
            }

            _currentUserState.Set(session, user);
            DniEntry.Text = string.Empty;
            await Navigation.PushAsync(_homeView);
        }
        catch (InvalidOperationException ex)
        {
            StatusLabel.Text = ex.Message;
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error de conexión: {ex.Message}";
        }
        finally
        {
            LoginButton.IsEnabled = true;
        }
    }

    private async void OnGoToRegisterClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(_registerView);
    }
}
