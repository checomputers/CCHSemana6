using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sema6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actualizacion : ContentPage
    {
        public Actualizacion()
        {
            InitializeComponent();
        }
         
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            try
            {
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                client.UploadValues("http://192.168.100.37/clientes/post.php", "POST", parametros);
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }


        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}