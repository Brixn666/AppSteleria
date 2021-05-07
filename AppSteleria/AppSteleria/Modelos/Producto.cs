using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace AppSteleria.Modelos
{
    public partial class Producto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombreProducto")]
        public string NombreProducto { get; set; }

        [JsonProperty("idcategoria")]
        public string Idcategoria { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("idusuario")]
        public string Idusuario { get; set; }

        [JsonProperty("precioVenta")]
        public decimal PrecioVenta { get; set; }

        [JsonProperty("idcategoriaNavigation")]
        public Categorium IdcategoriaNavigation { get; set; }

        [JsonProperty("idusuarioNavigation")]
        public Usuario IdusuarioNavigation { get; set; }

        [JsonProperty("elementosCatalogos")]
        public ElementosCatalogo[] ElementosCatalogos { get; set; }
        public override string ToString()
        {
            return $"ID:{Id} \nNombre: {NombreProducto} \nDescripcion: {Descripcion} \nPrecio: {PrecioVenta} \n";
        }
    }
}

