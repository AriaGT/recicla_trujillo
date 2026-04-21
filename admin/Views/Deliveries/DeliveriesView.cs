using admin.Components;
using admin.Services;
using shared;
using shared.Enums;
using shared.Services;
using shared.Structures.Simple;

namespace admin.Views;

internal partial class DeliveriesView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    private static readonly IReadOnlyDictionary<WasteTypeEnums, string> WasteTypeLabels = new Dictionary<WasteTypeEnums, string>
    {
        [WasteTypeEnums.Plastic] = "Plástico",
        [WasteTypeEnums.Paper] = "Cartón/Papel",
        [WasteTypeEnums.Glass] = "Vidrio",
        [WasteTypeEnums.Metal] = "Metal"
    };

    private sealed record WasteTypeOption(WasteTypeEnums Value, string Label);

    public DeliveriesView(ApiClient apiClient, INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;
    }

    private async void DeliveriesView_Load(object? sender, EventArgs e)
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
            NodeList<DeliveryDto> deliveries = await _apiClient.GetDeliveriesAsync();
            dgvDeliveries.Rows.Clear();
            Node<DeliveryDto>? current = deliveries.Head;
            while (current != null)
            {
                DeliveryDto delivery = current.Data;
                dgvDeliveries.Rows.Add(
                    delivery.Id,
                    $"{delivery.User.FullName} ({delivery.User.Dni})",
                    WasteTypeLabels[delivery.WasteType],
                    delivery.QuantityKg,
                    delivery.PointsEarned,
                    delivery.CreatedAt.ToString("g")
                );
                current = current.Next;
            }
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal("Error", "Falló la carga de entregas: " + ex.Message, ModalType.Error);
        }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        _navigationService.NavigateTo<RegisterDeliveryView>();
    }
}
