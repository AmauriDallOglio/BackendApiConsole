using BackendApiConsole.Nucleo;
using static BackendApiConsole.Nucleo.Defeito;

Guid tenantId = Guid.Parse("A31CF8A0-7B4D-EE11-A89E-F0D41578B814");

using (HttpClient httpClient = new HttpClient())
{
    try
    {
        Task<HttpResponseMessage> response;
        Console.WriteLine("Tenant: " + tenantId);
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Tenant Validando conexao ");
        Tenant tenant = new Tenant();
        var resultado = tenant.ValidaConexao(httpClient);
        if (resultado.Result != "Ok")
        {
            Console.WriteLine("Tenant conexao: " + resultado);
            return;
        }
        Console.WriteLine("Tenant conexao: " + resultado.Result);
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Tenant INSERIR: " + resultado.Result);
        Task<TenantResponse> novoTenant = tenant.Incluir(httpClient);
        Guid idTenant = novoTenant.Result.Id;
        Console.WriteLine("Novo tenant : " + idTenant);
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Tenant ALTERAR: " + idTenant);
        TenantResponse alterado = novoTenant.Result;
        alterado.Referencia = "TEN ALTERADO " + DateTime.Now.ToString();
        alterado.Descricao = "TEN DESC ALTERADO " + DateTime.Now.ToString();
        var tenantAlterado = tenant.Alterar(httpClient, alterado);
        Console.WriteLine("Referencia alterada tenant : " + tenantAlterado.Result.Referencia);
        Console.WriteLine("Descrição alterada tenant : " + tenantAlterado.Result.Descricao);
        Console.WriteLine("-----------------------------------------------------");


        var ok = tenant.ListarNumeros(httpClient);
        IEnumerable<int> okf = await tenant.ListarNumeros2(httpClient);
        Defeito defeito = new Defeito();
        //Task<HttpResponseMessage> response;

        //Defeito defeito1 = new Defeito();
        //defeito.Referencia = "DEF AUT" + DateTime.Now.ToString();
        //defeito.Descricao = "DEF AUT DESC " + DateTime.Now.ToString();
        //defeito.Id_Tenant = tenantId;
        //response = defeito1.Incluir(httpClient, defeito);

        //response = tenant.Incluir(httpClient);


        //#region IncluirDefeito
        //for (int i = 0; i < 10; i++)
        //{
        //    defeito = new Defeito();
        //    defeito.Referencia = "DEF AUT" + DateTime.Now.ToString() + i.ToString();
        //    defeito.Descricao = "DEF AUT DESC " + DateTime.Now.ToString() + i.ToString();
        //    defeito.Id_Tenant = tenantId;
        //    response = defeito.Incluir(httpClient, defeito);

        //    if (response.Result.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await response.Result.Content.ReadAsStringAsync();
        //        Console.WriteLine("Resposta da API: " + apiResponse);
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Erro na solicitação: {response.Result.StatusCode} - {response.Result.ReasonPhrase}");
        //    }
        //}
        //#endregion

        //#region AlterarListarDefeito
        //Task<List<DefeitoResponse>> listatenants = defeito.ListarTodos(httpClient);
        //foreach (DefeitoResponse defeitoItem in listatenants.Result.ToList())
        //{
        //    Console.WriteLine("Excluindo: " + defeitoItem.Descricao.ToString());
        //    response = defeito.Alterar(httpClient, defeitoItem);
        //    Console.WriteLine("Excluindo: " + response.Result.StatusCode);
        //}
        //#endregion


        //#region ListarNumeros
        //response = tenant.ListarNumeros(httpClient);
        //if (response.Result.IsSuccessStatusCode)
        //{
        //    Console.WriteLine("Resposta da API: " + response.ToString());
        //}
        //#endregion


        //#region IncluirTenant
        //for (int i = 0; i < 10; i++)
        //{
        //    tenant = new Tenant();
        //    string Refencia = "TEN" + DateTime.Now.ToString() + i.ToString();
        //    string Descricao = "desc " + DateTime.Now.ToString() + i.ToString();
        //    response = tenant.Incluir(httpClient, Refencia, Descricao);

        //    if (response.Result.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await response.Result.Content.ReadAsStringAsync();
        //        Console.WriteLine("Resposta da API: " + apiResponse);
        //        //response = tenant.Excluir(httpClient, Refencia);
        //        apiResponse = await response.Result.Content.ReadAsStringAsync();
        //        Console.WriteLine("Resposta da API: " + apiResponse);
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Erro na solicitação: {response.Result.StatusCode} - {response.Result.ReasonPhrase}");
        //    }
        //}
        //#endregion

        //#region DeletarListarTenant
        //Task<List<TenantResponse>> listatenants = tenant.ListarTodos(httpClient);
        //foreach (var tenantItem in listatenants.Result.ToList())
        //{
        //    Console.WriteLine("Excluindo: " + tenantItem.Descricao.ToString());
        //    response = tenant.Excluir(httpClient, tenantItem.Id);
        //}
        //#endregion

        //#region AlterarListarTenant
        //Task<List<TenantResponse>> listatenants = tenant.ListarTodos(httpClient);
        //foreach (TenantResponse tenantItem in listatenants.Result.ToList())
        //{
        //    Console.WriteLine("Excluindo: " + tenantItem.Descricao.ToString());
        //    response = tenant.Alterar(httpClient, tenantItem);
        //    Console.WriteLine("Excluindo: " + response.Result.StatusCode);
        //}
        //#endregion

    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro: " + ex.Message);
    }
}




Console.WriteLine("Fim");


 