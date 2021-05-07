using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSteleria.Modelos
{
    public class Temperatures
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("users")]
        public Users Users { get; set; }
    }
    public class Users
    {
        public string nombreDeUsuario { get; set; }
        public string password { get; set; }    
    }
}
