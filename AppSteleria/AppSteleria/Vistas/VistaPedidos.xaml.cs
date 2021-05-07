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
    public partial class VistaPedidos : ContentPage
    {
        public VistaPedidos()
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
        private void BtnCall_Clicked(object sender, EventArgs e)
        {
            List<Modelos.Pedido> datos = new GenericRepository<Modelos.Pedido>().TraerDatos("Pedidoes").Result;
            lstView.ItemsSource = datos;
        }
        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            Pedido Pedidos = new Pedido
            {
                Id = txtID.Text,
                Idcliente = txtIdcli.Text,
                FechaEntrega = Convert.ToDateTime(txtFecha.Text),
                HoraEntrega = Convert.ToDateTime(txtHora.Text),
                CantidadKilos = txtKilo.Text,
                Relleno = txtRelleno.Text,
                Forma = txtForma.Text,
                Color = txtColor.Text,
                Dibujo = txtDibujo.Text,
                Texto = txtTexto.Text,
                Importe = decimal.Parse(txtImporte.Text),
                Total = decimal.Parse(txtTotal.Text)
            };
            Uri RequesUri = new Uri("https://apisteleria.azurewebsites.net/api/Pedidoes");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(Pedidos);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Parametros.token.token);
            var response = await client.PostAsync(RequesUri, contentJson);
            await DisplayAlert("Pedidos", "Se actualizo correctamente la información", "OK");
            txtID.Text = "";
            txtIdcli.Text = "";
            txtFecha.Text = "";
            txtHora.Text = "";
            txtKilo.Text = "";
            txtRelleno.Text = "";
            txtForma.Text = "";
            txtColor.Text = "";
            txtDibujo.Text = "";
            txtTexto.Text = "";
            txtImporte.Text = "";
            txtTotal.Text = "";
            btnActualizar.IsVisible = true;
            Conte.IsVisible = false;
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            btnEditar.IsVisible = true;
            Conte1.IsVisible = false;
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