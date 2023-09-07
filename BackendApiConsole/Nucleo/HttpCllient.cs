using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BackendApiConsole.Nucleo
{
    public class HttpCllient
    {

        public async Task ExecutarAsync()
        {
            using (var cliente = new HttpClient())
            {

                ////        curl -X 'POST' \
                ////  'https://localhost:7076/api/v1/Tenant/Inserir' \

                //cliente.BaseAddress = new Uri("https://localhost:7076/");
                //cliente.DefaultRequestHeaders.Accept.Clear();
                //cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //// HTTP POST - define o produto
                //var produto_ipad = new TenantInserirRequest() { Referencia = "IPad", Descricao = "Tablet" };
                //var response = await cliente.PostAsJsonAsync("api/v1/Tenant/Inserir", produto_ipad);
                //if (response.IsSuccessStatusCode)
                //{
                //    Uri produtoUrl = response.Headers.Location;
                //    //// HTTP PUT
                //    //produto_ipad.Preco = 1800;   // atualiza o preco do produto
                //    //response = await cliente.PutAsJsonAsync(produtoUrl, produto_ipad);
                //    //// HTTP DELETE - deleta o produto
                //    //response = await cliente.DeleteAsync(produtoUrl);
                //}


                cliente.BaseAddress = new Uri("https://localhost:7076/"); //para uma api com esse caminho.
                cliente.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json")
                            );
                var produto_ipad = new TenantInserirRequest() { Referencia = "IPad", Descricao = "Tablet" };
                var serializedVendas = JsonConvert.SerializeObject(produto_ipad);
                var content = new StringContent(serializedVendas, Encoding.UTF8, "application/json");
                var result = await cliente.GetStringAsync("api/v1/Tenant/Ok"); //, content); //caso essa seja sua rota
                if (result.Count() > 0)
                {
                    var aaa = "Ok";
                }

            }
        }

    }
}




//curl - X 'POST' \
//  'https://localhost:7076/api/v1/Tenant/Inserir' \
//  -H 'accept: */*' \
//  -H 'Content-Type: application/json' \
//  -d '{
//  "referencia": "fff",
//  "descricao": "fff"
//}'


//        {
//  "result": {
//    "modelo": {
//      "id": "12b79d49-4341-4b0f-f90a-08dbafd1f0f4",
//      "referencia": "fff",
//      "descricao": "fff",
//      "inativo": false,
//      "id_Imagem": null
//    },
//    "sucesso": true,
//    "mensagem": ""
//  },
//  "id": 162,
//  "exception": null,
//  "status": 5,
//  "isCanceled": false,
//  "isCompleted": true,
//  "isCompletedSuccessfully": true,
//  "creationOptions": 0,
//  "asyncState": null,
//  "isFaulted": false
//}
