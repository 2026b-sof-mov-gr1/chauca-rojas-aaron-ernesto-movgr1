using ProyectoMovB1.Models;

namespace ProyectoMovB1.Pages
{
    public partial class CarritoPage : ContentPage
    {
        public CarritoPage()
        {
            InitializeComponent();
            BindableLayout.SetItemsSource(FilasLayout, DatosEjemplo.Carrito);
            HoraPicker.ItemsSource = DatosEjemplo.HorasRetiro.ToList();
            HoraPicker.SelectedItem = DatosEjemplo.HoraRetiro;
            TotalLabel.Text = Formato.Dinero(DatosEjemplo.TotalCarrito);
        }

        // Tocar cualquier parte del recuadro abre la lista de horas.
        private void OnHoraTapped(object? sender, TappedEventArgs e) => HoraPicker.Focus();

        private async void OnPagarClicked(object? sender, EventArgs e) =>
            await Shell.Current.GoToAsync(nameof(PagoExitosoPage));
    }
}
