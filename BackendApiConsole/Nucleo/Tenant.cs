using Newtonsoft.Json;
using System.Text;
using static BackendApiConsole.Nucleo.EntidadeModelo;

namespace BackendApiConsole.Nucleo
{
    public class Tenant
    {
        public string Referencia { get; set; }
        public string Descricao { get; set; }



        public async Task<ResultadoOperacao.Resposta> Incluir(HttpClient httpClient, Tenant entidade, string apiUrl)
        {
            string jsonData = JsonConvert.SerializeObject(entidade);
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync().Result;
            ResultadoOperacao.Resposta novo = JsonConvert.DeserializeObject<ResultadoOperacao.Resposta>(content);
            return novo;
        }

 


        public async Task<TenantResponse> Alterar(HttpClient httpClient, TenantResponse tenant)
        {
            string apiUrl = "https://localhost:7076/api/v1/Tenant/Alterar";

            // Converter objeto para JSON
            string jsonData = JsonConvert.SerializeObject(tenant);
            // Realizar uma solicitação POST à API
            HttpResponseMessage response = await httpClient.PutAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync().Result;
            TenantResponse alterado = JsonConvert.DeserializeObject<TenantResponse>(content);
            return alterado;
            ;

        }


        public async Task<HttpResponseMessage> Excluir(HttpClient httpClient, Guid id, string apiUrl)
        {

            Excluir requestData = new Excluir
            {
                Id = id
            };
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, apiUrl)
            {
                Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = await httpClient.SendAsync(request);


            return response;
        }



        public async Task<HttpResponseMessage> ListarNumeros(HttpClient httpClient)
        {
            string apiUrl = "https://localhost:7076/api/v1/Tenant/ListaNumeros";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            IEnumerable<int> lista = JsonConvert.DeserializeObject<IEnumerable<int>>(content);
            return response;
        }

        public async Task<IEnumerable<int>> ListarNumeros2(HttpClient httpClient)
        {
            string apiUrl = "https://localhost:7076/api/v1/Tenant/ListaNumeros2";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            IEnumerable<int> lista = JsonConvert.DeserializeObject<IEnumerable<int>>(content);
            return lista;
        }

        public async Task<string> ValidaConexao(HttpClient httpClient, string apiUrl)
        {

            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
 
            return content;
        }



        //public async Task<Tenantlistar> ListarTodos(HttpClient httpClient, string apiUrl)
        //{
        //    var stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    Console.WriteLine($"-- Início da requisição às {DateTime.Now}");



        //    HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
        //    var content = response.Content.ReadAsStringAsync().Result;
        //    Tenantlistar listagem = JsonConvert.DeserializeObject<Tenantlistar>(content);

        //    stopwatch.Stop();
        //    Console.WriteLine($"--- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");


        //    return listagem;
        //}



        public async Task<RetornoTenant> ListarTodos(HttpClient httpClient, string apiUrl)
        {
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            RetornoTenant listagem = JsonConvert.DeserializeObject<RetornoTenant>(content);
            return listagem;
        }






    }


    public class Item
    {
        public string Referencia { get; set; }
        public string Descricao { get; set; }
        public bool Inativo { get; set; }
        public object Id_Imagem { get; set; }
        public string Id { get; set; }
    }

    public class RetornoTenant
    {
        public int ItemPorPagina { get; set; }
        public int TotalPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalRegistrosFiltrados { get; set; }
        public string NomeObjeto { get; set; }
        public List<Item> Items { get; set; }
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
