using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using static BackendApiConsole.Nucleo.EntidadeModelo;
using static BackendApiConsole.Nucleo.ResultadoOperacaoListagem;

namespace BackendApiConsole.Nucleo
{
    public class AtivoLocal
    {
        public Guid Id_Tenant { get; set; } // Tipo: uniqueidentifier
        public string Referencia { get; set; } = string.Empty;  // Tipo: varchar(50)
        public string Area { get; set; } = string.Empty; // Tipo: varchar(50)
        public string Setor { get; set; } = string.Empty; // Tipo: varchar(50)
        public string Descricao { get; set; } = string.Empty; // Tipo: varchar(300)
    


        public async Task<string> ValidaConexao(HttpClient httpClient, string apiUrl)
        {
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return content;
        }


        public async Task<Resposta> Incluir(HttpClient httpClient, AtivoLocal entidade)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"-- Início da requisição às {DateTime.Now}");

            string apiUrl = "https://localhost:7076/api/v1/AtivoLocal/Inserir";
            string jsonData = JsonConvert.SerializeObject(entidade);
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync().Result;
            Resposta novo = JsonConvert.DeserializeObject<Resposta>(content);

            stopwatch.Stop();
            Console.WriteLine($"--- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");



            return novo;
        }

        public async Task<HttpResponseMessage> Excluir(HttpClient httpClient, Guid id)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"-- Início da requisição às {DateTime.Now}");

            string apiUrl = "https://localhost:7076/api/v1/AtivoLocal/Excluir";
            Excluir requestData = new Excluir
            {
                Id = id
            };
            string jsonBody = JsonConvert.SerializeObject(requestData);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, apiUrl)
            {
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = await httpClient.SendAsync(request);

            stopwatch.Stop();
            Console.WriteLine($"--- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");


            return response;
        }


        public async Task<ApiResponse<AtivoLocalModal>> ListarTodos(HttpClient httpClient, string pesquisa)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"-- Início da requisição às {DateTime.Now}");


            string apiUrl = $"https://localhost:7076/api/v1/AtivoLocal/ListarTodos?Descricao={pesquisa}";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            ApiResponse<AtivoLocalModal> listagem = JsonConvert.DeserializeObject<ApiResponse<AtivoLocalModal>>(content);


            stopwatch.Stop();
            Console.WriteLine($"--- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");



            return listagem;
        }

        public class AtivoLocalModal
        {
            public string id { get; set; }
            public string id_Tenant { get; set; }
            public Tenant tenant { get; set; }
            public string referencia { get; set; }
            public string area { get; set; }
            public string setor { get; set; }
            public string descricao { get; set; }
            public bool inativo { get; set; }
        }


    }
}
