using admin.Components;
using admin.Views;
using Microsoft.Extensions.DependencyInjection;
using shared.Services;

namespace admin.Services;

internal interface INavigationService
{
    void NavigateTo<T>() where T : BaseView;
    ModalResult ShowModal(string title, string message, ModalType type = ModalType.Information, ModalButtons buttons = ModalButtons.OK);
}

internal class NavigationService: INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ISessionService _sessionService;
    private MainContainer? _mainContainer;

    public NavigationService(IServiceProvider serviceProvider, ISessionService sessionService)
    {
        _serviceProvider = serviceProvider;
        _sessionService = sessionService;
    }

    public void Initialize(MainContainer mainContainer)
    {
        _mainContainer = mainContainer;
        if (_sessionService.IsLoggedIn())
        {
            NavigateTo<HomeView>();
        }
        else
        {
            NavigateTo<LoginView>();
        }
    }

    public void NavigateTo<T>() where T : BaseView
    {
        var view = _serviceProvider.GetRequiredService<T>();
        _mainContainer?.RenderView(view);
    }

    public ModalResult ShowModal(string title, string message, ModalType type = ModalType.Information, ModalButtons buttons = ModalButtons.OK)
    {
        var modal = new ModalContainer(title, message, type, buttons);
        var result = modal.ShowDialog(_mainContainer);
        return modal.Result;
    }
}
