using ExamenMovB1.Pages;

namespace ExamenMovB1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Rutas de navegación entre pantallas
            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
            Routing.RegisterRoute(nameof(PedidosPage), typeof(PedidosPage));
            Routing.RegisterRoute(nameof(CuentaPage), typeof(CuentaPage));
            Routing.RegisterRoute(nameof(CarritoPage), typeof(CarritoPage));
            Routing.RegisterRoute(nameof(PagoExitosoPage), typeof(PagoExitosoPage));
            Routing.RegisterRoute(nameof(PlatoFormPage), typeof(PlatoFormPage));
        }
    }
}
