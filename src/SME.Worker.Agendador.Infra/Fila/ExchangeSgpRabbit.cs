﻿namespace SME.Worker.Agendador.Infra
{
    public static class ExchangeRabbit
    {
        public static string ServidorRelatorios => "sme.sr.workers.relatorios";
        public static string Sgp => "sme.sgp.workers";
        public static string SgpDeadLetter => "sme.sgp.workers.deadletter";
        public static string ServidorRelatoriosDeadLetter => "sme.sr.workers.relatorios.deadletter";
        public static string SerapEstudantes => "serap.estudante.workers";
    }
}
