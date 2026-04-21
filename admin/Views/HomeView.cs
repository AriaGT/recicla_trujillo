using admin.Components;
using admin.Services;
using shared.Services;

namespace admin.Views;

internal partial class HomeView : BaseView
{
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    public HomeView(INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _sessionService = sessionService;

        lblWelcome.Text = $"Bienvenido, {_sessionService.CurrentSession?.FullName ?? "Usuario"}";
    }

    private void btnDeliveries_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<DeliveriesView>();
    }

    private void btnRewards_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<RewardsView>();
    }

    private void btnRedeemValidator_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<RedemptionsView>();
    }

    private void btnUsers_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<UsersView>();
    }

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        var result = _navigationService.ShowModal(
            title: "Cerrar Sesión",
            message: "¿Estás seguro de que deseas cerrar sesión?",
            type: ModalType.Question,
            buttons: ModalButtons.YesNo
        );

        if (result == ModalResult.Yes)
        {
            _sessionService.ClearSession();
            _navigationService.NavigateTo<LoginView>();
        }
    }
}
