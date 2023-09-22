using Newtonsoft.Json;
using System.Text;
using static BackendApiConsole.Nucleo.EntidadeModelo;

namespace BackendApiConsole.Nucleo
{
    public class AtivoLocal
    {

        
        public Guid Id_Tenant { get; set; } // Tipo: uniqueidentifier
        public string Referencia { get; set; } = string.Empty;  // Tipo: varchar(50)
        public string Area { get; set; } = string.Empty; // Tipo: varchar(50)
        public string Setor { get; set; } = string.Empty; // Tipo: varchar(50)
        public string Descricao { get; set; } = string.Empty; // Tipo: varchar(300)
    


        public async Task<string> ValidaConexao(HttpClient httpClient)
        {
            string apiUrl = "https://localhost:7076/api/v1/AtivoLocal/Conexao";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return content;
        }


        public async Task<Resposta> Incluir(HttpClient httpClient, AtivoLocal entidade)
        {
            string apiUrl = "https://localhost:7076/api/v1/AtivoLocal/Inserir";
            // Converter objeto para JSON
            string jsonData = JsonConvert.SerializeObject(entidade);
            // Realizar uma solicitação POST à API
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync().Result;
            Resposta novo = JsonConvert.DeserializeObject<Resposta>(content);
            return novo;
        }

        public async Task<HttpResponseMessage> Excluir(HttpClient httpClient, Guid id)
        {
            // Monta o corpo da solicitação em formato JSON
            string apiUrl = "https://localhost:7076/api/v1/AtivoLocal/Excluir";
            // Criar o objeto de solicitação
            Excluir requestData = new Excluir
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
            return response;
        }


        public async Task<List<ListarTodos>> ListarTodos(HttpClient httpClient, string pesquisa)
        {
            string apiUrl = $"https://localhost:7076/api/v1/AtivoLocal/ListarTodos?Descricao={pesquisa}";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            List<ListarTodos> listagem = JsonConvert.DeserializeObject<List<ListarTodos>>(content);
            return listagem;
        }

       
    }

    public class Resposta
    {
        public Modelo Modelo { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

    }

    public class Modelo
    {
        public string Id { get; set; }
    }

   
}
