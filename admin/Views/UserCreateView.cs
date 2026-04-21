using admin.Components;
using admin.Services;
using shared;
using shared.Enums;
using shared.Services;
using shared.Structures.Simple;

namespace admin.Views;

internal partial class UserCreateView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    public UserCreateView(ApiClient apiClient, INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;
        cmbRole.DataSource = Enum.GetValues<UserRoleEnums>();
    }

    private async void UserCreateView_Load(object? sender, EventArgs e)
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

    private async void btnRefresh_Click(object? sender, EventArgs e)
    {
        await LoadUsersAsync();
    }

    private async void btnCreate_Click(object? sender, EventArgs e)
    {
        await CreateUserAsync();
    }

    private async Task LoadUsersAsync()
    {
        //try
        //{
        //    NodeList<UserDto> users = await _apiClient.GetUsersAsync();
        //    dgvUsers.Rows.Clear();
        //    Node<UserDto>? current = users.Head;
        //    while (current != null)
        //    {
        //        UserDto user = current.Data;
        //        dgvUsers.Rows.Add(
        //            user.Id,
        //            user.Dni,
        //            user.FullName,
        //            user.Role
        //        );
        //        current = current.Next;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblStatus.Text = ex.Message;
        //}
    }

    private async Task CreateUserAsync()
    {
        var dni = txtDni.Text.Trim();
        var fullName = txtFullName.Text.Trim();
        var role = cmbRole.SelectedItem is UserRoleEnums selected ? selected : UserRoleEnums.Citizen;

        if (string.IsNullOrWhiteSpace(dni))
        {
            lblStatus.Text = "Ingresa un DNI";
            return;
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            lblStatus.Text = "Ingresa el nombre completo";
            return;
        }

        try
        {
            var user = await _apiClient.CreateUserAsync(new UserCreateDto(dni, fullName, role));
            lblStatus.Text = $"Usuario creado: {user.FullName} ({user.Role})";
            txtDni.Clear();
            txtFullName.Clear();
            await LoadUsersAsync();
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
}
