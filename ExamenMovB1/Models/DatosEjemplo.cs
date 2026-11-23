namespace ExamenMovB1.Models
{
    /// <summary>
    /// Datos de ejemplo. El menú se puede modificar mediante <see cref="ExamenMovB1.Services.MenuRepositorio"/>.
    /// </summary>
    public static class DatosEjemplo
    {
        public const string NombreUsuario = "Pepe Lopez";
        public const string CorreoUsuario = "pepe.lopez@gmail.com";
        public const string HoraRetiro = "13:00";

        /// <summary>Horas disponibles para retirar el pedido (cada 30 minutos).</summary>
        public static readonly IReadOnlyList<string> HorasRetiro =
            ["11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00"];

        public static readonly IReadOnlyList<string> Categorias =
            ["Almuerzos", "Desayunos", "Comida Rápida"];

        /// <summary>Platos con los que arranca la app (se copian al repositorio en memoria).</summary>
        public static readonly IReadOnlyList<Producto> MenuInicial =
        [
            new Producto { Nombre = "Almuerzo completo", Categoria = "Almuerzos", Precio = 3.50m,
                           Componentes = ["Sopa", "Arroz amarillo", "Pollo", "Postre"] },
            new Producto { Nombre = "Medio almuerzo", Categoria = "Almuerzos", Precio = 2.50m,
                           Componentes = ["Arroz amarillo", "Pollo"] },
            new Producto { Nombre = "Almuerzo vegetariano", Categoria = "Almuerzos", Precio = 3.00m,
                           Componentes = ["Crema de zapallo", "Arroz", "Menestra", "Ensalada"] },
            new Producto { Nombre = "Desayuno completo", Categoria = "Desayunos", Precio = 2.75m,
                           Componentes = ["Café o jugo", "Pan con huevo", "Fruta"] },
            new Producto { Nombre = "Desayuno sencillo", Categoria = "Desayunos", Precio = 1.50m,
                           Componentes = ["Café", "Pan con queso"] },
            new Producto { Nombre = "Bolón con huevo", Categoria = "Desayunos", Precio = 2.25m,
                           Componentes = ["Bolón de verde", "Huevo frito", "Café"] },
            new Producto { Nombre = "Pollo coreano", Categoria = "Comida Rápida", Precio = 4.00m,
                           Componentes = ["Alitas", "Papas fritas", "Salsa"] },
            new Producto { Nombre = "Hamburguesa de carne", Categoria = "Comida Rápida", Precio = 5.00m,
                           Componentes = ["Carne", "Queso", "Papas fritas"] },
            new Producto { Nombre = "Salchipapa", Categoria = "Comida Rápida", Precio = 2.00m,
                           Componentes = ["Salchicha", "Papas fritas"] },
        ];

        public static readonly IReadOnlyList<LineaPedido> PedidosPendientes =
        [
            new LineaPedido { Cantidad = 1, Tipo = "Pollo coreano", Precio = 4.00m },
            new LineaPedido { Cantidad = 1, Tipo = "Almuerzo", Precio = 3.50m },
        ];

        public static readonly IReadOnlyList<LineaPedido> Carrito =
        [
            new LineaPedido { Cantidad = 1, Tipo = "Pollo coreano", Precio = 4.00m },
            new LineaPedido { Cantidad = 1, Tipo = "Hamb. carne", Precio = 5.00m },
        ];

        public static decimal TotalCarrito => Carrito.Sum(l => l.Cantidad * l.Precio);
    }
}
