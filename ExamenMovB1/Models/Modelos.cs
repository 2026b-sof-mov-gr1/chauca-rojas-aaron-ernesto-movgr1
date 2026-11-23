using System.Globalization;

namespace ExamenMovB1.Models
{
    /// <summary>Plato del menú (entidad del CRUD).</summary>
    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre { get; init; }
        public required string Categoria { get; init; }
        public required decimal Precio { get; init; }
        public IReadOnlyList<string> Componentes { get; init; } = [];

        /// <summary>La imagen genérica depende de la categoría.</summary>
        public string Imagen => Categoria switch
        {
            "Desayunos" => "plato_desayuno.png",
            "Comida Rápida" => "plato_rapida.png",
            _ => "plato_almuerzo.png",
        };

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
