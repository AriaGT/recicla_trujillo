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
        RewardsContainer.Children.Clear();

        try
        {
            NodeList<RewardDto> rewards = await _apiClient.GetRewardsNodeListAsync();
            _rewards = rewards;

            Node<RewardDto>? current = rewards.Head;
            while (current != null)
            {
                var reward = current.Data;
                var card = new RewardItemView
                {
                    RewardId = reward.Id,
                    RewardName = reward.Name,
                    PriceText = $"Precio: S/ {reward.Price:0.00}",
                    StockText = $"Stock: {reward.Stock}",
                    Stock = reward.Stock
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

        try
        {
            var sale = await _apiClient.CreateSaleAsync(new SaleCreateDto(user.Id, reward.Id));

            StatusLabel.TextColor = Colors.Green;
            StatusLabel.IsVisible = true;
            StatusLabel.Text = $"Compra registrada: {reward.Name} — código {sale.Code}";
            await LoadRewardsAsync();
        }
        catch (Exception ex)
        {
            StatusLabel.TextColor = Colors.Red;
            StatusLabel.IsVisible = true;
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
}
