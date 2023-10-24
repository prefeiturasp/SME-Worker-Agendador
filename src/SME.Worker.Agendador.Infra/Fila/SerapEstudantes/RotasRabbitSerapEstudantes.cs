﻿namespace SME.Worker.Agendador.Infra
{
    public static class RotasRabbitSerapEstudantes
    {
        public static string ExchangeSerapEstudantes => "serap.estudante.workers";

        #region Provas

        public static string FilaProvaSync => "serap.estudante.prova.legado.sync";
        public static string WebPushTest => "serap.estudante.prova.webpush.teste";

        #endregion


        #region Deadletter
        public static string FilaDeadletterSync => "serap.deadletter.sync";

        #endregion

    }
}