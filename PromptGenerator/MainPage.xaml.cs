namespace GestionAuto;

public partial class MainPage : ContentPage
{
    string usuario;

    public MainPage(string nombreUsuario)
    {
        InitializeComponent();
        usuario = nombreUsuario;
        lblSaludo.Text = $"Bienvenido, {usuario}!";
    }

    private async void OnAutosClicked(object sender, EventArgs e) => await Navigation.PushAsync(new AutosPage());
    private async void OnClientesClicked(object sender, EventArgs e) => await Navigation.PushAsync(new ClientesPage());
    private async void OnVentasClicked(object sender, EventArgs e) => await Navigation.PushAsync(new VentasPage());
    private async void OnReportesClicked(object sender, EventArgs e) => await Navigation.PushAsync(new ReportesPage());
}
