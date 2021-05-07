using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AppSteleria.Modelos
{
    public partial class TipoUsuario
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("usuarios")]
        public Usuario[] Usuarios { get; set; }
    }
}
