namespace ProyectoMovB1.Pages
{
    public partial class PagoExitosoPage : ContentPage
    {
        public PagoExitosoPage()
        {
            InitializeComponent();
        }

        private async void OnVolverInicioClicked(object? sender, EventArgs e) =>
            await Shell.Current.GoToAsync("//MainPage");

        // El botón físico "atrás" de Android también regresa al Inicio.
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync("//MainPage");
            return true;
        }
    }
}
