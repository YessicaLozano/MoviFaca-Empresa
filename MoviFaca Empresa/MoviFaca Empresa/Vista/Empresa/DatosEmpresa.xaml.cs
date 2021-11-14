using MoviFaca_Empresa.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviFaca_Empresa.Vista.Empresa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosEmpresa : ContentPage
    {
        public DatosEmpresa()
        {
            InitializeComponent();
            NitTxt.Text = EmpresaCache.nit;
            NombreTxt.Text = EmpresaCache.nombre;
            DireccionTxt.Text = EmpresaCache.direccion;
            TelefonoTxt.Text = EmpresaCache.telefono;
            CorreoTxt.Text = EmpresaCache.correo;
            ContraseñaTxt.Text = EmpresaCache.contraseña;
        }
    }
}