using MoviFaca_Empresa.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviFaca_Empresa.Vista.Empresa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AsignarBus : ContentPage
    {
        public AsignarBus()
        {
            InitializeComponent();
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("asignado", "no");
            byte[] respuest = null;
            respuest = cliente.UploadValues("http://192.168.1.6/AppBD/mostrarBusesDis.php", "POST", parametros);
            String respuesta = Encoding.UTF8.GetString(respuest);
            char delimitador = '"';
            string[] valores = respuesta.Split(delimitador);

            int largo = valores.Length;
            if (largo >= 3)
            {
                Placa1Txt.Text = valores[3];

                if (largo >= 11)
                {
                    Placa2Txt.Text = valores[11];
                }
                if (largo >= 19)
                {
                    Placa3Txt.Text = valores[19];
                }
            }
           



            var param = new System.Collections.Specialized.NameValueCollection();
            param.Add("placa", "0");
            respuest = null;
            respuest = cliente.UploadValues("http://192.168.1.6/AppBD/mostrarConductoresDis.php", "POST", param);
            respuesta = Encoding.UTF8.GetString(respuest);
            string[] val = respuesta.Split(delimitador);

            int lar = val.Length;


            if (lar >= 3)
            {
                Cedula1Txt.Text = val[3];
                if (lar >= 11)
                {
                    Cedula2Txt.Text = val[11];
                }
                if (lar >= 19)
                {
                    Cedula3Txt.Text = val[19];
                }
            }
        }

        private void Placa1_Clicked(object sender, EventArgs e)
        {
            AsignarBuses.placa = Placa1Txt.Text;
    }
        private void Placa2_Clicked(object sender, EventArgs e)
        {
            AsignarBuses.placa = Placa2Txt.Text;
        }
        private void Placa3_Clicked(object sender, EventArgs e)
        {
            AsignarBuses.placa = Placa3Txt.Text;
        }
        private void Cedula1_Clicked(object sender, EventArgs e)
        {
            AsignarBuses.cedula = Cedula1Txt.Text;
        }
        private void Cedula2_Clicked(object sender, EventArgs e)
        {
            AsignarBuses.cedula = Cedula2Txt.Text;
        }
        private void Cedula3_Clicked(object sender, EventArgs e)
        {
            AsignarBuses.cedula = Cedula3Txt.Text;
        }
        private void AsignarBuss_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var parametro = new System.Collections.Specialized.NameValueCollection();
            parametro.Add("placa", AsignarBuses.placa);
            parametro.Add("cedula", AsignarBuses.cedula);
            parametro.Add("asignado", "si");
            byte[] respuest = null;

            respuest = cliente.UploadValues("http://192.168.1.6/AppBD/asignarBus.php", "POST", parametro);
            String respuesta = Encoding.UTF8.GetString(respuest);

            if (respuesta.Contains("Registro Exitoso"))
            {
                Application.Current.MainPage.DisplayAlert(
                 "Hola",
                 "El bus quedó asignado exitosamente.",
                 "Aceptar");
                return;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert(
                 "Error",
                 "El bus no fué asignado, por favor intentelo nuevamente.",
                 "Aceptar");
            }

        }



    }
}