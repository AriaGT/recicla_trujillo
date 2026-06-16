using admin.Components;
using admin.Services;
using shared;
using shared.Services;
using shared.Structures.Queue;
using shared.Structures.Simple;

namespace admin.Views;

internal partial class SalesView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    // FIFO queue of pending sales to hand over to the citizen.
    private readonly LinkedQueue<SaleDto> _pending = new();

    public SalesView(ApiClient apiClient, INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;
    }

    private async void SalesView_Load(object? sender, EventArgs e)
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

    private async void btnValidate_Click(object? sender, EventArgs e)
    {
        await ValidateAsync();
    }

    private void btnAttend_Click(object? sender, EventArgs e)
    {
        if (_pending.IsEmpty())
        {
            _navigationService.ShowModal("Cola de ventas", "No hay ventas pendientes por atender.", ModalType.Warning, ModalButtons.OK);
            return;
        }

        SaleDto next = _pending.Dequeue();
        UpdateQueueLabel();
        _navigationService.ShowModal(
            "Atendiendo venta",
            $"Venta #{next.Id}\nCódigo: {next.Code}\nUsuario: {next.UserId}\nMonto: S/ {next.Amount:0.00}",
            ModalType.Success,
            ModalButtons.OK);
    }

    private async Task LoadDataAsync()
    {
        try
        {
            NodeList<SaleDto> sales = await _apiClient.GetSalesNodeListAsync();
            dgvSales.Rows.Clear();
            _pending.Clear();

            Node<SaleDto>? current = sales.Head;
            while (current != null)
            {
                SaleDto sale = current.Data;
                dgvSales.Rows.Add(
                    sale.Id,
                    sale.UserId,
                    sale.RewardId,
                    sale.Amount.ToString("0.00"),
                    sale.Code,
                    sale.CreatedAt.ToString("g")
                );
                _pending.Enqueue(sale);
                current = current.Next;
            }

            UpdateQueueLabel();
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal("Error", "Falló la carga de ventas: " + ex.Message, ModalType.Error);
        }
    }

    private void UpdateQueueLabel()
    {
        lblQueue.Text = $"En cola: {_pending.Count}";
    }

    private async Task ValidateAsync()
    {
        var code = txtCode.Text.Trim();
        if (string.IsNullOrWhiteSpace(code))
        {
            _navigationService.ShowModal("Validación", "Ingresa un código.", ModalType.Warning, ModalButtons.OK);
            return;
        }

        try
        {
            var sale = await _apiClient.ValidateSaleByCodeAsync(code);
            if (sale is null)
            {
                _navigationService.ShowModal("Validación", "Código no válido.", ModalType.Warning, ModalButtons.OK);
                return;
            }

            _navigationService.ShowModal(
                "Código válido",
                $"Venta ID: {sale.Id}\nUsuario: {sale.UserId}\nReward: {sale.RewardId}\nMonto: S/ {sale.Amount:0.00}",
                ModalType.Success,
                ModalButtons.OK
            );

            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal("Error", ex.Message, ModalType.Error, ModalButtons.OK);
        }
    }
}
