using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AppSteleria.Modelos
{
    public partial class Cliente
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("domicilio")]
        public string Domicilio { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("pedidos")]
        public Pedido[] Pedidos { get; set; }

        public override string ToString()
        {
            return $"ID:{Id} \nNombre: {Nombre} \nDomicilio: {Domicilio} \nTelefono: {Telefono}\n";
        }
    }
}