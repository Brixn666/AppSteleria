using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSteleria.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnCatego_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VistaCategoria());
        }

        private void btnProduc_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VistaProductos());
        }

        private void btnClient_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VistaClientes());
        }

        private void btnPedid_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VistaPedidos());
        }

        private void btnCatalo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VistaCatalogo());
        }
        private void btnUsuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VistaUsuario());
        }
    }
}