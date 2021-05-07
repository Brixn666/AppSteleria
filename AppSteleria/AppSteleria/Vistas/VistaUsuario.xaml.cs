using AppSteleria.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSteleria.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaUsuario : ContentPage
    {
        public VistaUsuario()   
        {
            InitializeComponent();
            Conte.IsVisible = false;
            Conte1.IsVisible = false;
            Conte2.IsVisible = false;
        }
        #region Botones
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            Conte.IsVisible =true;
            btnActualizar.IsVisible = false;
        }
        private void btnBorrar_Clicked(object sender, EventArgs e)
        {
            Conte2.IsVisible = true;
            btnBorrar.IsVisible = false;
        }
        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            Conte1.IsVisible = true;
            btnEditar.IsVisible = false;
        }
        #endregion
        #region CRUD
        private void BtnCall_Clicked(object sender, EventArgs e)
        {
            List<Modelos.Usuario> datos = new GenericRepository<Modelos.Usuario>().TraerDatos("Usuarios").Result;
            lstView.ItemsSource = datos;
        }
        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario {
                Id = txtID.Text,
                NombreUsuario=txtNombUsuar.Text,
                Password=txtContra.Text,
                Area=txtArea.Text,
                Idtusuario=txtIDTipoUsua.Text
            };
            Uri RequesUri = new Uri("https://apisteleria.azurewebsites.net/api/Usuarios");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(usuario);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Parametros.token.token);
            var response = await client.PostAsync(RequesUri,contentJson);
            await DisplayAlert("Usuarios","Se actualizo correctamente la información","OK");
            txtID.Text = "";
            txtNombUsuar.Text = "";
            txtContra.Text = "";
            txtArea.Text = "";
            txtIDTipoUsua.Text = "";
            btnActualizar.IsVisible = true;
            Conte.IsVisible = false;
        }
        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            Usuario usuario2 = new Usuario
            {
                Id = txtID2.Text,
                NombreUsuario = txtNombUsuar2.Text,
                Password = txtContra2.Text,
                Area = txtArea2.Text,
                Idtusuario = txtIDTipoUsua2.Text
            };
            var json = JsonConvert.SerializeObject(usuario2);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri RequesUri = new Uri("https://apisteleria.azurewebsites.net/api/Usuarios");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Parametros.token.token);
            var result = await client.PutAsync(string.Concat(RequesUri, txtID2.Text), content);
            btnEditar.IsVisible = true;
            Conte1.IsVisible = false;
        }
        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            Usuario usuario3 = new Usuario
            {
                Id = txtID3.Text,
            };
            var json = JsonConvert.SerializeObject(usuario3);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri RequesUri = new Uri("https://apisteleria.azurewebsites.net/api/Usuarios");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Parametros.token.token);
            var result = await client.DeleteAsync(string.Concat(RequesUri, txtID3.Text));
            btnBorrar.IsVisible = true;
            Conte2.IsVisible = false;
        }
        #endregion
        #region Botones para ocultar
        private void Ocultar1_Clicked(object sender, EventArgs e)
        {
            btnActualizar.IsVisible = true;
            Conte.IsVisible = false;
        }
        private void Ocultar2_Clicked(object sender, EventArgs e)
        {
            btnBorrar.IsVisible = true;
            Conte2.IsVisible = false;
        }
        private void Ocultar3_Clicked(object sender, EventArgs e)
        {
            btnEditar.IsVisible = true;
            Conte1.IsVisible = false;
        }
        #endregion
    }
}