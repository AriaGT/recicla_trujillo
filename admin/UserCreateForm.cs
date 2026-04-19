using shared;
using shared.Enums;

namespace admin;

public class UserCreateForm : Form
{
    private readonly ApiClient _apiClient;
    private readonly TextBox _txtDni;
    private readonly TextBox _txtFullName;
    private readonly ComboBox _cmbRole;
    private readonly Label _lblStatus;
    private readonly DataGridView _grid;

    public UserCreateForm(ApiClient apiClient)
    {
        _apiClient = apiClient;

        Text = "Crear Usuario";
        StartPosition = FormStartPosition.CenterParent;
        Size = new Size(900, 560);

        var lblDni = new Label { Text = "DNI", AutoSize = true, Location = new Point(15, 18) };
        _txtDni = new TextBox { Location = new Point(15, 40), Width = 180, MaxLength = 8 };

        var lblFullName = new Label { Text = "Nombre completo", AutoSize = true, Location = new Point(210, 18) };
        _txtFullName = new TextBox { Location = new Point(210, 40), Width = 260 };

        var lblRole = new Label { Text = "Rol", AutoSize = true, Location = new Point(485, 18) };
        _cmbRole = new ComboBox { Location = new Point(485, 40), Width = 130, DropDownStyle = ComboBoxStyle.DropDownList };
        _cmbRole.DataSource = Enum.GetValues<UserRoleEnums>();

        var btnCreate = new Button { Text = "Crear usuario", Location = new Point(630, 38), Size = new Size(120, 30) };
        btnCreate.Click += async (_, _) => await CreateUserAsync();

        var btnRefresh = new Button { Text = "Refrescar", Location = new Point(760, 38), Size = new Size(110, 30) };
        btnRefresh.Click += async (_, _) => await LoadUsersAsync();

        _grid = new DataGridView
        {
            Location = new Point(15, 90),
            Size = new Size(855, 400),
            ReadOnly = true,
            AutoGenerateColumns = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false
        };

        _lblStatus = new Label { AutoSize = true, Location = new Point(15, 505) };

        Controls.AddRange([lblDni, _txtDni, lblFullName, _txtFullName, lblRole, _cmbRole, btnCreate, btnRefresh, _grid, _lblStatus]);

        Shown += async (_, _) => await LoadUsersAsync();
    }

    private async Task LoadUsersAsync()
    {
        try
        {
            var users = await _apiClient.GetUsersAsync();
            _grid.DataSource = users;
            _lblStatus.Text = $"Usuarios cargados: {users.Count}";
        }
        catch (Exception ex)
        {
            _lblStatus.Text = ex.Message;
        }
    }

    private async Task CreateUserAsync()
    {
        var dni = _txtDni.Text.Trim();
        var fullName = _txtFullName.Text.Trim();
        var role = _cmbRole.SelectedItem is UserRoleEnums selected ? selected : UserRoleEnums.Citizen;

        if (string.IsNullOrWhiteSpace(dni))
        {
            _lblStatus.Text = "Ingresa un DNI";
            return;
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            _lblStatus.Text = "Ingresa el nombre completo";
            return;
        }

        try
        {
            var user = await _apiClient.CreateUserAsync(new UserCreateDto(dni, fullName, role));
            _lblStatus.Text = $"Usuario creado: {user.FullName} ({user.Role})";
            _txtDni.Clear();
            _txtFullName.Clear();
            await LoadUsersAsync();
        }
        catch (Exception ex)
        {
            _lblStatus.Text = ex.Message;
        }
    }
}
