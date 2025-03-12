namespace SME.Worker.Agendador.Aplicacao
{
    public static class RotasRabbitSerapBoletim
    {
        public static string ExchangeSerapBoletim => "serap.boletim.workers";

        public const string BuscarProvasFinalizadas = "serap.boletim.buscar.provas.finalizadas";
    }
}