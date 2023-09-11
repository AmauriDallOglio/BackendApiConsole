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

        public async Task<HttpResponseMessage> Incluir(HttpClient httpClient, DefeitoResponse defeito)
        {
            string apiUrl = "https://localhost:7076/api/v1/Defeito/Inserir";
            // Converter objeto para JSON
            string jsonData = JsonConvert.SerializeObject(defeito);
            // Realizar uma solicitação POST à API
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;
        }

        public async Task<HttpResponseMessage> Alterar(HttpClient httpClient, DefeitoResponse defeito)
        {
            string apiUrl = "https://localhost:7076/api/v1/Defeito/Alterar";

            // Dados do produto iPad
            defeito.Descricao = "ALTERADO " + DateTime.Now.ToString();

            // Converter objeto para JSON
            string jsonData = JsonConvert.SerializeObject(defeito);
            // Realizar uma solicitação POST à API
            HttpResponseMessage response = await httpClient.PutAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;

        }

        public async Task<List<DefeitoResponse>> ListarTodos(HttpClient httpClient)
        {
            string apiUrl = "https://localhost:7076/api/v1/Defeito/ListarTodos?Descricao";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            List<DefeitoResponse> tenants = JsonConvert.DeserializeObject<List<DefeitoResponse>>(content);
            return tenants;
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
