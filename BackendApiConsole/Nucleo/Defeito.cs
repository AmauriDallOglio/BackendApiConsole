using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using static BackendApiConsole.Nucleo.EntidadeModelo;

namespace BackendApiConsole.Nucleo
{
    public class Defeito
    {
        public Guid Id_Tenant { get; set; }
        //public Guid? Id_Imagem { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public async Task<string> ValidaConexao(HttpClient httpClient, string apiUrl)
        {

            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return content;
        }


        public async Task<Resposta> Incluir(HttpClient httpClient, Defeito defeito)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"-- Início da requisição às {DateTime.Now}");

            string apiUrl = "https://localhost:7076/api/v1/Defeito/Inserir";
            // Converter objeto para JSON
            string jsonData = JsonConvert.SerializeObject(defeito);
            // Realizar uma solicitação POST à API
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync().Result;
            Resposta novo = JsonConvert.DeserializeObject<Resposta>(content);

            stopwatch.Stop();
            Console.WriteLine($"--- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");

            return novo;
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

        public async Task<HttpResponseMessage> Excluir(HttpClient httpClient, Guid id)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"-- Início da requisição às {DateTime.Now}");

            string apiUrl = "https://localhost:7076/api/v1/Defeito/Excluir";
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


        public async Task<List<ListarTodos>> ListarTodos(HttpClient httpClient, string pesquisa)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"-- Início da requisição às {DateTime.Now}");


            string apiUrl = $"https://localhost:7076/api/v1/Defeito/ListarTodos?Descricao={pesquisa}";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            List<ListarTodos> listagem = JsonConvert.DeserializeObject<List<ListarTodos>>(content);

            stopwatch.Stop();
            Console.WriteLine($"--- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");


            return listagem;
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
