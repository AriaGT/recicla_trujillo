using shared;

namespace admin;

public class DeliveriesForm : Form
{
    private readonly ApiClient _apiClient;
    private readonly ComboBox _cmbUsers;
    private readonly ComboBox _cmbWasteType;
    private readonly NumericUpDown _numKg;
    private readonly DataGridView _grid;
    private readonly Label _lblStatus;

    private static readonly IReadOnlyDictionary<WasteTypeEnums, string> WasteTypeLabels = new Dictionary<WasteTypeEnums, string>
    {
        [WasteTypeEnums.Plastic] = "Plástico",
        [WasteTypeEnums.Paper] = "Cartón/Papel",
        [WasteTypeEnums.Glass] = "Vidrio",
        [WasteTypeEnums.Metal] = "Metal"
    };

    public DeliveriesForm(ApiClient apiClient)
    {
        _apiClient = apiClient;

        Text = "Deliveries";
        StartPosition = FormStartPosition.CenterParent;
        Size = new Size(920, 560);

        var lblUser = new Label { Text = "Usuario", AutoSize = true, Location = new Point(15, 18) };
        _cmbUsers = new ComboBox { Location = new Point(15, 38), Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };

        var lblWaste = new Label { Text = "Tipo Residuo", AutoSize = true, Location = new Point(315, 18) };
        _cmbWasteType = new ComboBox { Location = new Point(315, 38), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
        _cmbWasteType.DataSource = WasteTypeLabels
            .Select(x => new WasteTypeOption(x.Key, x.Value))
            .ToList();
        _cmbWasteType.DisplayMember = nameof(WasteTypeOption.Label);
        _cmbWasteType.ValueMember = nameof(WasteTypeOption.Value);

        var lblKg = new Label { Text = "Cantidad (kg)", AutoSize = true, Location = new Point(515, 18) };
        _numKg = new NumericUpDown { Location = new Point(515, 38), Width = 120, DecimalPlaces = 2, Minimum = 1, Maximum = 1000, Value = 1 };

        var btnRegister = new Button { Text = "Registrar", Location = new Point(655, 35), Size = new Size(110, 30) };
        btnRegister.Click += async (_, _) => await RegisterDeliveryAsync();

        var btnRefresh = new Button { Text = "Refrescar", Location = new Point(775, 35), Size = new Size(110, 30) };
        btnRefresh.Click += async (_, _) => await LoadDataAsync();

        _grid = new DataGridView
        {
            Location = new Point(15, 85),
            Size = new Size(870, 410),
            ReadOnly = true,
            AutoGenerateColumns = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false
        };

        _lblStatus = new Label { AutoSize = true, Location = new Point(15, 510) };

        Controls.AddRange([lblUser, _cmbUsers, lblWaste, _cmbWasteType, lblKg, _numKg, btnRegister, btnRefresh, _grid, _lblStatus]);

        Shown += async (_, _) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var users = await _apiClient.GetUsersAsync();
            _cmbUsers.DataSource = users;
            _cmbUsers.DisplayMember = nameof(UserDto.FullName);
            _cmbUsers.ValueMember = nameof(UserDto.Id);

            var deliveries = await _apiClient.GetDeliveriesAsync();
            _grid.DataSource = deliveries;
            _lblStatus.Text = $"Deliveries: {deliveries.Count}";
        }
        catch (Exception ex)
        {
            _lblStatus.Text = ex.Message;
        }
    }

    private async Task RegisterDeliveryAsync()
    {
        if (_cmbUsers.SelectedValue is not int userId)
        {
            _lblStatus.Text = "Selecciona un usuario";
            return;
        }

        if (_cmbWasteType.SelectedItem is not WasteTypeOption wasteTypeOption)
        {
            _lblStatus.Text = "Selecciona un tipo de residuo";
            return;
        }

        try
        {
            var dto = new DeliveryCreateDto(userId, wasteTypeOption.Value.ToString(), _numKg.Value);
            await _apiClient.CreateDeliveryAsync(dto);
            _lblStatus.Text = "Delivery registrado";
            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            _lblStatus.Text = ex.Message;
        }
    }

    private sealed record WasteTypeOption(WasteTypeEnums Value, string Label);
}
