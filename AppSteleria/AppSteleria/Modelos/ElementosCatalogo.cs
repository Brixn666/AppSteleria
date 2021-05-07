using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AppSteleria.Modelos
{
    public partial class ElementosCatalogo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombrePastel")]
        public string NombrePastel { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }

        [JsonProperty("idproducto")]
        public string Idproducto { get; set; }

        [JsonProperty("idproductoNavigation")]
        public Producto IdproductoNavigation { get; set; }
        public override string ToString()
        {
            return $"ID:{Id} \nNombre: {NombrePastel} \nDescripcion: {Descripcion} \nID del producto: {Idproducto}\n";
        }
    }
}
