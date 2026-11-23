using System.Globalization;
using ExamenMovB1.Models;
using ExamenMovB1.Services;

namespace ExamenMovB1.Pages
{
    /// <summary>
    /// Formulario para crear (sin "id") o actualizar (con "id") un plato.
    /// Rutas: PlatoFormPage?categoria=Almuerzos  |  PlatoFormPage?id=3
    /// </summary>
    public partial class PlatoFormPage : ContentPage, IQueryAttributable
    {
        private int? _idEditando;

        public PlatoFormPage()
        {
            InitializeComponent();
            CategoriaPicker.ItemsSource = DatosEjemplo.Categorias.ToList();
            CategoriaPicker.SelectedIndex = 0;

#if ANDROID
            // Con el teléfono en español, el teclado numérico descarta el punto decimal.
            // Se permite escribir tanto "3.50" como "3,50".
            PrecioEntry.HandlerChanged += (_, _) =>
            {
                if (PrecioEntry.Handler?.PlatformView is Android.Widget.EditText campo)
                    campo.KeyListener = Android.Text.Method.DigitsKeyListener.GetInstance("0123456789.,");
            };
#endif
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("id", out var idTexto)
                && int.TryParse(idTexto?.ToString(), out var id)
                && MenuRepositorio.ObtenerPorId(id) is { } plato)
            {
                // Modo edición: se cargan los datos actuales
                _idEditando = plato.Id;
                EncabezadoView.Titulo = "Editar plato";
                GuardarButton.Text = "Guardar cambios";
                NombreEntry.Text = plato.Nombre;
                PrecioEntry.Text = plato.Precio.ToString("0.00", CultureInfo.InvariantCulture);
                CategoriaPicker.SelectedItem = plato.Categoria;
                ComponentesEditor.Text = string.Join(Environment.NewLine, plato.Componentes);
            }
            else if (query.TryGetValue("categoria", out var categoria))
            {
                // Modo creación: se preselecciona la categoría que estaba abierta
                CategoriaPicker.SelectedItem = Uri.UnescapeDataString(categoria?.ToString() ?? "");
            }
        }

        private async void OnGuardarClicked(object? sender, EventArgs e)
        {
            var nombre = NombreEntry.Text?.Trim() ?? "";
            var precioTexto = (PrecioEntry.Text ?? "").Trim().Replace(',', '.');
            var categoria = CategoriaPicker.SelectedItem as string;

            // Validaciones básicas
            if (nombre.Length == 0)
            {
                await DisplayAlertAsync("Falta el nombre", "Escribe el nombre del plato.", "OK");
                return;
            }
            if (!decimal.TryParse(precioTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out var precio)
                || precio <= 0)
            {
                await DisplayAlertAsync("Precio inválido", "Escribe un precio mayor a 0, por ejemplo 3.50.", "OK");
                return;
            }
            if (categoria is null)
            {
                await DisplayAlertAsync("Falta la categoría", "Elige una categoría.", "OK");
                return;
            }

            var componentes = (ComponentesEditor.Text ?? "")
                .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .ToList();

            var plato = new Producto
            {
                Nombre = nombre,
                Categoria = categoria,
                Precio = precio,
                Componentes = componentes,
            };

            if (_idEditando is int id)
            {
                plato.Id = id;
                MenuRepositorio.Actualizar(plato);
            }
            else
            {
                MenuRepositorio.Crear(plato);
            }

            MenuRepositorio.CategoriaPendiente = categoria;
            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancelarClicked(object? sender, EventArgs e) =>
            await Shell.Current.GoToAsync("..");
    }
}
