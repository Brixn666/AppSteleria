using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppSteleria
{
    public class GenericRepository<T> where T: class
    {
        public async Task<List<T>> TraerDatos(string URL)
        {
            HttpClient cliente = new HttpClient
            {
                BaseAddress = new Uri("https://apisteleria.azurewebsites.net/")
            };
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Parametros.token.token);
            HttpResponseMessage response = await cliente.GetAsync($"api/{URL}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                List<T> datos = JsonConvert.DeserializeObject<List<T>>(content);
                return datos;
            }
            else
            {
                return null;
            }
        }
    }
}
