using ExamenMovB1.Models;
using ExamenMovB1.Services;

namespace ExamenMovB1.Pages
{
    public partial class MenuPage : ContentPage
    {
        private readonly List<(string Nombre, Border Chip, Label Texto)> _chips = [];
        private string _categoriaActual = DatosEjemplo.Categorias[0];

        public MenuPage()
        {
            InitializeComponent();
            CrearPestanias();
            SeleccionarCategoria(_categoriaActual);
        }

        // Al volver del formulario se recarga la lista (y se muestra la categoría del plato guardado).
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (MenuRepositorio.CategoriaPendiente is { } categoria)
            {
                MenuRepositorio.CategoriaPendiente = null;
                SeleccionarCategoria(categoria);
            }
            else
            {
                CargarPlatos();
            }
        }

        private void CrearPestanias()
        {
            foreach (var categoria in DatosEjemplo.Categorias)
            {
                var texto = new Label
                {
                    Text = categoria,
                    FontSize = 15,
                    FontAttributes = FontAttributes.Bold,
                    VerticalTextAlignment = TextAlignment.Center,
                };

                var chip = new Border
                {
                    Content = texto,
                    Padding = new Thickness(16, 9),
                    StrokeThickness = 0,
                    StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle { CornerRadius = 20 },
                };

                var tap = new TapGestureRecognizer();
                tap.Tapped += (_, _) => SeleccionarCategoria(categoria);
                chip.GestureRecognizers.Add(tap);

                _chips.Add((categoria, chip, texto));
                CategoriasLayout.Children.Add(chip);
            }
        }

        private void SeleccionarCategoria(string categoria)
        {
            _categoriaActual = categoria;

            var rojo = (Color)Application.Current!.Resources["Rojo"];
            var fondoChip = (Color)Application.Current.Resources["FondoChip"];
            var azul = (Color)Application.Current.Resources["AzulMarino"];

            foreach (var (nombre, chip, texto) in _chips)
            {
                var activo = nombre == categoria;
                chip.BackgroundColor = activo ? rojo : fondoChip;
                texto.TextColor = activo ? Colors.White : azul;
            }

            CargarPlatos();
        }

        // ---------- BUSCAR ----------
        private void CargarPlatos() =>
            ProductosView.ItemsSource = MenuRepositorio.Buscar(_categoriaActual, BuscarBar.Text);

        private void OnBuscarTextChanged(object? sender, TextChangedEventArgs e) => CargarPlatos();

        // ---------- CREAR ----------
        private async void OnNuevoClicked(object? sender, EventArgs e) =>
            await Shell.Current.GoToAsync($"{nameof(PlatoFormPage)}?categoria={Uri.EscapeDataString(_categoriaActual)}");

        // ---------- ACTUALIZAR ----------
        private async void OnEditarClicked(object? sender, EventArgs e)
        {
            if ((sender as BindableObject)?.BindingContext is Producto plato)
                await Shell.Current.GoToAsync($"{nameof(PlatoFormPage)}?id={plato.Id}");
        }

        // ---------- BORRAR ----------
        private async void OnEliminarClicked(object? sender, EventArgs e)
        {
            if ((sender as BindableObject)?.BindingContext is not Producto plato)
                return;

            var confirmar = await DisplayAlertAsync(
                "Eliminar plato",
                $"¿Seguro que deseas eliminar \"{plato.Nombre}\"?",
                "Eliminar", "Cancelar");

            if (confirmar)
            {
                MenuRepositorio.Eliminar(plato.Id);
                CargarPlatos();
            }
        }

        private async void OnAgregarTapped(object? sender, TappedEventArgs e) =>
            await Shell.Current.GoToAsync(nameof(CarritoPage));
    }
}
