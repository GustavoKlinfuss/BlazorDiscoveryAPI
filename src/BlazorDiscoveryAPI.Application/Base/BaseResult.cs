namespace BlazorDiscoveryAPI.Application.Base
{
    public class BaseResult
    {
        public bool Sucesso => Erros is null;
        public IEnumerable<Error>? Erros { get; set; }
        public object? Dados { get; set; }

        public BaseResult(object dados)
        {
            Dados = dados;
        }

        public BaseResult(IEnumerable<Error> erros)
        {
            Erros = erros;
        }
    }

    public class Error
    {
        public Error(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }

        public string Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}
