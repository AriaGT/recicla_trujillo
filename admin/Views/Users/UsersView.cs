using admin.Components;
using admin.Services;
using shared;
using shared.Services;
using shared.Structures.Simple;
using shared.Structures.Tree;

namespace admin.Views;

internal partial class UsersView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    // Binary Search Tree ordered by DNI for fast lookups.
    private readonly BinarySearchTree<UserDto> _usersByDni = new();

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

    private void btnSearch_Click(object? sender, EventArgs e)
    {
        var dni = txtSearch.Text.Trim();
        if (string.IsNullOrWhiteSpace(dni))
        {
            lblSearchResult.Text = "Ingresa un DNI para buscar.";
            return;
        }

        // Search the BST using the DNI as the comparison key.
        var key = new UserDto(0, dni, string.Empty, default);
        int comparisons = 0;
        bool found = false;
        var match = _usersByDni.Search(key, CompareByDni, ref comparisons, ref found);

        if (found && match != null)
        {
            lblSearchResult.ForeColor = Color.SeaGreen;
            lblSearchResult.Text = $"{match.FullName} ({match.Role}) — {comparisons} comparación(es)";
            HighlightUser(match.Id);
        }
        else
        {
            lblSearchResult.ForeColor = Color.IndianRed;
            lblSearchResult.Text = $"DNI no encontrado — {comparisons} comparación(es)";
        }
    }

    private async Task LoadUsersAsync()
    {
        try
        {
            NodeList<UserDto> users = await _apiClient.GetUsersAsync();
            dgvUsers.Rows.Clear();
            _usersByDni.Clear();

            Node<UserDto>? current = users.Head;
            while (current != null)
            {
                UserDto user = current.Data;
                dgvUsers.Rows.Add(user.Id, user.Dni, user.FullName, user.Role);
                _usersByDni.Insert(user, CompareByDni);
                current = current.Next;
            }

            lblSearchResult.Text = string.Empty;
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal("Error", "Falló la carga de usuarios: " + ex.Message, ModalType.Error);
        }
    }

    private void HighlightUser(int userId)
    {
        foreach (DataGridViewRow row in dgvUsers.Rows)
        {
            if (row.Cells[0].Value is int id && id == userId)
            {
                row.Selected = true;
                dgvUsers.CurrentCell = row.Cells[0];
                break;
            }
        }
    }

    private static int CompareByDni(UserDto a, UserDto b) =>
        string.Compare(a.Dni, b.Dni, StringComparison.OrdinalIgnoreCase);
}
