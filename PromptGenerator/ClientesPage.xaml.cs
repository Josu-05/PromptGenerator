namespace GestionAuto;

public partial class ClientesPage : ContentPage
{
    public ClientesPage()
    {
        InitializeComponent();
        CargarClientes();
    }

    void CargarClientes()
    {
        listaClientes.ItemsSource = App.Db.Table<Cliente>().ToList();
    }

    private void OnAgregarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtTelefono.Text))
            return;

        App.Db.Insert(new Cliente { Nombre = txtNombre.Text, Telefono = txtTelefono.Text });
        CargarClientes();

        txtNombre.Text = txtTelefono.Text = string.Empty;
    }

    private void OnEliminarClicked(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipe && swipe.BindingContext is Cliente cliente)
        {
            App.Db.Delete(cliente);
            CargarClientes();
        }
    }
}
