using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using static BackendApiConsole.Nucleo.EntidadeModelo;
using static BackendApiConsole.Nucleo.ResultadoOperacaoListagem;

namespace BackendApiConsole.Nucleo
{
    public class AtivoTipo
    {
        public Guid Id_Tenant { get; set; }
        public string Referencia { get; set; }  
        public string Descricao { get; set; }


        public async Task<string> ValidaConexao(HttpClient httpClient, string apiUrl)
        {
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return content;
        }


        public async Task<Resposta> Incluir(HttpClient httpClient, AtivoTipo ativoTipo)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"-- Início da requisição às {DateTime.Now}");

            string apiUrl = "https://localhost:7076/api/v1/AtivoTipo/Inserir";
            string jsonData = JsonConvert.SerializeObject(ativoTipo);
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync().Result;
            Resposta novo = JsonConvert.DeserializeObject<Resposta>(content);
            if (novo.Mensagem == null) 
                novo.Mensagem = response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString(); 
      

            stopwatch.Stop();
            Console.WriteLine($"--- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");


            return novo;
        }

        public async Task<HttpResponseMessage> Excluir(HttpClient httpClient, Guid id)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"-- Início da requisição às {DateTime.Now}");

            string apiUrl = "https://localhost:7076/api/v1/AtivoTipo/Excluir";
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

            stopwatch.Stop();
            Console.WriteLine($"--- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");


            return response;
        }


        public async Task<ApiResponse<AtivoTipoModal>> ListarTodos(HttpClient httpClient, string pesquisa)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"Início da requisição às {DateTime.Now}");


            string apiUrl = $"https://localhost:7076/api/v1/AtivoTipo/ListarTodos?Descricao={pesquisa}";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var listagem = JsonConvert.DeserializeObject<ApiResponse<AtivoTipoModal>>(content);

            stopwatch.Stop();
            Console.WriteLine($"Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");


            return listagem;
        }


        public class AtivoTipoModal
        {
            public string id_Tenant { get; set; }
            public Tenant tenant { get; set; }
            public string referencia { get; set; }
            public string descricao { get; set; }
            public bool inativo { get; set; }
            public string id { get; set; }
        }



    }
}
