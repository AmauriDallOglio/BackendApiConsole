using BackendApiConsole.Nucleo;


Guid tenantId = Guid.Parse("CB0CDCD5-DEE1-4665-AD3E-388733FCDF3B");

using (HttpClient httpClient = new HttpClient())
{
    try
    {
        Tenant tenant = new Tenant();
        Task<HttpResponseMessage> response;

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

        #region AlterarListarTenant
        Task<List<TenantResponse>> listatenants = tenant.ListarTodos(httpClient);
        foreach (TenantResponse tenantItem in listatenants.Result.ToList())
        {
            Console.WriteLine("Excluindo: " + tenantItem.Descricao.ToString());
            response = tenant.Alterar(httpClient, tenantItem);
            Console.WriteLine("Excluindo: " + response.Result.StatusCode);
        }
        #endregion

    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro: " + ex.Message);
    }
}




Console.WriteLine("Fim");


 