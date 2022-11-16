using DynamicData.Binding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sema6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.37/clientes/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Sema6.Datos> _post;
        public MainPage()
        { 
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Sema6.Datos> posts = JsonConvert.DeserializeObject<List<Sema6.Datos>>(content);
            _post = new ObservableCollection<Sema6.Datos>(posts);
            MyLisView.ItemsSource = _post;
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VentanaIngreso());
        }

        private void btnGet_Clicked_1(object sender, EventArgs e)
        {

        }

 
        private async void btnActualización_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Actualizacion());
        }
    }
}
