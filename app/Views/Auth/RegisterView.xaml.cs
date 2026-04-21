using shared;
using app.Views.Home;

namespace app.Views.Auth;

public partial class RegisterView : ContentPage
{
    private readonly ApiClient _apiClient;
    private readonly CurrentUserState _currentUserState;
    private readonly HomeView _homeView;

    public RegisterView(ApiClient apiClient, CurrentUserState currentUserState, HomeView homeView)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _currentUserState = currentUserState;
        _homeView = homeView;
    }

    private async void OnRegisterClicked(object? sender, EventArgs e)
    {
        StatusLabel.TextColor = Colors.Red;
        StatusLabel.Text = string.Empty;

        var dni = DniEntry.Text?.Trim() ?? string.Empty;
        var fullName = FullNameEntry.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(dni))
        {
            StatusLabel.Text = "Ingresa un DNI";
            return;
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            StatusLabel.Text = "Ingresa tu nombre completo";
            return;
        }

        RegisterButton.IsEnabled = false;

        try
        {
            var user = await _apiClient.RegisterCitizenAsync(new AuthRegisterDto(dni, fullName));
            var session = new AuthSessionDto(user.Id, user.FullName, user.Role);
            _currentUserState.Set(session, user);

            StatusLabel.TextColor = Colors.Green;
            StatusLabel.Text = "Registro exitoso. Iniciando sesión...";

            DniEntry.Text = string.Empty;
            FullNameEntry.Text = string.Empty;

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
            RegisterButton.IsEnabled = true;
        }
    }

    private async void OnBackToLoginClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
