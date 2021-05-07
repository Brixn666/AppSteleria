using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AppSteleria.Modelos
{
    public partial class Usuario
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombreUsuario")]
        public string NombreUsuario { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("idtusuario")]
        public string Idtusuario { get; set; }

        [JsonProperty("idtusuarioNavigation")]
        public TipoUsuario IdtusuarioNavigation { get; set; }

         [JsonProperty("productos")]
        public Producto[] Productos { get; set; }
        public override string ToString()
        {
            return $"ID:{Id} \nNombre: {NombreUsuario} \nArea: {Area}\n";
        }
    }
}