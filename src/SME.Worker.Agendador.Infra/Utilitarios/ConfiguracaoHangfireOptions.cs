namespace SME.Worker.Agendador.Infra.Utilitarios
{
    public class ConfiguracaoHangfireOptions
    {
        public const string Secao = "Hangfire";
        public int BackgroundWorkerQueuePollInterval { get; set; }
        public int BackgroundWorkerParallelDegree { get; set; }
        public string ConnectionString { get; set; }
    }
}
