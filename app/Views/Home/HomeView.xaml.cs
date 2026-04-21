using shared;
using app.Views.Rewards;

namespace app.Views.Home;

public partial class HomeView : ContentPage
{
    private readonly CurrentUserState _currentUserState;
    private readonly ApiClient _apiClient;
    private readonly RewardsView _rewardsView;

    public HomeView(CurrentUserState currentUserState, ApiClient apiClient, RewardsView rewardsView)
    {
        InitializeComponent();
        _currentUserState = currentUserState;
        _apiClient = apiClient;
        _rewardsView = rewardsView;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RenderState();
    }

    private void RenderState()
    {
        var session = _currentUserState.Session;
        var user = _currentUserState.User;

        if (session is null || user is null)
        {
            WelcomeLabel.Text = "Sesión no disponible";
            UserIdRow.Value = string.Empty;
            DniRow.Value = string.Empty;
            FullNameRow.Value = string.Empty;
            PointsRow.Value = string.Empty;
            RoleRow.Value = string.Empty;
            return;
        }

        WelcomeLabel.Text = $"Bienvenido, {session.FullName}";
        UserIdRow.Value = user.Id.ToString();
        DniRow.Value = user.Dni;
        FullNameRow.Value = user.FullName;
        PointsRow.Value = user.Points.ToString();
        RoleRow.Value = user.Role.ToString();
    }

    private async void OnRewardsClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(_rewardsView);
    }

    private async void OnRefreshClicked(object? sender, EventArgs e)
    {
        WelcomeLabel.Text = "Actualizando...";

        var session = _currentUserState.Session;
        if (session is null)
            return;

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
