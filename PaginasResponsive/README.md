# Pantalla adaptable

La estructura visual está en MainPage.xaml: fondo de toda el área de la página, Grid con 24 unidades independientes de densidad y Label centrado. Un estilo explícito vacío evita heredar OpenSans y el tamaño de la plantilla; se usan los valores predeterminados del Label de MAUI. No hay barra de navegación ni controles de selección.

## Configuraciones

- Resources/Localization/Greetings.resx: español predeterminado.
- Resources/Localization/Greetings.en.resx: inglés.

Cada archivo contiene Portrait_Saludo, Portrait_texto_saludo, Portrait_fondo_pantalla y las tres claves equivalentes con prefijo Landscape. Los saltos son caracteres LF reales. El saludo inglés horizontal conserva el espacio antes del salto de línea.

GreetingResources.cs consulta el idioma de la plataforma; solo en usa inglés y cualquier otro usa español. ResourceManager carga los recursos .resx. MainPage.xaml.cs selecciona Landscape cuando el ancho de la vista supera su alto y publica Saludo, texto_saludo y fondo_pantalla como recursos dinámicos. Cambiar el tamaño actualiza inmediatamente la selección. El idioma se revisa cada segundo mientras la página está visible y al reanudar la ventana. Si el sistema reinicia la aplicación al cambiar el idioma, la nueva instancia lee la configuración actual.

## Comprobación manual

1. Selecciona español en los ajustes del dispositivo/emulador y abre la aplicación en vertical: fondo #20FF20, texto #1B5E20.
2. Gira a horizontal: fondo #FF20FF, texto #4A148C.
3. Cambia el idioma preferido a inglés y vuelve a la aplicación, en vertical: fondo #20FFFF, texto #0D47A1.
4. Gira a horizontal: fondo #FFAA20, texto #BF360C.
5. Prueba otro idioma (por ejemplo francés): debe mostrar español. Revisa ambas orientaciones, también con tema oscuro, y compara los textos con los recursos.

En Android habilita la rotación automática y utiliza los controles de giro del emulador. En iOS usa la rotación del simulador y el idioma del sistema o de la aplicación. En Windows cambia el primer idioma preferido en Configuración > Hora e idioma > Idioma y región; redimensiona el área de la ventana para que sea más alta o más ancha. Algunos sistemas requieren reiniciar la aplicación o la sesión para aplicar el idioma. Una previsualización debe ejecutar el código y proporcionar configuración de plataforma; una vista XAML estática no ejecuta la detección.

El fondo ocupa el área de contenido MAUI de borde a borde; las barras del sistema y la decoración de ventanas son administradas por el sistema operativo.

## Verificación realizada

Compilación Debug para Windows y Android completada con cero advertencias y cero errores. Se compararon los doce valores de los .resx con los textos y colores solicitados, incluyendo saltos de línea y el espacio del saludo inglés horizontal. No se ejecutaron pruebas visuales en dispositivo ni simulador. iOS y MacCatalyst no se compilaron: requieren el entorno Apple correspondiente.
