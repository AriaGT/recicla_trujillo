using admin.Components;
using admin.Services;
using shared;
using shared.Enums;
using shared.Services;
using shared.Structures.Simple;
using System.Diagnostics;

namespace admin.Views;

internal partial class RegisterDeliveryView : BaseView
{
    private readonly ApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    public RegisterDeliveryView(
        ApiClient apiClient,
        INavigationService navigationService,
        ISessionService sessionService)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _navigationService = navigationService;
        _sessionService = sessionService;

        var wasteTypeList = DataTransformer.EnumToNodeList<WasteTypeEnums>(wt => wt switch
        {
            WasteTypeEnums.Metal => "Metal",
            WasteTypeEnums.Paper => "Papel",
            WasteTypeEnums.Plastic => "Plástico",
            WasteTypeEnums.Glass => "Vidrio",
            _ => wt.ToString()
        });
        selectWasteType.ValueMember = "Value";
        selectWasteType.DisplayMember = "Label";
        selectWasteType.LoadItems(wasteTypeList);
    }

    private async void RegisterDeliveryView_Load(object? sender, EventArgs e)
    {
        if (!_sessionService.IsLoggedIn())
        {
            _navigationService.NavigateTo<LoginView>();
            return;
        }

        await LoadUsersAsync();
    }

    private async Task LoadUsersAsync()
    {
        try
        {
            NodeList<UserDto> users = await _apiClient.GetUsersAsync();
            selectUsers.ValueMember = "Id";
            selectUsers.DisplayMember = "FullName";
            selectUsers.LoadItems(users);
            lblStatus.Text = "Formulario listo";
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error cargando usuarios: {ex.Message}";
        }
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<DeliveriesView>();
    }

    private async void btnRegister_Click(object? sender, EventArgs e)
    {
        await RegisterDeliveryAsync();
    }

    private async Task RegisterDeliveryAsync()
    {
        lblStatus.Text = "";

        if (selectUsers.SelectedValue is not int userId)
        {
            _navigationService.ShowModal(
                "Validación",
                "Por favor selecciona un usuario.",
                ModalType.Warning,
                ModalButtons.OK
            );
            return;
        }

        if (selectWasteType.SelectedValue is not WasteTypeEnums wasteType)
        {
            _navigationService.ShowModal(
                "Validación",
                "Por favor selecciona un tipo de residuo.",
                ModalType.Warning,
                ModalButtons.OK
            );
            return;
        }

        if (numKg.Value <= 0)
        {
            _navigationService.ShowModal(
                "Validación",
                "La cantidad en kg debe ser mayor a 0.",
                ModalType.Warning,
                ModalButtons.OK
            );
            return;
        }

        try
        {
            var dto = new DeliveryCreateDto(userId, wasteType, numKg.Value);
            await _apiClient.CreateDeliveryAsync(dto);

            _navigationService.ShowModal(
                "Éxito",
                "Delivery registrado correctamente.",
                ModalType.Success,
                ModalButtons.OK
            );
            _navigationService.NavigateTo<DeliveriesView>();
        }
        catch (Exception ex)
        {
            _navigationService.ShowModal(
                "Error",
                ex.Message,
                ModalType.Error,
                ModalButtons.OK
            );
        }
    }

    private sealed record WasteTypeOption(WasteTypeEnums Value, string Label);
}
