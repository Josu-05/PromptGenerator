namespace GestionAuto;

public partial class ReportesPage : ContentPage
{
    public ReportesPage()
    {
        InitializeComponent();
        CargarReportes();
    }

    void CargarReportes()
    {
        var ventas = App.Db.Table<Venta>().OrderByDescending(v => v.Fecha).ToList();
        listaReportes.ItemsSource = ventas;

        decimal total = ventas.Sum(v => v.Monto);
        lblTotal.Text = $"Total vendido: ${total:F2}";
    }
}
    