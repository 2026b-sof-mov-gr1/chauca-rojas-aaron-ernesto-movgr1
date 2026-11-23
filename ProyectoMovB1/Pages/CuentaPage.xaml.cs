using ProyectoMovB1.Models;

namespace ProyectoMovB1.Pages
{
    public partial class CuentaPage : ContentPage
    {
        public CuentaPage()
        {
            InitializeComponent();
            NombreLabel.Text = DatosEjemplo.NombreUsuario;
            CorreoLabel.Text = DatosEjemplo.CorreoUsuario;
        }

        // La edición de datos (CRUD) queda para el examen; aquí solo se muestra un aviso.
        private async void OnEditarTapped(object? sender, TappedEventArgs e) =>
            await DisplayAlertAsync("Editar datos", "Función disponible próximamente.", "OK");
    }
}
