namespace SME.Worker.Agendador.Aplicacao
{
    public class RotasRabbitEol
    {
        public const string InserirInformacoesListagemDoListaoEolSync = "ApiEol:CargaESTurmaComponentesCommand";
        public const string InserirUsuariosEolElasticSearchSync = "ApiEol:CargaESUsuariosCommand";
    }
}