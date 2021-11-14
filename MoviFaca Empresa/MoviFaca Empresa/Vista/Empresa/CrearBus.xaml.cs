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
    public partial class CrearBus : ContentPage
    {
        public CrearBus()
        {
            InitializeComponent();

        }
        private void RegistroBus_Clicked(object sender, EventArgs e)
        {
            if (PlacaTxt.Text != null)
            {
                if (TecnoTxt.Text != null)
                {
                    if (TarjetaProTxt.Text != null)
                    {
                        if (SoatTxt.Text != null)
                        {
                                            //creacion de cliente web 
                                            WebClient cliente = new WebClient();

                                            //creacion de variable para enviar los datos 
                                            var parametros = new System.Collections.Specialized.NameValueCollection();

                                            parametros.Add("placa", PlacaTxt.Text);
                                            parametros.Add("tecnomecanica", TecnoTxt.Text);
                                            parametros.Add("tarjeta_propiedad", TarjetaProTxt.Text);
                                            parametros.Add("soat", SoatTxt.Text);
                                            parametros.Add("asignado", "no");


                            // creacion variable para obtener respuesta del Php
                                            byte[] respuest = null;
                                            respuest = cliente.UploadValues("http://192.168.1.6/AppBD/insertarDatosBus.php", "POST", parametros);
                                            // se pasa la variable a string para que pueda ser leida 
                                            String respuesta = Encoding.UTF8.GetString(respuest);

                            if (respuesta.Contains("Registro Exitoso"))
                                            {
                                                Application.Current.MainPage.DisplayAlert(
                                                 "Hola",
                                                 "Registro exitoso, por favor asigne el bus a un conductor.",
                                                 "Aceptar");
                                                    return;

                                            }
                                            else
                                            {
                                                Application.Current.MainPage.DisplayAlert(
                                                 "Error",
                                                 "Ya tiene un bus creado con esa placa, por favor asigne el bus a un conductor.",
                                                 "Aceptar");
                                                Navigation.PushAsync(new AsignarBus());
                                            }
                                        }
                                        else
                                        {
                                            Application.Current.MainPage.DisplayAlert(
                                                 "Error",
                                                 "Por favor ingrese la fecha de vencimiento del SOAT del bus. ",
                                                 "Aceptar");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        Application.Current.MainPage.DisplayAlert(
                                           "Error",
                                           "Por favor ingrese el No. de la Licencia de transito - Tarjeta de propiedad.",
                                           "Aceptar");
                                        return;
                                    }
                                }
                                else
                                {
                                    Application.Current.MainPage.DisplayAlert(
                                      "Error",
                                      "Por favor ingrese la fecha de vencimiento de la tecnomecanica del bus. ",
                                      "Aceptar");
                                    return;
                                }

                            }
                            else
                            {
                                Application.Current.MainPage.DisplayAlert(
                                    "Error",
                                    "Por favor ingrese la placa del bus.",
                                    "Aceptar");
                                return;
                            }

        }
    }

}