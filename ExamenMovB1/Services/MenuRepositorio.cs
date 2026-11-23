using ExamenMovB1.Models;

namespace ExamenMovB1.Services
{
    /// <summary>
    /// CRUD de platos guardado en memoria: los cambios duran mientras la app esté abierta.
    /// </summary>
    public static class MenuRepositorio
    {
        private static readonly List<Producto> _platos = [];
        private static int _siguienteId = 1;

        static MenuRepositorio()
        {
            foreach (var plato in DatosEjemplo.MenuInicial)
                Crear(plato);
        }

        /// <summary>Categoría que el Menú debe mostrar al volver del formulario.</summary>
        public static string? CategoriaPendiente { get; set; }

        // ---------- Crear ----------
        public static void Crear(Producto plato)
        {
            plato.Id = _siguienteId++;
            _platos.Add(plato);
        }

        // ---------- Leer / Buscar ----------
        public static Producto? ObtenerPorId(int id) =>
            _platos.FirstOrDefault(p => p.Id == id);

        public static List<Producto> Buscar(string categoria, string? texto)
        {
            var consulta = _platos.Where(p => p.Categoria == categoria);

            if (!string.IsNullOrWhiteSpace(texto))
                consulta = consulta.Where(p => p.Nombre.Contains(texto.Trim(), StringComparison.OrdinalIgnoreCase));

            return consulta.ToList();
        }

        // ---------- Actualizar ----------
        public static void Actualizar(Producto plato)
        {
            var indice = _platos.FindIndex(p => p.Id == plato.Id);
            if (indice >= 0)
                _platos[indice] = plato;
        }

        // ---------- Borrar ----------
        public static void Eliminar(int id) =>
            _platos.RemoveAll(p => p.Id == id);
    }
}
