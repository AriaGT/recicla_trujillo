using app.Views.Auth;

namespace app;

public partial class App : Application
{
    private readonly LoginView _loginView;

    public App(LoginView loginView)
    {
        InitializeComponent();

        UserAppTheme = AppTheme.Light;
        _loginView = loginView;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new NavigationPage(_loginView));
#if WINDOWS
    window.Width = 380;
    window.Height = 800;
    window.X = 100;
    window.Y = 100;
#endif
        return window;
    }
}