namespace SME.Worker.Agendador.Infra
{
    public static class RotasRabbitSerapEstudantes
    {
        public static string ExchangeSerapEstudantes => "serap.estudante.workers";

        #region Provas

        public static string FilaProvaSync => "serap.estudante.prova.legado.sync";
        public static string WebPushTestSync => "serap.estudante.prova.webpush.teste.sync";

        #endregion
    }
}