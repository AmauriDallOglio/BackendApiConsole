// See https://aka.ms/new-console-template for more information
using BackendApiConsole.Nucleo;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;



//HttpCllient httpCllient = new HttpCllient();
//var aaa = httpCllient.ExecutarAsync();






using (HttpClient httpClient = new HttpClient())
{
    try
    {
        string apiUrl = "https://localhost:7076/api/v1/Tenant/Inserir";
        //string jsonData = "{\"referencia\": \"dd2\", \"descricao\": \"dd2\"}";
        //httpClient.DefaultRequestHeaders.Add("accept", "text/plain");
        ////  HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

        // Dados do produto iPad
        var produto_ipad = new TenantInserirRequest()
        {
            Referencia = "IPad",
            Descricao = "Tablet"
        };

        // Converter objeto para JSON
        string jsonData = JsonConvert.SerializeObject(produto_ipad);
        // Realizar uma solicitação POST à API
        HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

        if (response.IsSuccessStatusCode)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Solicitação bem-sucedida!");
            Console.WriteLine("Resposta da API: " + apiResponse);
        }
        else
        {
            Console.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro: " + ex.Message);
    }
}




// URL da API
//string apiUrl = "https://localhost:7076/api/v1/Tenant/Ok";

//using (HttpClient httpClient = new HttpClient())
//{
//    try
//    {
//        // Configurar cabeçalhos
//        httpClient.DefaultRequestHeaders.Add("accept", "text/plain");
//        // Realizar uma solicitação GET à API
//        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

//        // Verificar a resposta da API
//        if (response.IsSuccessStatusCode)
//        {
//            string apiResponse = await response.Content.ReadAsStringAsync();
//            Console.WriteLine("Solicitação bem-sucedida!");
//            Console.WriteLine("Resposta da API: " + apiResponse);
//        }
//        else
//        {
//            Console.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Erro: " + ex.Message);
//    }
//}








// URL da API
//string apiUrl = "https://localhost:7076/api/v1/Tenant/Inserir";

// Dados que você deseja enviar para a API (no formato JSON)
//string jsonData = "{\"referencia\": \"dd\", \"descricao\": \"dd\"}";

//using (var httpClient = new HttpClient())
//{
//    try
//    {
//        // Configurar cabeçalhos
//        httpClient.DefaultRequestHeaders.Add("accept", "*/*");
//        httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

//        // Realizar uma solicitação POST à API
//        HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

//        // Verificar a resposta da API
//        if (response.IsSuccessStatusCode)
//        {
//            string apiResponse = await response.Content.ReadAsStringAsync();
//            Console.WriteLine("Solicitação bem-sucedida!");
//            Console.WriteLine("Resposta da API: " + apiResponse);
//        }
//        else
//        {
//            Console.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Erro: " + ex.Message);
//    }
//}

Console.WriteLine("Hello, World!");


 