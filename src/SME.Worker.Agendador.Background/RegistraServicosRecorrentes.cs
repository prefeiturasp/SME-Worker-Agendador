using Hangfire;
using SME.SGP.Agendador.Dominio.CasosDeUso.Aula.CriacaoAutomatica;
using SME.SGP.Agendador.Dominio.CasosDeUso.AulasPrevistas;
using SME.SGP.Agendador.Dominio.CasosDeUso.ComponentesCurriculares;
using SME.SGP.Agendador.Dominio.CasosDeUso.ConsolidacaoAcompanhamentoAprendizagemAluno;
using SME.SGP.Agendador.Dominio.CasosDeUso.ConsolidacaoDevolutivas;
using SME.SGP.Agendador.Dominio.CasosDeUso.ConsolidacaoMatriculaTurma;
using SME.SGP.Agendador.Dominio.CasosDeUso.ConsolidacaoMediaRegistrosIndividuais;
using SME.SGP.Agendador.Dominio.CasosDeUso.Frequencia;
using SME.SGP.Agendador.Dominio.CasosDeUso.Frequencia.ConciliacaoFrequenciaTurmas;
using SME.SGP.Agendador.Dominio.CasosDeUso.GoogleClassroom;
using SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoAlunosFaltosos;
using SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoAndamentoFechamento;
using SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoFrequenciaUe;
using SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoInicioFimPeriodoFechamento;
using SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoPeriodoFechamento;
using SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoResultadoInsatisfatorio;
using SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoReuniaoPedagogica;
using SME.SGP.Agendador.Dominio.CasosDeUso.NotificacaoUeFechamentosInsuficientes;
using SME.SGP.Agendador.Dominio.CasosDeUso.NotificacoesNiveisCargos;
using SME.SGP.Agendador.Dominio.CasosDeUso.ObjetivoAprendizagem;
using SME.SGP.Agendador.Dominio.CasosDeUso.PendenciaAusenciaFechamento;
using SME.SGP.Agendador.Dominio.CasosDeUso.PendenciaProfessor;
using SME.SGP.Agendador.Dominio.CasosDeUso.PendenciaRegistroIndividual;
using SME.SGP.Agendador.Dominio.CasosDeUso.PendenciasGerais;
using SME.SGP.Agendador.Dominio.CasosDeUso.PlanoAEE.EncerramentoPlanoAEEEstudantesInativos;
using SME.SGP.Agendador.Dominio.CasosDeUso.PlanoAEE.NotificacaoPlanoAEEEmAberto;
using SME.SGP.Agendador.Dominio.CasosDeUso.PlanoAEE.NotificacaoPlanoAEEExpirado;
using SME.SGP.Agendador.Dominio.CasosDeUso.PlanoAEE.PendenciaValidadePlanoAEE;
using SME.SGP.Agendador.Dominio.CasosDeUso.RabbitDeadletter;
using SME.SGP.Agendador.Dominio.CasosDeUso.RotasAgendamento;
using SME.SGP.Agendador.Dominio.CasosDeUso.SerapEstudantes;
using SME.SGP.Agendador.Dominio.CasosDeUso.SincronizacaoInstitucional;
using SME.Worker.Agendador.Background.Core;

namespace SME.Worker.Agendador.Background
{
    public static class RegistraServicosRecorrentes
    {
        public static void Registrar()
        {
            Cliente.ExecutarPeriodicamente<INotifificarRegistroFrequenciaUseCase>(c => c.Executar(), Cron.Daily(2));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAulasPrevistasUseCase>(c => c.Executar(), Cron.Daily(2));

            // Estamos removendo pois essa rotina está sendo refeita e será executada através do Rabbit.
            // de segunda a sexta as 10, 14 e 16 horas
            //Cliente.ExecutarPeriodicamente<IServicoAbrangencia>(c => c.SincronizarEstruturaInstitucionalVigenteCompleta(), "0 13,17,19 * * 1-5");

            //todos os dias à 1 da manhã
            Cliente.ExecutarPeriodicamente<ISincronizarObjetivosComJuremaUseCase>(c => c.Executar(), Cron.Daily(22));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAlunosFaltososUseCase>(c => c.Executar(), Cron.Daily(2));

            Cliente.ExecutarPeriodicamente<INotificarAlunosFaltososBimestreUseCase>(c => c.Executar(), Cron.Daily(3));

            Cliente.ExecutarPeriodicamente<ISincronizarAulasInfantilUseCase>(c => c.Executar(), Cron.Daily(6));

            // Executa as 04am (vai ser ajustado o UTC corretamente depois no hangfire)
            //Cliente.ExecutarPeriodicamente<IExecutaPendenciaAulaUseCase>(c => c.Executar(), Cron.Daily(4));

            Cliente.ExecutarPeriodicamente<ISincronizarComponentesCurricularesEolUseCase>(c => c.Executar(), Cron.Daily(4));

            // Executa as 02:00 
            Cliente.ExecutarPeriodicamente<IPendenciasGeraisUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaPendenciasProfessorAvaliacaoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaPendenciasAusenciaFechamentoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoResultadoInsatisfatorioUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAndamentoFechamentoUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoUeFechamentosInsuficientesUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoReuniaoPedagogicaUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPeriodoFechamentoUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            Cliente.ExecutarPeriodicamente<IPublicarPendenciaAusenciaRegistroIndividualUseCase>(c => c.Executar(), Cron.Daily(2));

            // de segunda a sexta as 11 horas
            Cliente.ExecutarPeriodicamente<ITratarNotificacoesNiveisCargosUseCase>(c => c.Executar(), "0 14 * * 1-5");

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoInicioFimPeriodoFechamentoUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoFrequenciaUeUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            //Cliente.ExecutarPeriodicamente<IRemoveConexaoIdleUseCase>(c => c.Executar(), Cron.MinuteInterval(30));

            Cliente.ExecutarPeriodicamente<ISyncGeralGoogleClassroomUseCase>(c => c.Executar(), Cron.Daily(11));
            Cliente.ExecutarPeriodicamente<ISyncGsaGoogleClassroomUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Sunday, 10));

            Cliente.ExecutarPeriodicamente<IExecutaEncerramentoPlanoAEEEstudantesInativosUseCase>(c => c.Executar(), Cron.Daily(8));

            Cliente.ExecutarPeriodicamente<IExecutaPendenciaValidadePlanoAEEUseCase>(c => c.Executar(), Cron.Daily(8));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPlanoAEEExpiradoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPlanoAEEEmAbertoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoInstitucionalSyncUseCase>(c => c.Executar(), Cron.Daily(13));

            Cliente.ExecutarPeriodicamente<IExecutarConsolidacaoMatriculaTurmasUseCase>(c => c.Executar(), Cron.Daily(10));

            // Removido até melhoria de performance prevista
            //Cliente.ExecutarPeriodicamente<IExecutarConsolidacaoFrequenciaTurmaSyncUseCase>(c => c.Executar(), Cron.Daily(6));

            Cliente.ExecutarPeriodicamente<IConciliacaoFrequenciaTurmasCronUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Saturday, 23));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoAulasRegenciaAutomaticasUseCase>(c => c.Executar(), Cron.Daily(9));

            //De 10 em 10 minutos
            Cliente.ExecutarPeriodicamente<IRabbitDeadletterSgpSyncUseCase>(c => c.Executar(), Cron.MinuteInterval(10));
            //ToDo:voltar 10 em 10
            //Cliente.ExecutarPeriodicamente<IRabbitDeadletterSrSyncUseCase>(c => c.Executar(), Cron.MinuteInterval(10));
            Cliente.ExecutarPeriodicamente<IRabbitDeadletterSrSyncUseCase>(c => c.Executar(), Cron.MinuteInterval(1));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            // Consolidação Acompanhamento Aprendizagem do Aluno
            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            Cliente.ExecutarPeriodicamente<IRotasAgendamentoSyncUseCase>(c => c.Executar(), Cron.Daily(10));

            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesProvasUseCase>(c => c.Executar(), Cron.Daily(1));
        }
    }
}
