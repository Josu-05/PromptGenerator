namespace GestionAuto;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var user = App.Db.Table<Usuario>()
            .FirstOrDefault(u => u.NombreUsuario == txtUsuario.Text && u.Contrasena == txtContrasena.Text);

        if (user != null)
        {
            await Navigation.PushAsync(new MainPage(user.NombreUsuario));
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }
    }
}
