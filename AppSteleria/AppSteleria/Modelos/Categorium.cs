using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AppSteleria.Modelos
{
    public partial class Categorium
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("productos")]
        public Producto[] Productos { get; set; }
        public override string ToString()
        {
            return $"ID:{Id} \nNombre: {Nombre} \nDescripcion: {Descripcion}\n";
        }
    }
}