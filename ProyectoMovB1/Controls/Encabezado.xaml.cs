using ProyectoMovB1.Pages;

namespace ProyectoMovB1.Controls
{
    public partial class Encabezado : ContentView
    {
        public static readonly BindableProperty TituloProperty = BindableProperty.Create(
            nameof(Titulo), typeof(string), typeof(Encabezado), string.Empty,
            propertyChanged: (b, _, n) => ((Encabezado)b).TituloLabel.Text = (string)n);

        public static readonly BindableProperty MostrarCarritoProperty = BindableProperty.Create(
            nameof(MostrarCarrito), typeof(bool), typeof(Encabezado), false,
            propertyChanged: (b, _, n) => ((Encabezado)b).CarritoButton.IsVisible = (bool)n);

        public static readonly BindableProperty VolverAlInicioProperty = BindableProperty.Create(
            nameof(VolverAlInicio), typeof(bool), typeof(Encabezado), false);

        public Encabezado()
        {
            InitializeComponent();
        }

        public string Titulo
        {
            get => (string)GetValue(TituloProperty);
            set => SetValue(TituloProperty, value);
        }

        public bool MostrarCarrito
        {
            get => (bool)GetValue(MostrarCarritoProperty);
            set => SetValue(MostrarCarritoProperty, value);
        }

        /// <summary>Si es true, la flecha regresa al Inicio en lugar de a la pantalla anterior.</summary>
        public bool VolverAlInicio
        {
            get => (bool)GetValue(VolverAlInicioProperty);
            set => SetValue(VolverAlInicioProperty, value);
        }

        private async void OnAtrasClicked(object? sender, EventArgs e) =>
            await Shell.Current.GoToAsync(VolverAlInicio ? "//MainPage" : "..");

        private async void OnCarritoClicked(object? sender, EventArgs e) =>
            await Shell.Current.GoToAsync(nameof(CarritoPage));
    }
}
