using AppSteleria.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSteleria.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaCatalogo : ContentPage
    {
        public VistaCatalogo()
        {
            InitializeComponent();
            Conte.IsVisible = false;
            Conte1.IsVisible = false;
            Conte2.IsVisible = false;
        }
        #region Botones
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            Conte.IsVisible = true;
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
        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            ElementosCatalogo Catalogo = new ElementosCatalogo
            {
                Id = txtID.Text,
                NombrePastel = txtNombrePastel.Text,
                Descripcion = txtDescripcion.Text,
                Idproducto = txtIDPrdo.Text
            };
            Uri RequesUri = new Uri("https://apisteleria.azurewebsites.net/api/ElementosCatalogoes");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(Catalogo);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Parametros.token.token);
            var response = await client.PostAsync(RequesUri, contentJson);
            await DisplayAlert("Catalogo", "Se actualizo correctamente la información", "OK");
            txtID.Text = "";
            txtNombrePastel.Text = "";
            txtDescripcion.Text = "";
            txtIDPrdo.Text = "";
            btnActualizar.IsVisible = true;
            Conte.IsVisible = false;
        }
        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            btnEditar.IsVisible = true;
            Conte1.IsVisible = false;
        }
        private void BtnCall_Clicked(object sender, EventArgs e)
        {
            List<Modelos.ElementosCatalogo> datos = new GenericRepository<Modelos.ElementosCatalogo>().TraerDatos("ElementosCatalogoes").Result;
            lstView.ItemsSource = datos;
        }
        private void btnDelete_Clicked(object sender, EventArgs e)
        {
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