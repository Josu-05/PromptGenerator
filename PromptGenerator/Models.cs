using SQLite;

namespace GestionAuto;

public class Usuario
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string NombreUsuario { get; set; }
    public string Contrasena { get; set; }
}

public class Auto
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
}

public class Cliente
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
}

public class Venta
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Cliente { get; set; }
    public string Auto { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Monto { get; set; }
}
