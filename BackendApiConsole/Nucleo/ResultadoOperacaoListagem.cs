namespace BackendApiConsole.Nucleo
{
    public class ResultadoOperacaoListagem 
    {
        public class ApiResponse<T>
        {
            public int itemPorPagina { get; set; }
            public int totalPagina { get; set; }
            public int totalRegistros { get; set; }
            public int totalRegistrosFiltrados { get; set; }
            public string nomeObjeto { get; set; }
            public List<T> items { get; set; }
        }

        public class Tenant
        {
            public string id_Tenant { get; set; }
            public ReferenciaTenant tenant { get; set; }
        }

        public class ReferenciaTenant
        {
            public string referencia { get; set; }
            public string descricao { get; set; }
            public bool inativo { get; set; }
            public object id_Imagem { get; set; }
            public string id { get; set; }
        }

       

      

    }
   
}
