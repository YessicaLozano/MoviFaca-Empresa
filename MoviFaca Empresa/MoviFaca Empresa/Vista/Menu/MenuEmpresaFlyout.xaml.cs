using MoviFaca_Empresa.Vista.Empresa;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviFaca_Empresa.Vista.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuEmpresaFlyout : ContentPage
    {
        public ListView ListView;

        public MenuEmpresaFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuEmpresaFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MenuEmpresaFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuEmpresaFlyoutMenuItem> MenuItems { get; set; }

            public MenuEmpresaFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MenuEmpresaFlyoutMenuItem>(new[]
                {
                    new MenuEmpresaFlyoutMenuItem { Id = 0, Title = "Datos de la empresa", Icono="perfil.png", TargetType=typeof(DatosEmpresa) },
                    new MenuEmpresaFlyoutMenuItem  { Id = 1, Title = "Crear bus", Icono = "carro.png", TargetType=typeof(CrearBus) },
                    new MenuEmpresaFlyoutMenuItem { Id = 2, Title = "Asignar bus", Icono = "asignar.png", TargetType=typeof(AsignarBus) },
                    new MenuEmpresaFlyoutMenuItem  { Id = 3, Title = "Ayuda", Icono = "ayuda.png", TargetType=typeof(Ayuda) },
                    new MenuEmpresaFlyoutMenuItem { Id = 4, Title = "Cerrar sesión", Icono="cerrar.png", TargetType=typeof(InicioDeSesion) },

                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}