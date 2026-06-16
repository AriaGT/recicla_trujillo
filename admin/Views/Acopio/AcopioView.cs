using admin.Components;
using admin.Services;
using shared.Services;
using shared.Structures.Graph;

namespace admin.Views;

internal partial class AcopioView : BaseView
{
    private readonly INavigationService _navigationService;
    private readonly ISessionService _sessionService;

    // Fixed undirected graph with the city's collection-point network.
    private readonly UndirectedGraph<string> _network = new();

    public AcopioView(INavigationService navigationService, ISessionService sessionService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _sessionService = sessionService;

        BuildNetwork();
    }

    private void AcopioView_Load(object? sender, EventArgs e)
    {
        if (!_sessionService.IsLoggedIn())
        {
            _navigationService.NavigateTo<LoginView>();
            return;
        }

        foreach (var punto in new[] { "Centro", "La Esperanza", "El Porvenir", "Florencia de Mora", "Víctor Larco", "Moche" })
            cboOrigin.Items.Add(punto);

        if (cboOrigin.Items.Count > 0)
            cboOrigin.SelectedIndex = 0;
    }

    private void BuildNetwork()
    {
        // Edges (routes) between collection points. Being undirected, they're bidirectional.
        _network.AddEdge("Centro", "La Esperanza");
        _network.AddEdge("Centro", "El Porvenir");
        _network.AddEdge("Centro", "Víctor Larco");
        _network.AddEdge("La Esperanza", "Florencia de Mora");
        _network.AddEdge("El Porvenir", "Florencia de Mora");
        _network.AddEdge("Víctor Larco", "Moche");
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        _navigationService.NavigateTo<HomeView>();
    }

    private void btnAnalyze_Click(object? sender, EventArgs e)
    {
        if (cboOrigin.SelectedItem is not string origin)
        {
            lblOutput.Text = "Selecciona un punto de acopio.";
            return;
        }

        var neighbors = _network.Neighbors(origin);
        var reachable = _network.BreadthFirstSearch(origin);

        lblOutput.Text =
            $"Punto: {origin}\r\n\r\n" +
            $"Vecinos directos: {(neighbors.Length > 0 ? string.Join(", ", neighbors) : "ninguno")}\r\n\r\n" +
            $"Alcanzables (BFS): {string.Join(" → ", reachable)}";
    }
}
