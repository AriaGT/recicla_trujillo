namespace app.Components;

public partial class RewardItemView : ContentView
{
    public static readonly BindableProperty RewardIdProperty =
        BindableProperty.Create(nameof(RewardId), typeof(int), typeof(RewardItemView), 0);

    public static readonly BindableProperty RewardNameProperty =
        BindableProperty.Create(nameof(RewardName), typeof(string), typeof(RewardItemView), string.Empty);

    public static readonly BindableProperty RequiredPointsTextProperty =
        BindableProperty.Create(nameof(RequiredPointsText), typeof(string), typeof(RewardItemView), string.Empty);

    public static readonly BindableProperty StockTextProperty =
        BindableProperty.Create(nameof(StockText), typeof(string), typeof(RewardItemView), string.Empty);

    public int RewardId
    {
        get => (int)GetValue(RewardIdProperty);
        set => SetValue(RewardIdProperty, value);
    }

    public string RewardName
    {
        get => (string)GetValue(RewardNameProperty);
        set => SetValue(RewardNameProperty, value);
    }

    public string RequiredPointsText
    {
        get => (string)GetValue(RequiredPointsTextProperty);
        set => SetValue(RequiredPointsTextProperty, value);
    }

    public string StockText
    {
        get => (string)GetValue(StockTextProperty);
        set => SetValue(StockTextProperty, value);
    }

    public event EventHandler<int>? RedeemClicked;

    public RewardItemView()
    {
        InitializeComponent();
    }

    private void OnRedeemClicked(object? sender, EventArgs e)
    {
        RedeemClicked?.Invoke(this, RewardId);
    }
}
