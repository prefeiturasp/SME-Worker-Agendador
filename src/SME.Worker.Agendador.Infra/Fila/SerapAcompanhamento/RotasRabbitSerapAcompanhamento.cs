
namespace SME.Worker.Agendador.Infra
{
    public class RotasRabbitSerapAcompanhamento
    {
        public static string ExchangeSerapAcompanhamento => "serap.estudante.acomp.workers";

        #region FILAS

        public const string IniciarSync = "serap.estudante.acomp.iniciar.sync";

        #endregion
    }
}
