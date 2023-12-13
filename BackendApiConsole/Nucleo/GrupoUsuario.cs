using Newtonsoft.Json;
using System.Text;
using static BackendApiConsole.Nucleo.EntidadeModelo;

namespace BackendApiConsole.Nucleo
{
    public class GrupoUsuario
    {
        public string Referencia { get; set; }
        public string Descricao { get; set; }


        public async Task<string> ValidaConexao(HttpClient httpClient, string apiUrl)
        {
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return content;
        }



        public async Task<ResultadoOperacao.Resposta> Incluir(HttpClient httpClient, GrupoUsuario entidade, string apiUrl)
        {
            string jsonData = JsonConvert.SerializeObject(entidade);
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            var aaaa = 1254;
            var content = response.Content.ReadAsStringAsync().Result;
            ResultadoOperacao.Resposta novo = JsonConvert.DeserializeObject<ResultadoOperacao.Resposta>(content);
            var idd = novo.Resultado.Id;
            return novo;
        }


        public async Task<RetornoGrupoUsuario> ListarTodos(HttpClient httpClient, string apiUrl)
        {


            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            RetornoGrupoUsuario listagem = JsonConvert.DeserializeObject<RetornoGrupoUsuario>(content);


            return listagem;
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




        //public class Modelo
        //{
        //    public string Id { get; set; }
        //}

        //public class ResultadoIncluir
        //{
        //    public Modelo Modelo { get; set; }
        //    public bool Sucesso { get; set; }
        //    public string Mensagem { get; set; }
        //}


 



        public class VirtualTenant
        {
            public string Referencia { get; set; }
            public string Descricao { get; set; }
            public bool Inativo { get; set; }
            public object Id_Imagem { get; set; }
            public string Id { get; set; }
        }

        public class Resultado
        {
            public string Id_Tenant { get; set; }
            public VirtualTenant VirtualTenant { get; set; }
            public string Referencia { get; set; }
            public string Descricao { get; set; }
            public int Tipo { get; set; }
            public bool Inativo { get; set; }
            public string Id { get; set; }
        }

        public class RetornoGrupoUsuario
        {
            public int ItemPorPagina { get; set; }
            public int TotalPagina { get; set; }
            public int TotalRegistros { get; set; }
            public int TotalRegistrosFiltrados { get; set; }
            public string NomeObjeto { get; set; }
            public List<Resultado> Resultado { get; set; }
        }

    }
}
