using ProyectoMovB1.Models;

namespace ProyectoMovB1.Pages
{
    public partial class PedidosPage : ContentPage
    {
        public PedidosPage()
        {
            InitializeComponent();
            BindableLayout.SetItemsSource(FilasLayout, DatosEjemplo.PedidosPendientes);
        }
    }
}
