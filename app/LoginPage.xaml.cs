using shared;

namespace app;

public partial class LoginPage : ContentPage
{
    private readonly ApiClient _apiClient;
    private readonly CurrentUserState _currentUserState;
    private readonly HomePage _homePage;
    private readonly RegisterPage _registerPage;

    public LoginPage(ApiClient apiClient, CurrentUserState currentUserState, HomePage homePage, RegisterPage registerPage)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _currentUserState = currentUserState;
        _homePage = homePage;
        _registerPage = registerPage;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_currentUserState.Session is null || _currentUserState.User is null)
            return;

        if (_currentUserState.Session.Role != UserRole.Citizen)
        {
            _currentUserState.Clear();
            return;
        }

        await Navigation.PushAsync(_homePage);
    }

    private async void OnLoginClicked(object? sender, EventArgs e)
    {
        var statusLabel = this.FindByName<Label>("StatusLabel");
        var dniEntry = this.FindByName<Entry>("DniEntry");
        var loginButton = this.FindByName<Button>("LoginButton");

        if (statusLabel is null || dniEntry is null || loginButton is null)
            return;

        statusLabel.TextColor = Colors.Red;
        statusLabel.Text = string.Empty;

        var dni = dniEntry.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(dni))
        {
            statusLabel.Text = "Ingresa un DNI";
            return;
        }

        loginButton.IsEnabled = false;

        try
        {
            var session = await _apiClient.LoginByDniAsync(dni);
            if (session is null)
            {
                statusLabel.Text = "Credenciales inválidas";
                return;
            }

            if (session.Role != UserRole.Citizen)
            {
                statusLabel.Text = "Acceso denegado: solo Citizens";
                return;
            }

            var user = await _apiClient.GetUserByIdAsync(session.UserId);
            if (user is null)
            {
                statusLabel.Text = "No se pudo obtener el usuario actual";
                return;
            }

            _currentUserState.Set(session, user);
            dniEntry.Text = string.Empty;
            await Navigation.PushAsync(_homePage);
        }
        catch (InvalidOperationException ex)
        {
            statusLabel.Text = ex.Message;
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Error de conexión: {ex.Message}";
        }
        finally
        {
            loginButton.IsEnabled = true;
        }
    }

    private async void OnGoToRegisterClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(_registerPage);
    }
}
