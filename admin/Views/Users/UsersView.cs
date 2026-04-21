using admin.Components;
using admin.Services;
using shared;
using shared.Services;
using shared.Structures.Simple;

namespace admin.Views;

internal partial class UsersView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    public UsersView(ApiClient apiClient, INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;
    }

    private async void UsersView_Load(object? sender, EventArgs e)
    {
        if (!_sessionService.IsLoggedIn())
        {
            _navigationService.NavigateTo<LoginView>();
            return;
        }

        await LoadUsersAsync();
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<HomeView>();
    }

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<RegisterUserView>();
    }

    private async void btnRefresh_Click(object? sender, EventArgs e)
    {
        await LoadUsersAsync();
    }

    private async Task LoadUsersAsync()
    {
        try
        {
            NodeList<UserDto> users = await _apiClient.GetUsersAsync();
            dgvUsers.Rows.Clear();

            Node<UserDto>? current = users.Head;
            while (current != null)
            {
                UserDto user = current.Data;
                dgvUsers.Rows.Add(user.Id, user.Dni, user.FullName, user.Role, user.Points);
                current = current.Next;
            }
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal("Error", "Falló la carga de usuarios: " + ex.Message, ModalType.Error);
        }
    }
}
