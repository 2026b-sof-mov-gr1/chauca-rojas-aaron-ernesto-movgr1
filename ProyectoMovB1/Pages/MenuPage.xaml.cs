using ProyectoMovB1.Models;

namespace ProyectoMovB1.Pages
{
    public partial class MenuPage : ContentPage
    {
        private readonly List<(string Nombre, Border Chip, Label Texto)> _chips = [];

        public MenuPage()
        {
            InitializeComponent();
            CrearPestanias();
            SeleccionarCategoria(DatosEjemplo.Categorias[0]);
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
            var rojo = (Color)Application.Current!.Resources["Rojo"];
            var fondoChip = (Color)Application.Current.Resources["FondoChip"];
            var azul = (Color)Application.Current.Resources["AzulMarino"];

            foreach (var (nombre, chip, texto) in _chips)
            {
                var activo = nombre == categoria;
                chip.BackgroundColor = activo ? rojo : fondoChip;
                texto.TextColor = activo ? Colors.White : azul;
            }

            ProductosView.ItemsSource = DatosEjemplo.Menu[categoria];
        }

        private async void OnAgregarTapped(object? sender, TappedEventArgs e) =>
            await Shell.Current.GoToAsync(nameof(CarritoPage));
    }
}
