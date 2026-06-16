using shared.Structures.Simple;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace shared;

public sealed class ApiClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly bool _ownsHttpClient;
    private readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() }
    };

    public Uri? BaseAddress => _httpClient.BaseAddress;

    public ApiClient(string baseUrl)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
        _ownsHttpClient = true;
    }

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AuthSessionDto?> LoginByDniAsync(string dni, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", new AuthLoginDto(dni), _jsonOptions, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return null;

        await EnsureBusinessSuccessAsync(response, cancellationToken);
        return await response.Content.ReadFromJsonAsync<AuthSessionDto>(_jsonOptions, cancellationToken);
    }

    public async Task<UserDto> RegisterCitizenAsync(AuthRegisterDto dto, CancellationToken cancellationToken = default)
        => await PostAsync<AuthRegisterDto, UserDto>("api/auth/register", dto, cancellationToken);

    public async Task<NodeList<UserDto>> GetUsersAsync(CancellationToken cancellationToken = default)
        => await GetNodeListAsync<UserDto>("api/users", cancellationToken);

    public async Task<UserDto?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default)
        => await GetByIdAsync<UserDto>($"api/users/{id}", cancellationToken);

    public async Task<UserDto> CreateUserAsync(UserCreateDto dto, CancellationToken cancellationToken = default)
        => await PostAsync<UserCreateDto, UserDto>("api/users", dto, cancellationToken);

    public async Task<UserDto?> UpdateUserAsync(int id, UserUpdateDto dto, CancellationToken cancellationToken = default)
        => await PutAsync<UserUpdateDto, UserDto>($"api/users/{id}", dto, cancellationToken);

    public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken = default)
        => await DeleteAsync($"api/users/{id}", cancellationToken);

    public async Task<List<RewardDto>> GetRewardsAsync(CancellationToken cancellationToken = default)
        => await GetListAsync<RewardDto>("api/rewards", cancellationToken);

    public async Task<NodeList<RewardDto>> GetRewardsNodeListAsync(CancellationToken cancellationToken = default)
        => await GetNodeListAsync<RewardDto>("api/rewards", cancellationToken);

    public async Task<RewardDto?> GetRewardByIdAsync(int id, CancellationToken cancellationToken = default)
        => await GetByIdAsync<RewardDto>($"api/rewards/{id}", cancellationToken);

    public async Task<RewardDto> CreateRewardAsync(RewardCreateDto dto, CancellationToken cancellationToken = default)
        => await PostAsync<RewardCreateDto, RewardDto>("api/rewards", dto, cancellationToken);

    public async Task<RewardDto?> UpdateRewardAsync(int id, RewardUpdateDto dto, CancellationToken cancellationToken = default)
        => await PutAsync<RewardUpdateDto, RewardDto>($"api/rewards/{id}", dto, cancellationToken);

    public async Task<bool> DeleteRewardAsync(int id, CancellationToken cancellationToken = default)
        => await DeleteAsync($"api/rewards/{id}", cancellationToken);

    public async Task<NodeList<DeliveryDto>> GetDeliveriesAsync(CancellationToken cancellationToken = default)
        => await GetNodeListAsync<DeliveryDto>("api/deliveries", cancellationToken);

    public async Task<DeliveryDto?> GetDeliveryByIdAsync(int id, CancellationToken cancellationToken = default)
        => await GetByIdAsync<DeliveryDto>($"api/deliveries/{id}", cancellationToken);

    public async Task<DeliveryDto> CreateDeliveryAsync(DeliveryCreateDto dto, CancellationToken cancellationToken = default)
        => await PostAsync<DeliveryCreateDto, DeliveryDto>("api/deliveries", dto, cancellationToken);

    public async Task<DeliveryDto?> UpdateDeliveryAsync(int id, DeliveryUpdateDto dto, CancellationToken cancellationToken = default)
        => await PutAsync<DeliveryUpdateDto, DeliveryDto>($"api/deliveries/{id}", dto, cancellationToken);

    public async Task<bool> DeleteDeliveryAsync(int id, CancellationToken cancellationToken = default)
        => await DeleteAsync($"api/deliveries/{id}", cancellationToken);

    public async Task<List<SaleDto>> GetSalesAsync(CancellationToken cancellationToken = default)
        => await GetListAsync<SaleDto>("api/sales", cancellationToken);

    public async Task<NodeList<SaleDto>> GetSalesNodeListAsync(CancellationToken cancellationToken = default)
        => await GetNodeListAsync<SaleDto>("api/sales", cancellationToken);

    public async Task<SaleDto?> GetSaleByIdAsync(int id, CancellationToken cancellationToken = default)
        => await GetByIdAsync<SaleDto>($"api/sales/{id}", cancellationToken);

    public async Task<SaleDto> CreateSaleAsync(SaleCreateDto dto, CancellationToken cancellationToken = default)
        => await PostAsync<SaleCreateDto, SaleDto>("api/sales", dto, cancellationToken);

    public async Task<bool> DeleteSaleAsync(int id, CancellationToken cancellationToken = default)
        => await DeleteAsync($"api/sales/{id}", cancellationToken);

    public async Task<SaleDto?> ValidateSaleByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        var encoded = Uri.EscapeDataString(code);
        var response = await _httpClient.GetAsync($"api/sales/validate?code={encoded}", cancellationToken);

        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        await EnsureBusinessSuccessAsync(response, cancellationToken);
        return await response.Content.ReadFromJsonAsync<SaleDto>(_jsonOptions, cancellationToken);
    }

    public async Task<CashSummaryDto> GetCashSummaryAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("api/cash/summary", cancellationToken);
        await EnsureBusinessSuccessAsync(response, cancellationToken);
        return await response.Content.ReadFromJsonAsync<CashSummaryDto>(_jsonOptions, cancellationToken)
            ?? new CashSummaryDto(0, 0, 0);
    }

    public async Task<List<CashMovementDto>> GetCashMovementsAsync(CancellationToken cancellationToken = default)
        => await GetListAsync<CashMovementDto>("api/cash/movements", cancellationToken);
    private async Task<NodeList<T>> GetNodeListAsync<T>(string endpoint, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(endpoint, cancellationToken);
        await EnsureBusinessSuccessAsync(response, cancellationToken);
        var jsonResponse = await response.Content.ReadAsStringAsync(cancellationToken);
        return DataTransformer.ToSimpleList<T>(jsonResponse);
    }

    private async Task<List<T>> GetListAsync<T>(string endpoint, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(endpoint, cancellationToken);
        await EnsureBusinessSuccessAsync(response, cancellationToken);
        return await response.Content.ReadFromJsonAsync<List<T>>(_jsonOptions, cancellationToken) ?? [];
    }

    private async Task<T?> GetByIdAsync<T>(string endpoint, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(endpoint, cancellationToken);

        if (response.StatusCode == HttpStatusCode.NotFound)
            return default;

        await EnsureBusinessSuccessAsync(response, cancellationToken);
        return await response.Content.ReadFromJsonAsync<T>(_jsonOptions, cancellationToken);
    }

    private async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(endpoint, request, _jsonOptions, cancellationToken);
        await EnsureBusinessSuccessAsync(response, cancellationToken);

        var body = await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions, cancellationToken);
        return body ?? throw new InvalidOperationException("La API devolvió una respuesta vacía");
    }

    private async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PutAsJsonAsync(endpoint, request, _jsonOptions, cancellationToken);

        if (response.StatusCode == HttpStatusCode.NotFound)
            return default;

        await EnsureBusinessSuccessAsync(response, cancellationToken);
        return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions, cancellationToken);
    }

    private async Task<bool> DeleteAsync(string endpoint, CancellationToken cancellationToken)
    {
        var response = await _httpClient.DeleteAsync(endpoint, cancellationToken);

        if (response.StatusCode == HttpStatusCode.NotFound)
            return false;

        await EnsureBusinessSuccessAsync(response, cancellationToken);
        return true;
    }

    private async Task EnsureBusinessSuccessAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        if (response.IsSuccessStatusCode)
            return;

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>(_jsonOptions, cancellationToken);
            throw new InvalidOperationException(error?.Message ?? "Operación inválida");
        }

        response.EnsureSuccessStatusCode();
    }

    public void Dispose()
    {
        if (_ownsHttpClient)
            _httpClient.Dispose();
    }

    private sealed record ApiErrorResponse(string Message);
}
