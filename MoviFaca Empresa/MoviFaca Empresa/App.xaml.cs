using MoviFaca_Empresa.Vista;
using MoviFaca_Empresa.Vista.Empresa;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviFaca_Empresa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            /*El NavigationPage es para que la App tenga una navegación entre páginas,
            por lo tanto un retroceso o sea se pueda devolver a la pagina anterior*/

            // var navigationPage = new NavigationPage(new InicioDeSesion());
            var navigationPage = new NavigationPage(new InicioDeSesion());
            navigationPage.BackgroundColor = Color.Gray;
            navigationPage.BarBackgroundColor = Color.White;
            navigationPage.BarTextColor = Color.Gray;
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
