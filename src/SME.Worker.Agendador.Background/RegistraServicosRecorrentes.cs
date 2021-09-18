using Hangfire;
using SME.Worker.Agendador.Dominio.CasosDeUso.Aula.CriacaoAutomatica;
using SME.Worker.Agendador.Dominio.CasosDeUso.AulasPrevistas;
using SME.Worker.Agendador.Dominio.CasosDeUso.ComponentesCurriculares;
using SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoAcompanhamentoAprendizagemAluno;
using SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoDevolutivas;
using SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoMatriculaTurma;
using SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoMediaRegistrosIndividuais;
using SME.Worker.Agendador.Dominio.CasosDeUso.Frequencia;
using SME.Worker.Agendador.Dominio.CasosDeUso.Frequencia.ConciliacaoFrequenciaTurmas;
using SME.Worker.Agendador.Dominio.CasosDeUso.GoogleClassroom;
using SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoAlunosFaltosos;
using SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoAndamentoFechamento;
using SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoFrequenciaUe;
using SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoInicioFimPeriodoFechamento;
using SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoPeriodoFechamento;
using SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoResultadoInsatisfatorio;
using SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoReuniaoPedagogica;
using SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoUeFechamentosInsuficientes;
using SME.Worker.Agendador.Dominio.CasosDeUso.NotificacoesNiveisCargos;
using SME.Worker.Agendador.Dominio.CasosDeUso.ObjetivoAprendizagem;
using SME.Worker.Agendador.Dominio.CasosDeUso.PendenciaAusenciaFechamento;
using SME.Worker.Agendador.Dominio.CasosDeUso.PendenciaProfessor;
using SME.Worker.Agendador.Dominio.CasosDeUso.PendenciaRegistroIndividual;
using SME.Worker.Agendador.Dominio.CasosDeUso.PendenciasGerais;
using SME.Worker.Agendador.Dominio.CasosDeUso.PlanoAEE.EncerramentoPlanoAEEEstudantesInativos;
using SME.Worker.Agendador.Dominio.CasosDeUso.PlanoAEE.NotificacaoPlanoAEEEmAberto;
using SME.Worker.Agendador.Dominio.CasosDeUso.PlanoAEE.NotificacaoPlanoAEEExpirado;
using SME.Worker.Agendador.Dominio.CasosDeUso.PlanoAEE.PendenciaValidadePlanoAEE;
using SME.Worker.Agendador.Dominio.CasosDeUso.RabbitDeadletter;
using SME.Worker.Agendador.Dominio.CasosDeUso.RotasAgendamento;
using SME.Worker.Agendador.Dominio.CasosDeUso.SerapEstudantes;
using SME.Worker.Agendador.Dominio.CasosDeUso.SincronizacaoInstitucional;
using SME.Worker.Agendador.Background.Core;

namespace SME.Worker.Agendador.Background
{
    public static class RegistraServicosRecorrentes
    {
        public static void Registrar()
        {
            //ToDo: Eduardo Remover
            RegistrarTeste();
            return;

            Cliente.ExecutarPeriodicamente<INotifificarRegistroFrequenciaUseCase>(c => c.Executar(), Cron.Daily(2));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAulasPrevistasUseCase>(c => c.Executar(), Cron.Daily(2));

            //todos os dias à 1 da manhã
            Cliente.ExecutarPeriodicamente<ISincronizarObjetivosComJuremaUseCase>(c => c.Executar(), Cron.Daily(22));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAlunosFaltososUseCase>(c => c.Executar(), Cron.Daily(2));

            Cliente.ExecutarPeriodicamente<INotificarAlunosFaltososBimestreUseCase>(c => c.Executar(), Cron.Daily(3));

            Cliente.ExecutarPeriodicamente<ISincronizarAulasInfantilUseCase>(c => c.Executar(), Cron.Daily(6));

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

            Cliente.ExecutarPeriodicamente<ISyncGeralGoogleClassroomUseCase>(c => c.Executar(), Cron.Daily(11));

            Cliente.ExecutarPeriodicamente<ISyncGsaGoogleClassroomUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Sunday, 10));

            Cliente.ExecutarPeriodicamente<IExecutaEncerramentoPlanoAEEEstudantesInativosUseCase>(c => c.Executar(), Cron.Daily(8));

            Cliente.ExecutarPeriodicamente<IExecutaPendenciaValidadePlanoAEEUseCase>(c => c.Executar(), Cron.Daily(8));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPlanoAEEExpiradoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPlanoAEEEmAbertoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoInstitucionalSyncUseCase>(c => c.Executar(), Cron.Daily(13));

            Cliente.ExecutarPeriodicamente<IExecutarConsolidacaoMatriculaTurmasUseCase>(c => c.Executar(), Cron.Daily(10));

            Cliente.ExecutarPeriodicamente<IConciliacaoFrequenciaTurmasCronUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Saturday, 23));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoAulasRegenciaAutomaticasUseCase>(c => c.Executar(), Cron.Daily(9));

            //De 10 em 10 minutos
            Cliente.ExecutarPeriodicamente<IRabbitDeadletterSgpSyncUseCase>(c => c.Executar(), Cron.MinuteInterval(10));

            //De 10 em 10 minutos
            Cliente.ExecutarPeriodicamente<IRabbitDeadletterSrSyncUseCase>(c => c.Executar(), Cron.MinuteInterval(10));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            Cliente.ExecutarPeriodicamente<IRotasAgendamentoSyncUseCase>(c => c.Executar(), Cron.Daily(10));

            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesProvasUseCase>(c => c.Executar(), Cron.Daily(1));
        }


        public static void RegistrarTeste()
        {
            var oneMinute = Cron.MinuteInterval(1);

            Cliente.ExecutarPeriodicamente<INotifificarRegistroFrequenciaUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAulasPrevistasUseCase>(c => c.Executar(), oneMinute);

            //todos os dias à 1 da manhã
            Cliente.ExecutarPeriodicamente<ISincronizarObjetivosComJuremaUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAlunosFaltososUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<INotificarAlunosFaltososBimestreUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<ISincronizarAulasInfantilUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<ISincronizarComponentesCurricularesEolUseCase>(c => c.Executar(), oneMinute);

            // Executa as 02:00 
            Cliente.ExecutarPeriodicamente<IPendenciasGeraisUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaPendenciasProfessorAvaliacaoUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaPendenciasAusenciaFechamentoUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoResultadoInsatisfatorioUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAndamentoFechamentoUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoUeFechamentosInsuficientesUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoReuniaoPedagogicaUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPeriodoFechamentoUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IPublicarPendenciaAusenciaRegistroIndividualUseCase>(c => c.Executar(), oneMinute);

            // de segunda a sexta as 11 horas
            Cliente.ExecutarPeriodicamente<ITratarNotificacoesNiveisCargosUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoInicioFimPeriodoFechamentoUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoFrequenciaUeUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<ISyncGeralGoogleClassroomUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<ISyncGsaGoogleClassroomUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaEncerramentoPlanoAEEEstudantesInativosUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaPendenciaValidadePlanoAEEUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPlanoAEEExpiradoUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPlanoAEEEmAbertoUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoInstitucionalSyncUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutarConsolidacaoMatriculaTurmasUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IConciliacaoFrequenciaTurmasCronUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoAulasRegenciaAutomaticasUseCase>(c => c.Executar(), oneMinute);

            //De 10 em 10 minutos
            Cliente.ExecutarPeriodicamente<IRabbitDeadletterSgpSyncUseCase>(c => c.Executar(), oneMinute);

            //De 10 em 10 minutos
            Cliente.ExecutarPeriodicamente<IRabbitDeadletterSrSyncUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<IRotasAgendamentoSyncUseCase>(c => c.Executar(), oneMinute);

            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesProvasUseCase>(c => c.Executar(), oneMinute);
        }
    }
}
