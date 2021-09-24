using Sentry;
using SME.Worker.Agendador.Background.Core.Enumerados;
using System;
using System.Linq.Expressions;

namespace SME.Worker.Agendador.Background.Core
{
    public static class Cliente
    {
        public static string Executar(Expression<Action> metodo, TipoProcessamento tipoProcessamento = TipoProcessamento.ExecucaoLonga)
        {
            return Orquestrador.ObterProcessador(tipoProcessamento).Executar(metodo);
        }

        public static string Executar<T>(Expression<Action<T>> metodo, TipoProcessamento tipoProcessamento = TipoProcessamento.ExecucaoLonga)
        {
            return Orquestrador.ObterProcessador(tipoProcessamento).Executar<T>(metodo);
        }

        public static void ExecutarPeriodicamente<T>(Expression<Action<T>> metodo, string cron, string nomeFila = "sgp")
        {
            Orquestrador.ObterProcessador(TipoProcessamento.ExecucaoRecorrente).ExecutarPeriodicamente(metodo, cron, nomeFila);
        }
        
    }
}