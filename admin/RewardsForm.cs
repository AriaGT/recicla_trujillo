using shared;

namespace admin;

public class RewardsForm : Form
{
    private readonly ApiClient _apiClient;
    private readonly TextBox _txtName;
    private readonly NumericUpDown _numPoints;
    private readonly NumericUpDown _numStock;
    private readonly DataGridView _grid;
    private readonly Label _lblStatus;

    public RewardsForm(ApiClient apiClient)
    {
        _apiClient = apiClient;

        Text = "Tienda de Rewards";
        StartPosition = FormStartPosition.CenterParent;
        Size = new Size(900, 540);

        var lblName = new Label { Text = "Nombre", AutoSize = true, Location = new Point(15, 15) };
        _txtName = new TextBox { Location = new Point(15, 35), Width = 220 };

        var lblPoints = new Label { Text = "Puntos", AutoSize = true, Location = new Point(255, 15) };
        _numPoints = new NumericUpDown { Location = new Point(255, 35), Width = 120, Minimum = 1, Maximum = 100000, Value = 10 };

        var lblStock = new Label { Text = "Stock", AutoSize = true, Location = new Point(395, 15) };
        _numStock = new NumericUpDown { Location = new Point(395, 35), Width = 120, Minimum = 0, Maximum = 100000, Value = 1 };

        var btnCreate = new Button { Text = "Crear", Location = new Point(535, 32), Size = new Size(100, 30) };
        btnCreate.Click += async (_, _) => await CreateRewardAsync();

        var btnUpdate = new Button { Text = "Actualizar", Location = new Point(645, 32), Size = new Size(100, 30) };
        btnUpdate.Click += async (_, _) => await UpdateRewardAsync();

        var btnRefresh = new Button { Text = "Refrescar", Location = new Point(755, 32), Size = new Size(100, 30) };
        btnRefresh.Click += async (_, _) => await LoadRewardsAsync();

        _grid = new DataGridView
        {
            Location = new Point(15, 80),
            Size = new Size(840, 390),
            ReadOnly = true,
            AutoGenerateColumns = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false
        };
        _grid.SelectionChanged += (_, _) => FillInputsFromSelectedRow();

        _lblStatus = new Label { AutoSize = true, Location = new Point(15, 485) };

        Controls.AddRange([lblName, _txtName, lblPoints, _numPoints, lblStock, _numStock, btnCreate, btnUpdate, btnRefresh, _grid, _lblStatus]);

        Shown += async (_, _) => await LoadRewardsAsync();
    }

    private async Task LoadRewardsAsync()
    {
        try
        {
            var rewards = await _apiClient.GetRewardsAsync();
            _grid.DataSource = rewards;
            _lblStatus.Text = $"Rewards: {rewards.Count}";
        }
        catch (Exception ex)
        {
            _lblStatus.Text = ex.Message;
        }
    }

    private async Task CreateRewardAsync()
    {
        try
        {
            var dto = new RewardCreateDto(_txtName.Text.Trim(), (int)_numPoints.Value, (int)_numStock.Value);
            await _apiClient.CreateRewardAsync(dto);
            _lblStatus.Text = "Reward creado";
            await LoadRewardsAsync();
        }
        catch (Exception ex)
        {
            _lblStatus.Text = ex.Message;
        }
    }

    private async Task UpdateRewardAsync()
    {
        if (_grid.CurrentRow?.DataBoundItem is not RewardDto selected)
        {
            _lblStatus.Text = "Selecciona un reward";
            return;
        }

        try
        {
            var dto = new RewardUpdateDto(_txtName.Text.Trim(), (int)_numPoints.Value, (int)_numStock.Value);
            var updated = await _apiClient.UpdateRewardAsync(selected.Id, dto);
            _lblStatus.Text = updated is null ? "Reward no encontrado" : "Reward actualizado";
            await LoadRewardsAsync();
        }
        catch (Exception ex)
        {
            _lblStatus.Text = ex.Message;
        }
    }

    private void FillInputsFromSelectedRow()
    {
        if (_grid.CurrentRow?.DataBoundItem is not RewardDto selected)
            return;

        _txtName.Text = selected.Name;
        _numPoints.Value = Math.Clamp(selected.RequiredPoints, (int)_numPoints.Minimum, (int)_numPoints.Maximum);
        _numStock.Value = Math.Clamp(selected.Stock, (int)_numStock.Minimum, (int)_numStock.Maximum);
    }
}
