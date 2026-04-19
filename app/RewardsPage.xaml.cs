using shared;

namespace app;

public partial class RewardsPage : ContentPage
{
    private readonly ApiClient _apiClient;
    private List<RewardDto> _rewards = [];
    private readonly Dictionary<int, int> _cart = [];

    public RewardsPage(ApiClient apiClient)
    {
        InitializeComponent();
        _apiClient = apiClient;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_rewards.Count == 0)
            await RefreshDataAsync();
    }

    private async void OnRefreshClicked(object? sender, EventArgs e)
    {
        await RefreshDataAsync();
    }

    private async Task RefreshDataAsync()
    {
        var statusLabel = this.FindByName<Label>("StatusLabel");
        var cartTotalLabel = this.FindByName<Label>("CartTotalLabel");
        var rewardsCollectionView = this.FindByName<CollectionView>("RewardsCollectionView");
        var cartCollectionView = this.FindByName<CollectionView>("CartCollectionView");

        if (statusLabel is null || cartTotalLabel is null || rewardsCollectionView is null || cartCollectionView is null)
            return;

        statusLabel.TextColor = Colors.Gray;
        statusLabel.Text = "Actualizando rewards...";

        _rewards = [];
        _cart.Clear();
        rewardsCollectionView.ItemsSource = null;
        cartCollectionView.ItemsSource = null;
        cartTotalLabel.Text = "Total carrito: 0 pts";

        try
        {
            var rewards = await _apiClient.GetRewardsAsync();
            _rewards = rewards;
            rewardsCollectionView.ItemsSource = _rewards.Select(r => new RewardRowVm(r.Id, r.Name, $"Precio: {r.RequiredPoints} pts", $"Stock: {r.Stock}")).ToList();
            RenderCart();
            statusLabel.TextColor = Colors.Green;
            statusLabel.Text = "Rewards actualizados";
        }
        catch (Exception ex)
        {
            statusLabel.TextColor = Colors.Red;
            statusLabel.Text = $"No se pudo actualizar: {ex.Message}";
        }
    }

    private void OnAddToCartClicked(object? sender, EventArgs e)
    {
        if (sender is not Button button || button.CommandParameter is not int rewardId)
            return;

        var reward = _rewards.FirstOrDefault(r => r.Id == rewardId);
        if (reward is null)
            return;

        var statusLabel = this.FindByName<Label>("StatusLabel");
        var currentQuantity = _cart.TryGetValue(rewardId, out var quantity) ? quantity : 0;

        if (currentQuantity >= reward.Stock)
        {
            if (statusLabel is not null)
            {
                statusLabel.TextColor = Colors.Red;
                statusLabel.Text = "No hay más stock disponible para ese reward";
            }
            return;
        }

        _cart[rewardId] = currentQuantity + 1;

        if (statusLabel is not null)
        {
            statusLabel.TextColor = Colors.Green;
            statusLabel.Text = "Reward agregado al carrito local";
        }

        RenderCart();
    }

    private void OnRemoveFromCartClicked(object? sender, EventArgs e)
    {
        if (sender is not Button button || button.CommandParameter is not int rewardId)
            return;

        if (!_cart.TryGetValue(rewardId, out var quantity))
            return;

        if (quantity <= 1)
            _cart.Remove(rewardId);
        else
            _cart[rewardId] = quantity - 1;

        RenderCart();
    }

    private void OnClearCartClicked(object? sender, EventArgs e)
    {
        _cart.Clear();
        RenderCart();

        var statusLabel = this.FindByName<Label>("StatusLabel");
        if (statusLabel is not null)
        {
            statusLabel.TextColor = Colors.Gray;
            statusLabel.Text = "Carrito limpio";
        }
    }

    private void RenderCart()
    {
        var cartCollectionView = this.FindByName<CollectionView>("CartCollectionView");
        var cartTotalLabel = this.FindByName<Label>("CartTotalLabel");

        if (cartCollectionView is null || cartTotalLabel is null)
            return;

        var rows = _cart
            .Select(item =>
            {
                var reward = _rewards.FirstOrDefault(r => r.Id == item.Key);
                if (reward is null)
                    return null;

                var quantity = item.Value;
                var subtotal = reward.RequiredPoints * quantity;
                return new CartRowVm(reward.Id, reward.Name, $"Cantidad: {quantity}", $"Subtotal: {subtotal} pts", subtotal);
            })
            .Where(row => row is not null)
            .Cast<CartRowVm>()
            .ToList();

        cartCollectionView.ItemsSource = rows;
        cartTotalLabel.Text = $"Total carrito: {rows.Sum(x => x.Subtotal)} pts";
    }

    private sealed record RewardRowVm(int Id, string Name, string PriceText, string StockText);
    private sealed record CartRowVm(int RewardId, string Name, string QuantityText, string SubtotalText, int Subtotal);
}
