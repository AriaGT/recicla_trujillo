using admin.Components;
using admin.Services;
using shared;
using shared.Services;
using shared.Structures.Stack;

namespace admin.Views;

internal partial class CajaView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    public CajaView(ApiClient apiClient, INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;
    }

    private async void CajaView_Load(object? sender, EventArgs e)
    {
        if (!_sessionService.IsLoggedIn())
        {
            _navigationService.NavigateTo<LoginView>();
            return;
        }

        await LoadDataAsync();
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<HomeView>();
    }

    private async void btnRefresh_Click(object? sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            CashSummaryDto summary = await _apiClient.GetCashSummaryAsync();
            lblIncome.Text = $"Ingresos: S/ {summary.TotalIncome:0.00}";
            lblExpense.Text = $"Egresos: S/ {summary.TotalExpense:0.00}";
            lblBalance.Text = $"Saldo: S/ {summary.Balance:0.00}";
            lblBalance.ForeColor = summary.Balance >= 0 ? Color.SeaGreen : Color.IndianRed;

            List<CashMovementDto> movements = await _apiClient.GetCashMovementsAsync();

            // Stack: push the movements and display them in LIFO order
            // (the last one pushed shows first: "most recent movements").
            var stack = new LinkedStack<CashMovementDto>();
            foreach (var movement in movements)
                stack.Push(movement);

            dgvMovements.Rows.Clear();
            foreach (var movement in stack.ToArray())
            {
                dgvMovements.Rows.Add(
                    movement.Date.ToString("g"),
                    movement.Type,
                    movement.Amount.ToString("0.00"),
                    movement.Concept
                );
            }
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal("Error", "Falló la carga de caja: " + ex.Message, ModalType.Error);
        }
    }
}
