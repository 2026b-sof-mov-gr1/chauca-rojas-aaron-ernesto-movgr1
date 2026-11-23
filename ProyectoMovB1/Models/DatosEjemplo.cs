namespace ProyectoMovB1.Models
{
    /// <summary>
    /// Datos estáticos para el prototipo. No hay persistencia ni CRUD.
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

        public static readonly IReadOnlyDictionary<string, IReadOnlyList<Producto>> Menu =
            new Dictionary<string, IReadOnlyList<Producto>>
            {
                ["Almuerzos"] =
                [
                    new Producto { Nombre = "Almuerzo completo", Imagen = "plato_almuerzo.png", Precio = 3.50m,
                                   Componentes = ["Sopa", "Arroz amarillo", "Pollo", "Postre"] },
                    new Producto { Nombre = "Medio almuerzo", Imagen = "plato_almuerzo.png", Precio = 2.50m,
                                   Componentes = ["Arroz amarillo", "Pollo"] },
                    new Producto { Nombre = "Almuerzo vegetariano", Imagen = "plato_almuerzo.png", Precio = 3.00m,
                                   Componentes = ["Crema de zapallo", "Arroz", "Menestra", "Ensalada"] },
                ],
                ["Desayunos"] =
                [
                    new Producto { Nombre = "Desayuno completo", Imagen = "plato_desayuno.png", Precio = 2.75m,
                                   Componentes = ["Café o jugo", "Pan con huevo", "Fruta"] },
                    new Producto { Nombre = "Desayuno sencillo", Imagen = "plato_desayuno.png", Precio = 1.50m,
                                   Componentes = ["Café", "Pan con queso"] },
                    new Producto { Nombre = "Bolón con huevo", Imagen = "plato_desayuno.png", Precio = 2.25m,
                                   Componentes = ["Bolón de verde", "Huevo frito", "Café"] },
                ],
                ["Comida Rápida"] =
                [
                    new Producto { Nombre = "Pollo coreano", Imagen = "plato_rapida.png", Precio = 4.00m,
                                   Componentes = ["Alitas", "Papas fritas", "Salsa"] },
                    new Producto { Nombre = "Hamburguesa de carne", Imagen = "plato_rapida.png", Precio = 5.00m,
                                   Componentes = ["Carne", "Queso", "Papas fritas"] },
                    new Producto { Nombre = "Salchipapa", Imagen = "plato_rapida.png", Precio = 2.00m,
                                   Componentes = ["Salchicha", "Papas fritas"] },
                ],
            };

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
