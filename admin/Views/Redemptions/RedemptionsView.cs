using admin.Components;
using admin.Services;
using shared;
using shared.Services;
using shared.Structures.Simple;

namespace admin.Views;

internal partial class RedemptionsView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    public RedemptionsView(ApiClient apiClient, INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;
    }

    private async void RedemptionsView_Load(object? sender, EventArgs e)
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

    private async Task LoadDataAsync()
    {
        try
        {
            NodeList<RedemptionDto> redemptions = await _apiClient.GetRedemptionsNodeListAsync();
            dgvRedemptions.Rows.Clear();

            Node<RedemptionDto>? current = redemptions.Head;
            while (current != null)
            {
                RedemptionDto redemption = current.Data;
                dgvRedemptions.Rows.Add(
                    redemption.Id,
                    redemption.UserId,
                    redemption.RewardId,
                    redemption.PointsSpent,
                    redemption.Code,
                    redemption.CreatedAt.ToString("g")
                );
                current = current.Next;
            }
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal("Error", "Falló la carga de canjes: " + ex.Message, ModalType.Error);
        }
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
            var redemption = await _apiClient.ValidateRedemptionByCodeAsync(code);
            if (redemption is null)
            {
                _navigationService.ShowModal("Validación", "Código no válido.", ModalType.Warning, ModalButtons.OK);
                return;
            }

            _navigationService.ShowModal(
                "Código válido",
                $"Canje ID: {redemption.Id}\nUsuario: {redemption.UserId}\nReward: {redemption.RewardId}\nPuntos: {redemption.PointsSpent}",
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
