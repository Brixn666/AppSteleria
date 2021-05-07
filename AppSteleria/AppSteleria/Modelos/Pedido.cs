using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AppSteleria.Modelos
{
    public partial class Pedido
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("idcliente")]
        public string Idcliente { get; set; }

        [JsonProperty("fechaEntrega")]
        public DateTime FechaEntrega { get; set; }

        [JsonProperty("horaEntrega")]
        public DateTime HoraEntrega { get; set; }

        [JsonProperty("cantidadKilos")]
        public string CantidadKilos { get; set; }

        [JsonProperty("tipoPastel")]
        public string TipoPastel { get; set; }

        [JsonProperty("relleno")]
        public string Relleno { get; set; }

        [JsonProperty("forma")]
        public string Forma { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("dibujo")]
        public string Dibujo { get; set; }

        [JsonProperty("texto")]
        public string Texto { get; set; }

        [JsonProperty("importe")]
        public decimal Importe { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("idclienteNavigation")]
        public Cliente IdclienteNavigation { get; set; }

        public override string ToString()
        {
            return $"ID:{Id} \nID del Cliente: {Idcliente} \nFecha de entrega: {FechaEntrega} \nHora de entrega: {HoraEntrega} \nKilos: {CantidadKilos} \nTipo: {TipoPastel} \nRelleno: {Relleno} \nForma: {Forma} \nColor: {Color} \nDibujo: {Dibujo} \nTexto: {Texto} \nImporte: {Importe} \nTotal: {Total}\n";
        }
    }
}
