using Newtonsoft.Json;
using System.Text;

namespace BackendApiConsole.Nucleo
{
    public class Tenant
    {
        public string Referencia { get; set; }
        public string Descricao { get; set; }


        public async Task<HttpResponseMessage> Incluir(HttpClient httpClient, string Referencia, string Descricao)
        {
            string apiUrl = "https://localhost:7076/api/v1/Tenant/Inserir";

            // Dados do produto iPad
            var produto_ipad = new Tenant()
            {
                Referencia = Referencia,
                Descricao = Descricao
            };
            // Converter objeto para JSON
            string jsonData = JsonConvert.SerializeObject(produto_ipad);
            // Realizar uma solicitação POST à API
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;

        }


        public async Task<HttpResponseMessage> Alterar(HttpClient httpClient, TenantResponse tenant)
        {
            string apiUrl = "https://localhost:7076/api/v1/Tenant/Alterar";

            // Dados do produto iPad
            tenant.Descricao = DateTime.Now.ToString();

            // Converter objeto para JSON
            string jsonData = JsonConvert.SerializeObject(tenant);
            // Realizar uma solicitação POST à API
            HttpResponseMessage response = await httpClient.PutAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;

        }

        public async Task<HttpResponseMessage> Excluir(HttpClient httpClient, Guid id)
        {
            // Monta o corpo da solicitação em formato JSON
            string apiUrl = "https://localhost:7076/api/v1/Tenant/Excluir";
            // Criar o objeto de solicitação
            TenantExcluir requestData = new TenantExcluir
            {
                Id = id
            };
            // Converte os dados de entrada em formato JSON
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
            // Cria a solicitação DELETE com o corpo JSON
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, apiUrl)
            {
                Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json")
            };
            // Envia a solicitação DELETE
            HttpResponseMessage response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                var tenantExcluirResponse = JsonConvert.DeserializeObject<TenantExcluir>(apiResponse);
                Console.WriteLine("Solicitação DELETE bem-sucedida!");
                // Lide com a resposta da API aqui
            }
            return response;
        }

        public async Task<HttpResponseMessage> ListarNumeros(HttpClient httpClient)
        {
            string apiUrl = "https://localhost:7076/api/v1/Tenant/ListaNumeros";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            return response;
        }

        public async Task<List<TenantResponse>> ListarTodos(HttpClient httpClient)
        {
            string apiUrl = "https://localhost:7076/api/v1/Tenant/ListarTodos?Descricao";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            List<TenantResponse> tenants = JsonConvert.DeserializeObject<List<TenantResponse>>(content);
            //foreach (var tenant in tenants)
            //{
            //    var retorno = tenant;
            //    //Excluir(httpClient, retorno.Id);
            //}
            return tenants;
        }



    }



    public class TenantResponse
    {
        public Guid Id { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Inativo { get; set; }
        public Guid? Id_Imagem { get; set; }
    }

    public class TenantExcluir
    {
        public Guid? Id { get; set; }
    }


}
