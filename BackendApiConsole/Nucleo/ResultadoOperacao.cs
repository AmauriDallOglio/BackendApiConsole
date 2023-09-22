﻿namespace BackendApiConsole.Nucleo
{
    public class ResultadoOperacao<T> : ResultadoOperacao
    {
        public T Modelo { get; set; }
        private ResultadoOperacao() { }
        public ResultadoOperacao(T modelo)
        {
            Modelo = modelo;
        }
    }
    public class ResultadoOperacao
    {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; }
    }
    public enum TipoMensagemOperacaoEnumumerador
    {
        Erro = 0,
        Alerta = 1,
        Info = 2,
        Sucesso = 3,
    }
}
