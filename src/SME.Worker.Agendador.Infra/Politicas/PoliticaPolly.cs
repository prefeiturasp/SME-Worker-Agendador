namespace SME.Worker.Agendador.Infra.Politicas
{
    public abstract class PoliticaPolly
    {
        public static string SGP => "RetryPolicySGP";
        public static string PublicaFila => "RetryPolicyFilasRabbit";
    }
}
