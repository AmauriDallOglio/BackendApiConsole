using BackendApiConsole.Nucleo;
using Newtonsoft.Json;
using static BackendApiConsole.Nucleo.EntidadeModelo;

Guid tenantId = Guid.Parse("A31CF8A0-7B4D-EE11-A89E-F0D41578B814");

using (HttpClient httpClient = new HttpClient())
{
    try
    {
        Task<HttpResponseMessage> response;
        int contador = 0;
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

        //Console.WriteLine("Tenant INSERIR: " + resultado.Result);
        //Task<TenantResponse> novoTenant = tenant.Incluir(httpClient);
        //Guid idTenant = novoTenant.Result.Id;
        //Console.WriteLine("Novo tenant : " + idTenant);
        //Console.WriteLine("-----------------------------------------------------");
        //Console.WriteLine("Tenant ALTERAR: " + idTenant);
        //TenantResponse alterado = novoTenant.Result;
        //alterado.Referencia = "TEN ALTERADO " + DateTime.Now.ToString();
        //alterado.Descricao = "TEN DESC ALTERADO " + DateTime.Now.ToString();
        //var tenantAlterado = tenant.Alterar(httpClient, alterado);
        //Console.WriteLine("Referencia alterada tenant : " + tenantAlterado.Result.Referencia);
        //Console.WriteLine("Descrição alterada tenant : " + tenantAlterado.Result.Descricao);
        //Console.WriteLine("-----------------------------------------------------");




        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Ativo Tipo Inserir ");
        Console.WriteLine("-----------------------------------------------------");
        AtivoTipo ativoTipo = new AtivoTipo();

        resultado = ativoTipo.ValidaConexao(httpClient);
        if (resultado.Result != "Ok")
        {
            Console.WriteLine("AtivoTipo conexao: " + resultado);
            return;
        }
        Console.WriteLine("AtivoTipo conexao: " + resultado.Result);
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Inserindo " + i);
            ativoTipo.Referencia = "AtivoTipo " + i + " - " + DateTime.Now.ToString();
            ativoTipo.Descricao = "AtivoTipo " + i + " - " + DateTime.Now.ToString();
            ativoTipo.Id_Tenant = tenantId;

            var resposta = ativoTipo.Incluir(httpClient, ativoTipo);
            if (resposta.Result.Sucesso)
            {
                Console.WriteLine("AtivoTipo conexao: " + (resposta.Result != null ? resposta.Result.Modelo.Id.ToString() : "Nenhum valor disponível"));

            }
        }
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Ativo Tipo Listar ");
        Console.WriteLine("-----------------------------------------------------");
        List<ListarTodos> lista = await ativoTipo.ListarTodos(httpClient, "AtivoTipo ");

        Console.WriteLine("AtivoTipo total de  : " + lista.Count());

        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Ativo Tipo Excluindo ");
        Console.WriteLine("-----------------------------------------------------");
        contador = 0;
        foreach (var item in lista)
        {
            var responseExcluir = await ativoTipo.Excluir(httpClient, item.Id);

            if (responseExcluir.IsSuccessStatusCode)
            {
                string apiResponse = await responseExcluir.Content.ReadAsStringAsync();
                var tenantExcluirResponse = JsonConvert.DeserializeObject<BackendApiConsole.Nucleo.Resposta>(apiResponse);
                if (tenantExcluirResponse.Sucesso)
                {
                    contador++;
                    Console.WriteLine("AtivoTipo excluindo: " + contador + " / " + (tenantExcluirResponse.Modelo.Id != null ? tenantExcluirResponse.Modelo.Id.ToString() : "Nenhum valor disponível"));

                }
            }
        }

        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Ativo Local Inserir ");
        Console.WriteLine("-----------------------------------------------------");
        AtivoLocal ativoLocal = new AtivoLocal();

        resultado = ativoLocal.ValidaConexao(httpClient);
        if (resultado.Result != "Ok")
        {
            Console.WriteLine("ativoLocal conexao: " + resultado);
            return;
        }
        Console.WriteLine("ativoLocal conexao: " + resultado.Result);
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Inserindo " + i);
            ativoLocal.Referencia = "AtivoLocal " + i + " - " + DateTime.Now.ToString();
            ativoLocal.Descricao = "AtivoLocal " + i + " - " + DateTime.Now.ToString();
            ativoLocal.Area = "AtivoLocal Area " + i + " - " + DateTime.Now.ToString();
            ativoLocal.Setor = "AtivoLocal Setor " + i + " - " + DateTime.Now.ToString();
            ativoLocal.Id_Tenant = tenantId;

            var resposta = ativoLocal.Incluir(httpClient, ativoLocal);
            if (resposta.Result.Sucesso)
            {
                Console.WriteLine("ativoLocal conexao: " + (resposta.Result != null ? resposta.Result.Modelo.Id.ToString() : "Nenhum valor disponível"));

            }
        }


        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Ativo local Listar ");
        Console.WriteLine("-----------------------------------------------------");
        var listaLocal = await ativoLocal.ListarTodos(httpClient, "AtivoLocal");

        Console.WriteLine("AtivoLocal total de  : " + listaLocal.Count());


        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Ativo Tipo Excluindo ");
        Console.WriteLine("-----------------------------------------------------");
        contador = 0;
        foreach (var item in listaLocal)
        {
            var responseExcluir = await ativoLocal.Excluir(httpClient, item.Id);

            if (responseExcluir.IsSuccessStatusCode)
            {
                string apiResponse = await responseExcluir.Content.ReadAsStringAsync();
                var resultadoExcluir = JsonConvert.DeserializeObject<BackendApiConsole.Nucleo.Resposta>(apiResponse);
                if (resultadoExcluir.Sucesso)
                {
                    contador++;
                    Console.WriteLine("ativoLocal excluindo: " + contador + " / " + (resultadoExcluir.Modelo.Id != null ? resultadoExcluir.Modelo.Id.ToString() : "Nenhum valor disponível"));

                }
            }
        }



        //Console.WriteLine("-----------------------------------------------------");

        //Defeito defeito = new Defeito();
        //defeito.Referencia = "DEF AUT" + DateTime.Now.ToString();
        //defeito.Descricao = "DEF AUT DESC " + DateTime.Now.ToString();
        //defeito.Id_Tenant = tenantId;
        //defeito.Incluir(httpClient, defeito);



        //var ok = tenant.ListarNumeros(httpClient);
        //IEnumerable<int> okf = await tenant.ListarNumeros2(httpClient);
        //Defeito defeito = new Defeito();
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


 