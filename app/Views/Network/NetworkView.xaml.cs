using Microsoft.Maui.Controls.Shapes;
using shared.Structures.Graph;

namespace app.Views.Network;

public partial class NetworkView : ContentPage
{
    private readonly UndirectedGraph<string> _network = new();

    private static readonly Color Primary        = Color.FromArgb("#483D8B");
    private static readonly Color Secondary      = Color.FromArgb("#DFD8F7");
    private static readonly Color PrimaryDarkText = Color.FromArgb("#242424");
    private static readonly Color Gray200        = Color.FromArgb("#C8C8C8");

    private static readonly string[] Districts =
        ["Centro", "La Esperanza", "El Porvenir", "Florencia de Mora", "Víctor Larco", "Moche"];

    public NetworkView()
    {
        InitializeComponent();
        BuildNetwork();
        foreach (var d in Districts)
            DistrictPicker.Items.Add(d);
    }

    private void BuildNetwork()
    {
        _network.AddEdge("Centro", "La Esperanza");
        _network.AddEdge("Centro", "El Porvenir");
        _network.AddEdge("Centro", "Víctor Larco");
        _network.AddEdge("La Esperanza", "Florencia de Mora");
        _network.AddEdge("El Porvenir", "Florencia de Mora");
        _network.AddEdge("Víctor Larco", "Moche");
    }

    private void OnAnalyzeClicked(object? sender, EventArgs e)
    {
        if (DistrictPicker.SelectedItem is not string origin)
            return;

        var neighbors = _network.Neighbors(origin);

        RenderNeighbors(neighbors);

        NeighborsCard.IsVisible = true;
    }

    private void RenderNeighbors(string[] neighbors)
    {
        NeighborsContainer.Children.Clear();
        foreach (var name in neighbors)
        {
            var row = new HorizontalStackLayout { Spacing = 10 };

            row.Children.Add(new Border
            {
                BackgroundColor = Secondary,
                Stroke = new SolidColorBrush(Primary),
                StrokeThickness = 1.5,
                StrokeShape = new Ellipse(),
                WidthRequest = 12,
                HeightRequest = 12,
                VerticalOptions = LayoutOptions.Center
            });

            row.Children.Add(new Label
            {
                Text = name,
                TextColor = PrimaryDarkText,
                VerticalOptions = LayoutOptions.Center
            });

            NeighborsContainer.Children.Add(row);
        }
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
