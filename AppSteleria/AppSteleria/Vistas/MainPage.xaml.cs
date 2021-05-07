using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using AppSteleria.Modelos;
using System.Net.Http;
using System.Net;
using AppSteleria.Vistas;

namespace AppSteleria
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void btnIngr_Clicked(object sender, EventArgs e)
        {
            Users log = new Users
            {
                nombreDeUsuario = txtUsua.Text,
                password = txtCont.Text
            };
            Uri RequestUri = new Uri("https://apisteleria.azurewebsites.net/api/Auth/Login");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);
                if (response.StatusCode==HttpStatusCode.OK)
            {
                await DisplayAlert("Bienvenido", "Datos Validados", "OK");
                var respuesta = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Parametros.token = JsonConvert.DeserializeObject<Token>(respuesta);

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Parametros.token.token);
                response = await client.GetAsync(new Uri("https://apisteleria.azurewebsites.net/api/Usuarios"));
                
                if (response.StatusCode==HttpStatusCode.OK)
                {
                    var respuesta2 = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var datos = JsonConvert.DeserializeObject<List<Users>>(respuesta2);
                    //await DisplayAlert("Datos Obtenidos",datos.Count.ToString(),"OK");
                }
                await Navigation.PushAsync(new Vistas.Menu());
            }
                else
            {
                await DisplayAlert("Error","Datos Invalidos","OK");
            }
        }
    }
}
