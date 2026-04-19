using shared;

namespace app;

public partial class RegisterPage : ContentPage
{
    private readonly ApiClient _apiClient;
    private readonly CurrentUserState _currentUserState;
    private readonly HomePage _homePage;

    public RegisterPage(ApiClient apiClient, CurrentUserState currentUserState, HomePage homePage)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _currentUserState = currentUserState;
        _homePage = homePage;
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

            statusLabel.TextColor = Colors.Green;
            statusLabel.Text = "Registro exitoso. Iniciando sesión...";

            dniEntry.Text = string.Empty;
            fullNameEntry.Text = string.Empty;

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
            registerButton.IsEnabled = true;
        }
    }

    private async void OnBackToLoginClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
