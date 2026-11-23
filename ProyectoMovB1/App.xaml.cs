namespace ProyectoMovB1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // El prototipo solo tiene diseño en modo claro.
            UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
