namespace GestionAuto;

public partial class VentasPage : ContentPage
{
    public VentasPage()
    {
        InitializeComponent();
        CargarCombos();
        CargarVentas();
    }

    void CargarCombos()
    {
        pickerCliente.ItemsSource = App.Db.Table<Cliente>().Select(c => c.Nombre).ToList();
        pickerAuto.ItemsSource = App.Db.Table<Auto>().Select(a => $"{a.Marca} {a.Modelo} ({a.Año})").ToList();
    }

    void CargarVentas()
    {
        listaVentas.ItemsSource = App.Db.Table<Venta>().OrderByDescending(v => v.Fecha).ToList();
    }

    private void OnAgregarClicked(object sender, EventArgs e)
    {
        if (pickerCliente.SelectedItem == null || pickerAuto.SelectedItem == null || string.IsNullOrEmpty(txtMonto.Text))
        {
            DisplayAlert("Error", "Complete todos los campos", "OK");
            return;
        }

        var venta = new Venta
        {
            Cliente = pickerCliente.SelectedItem.ToString(),
            Auto = pickerAuto.SelectedItem.ToString(),
            Fecha = dateFecha.Date,
            Monto = decimal.Parse(txtMonto.Text)
        };

        App.Db.Insert(venta);
        CargarVentas();

        pickerCliente.SelectedIndex = -1;
        pickerAuto.SelectedIndex = -1;
        txtMonto.Text = string.Empty;
    }

    private void OnEliminarClicked(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipe && swipe.BindingContext is Venta venta)
        {
            App.Db.Delete(venta);
            CargarVentas();
        }
    }
}
