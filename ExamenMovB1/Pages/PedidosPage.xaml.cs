using ExamenMovB1.Models;

namespace ExamenMovB1.Pages
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
