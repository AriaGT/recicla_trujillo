using app.Components;
using shared;
using shared.Structures.Simple;

namespace app.Views.Rewards;

public partial class RewardsView : ContentPage
{
    private readonly ApiClient _apiClient;
    private readonly CurrentUserState _currentUserState;
    private NodeList<RewardDto> _rewards = new();

    public RewardsView(ApiClient apiClient, CurrentUserState currentUserState)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _currentUserState = currentUserState;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadRewardsAsync();
    }

    private async void OnRefreshClicked(object? sender, EventArgs e)
    {
        await LoadRewardsAsync();
    }

    private async Task LoadRewardsAsync()
    {
        RefreshUserInfo();
        RewardsContainer.Children.Clear();

        try
        {
            NodeList<RewardDto> rewards = await _apiClient.GetRewardsNodeListAsync();

            Node<RewardDto>? current = rewards.Head;
            while (current != null)
            {
                var reward = current.Data;
                var card = new RewardItemView
                {
                    RewardId = reward.Id,
                    RewardName = reward.Name,
                    RequiredPointsText = $"Precio: {reward.RequiredPoints} pts",
                    StockText = $"Stock: {reward.Stock}"
                };

                card.RedeemClicked += OnRewardRedeemClicked;
                RewardsContainer.Children.Add(card);
                current = current.Next;
            }

            StatusLabel.TextColor = Colors.Green;
            StatusLabel.IsVisible = false;
        }
        catch (Exception ex)
        {
            StatusLabel.TextColor = Colors.Red;
            StatusLabel.Text = $"No se pudo actualizar: {ex.Message}";
        }
    }

    private async void OnRewardRedeemClicked(object? sender, int rewardId)
    {
        var session = _currentUserState.Session;
        var user = _currentUserState.User;

        if (session is null || user is null)
        {
            StatusLabel.TextColor = Colors.Red;
            StatusLabel.Text = "Sesión no disponible";
            return;
        }

        var reward = FindRewardById(rewardId);
        if (reward is null)
        {
            StatusLabel.TextColor = Colors.Red;
            StatusLabel.Text = "Reward no encontrado";
            return;
        }

        if (reward.Stock <= 0)
        {
            StatusLabel.TextColor = Colors.Red;
            StatusLabel.Text = "No hay stock disponible";
            return;
        }

        if (user.Points < reward.RequiredPoints)
        {
            StatusLabel.TextColor = Colors.Red;
            StatusLabel.Text = "No tienes puntos suficientes";
            return;
        }

        try
        {
            await _apiClient.CreateRedemptionAsync(new RedemptionCreateDto(user.Id, reward.Id, reward.RequiredPoints));

            var refreshedUser = await _apiClient.GetUserByIdAsync(user.Id);
            if (refreshedUser != null)
            {
                _currentUserState.Set(new AuthSessionDto(refreshedUser.Id, refreshedUser.FullName, refreshedUser.Role), refreshedUser);
            }

            RefreshUserInfo();
            StatusLabel.TextColor = Colors.Green;
            StatusLabel.Text = $"Canje registrado: {reward.Name}";
            await LoadRewardsAsync();
        }
        catch (Exception ex)
        {
            StatusLabel.TextColor = Colors.Red;
            StatusLabel.Text = ex.Message;
        }
    }

    private RewardDto? FindRewardById(int rewardId)
    {
        Node<RewardDto>? current = _rewards.Head;
        while (current != null)
        {
            if (current.Data.Id == rewardId)
                return current.Data;

            current = current.Next;
        }

        return null;
    }

    private void RefreshUserInfo()
    {
        var user = _currentUserState.User;
        UserPointsLabel.Text = user is null ? "Puntos: -" : $"Tus puntos: {user.Points}";
    }
}
