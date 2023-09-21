using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackendApiConsole.Nucleo
{
    public class AtivoTipo
    {
       
        public Guid Id_Tenant { get; set; }
        public string Referencia { get; set; }  
        public string Descricao { get; set; }


        public async Task<string> ValidaConexao(HttpClient httpClient)
        {
            string apiUrl = "https://localhost:7076/api/v1/AtivoTipo/Conexao";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return content;
        }


        public async Task<Resposta> Incluir(HttpClient httpClient, AtivoTipo ativoTipo)
        {
            string apiUrl = "https://localhost:7076/api/v1/AtivoTipo/Inserir";
            // Converter objeto para JSON
            string jsonData = JsonConvert.SerializeObject(ativoTipo);
            // Realizar uma solicitação POST à API
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync().Result;
            Resposta novo = JsonConvert.DeserializeObject<Resposta>(content);
            return novo;
        }

        public async Task<HttpResponseMessage> Excluir(HttpClient httpClient, Guid id)
        {
            // Monta o corpo da solicitação em formato JSON
            string apiUrl = "https://localhost:7076/api/v1/AtivoTipo/Excluir";
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
            string apiUrl = "https://localhost:7076/api/v1/AtivoTipo/ListarTodos?Descricao=ativoTipo";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            List<ListarTodos> listagem = JsonConvert.DeserializeObject<List<ListarTodos>>(content);
            //foreach (var tenant in tenants)
            //{
            //    var retorno = tenant;
            //    //Excluir(httpClient, retorno.Id);
            //}
            return listagem;
          
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



    public class ListarTodos
    {
        public Guid Id { get; set; }
        public Guid Id_Tenant { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Inativo { get; set; }
    }

    public class Excluir
    {
        public Guid? Id { get; set; }
    }

}
