namespace BackendApiConsole.Nucleo
{
    public class EntidadeModelo
    {
        public class Resposta
        {
            public Modelo Modelo { get; set; }
            public bool Sucesso { get; set; }
            public string Mensagem { get; set; }

            public List<string> Messages { get; set; } = new List<string>();

            public bool Succeeded { get; set; }

            public string Data { get; set; }
        }

        public class Modelo
        {
            public string Id { get; set; }
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
}
