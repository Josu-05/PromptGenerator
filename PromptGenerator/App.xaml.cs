using SQLite;
using System.IO;

namespace GestionAuto;

public partial class App : Application
{
    public static SQLiteConnection Db;

    public App()
    {
        InitializeComponent();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "gestionauto.db3");
        Db = new SQLiteConnection(dbPath);
        CrearTablas();

        MainPage = new NavigationPage(new LoginPage());
    }

    void CrearTablas()
    {
        Db.CreateTable<Usuario>();
        Db.CreateTable<Auto>();
        Db.CreateTable<Cliente>();
        Db.CreateTable<Venta>();

        // Usuario por defecto
        if (!Db.Table<Usuario>().Any())
            Db.Insert(new Usuario { NombreUsuario = "admin", Contrasena = "1234" });
    }
}
