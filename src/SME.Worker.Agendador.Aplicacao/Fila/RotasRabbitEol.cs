namespace SME.Worker.Agendador.Aplicacao
{
    public class RotasRabbitEol
    {
        public const string InserirInformacoesListagemDoListaoEolSync = "ApiEol:CargaESTurmaComponentesCommand";
        public const string InserirFuncionariosEolElasticSearchSync = "ApiEol:CargaESFuncionariosCommand";
        public const string InserirComponentesTurmasProfessoresEolElasticSearchSync = "ApiEol:CargaESComponentesTurmasProfessoresPorTurmaCommand";
    }
}