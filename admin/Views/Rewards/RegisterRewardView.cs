using admin.Components;
using admin.Services;
using shared;
using shared.Services;

namespace admin.Views;

internal partial class RegisterRewardView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    public RegisterRewardView(ApiClient apiClient, INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;
    }

    private void RegisterRewardView_Load(object? sender, EventArgs e)
    {
        if (!_sessionService.IsLoggedIn())
        {
            _navigationService.NavigateTo<LoginView>();
        }
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<RewardsView>();
    }

    private async void btnRegister_Click(object? sender, EventArgs e)
    {
        await RegisterRewardAsync();
    }

    private async Task RegisterRewardAsync()
    {
        var name = txtName.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            _navigationService.ShowModal("Validación", "Ingresa el nombre del reward.", ModalType.Warning, ModalButtons.OK);
            return;
        }

        if (numPoints.Value <= 0)
        {
            _navigationService.ShowModal("Validación", "Los puntos deben ser mayores a 0.", ModalType.Warning, ModalButtons.OK);
            return;
        }

        if (numStock.Value < 0)
        {
            _navigationService.ShowModal("Validación", "El stock no puede ser negativo.", ModalType.Warning, ModalButtons.OK);
            return;
        }

        try
        {
            var dto = new RewardCreateDto(name, (int)numPoints.Value, (int)numStock.Value);
            await _apiClient.CreateRewardAsync(dto);
            _navigationService.ShowModal("Éxito", "Reward registrado correctamente.", ModalType.Success, ModalButtons.OK);
            _navigationService.NavigateTo<RewardsView>();
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal("Error", ex.Message, ModalType.Error, ModalButtons.OK);
        }
    }
}
