namespace GestionAuto;

public partial class AutosPage : ContentPage
{
    public AutosPage()
    {
        InitializeComponent();
        CargarAutos();
    }

    void CargarAutos()
    {
        listaAutos.ItemsSource = App.Db.Table<Auto>().ToList();
    }

    private void OnAgregarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtMarca.Text) || string.IsNullOrEmpty(txtModelo.Text) || string.IsNullOrEmpty(txtAno.Text))
            return;

        App.Db.Insert(new Auto { Marca = txtMarca.Text, Modelo = txtModelo.Text, Año = int.Parse(txtAno.Text) });
        CargarAutos();

        txtMarca.Text = txtModelo.Text = txtAno.Text = string.Empty;
    }

    private void OnEliminarClicked(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipe && swipe.BindingContext is Auto auto)
        {
            App.Db.Delete(auto);
            CargarAutos();
        }
    }
}
