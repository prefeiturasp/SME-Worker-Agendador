namespace SME.Worker.Agendador.Hangfire.Configurations
{
    internal class UriConfiguration
    {
        public static string[] GetUrls() =>
            new[] { "http://*:5010", "https://*:5011" };
    }
}
