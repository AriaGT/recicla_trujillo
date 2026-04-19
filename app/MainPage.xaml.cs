using shared;

namespace app;

public partial class MainPage : ContentPage
{
    private readonly ApiClient _apiClient;
    private readonly CurrentUserState _currentUserState;
    private readonly HomePage _homePage;

    public MainPage(ApiClient apiClient, CurrentUserState currentUserState, HomePage homePage)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _currentUserState = currentUserState;
        _homePage = homePage;
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

    private async void OnRegisterClicked(object? sender, EventArgs e)
    {
        var statusLabel = this.FindByName<Label>("StatusLabel");
        var dniEntry = this.FindByName<Entry>("DniEntry");
        var fullNameEntry = this.FindByName<Entry>("FullNameEntry");
        var registerButton = this.FindByName<Button>("RegisterButton");

        if (statusLabel is null || dniEntry is null || fullNameEntry is null || registerButton is null)
            return;

        statusLabel.TextColor = Colors.Red;
        statusLabel.Text = string.Empty;

        var dni = dniEntry.Text?.Trim() ?? string.Empty;
        var fullName = fullNameEntry.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(dni))
        {
            statusLabel.Text = "Ingresa un DNI";
            return;
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            statusLabel.Text = "Ingresa tu nombre completo";
            return;
        }

        registerButton.IsEnabled = false;

        try
        {
            var user = await _apiClient.RegisterCitizenAsync(new AuthRegisterDto(dni, fullName));
            var session = new AuthSessionDto(user.Id, user.FullName, user.Role);
            _currentUserState.Set(session, user);

            fullNameEntry.Text = string.Empty;
            statusLabel.TextColor = Colors.Green;
            statusLabel.Text = "Registro exitoso. Iniciando sesión...";

            await Navigation.PushAsync(_homePage);
        }
        catch (InvalidOperationException ex)
        {
            statusLabel.TextColor = Colors.Red;
            statusLabel.Text = ex.Message;
        }
        catch (Exception ex)
        {
            statusLabel.TextColor = Colors.Red;
            statusLabel.Text = $"Error de conexión: {ex.Message}";
        }
        finally
        {
            registerButton.IsEnabled = true;
        }
    }
}
