using System.Globalization;

namespace ProyectoMovB1.Models
{
    /// <summary>Plato que se muestra en el menú.</summary>
    public class Producto
    {
        public required string Nombre { get; init; }
        public required string Imagen { get; init; }
        public required decimal Precio { get; init; }
        public IReadOnlyList<string> Componentes { get; init; } = [];

        public string PrecioTexto => Formato.Dinero(Precio);
    }

    /// <summary>Fila de las tablas de "Mis pedidos" y "Mi carrito".</summary>
    public class LineaPedido
    {
        public required int Cantidad { get; init; }
        public required string Tipo { get; init; }
        public required decimal Precio { get; init; }

        public string PrecioTexto => Formato.Dinero(Precio);
    }

    public static class Formato
    {
        public static string Dinero(decimal valor) =>
            "$" + valor.ToString("0.00", CultureInfo.InvariantCulture);
    }
}
