using Newtonsoft.Json;
using System.Text;

namespace BackendApiConsole.Nucleo
{
    public class Defeito
    {
        public Guid Id_Tenant { get; set; }
        //public Guid? Id_Imagem { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public async Task<HttpResponseMessage> Incluir(HttpClient httpClient, Defeito defeito)
        {
            string apiUrl = "https://localhost:7076/api/v1/Defeito/Inserir";
            // Converter objeto para JSON
            string jsonData = JsonConvert.SerializeObject(defeito);
            // Realizar uma solicitação POST à API
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;
        }

        public class DefeitoResponse
        {
            public Guid Id { get; set; }
            public Guid? Id_Tenant { get; set; }
            public Guid? Id_Imagem { get; set; }
            public string Referencia { get; set; } = string.Empty;
            public string Descricao { get; set; } = string.Empty;
            public bool Inativo { get; set; }
        }



    }
}
