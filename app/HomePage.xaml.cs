using shared;

namespace app;

public partial class HomePage : ContentPage
{
    private readonly CurrentUserState _currentUserState;
    private readonly ApiClient _apiClient;
    private readonly RewardsPage _rewardsPage;

    public HomePage(CurrentUserState currentUserState, ApiClient apiClient, RewardsPage rewardsPage)
    {
        InitializeComponent();
        _currentUserState = currentUserState;
        _apiClient = apiClient;
        _rewardsPage = rewardsPage;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RenderState();
    }

    private void RenderState()
    {
        var welcomeLabel = this.FindByName<Label>("WelcomeLabel");
        var userIdLabel = this.FindByName<Label>("UserIdLabel");
        var dniLabel = this.FindByName<Label>("DniLabel");
        var fullNameLabel = this.FindByName<Label>("FullNameLabel");
        var pointsLabel = this.FindByName<Label>("PointsLabel");
        var roleLabel = this.FindByName<Label>("RoleLabel");

        if (welcomeLabel is null || userIdLabel is null || dniLabel is null || fullNameLabel is null || pointsLabel is null || roleLabel is null)
            return;

        var session = _currentUserState.Session;
        var user = _currentUserState.User;

        if (session is null || user is null)
        {
            welcomeLabel.Text = "Sesión no disponible";
            userIdLabel.Text = string.Empty;
            dniLabel.Text = string.Empty;
            fullNameLabel.Text = string.Empty;
            pointsLabel.Text = string.Empty;
            roleLabel.Text = string.Empty;
            return;
        }

        welcomeLabel.Text = $"Bienvenido, {session.FullName}";
        userIdLabel.Text = $"ID: {user.Id}";
        dniLabel.Text = $"DNI: {user.Dni}";
        fullNameLabel.Text = $"Nombre: {user.FullName}";
        pointsLabel.Text = $"Puntos: {user.Points}";
        roleLabel.Text = $"Rol: {user.Role}";
    }

    private async void OnRewardsClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(_rewardsPage);
    }

    private async void OnRefreshClicked(object? sender, EventArgs e)
    {
        var welcomeLabel = this.FindByName<Label>("WelcomeLabel");
        if (welcomeLabel is null)
            return;

        var session = _currentUserState.Session;
        if (session is null)
            return;

        welcomeLabel.Text = "Actualizando...";

        try
        {
            var refreshedUser = await _apiClient.GetUserByIdAsync(session.UserId);
            if (refreshedUser is null)
            {
                _currentUserState.Clear();
                await Navigation.PopToRootAsync();
                return;
            }

            var refreshedSession = new AuthSessionDto(refreshedUser.Id, refreshedUser.FullName, refreshedUser.Role);
            _currentUserState.Set(refreshedSession, refreshedUser);
            RenderState();
        }
        catch
        {
            RenderState();
        }
    }

    private async void OnLogoutClicked(object? sender, EventArgs e)
    {
        _currentUserState.Clear();
        await Navigation.PopToRootAsync();
    }
}
