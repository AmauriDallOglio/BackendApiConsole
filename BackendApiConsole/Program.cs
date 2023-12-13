using BackendApiConsole.Nucleo;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

//Guid tenantId = Guid.Parse("A31CF8A0-7B4D-EE11-A89E-F0D41578B814"); //c
//Guid tenantId = Guid.Parse("62643056-F34C-EE11-9829-5CCD5B8BDCFF"); //o
Guid tenantId = Guid.Parse("9D3E64E9-F38E-EE11-B2BF-802BF9FF5176"); //mms

var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJTZWNyZXRfQ29kaWdvIjoiI1RFTkFOVDpPS0VBOlNZU1RFTTohTU1TMjAyMyFfIzQzNDQzRkRGREYzNERGMzQzNDNmZGYzNDRTREZTREZTREZTREZTREY0NTQ1MzU0MzQ1U0RGR0RGR0RGR0RGR2RmZmdmZEdERkdER1IiLCJVc3VhcmlvX05vbWUiOiJBbWF1cmkiLCJVc3VhcmlvX0lkIjoiMTc3Y2ExMDYtNGM5MC1lZTExLWIyYmYtODAyYmY5ZmY1MTc2IiwiVXN1YXJpb19FbWFpbCI6IkVtYWlsIGFtYXVyaTFAdGVycmEuY29tLmJyIiwiVGVuYW50X0lkIjoiMThjMGU4YjEtMzhkNi00ZTRkLTQzYWQtMDhkYmYxYTcxNmY2IiwiRGF0YV9FeHBpcmFjYW8iOiIxMi8xMi8yMDIzIDE5OjUxOjI1IiwibmJmIjoxNzAyNDA4ODg1LCJleHAiOjE3MDI0MTA2ODUsImlhdCI6MTcwMjQwODg4NSwiaXNzIjoieHh4IGFwaSIsImF1ZCI6InZ2diBhcGkifQ.jNGPu_-Av_cc3961qxljx6bzKATQKS4mkG_b1TttHTo";

string urlservidor = "https://localhost:7199/api/v1/"; //mms
string tipoUrl = "mms";


using (HttpClient httpClient = new HttpClient())
{
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    httpClient.DefaultRequestVersion = new Version("1.0");
    try
    {

        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Defeito validando conexão");
        Console.WriteLine("-----------------------------------------------------");

        Defeito defeito = new Defeito();
 
        string apiUrl = urlservidor + "Defeito/Conexao";
        var resultado = defeito.ValidaConexao(httpClient, apiUrl);
        switch (resultado.Result)
        {
            case "Ok":
                Console.WriteLine("Defeito conexao: " + resultado.Result);
                break;
            default:
                Console.WriteLine("Defeito conexao: " + "Sem retorno " + resultado.Result);
                break;
        }

        Tenant tenant = new Tenant();
        apiUrl = urlservidor + "Tenant/Conexao";
        resultado = tenant.ValidaConexao(httpClient, apiUrl);
        switch (resultado.Result)
        {
            case "Ok":
                Console.WriteLine("Tenant conexao: " + resultado.Result);
                break;
            default:
                Console.WriteLine("Tenant conexao: " + "Sem retorno " + resultado.Result);
                break;
        }

        AtivoTipo ativoTipo = new AtivoTipo();
        apiUrl = urlservidor + "AtivoTipo/Conexao";
        resultado = ativoTipo.ValidaConexao(httpClient, apiUrl);
        switch (resultado.Result)
        {
            case "Ok":
                Console.WriteLine("AtivoTipo conexao: " + resultado.Result);
                break;
            default:
                Console.WriteLine("AtivoTipo conexao: " + "Sem retorno " + resultado.Result);
                break;
        }

        AtivoLocal ativoLocal = new AtivoLocal();
        apiUrl = urlservidor + "AtivoLocal/Conexao";
        resultado = ativoLocal.ValidaConexao(httpClient, apiUrl);
        switch (resultado.Result)
        {
            case "Ok":
                Console.WriteLine("AtivoLocal conexao: " + resultado.Result);
                break;
            default:
                Console.WriteLine("AtivoLocal conexao: " + "Sem retorno " + resultado.Result);
                break;
        }

        GrupoUsuario grupoUsuario = new GrupoUsuario();
        apiUrl = urlservidor + "GrupoUsuario/Conexao";
        resultado = grupoUsuario.ValidaConexao(httpClient, apiUrl);
        switch (resultado.Result)
        {
            case "Ok":
                Console.WriteLine("GrupoUsuario conexao: " + resultado.Result);
                break;
            default:
                Console.WriteLine("GrupoUsuario conexao: " + "Sem retorno " + resultado.Result);
                break;
        }


        Task<HttpResponseMessage> response;
        int contador = 0;



         
        /*

        #region IncluirDefeito
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Tenant Inserir");
        Console.WriteLine("-----------------------------------------------------");
        for (int i = 0; i < 10; i++)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"- Início da requisição às {DateTime.Now}");

            tenant = new Tenant();
            tenant.Referencia = "Tenant " + i + " - " + DateTime.Now.ToString();
            tenant.Descricao = "Tenant " + i + " - " + DateTime.Now.ToString();
            apiUrl = urlservidor + "Tenant/Inserir";

            Task<ResultadoOperacao.Resposta> resposta = tenant.Incluir(httpClient, tenant, apiUrl);
            Console.WriteLine($"-- GrupoUsuario Inserindo: {i} / " + resposta.Result.Modelo.Id);

            stopwatch.Stop();
            Console.WriteLine($"--- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");

        }
        #endregion




        #region TenantListar
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Tenant Listar ");
        Console.WriteLine("-----------------------------------------------------");

        apiUrl = "";
        string pesquisa = "Tenant ";
        switch (tipoUrl)
        {
            case "mms":
                apiUrl = $"https://localhost:7199/api/v1/Tenant/ListarTodos?Descricao={pesquisa}";
                break;

            default:
                break;
        }

        var listaTenant = await tenant.ListarTodos(httpClient, apiUrl);
        Console.WriteLine("Tenant total de  : " + listaTenant.Items.Count());

        #endregion

        #region DefeitoExcluir
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Tenant Excluindo ");
        Console.WriteLine("-----------------------------------------------------");
        contador = 0;
        foreach (var item in listaTenant.Items)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"- Início da requisição às {DateTime.Now}");

            Guid idTenant = Guid.Parse(item.Id);
            apiUrl = urlservidor + "Tenant/Excluir";
            var responseExcluir = await tenant.Excluir(httpClient, idTenant, apiUrl);
            if (responseExcluir.IsSuccessStatusCode)
            {
                string apiResponse = await responseExcluir.Content.ReadAsStringAsync();
                ResultadoOperacao.Resposta resposta = JsonConvert.DeserializeObject<ResultadoOperacao.Resposta>(apiResponse);
                contador++;
                Console.WriteLine($"-- Tenant Inserindo: {contador} / " + resposta.Modelo.Id); ;
            }

            stopwatch.Stop();
            Console.WriteLine($"--- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");
        }
        #endregion

        */



        #region IncluirGrupoUsuario
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("GrupoUsuario Inserir");
        Console.WriteLine("-----------------------------------------------------");
        for (int i = 0; i < 6000; i++)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"{i} - Início da requisição às {DateTime.Now}");

            grupoUsuario = new GrupoUsuario();
            grupoUsuario.Referencia = "GrupoUsuario " + i + " - " + DateTime.Now.ToString();
            grupoUsuario.Descricao = "GrupoUsuario " + i + " - " + DateTime.Now.ToString();
            apiUrl = urlservidor + "GrupoUsuario/Inserir";

            Task<ResultadoOperacao.Resposta> resposta = grupoUsuario.Incluir(httpClient, grupoUsuario, apiUrl);
            Console.WriteLine($"{i} -- GrupoUsuario Inserindo: {i} / " + resposta.Result.Resultado.Id  );

            stopwatch.Stop();
            Console.WriteLine($"{i} --- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");

        }
        #endregion


        #region GrupoUsuarioListar
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("GrupoUsuario Listar ");
        Console.WriteLine("-----------------------------------------------------");

        apiUrl = "";
        var pesquisa = "GrupoUsuario ";
        switch (tipoUrl)
        {
            case "mms":
                apiUrl = $"https://localhost:7199/api/v1/grupoUsuario/ListarTodos?Nome={pesquisa}";
                break;
        }
        var listaGrupoUsuario = await grupoUsuario.ListarTodos(httpClient, apiUrl);
        Console.WriteLine("GrupoUsuario total de  : " + listaGrupoUsuario.Resultado.Count());
        #endregion

        //#region DefeitoExcluir
        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("GrupoUsuario Excluindo ");
        //Console.WriteLine("-----------------------------------------------------");
        //contador = 0;
        //foreach (var item in listaGrupoUsuario.Resultado)
        //{

        //    var stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    Console.WriteLine($"{contador} - Início da requisição às {DateTime.Now}");

        //    Guid idGrupoUsuario = Guid.Parse(item.Id);
        //    apiUrl = urlservidor + "GrupoUsuario/Excluir/" + idGrupoUsuario;
        //    var responseExcluir = await grupoUsuario.Excluir(httpClient, idGrupoUsuario, apiUrl);
        //    if (responseExcluir.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await responseExcluir.Content.ReadAsStringAsync();
        //        ResultadoOperacao.Resposta resposta = JsonConvert.DeserializeObject<ResultadoOperacao.Resposta>(apiResponse);
        //        contador++;
        //        Console.WriteLine($"{contador} -- GrupoUsuario Excluindo: {contador} / " + resposta.Resultado.Id); ;
        //    }

        //    stopwatch.Stop();
        //    Console.WriteLine($"{contador} --- Fim da requisição às {DateTime.Now}. Tempo total: {stopwatch.ElapsedMilliseconds}ms");
        //}
        //#endregion









        //#region IncluirDefeito
        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("Defeito Inserir");
        //Console.WriteLine("-----------------------------------------------------");
        //for (int i = 0; i < 1000; i++)
        //{
        //    defeito = new Defeito();
        //    defeito.Referencia = "Defeito " + i + " - " + DateTime.Now.ToString();
        //    defeito.Descricao = "Defeito " + i + " - " + DateTime.Now.ToString();
        //    defeito.Id_Tenant = tenantId;

        //    var resposta = defeito.Incluir(httpClient, defeito);
        //    var id = resposta.Result.Modelo?.Id ?? "Nenhum valor disponível";
        //    switch (resposta.Result.Sucesso)
        //    {
        //        case true:
        //            Console.WriteLine($"Defeito Inserindo: {i} / {id}  /  {DateTime.Now.ToString()} ");
        //            break;
        //        case false:
        //            Console.WriteLine($"Defeito erro: {i} / {id}  / {resposta.Result.Mensagem}");
        //            break;
        //    }
        //}
        //#endregion

        //#region DefeitoListar
        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("Defeito Listar ");
        //Console.WriteLine("-----------------------------------------------------");
        //List<ListarTodos> listaDefeito = await defeito.ListarTodos(httpClient, "Defeito");
        //Console.WriteLine("Defeito total de  : " + listaDefeito.Count());

        //#endregion

        //#region DefeitoExcluir
        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("Defeito Excluindo ");
        //Console.WriteLine("-----------------------------------------------------");
        //contador = 0;
        //foreach (var item in listaDefeito)
        //{
        //    var responseExcluir = await defeito.Excluir(httpClient, item.Id);
        //    if (responseExcluir.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await responseExcluir.Content.ReadAsStringAsync();
        //        var tenantExcluirResponse = JsonConvert.DeserializeObject<Resposta>(apiResponse);
        //        if (tenantExcluirResponse.Sucesso)
        //        {
        //            contador++;
        //            Console.WriteLine("Defeito excluido: " + contador + " / " + (tenantExcluirResponse.Modelo.Id != null ? tenantExcluirResponse.Modelo.Id.ToString() + " / " + DateTime.Now.ToString() : "Nenhum valor disponível"));

        //        }
        //    }
        //}
        //#endregion




        //#region AtivoTipoInserir
        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("Ativo Tipo Inserir ");
        //Console.WriteLine("-----------------------------------------------------");


        //Console.WriteLine("Ativo Tipo conexao: " + resultado.Result);
        //for (int i = 0; i < 1000; i++)
        //{

        //    ativoTipo.Referencia = "Ativo Tipo " + i + " - " + DateTime.Now.ToString();
        //    ativoTipo.Descricao = "Ativo Tipo " + i + " - " + DateTime.Now.ToString();
        //    ativoTipo.Id_Tenant = tenantId;

        //    var resposta = ativoTipo.Incluir(httpClient, ativoTipo);
        //    var id = resposta.Result.Modelo?.Id ?? "Nenhum valor disponível";
        //    switch (resposta.Result.Sucesso)
        //    {
        //        case true:
        //            Console.WriteLine($"Ativo Tipo Inserindo: {i} / {id}  /  {DateTime.Now.ToString()} ");
        //            break;
        //        case false:
        //            Console.WriteLine($"Ativo Tipo erro: {i} / {id}  / {resposta.Result.Mensagem}");
        //            break;
        //    }
        //}
        //#endregion

        //#region AtivoTipoListar
        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("Ativo Tipo Listar ");
        //Console.WriteLine("-----------------------------------------------------");
        //var lista = await ativoTipo.ListarTodos(httpClient, "AtivoTipo ");
        //Console.WriteLine("Ativo Tipo total de  : " + lista.items.Count());
        //#endregion

        //#region AtivoTipoExcluir
        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("Ativo Tipo Ativo Tipo Excluindo ");
        //Console.WriteLine("-----------------------------------------------------");
        //contador = 0;
        //foreach (var item in lista.items.Select(a => a).ToList())
        //{
        //    Guid id = Guid.Parse(item.id);
        //    var responseExcluir = await ativoTipo.Excluir(httpClient, id);

        //    if (responseExcluir.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await responseExcluir.Content.ReadAsStringAsync();
        //        var tenantExcluirResponse = JsonConvert.DeserializeObject<Resposta>(apiResponse);
        //        if (tenantExcluirResponse.Sucesso)
        //        {
        //            contador++;
        //            Console.WriteLine("Ativo Tipo excluindo: " + contador + " / " + (tenantExcluirResponse.Modelo.Id != null ? tenantExcluirResponse.Modelo.Id.ToString() + " / " + DateTime.Now.ToString() : "Nenhum valor disponível"));

        //        }
        //    }
        //}
        //#endregion

        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("Ativo Local Inserir ");
        //Console.WriteLine("-----------------------------------------------------");

        //for (int i = 0; i < 1000; i++)
        //{

        //    ativoLocal.Referencia = "AtivoLocal " + i + " - " + DateTime.Now.ToString();
        //    ativoLocal.Descricao = "AtivoLocal " + i + " - " + DateTime.Now.ToString();
        //    ativoLocal.Area = "AtivoLocal Area " + i + " - " + DateTime.Now.ToString();
        //    ativoLocal.Setor = "AtivoLocal Setor " + i + " - " + DateTime.Now.ToString();
        //    ativoLocal.Id_Tenant = tenantId;

        //    var resposta = ativoLocal.Incluir(httpClient, ativoLocal);
        //    switch (resposta.Result.Sucesso)
        //    {
        //        case true:
        //            var id = resposta.Result.Modelo?.Id ?? "Nenhum valor disponível";
        //            Console.WriteLine($"AtivoLocal Inserindo: {i} / {id}  /  {DateTime.Now.ToString()} ");
        //            break;
        //        case false:
        //            Console.WriteLine($"AtivoLocal erro: {resposta.Result.Mensagem}");
        //            break;
        //    }
        //}


        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("Ativo local Listar ");
        //Console.WriteLine("-----------------------------------------------------");
        //var listaLocal = await ativoLocal.ListarTodos(httpClient, "AtivoLocal");
        //Console.WriteLine("AtivoLocal total de  : " + listaLocal.items.Count());


        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("Ativo local Excluindo ");
        //Console.WriteLine("-----------------------------------------------------");
        //contador = 0;
        //foreach (var item in listaLocal.items)
        //{
        //    Guid id = Guid.Parse(item.id);
        //    var responseExcluir = await ativoLocal.Excluir(httpClient, id);

        //    if (responseExcluir.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await responseExcluir.Content.ReadAsStringAsync();
        //        var resultadoExcluir = JsonConvert.DeserializeObject<Resposta>(apiResponse);
        //        if (resultadoExcluir.Sucesso)
        //        {
        //            contador++;
        //            Console.WriteLine("Ativo local excluindo: " + contador + " / " + (resultadoExcluir.Modelo.Id != null ? resultadoExcluir.Modelo.Id.ToString() + " / " + DateTime.Now.ToString() : "Nenhum valor disponível"));

        //        }
        //    }
        //}




    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro: " + ex.Message);
    }
}




Console.WriteLine("Fim");


 