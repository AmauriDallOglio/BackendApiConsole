namespace BackendApiConsole.Nucleo
{
    public class ResultadoOperacao
    {

        public class Resultado
        {
            public string Id { get; set; }
        }

        public class Resposta
        {
            public Resultado Resultado { get; set; }
            public bool Sucesso { get; set; }
            public string Mensagem { get; set; }
        }
    }
}
