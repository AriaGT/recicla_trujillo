using admin.Components;
using admin.Services;
using shared;
using shared.Services;
using shared.Structures.Simple;

namespace admin.Views;

internal partial class RewardsView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    public RewardsView(ApiClient apiClient, INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;
    }

    private async void RewardsView_Load(object? sender, EventArgs e)
    {
        if (!_sessionService.IsLoggedIn())
        {
            _navigationService.NavigateTo<LoginView>();
            return;
        }

        await LoadRewardsAsync();
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<HomeView>();
    }

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<RegisterRewardView>();
    }

    private async void btnRefresh_Click(object? sender, EventArgs e)
    {
        await LoadRewardsAsync();
    }

    private async Task LoadRewardsAsync()
    {
        try
        {
            NodeList<RewardDto> rewards = await _apiClient.GetRewardsNodeListAsync();
            dgvRewards.Rows.Clear();

            Node<RewardDto>? current = rewards.Head;
            while (current != null)
            {
                RewardDto reward = current.Data;
                dgvRewards.Rows.Add(reward.Id, reward.Name, reward.RequiredPoints, reward.Stock);
                current = current.Next;
            }
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal("Error", "Falló la carga de rewards: " + ex.Message, ModalType.Error);
        }
    }
}
