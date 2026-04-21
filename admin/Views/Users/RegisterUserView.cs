using admin.Components;
using admin.Services;
using shared;
using shared.Enums;
using shared.Services;

namespace admin.Views;

internal partial class RegisterUserView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    public RegisterUserView(ApiClient apiClient, INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;

        var roleList = DataTransformer.EnumToNodeList<UserRoleEnums>(role => role switch
        {
            UserRoleEnums.Admin => "Administrador",
            UserRoleEnums.Citizen => "Ciudadano",
            _ => role.ToString()
        });

        selectRole.ValueMember = "Value";
        selectRole.DisplayMember = "Label";
        selectRole.LoadItems(roleList);
    }

    private void RegisterUserView_Load(object? sender, EventArgs e)
    {
        if (!_sessionService.IsLoggedIn())
        {
            _navigationService.NavigateTo<LoginView>();
        }
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<UsersView>();
    }

    private async void btnRegister_Click(object? sender, EventArgs e)
    {
        await RegisterUserAsync();
    }

    private async Task RegisterUserAsync()
    {
        var dni = txtDni.Text.Trim();
        var fullName = txtFullName.Text.Trim();

        if (string.IsNullOrWhiteSpace(dni))
        {
            _navigationService.ShowModal("Validación", "Ingresa un DNI.", ModalType.Warning, ModalButtons.OK);
            return;
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            _navigationService.ShowModal("Validación", "Ingresa el nombre completo.", ModalType.Warning, ModalButtons.OK);
            return;
        }

        if (selectRole.SelectedValue is not UserRoleEnums role)
        {
            _navigationService.ShowModal("Validación", "Selecciona un rol.", ModalType.Warning, ModalButtons.OK);
            return;
        }

        try
        {
            await _apiClient.CreateUserAsync(new UserCreateDto(dni, fullName, role));
            _navigationService.ShowModal("Éxito", "Usuario registrado correctamente.", ModalType.Success, ModalButtons.OK);
            _navigationService.NavigateTo<UsersView>();
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal("Error", ex.Message, ModalType.Error, ModalButtons.OK);
        }
    }
}
