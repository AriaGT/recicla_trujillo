using shared;

namespace admin;

public class RedemptionFlowForm : Form
{
    private readonly ApiClient _apiClient;
    private readonly TextBox _txtCode;
    private readonly Label _lblStatus;
    private readonly DataGridView _grid;

    public RedemptionFlowForm(ApiClient apiClient)
    {
        _apiClient = apiClient;

        Text = "Validador de Canjes";
        StartPosition = FormStartPosition.CenterParent;
        Size = new Size(920, 560);

        var lblCode = new Label { Text = "Código de canje (7 dígitos)", AutoSize = true, Location = new Point(15, 18) };
        _txtCode = new TextBox { Location = new Point(15, 40), Width = 260, MaxLength = 7 };

        var btnValidate = new Button { Text = "Validar", Location = new Point(290, 38), Size = new Size(120, 30) };
        btnValidate.Click += async (_, _) => await ValidateAsync();

        var btnRefresh = new Button { Text = "Refrescar", Location = new Point(420, 38), Size = new Size(120, 30) };
        btnRefresh.Click += async (_, _) => await LoadDataAsync();

        _grid = new DataGridView
        {
            Location = new Point(15, 90),
            Size = new Size(850, 400),
            ReadOnly = true,
            AutoGenerateColumns = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false
        };

        _lblStatus = new Label { AutoSize = true, Location = new Point(15, 505) };

        Controls.AddRange([lblCode, _txtCode, btnValidate, btnRefresh, _grid, _lblStatus]);

        Shown += async (_, _) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var redemptions = await _apiClient.GetRedemptionsAsync();
            _grid.DataSource = redemptions;
            _lblStatus.Text = $"Canjes cargados: {redemptions.Count}";
        }
        catch (Exception ex)
        {
            _lblStatus.Text = ex.Message;
        }
    }

    private async Task ValidateAsync()
    {
        var code = _txtCode.Text.Trim();
        if (string.IsNullOrWhiteSpace(code))
        {
            _lblStatus.Text = "Ingresa un código";
            return;
        }

        try
        {
            var redemption = await _apiClient.ValidateRedemptionByCodeAsync(code);
            if (redemption is null)
            {
                _lblStatus.Text = "Código no válido";
                _grid.DataSource = null;
                return;
            }

            _grid.DataSource = new List<RedemptionDto> { redemption };
            _lblStatus.Text = $"Código válido. Redemption ID: {redemption.Id}, User: {redemption.UserId}, Reward: {redemption.RewardId}, Puntos: {redemption.PointsSpent}";
        }
        catch (Exception ex)
        {
            _lblStatus.Text = ex.Message;
        }
    }
}
