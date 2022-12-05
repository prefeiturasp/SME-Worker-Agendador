using Hangfire;
using SME.Worker.Agendador.Aplicacao;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Aula.CriacaoAutomatica;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.AulasPrevistas;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ComponentesCurriculares;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoAcompanhamentoAprendizagemAluno;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoDevolutivas;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoFrequenciaTurma;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoMatriculaTurma;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoMediaRegistrosIndividuais;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoRegistrosPedagogicos;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Devolutiva;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.EncerrarEncaminhamentoAeeAutomatico;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia.ConciliacaoFrequenciaTurmas;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.GoogleClassroom;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAlunosFaltosos;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAndamentoFechamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoFrequenciaUe;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoInicioFimPeriodoFechamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoResultadoInsatisfatorio;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoReuniaoPedagogica;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoUeFechamentosInsuficientes;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacoesNiveisCargos;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ObjetivoAprendizagem;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaAusenciaFechamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaPerfilUsuario;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaProfessor;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaRegistroIndividual;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciasAula;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciasGerais;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PlanoAEE.EncerramentoPlanoAEEEstudantesInativos;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PlanoAEE.NotificacaoPlanoAEEEmAberto;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PlanoAEE.NotificacaoPlanoAEEExpirado;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PlanoAEE.PendenciaValidadePlanoAEE;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.RotasAgendamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.SincronizacaoInstitucional;
using SME.Worker.Agendador.Background.Core;

namespace SME.Worker.Agendador.Background
{
    public static class RegistraServicosRecorrentes
    {
        public static void Registrar()
        {
            RegistrarServicosSgp();
            RegistrarServicosSerap();
            RegistrarServicoEol();
            RegistrarServicosSerapAcompanhamento();
        }

        private static void RegistrarServicoEol()
        {
            Cliente.ExecutarPeriodicamente<IInserirInformacoesListagemListaoEolUseCase>(c => c.Executar(), Cron.Daily(8, 30));            
        }

        public static void RegistrarServicosSgp()
        {
            Cliente.ExecutarPeriodicamente<INotifificarRegistroFrequenciaUseCase>(c => c.Executar(), Cron.Daily(2));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAulasPrevistasUseCase>(c => c.Executar(), Cron.Daily(2));

            // Estamos removendo pois essa rotina está sendo refeita e será executada através do Rabbit.
            // de segunda a sexta as 10, 14 e 16 horas
            //Cliente.ExecutarPeriodicamente<IServicoAbrangencia>(c => c.SincronizarEstruturaInstitucionalVigenteCompleta(), "0 13,17,19 * * 1-5");

            //todos os dias à 1 da manhã
            //Cliente.ExecutarPeriodicamente<IServicoObjetivosAprendizagem>(c => c.SincronizarObjetivosComJurema(), Cron.Daily(22));
            Cliente.ExecutarPeriodicamente<ISincronizarObjetivosComJuremaUseCase>(c => c.Executar(), Cron.Daily(22));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAlunosFaltososUseCase>(c => c.Executar(), Cron.Daily(2));

            //Cliente.ExecutarPeriodicamente<IServicoNotificacaoFrequencia>(c => c.NotificarAlunosFaltososBimestre(), Cron.Daily(3));
            Cliente.ExecutarPeriodicamente<INotificarAlunosFaltososBimestreUseCase>(c => c.Executar(), Cron.Daily(3));

            Cliente.ExecutarPeriodicamente<ISincronizarAulasInfantilUseCase>(c => c.Executar(), Cron.Daily(6));

            // Executa as 04am (vai ser ajustado o UTC corretamente depois no hangfire)
            //Cliente.ExecutarPeriodicamente<IExecutaPendenciaAulaUseCase>(c => c.Executar(), Cron.Daily(4));

            //Cliente.ExecutarPeriodicamente<IExecutaSincronismoComponentesCurricularesEolUseCase>(c => c.Executar(), Cron.Daily(4));
            Cliente.ExecutarPeriodicamente<ISincronizarComponentesCurricularesEolUseCase>(c => c.Executar(), Cron.Daily(4));

            // Executa as 02:00 
            Cliente.ExecutarPeriodicamente<IPendenciasGeraisUseCase>(c => c.Executar(), Cron.Daily(5));
            Cliente.ExecutarPeriodicamente<IPendenciasAulaUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaPendenciasProfessorAvaliacaoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaPendenciasAusenciaFechamentoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoResultadoInsatisfatorioUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAndamentoFechamentoUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoUeFechamentosInsuficientesUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoReuniaoPedagogicaUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            Cliente.ExecutarPeriodicamente<IPublicarPendenciaAusenciaRegistroIndividualUseCase>(c => c.Executar(), Cron.Daily(2));

            // de segunda a sexta as 11 horas
            //Cliente.ExecutarPeriodicamente<IExecutaTrataNotificacoesNiveisCargosUseCase>(c => c.Executar(), "0 14 * * 1-5");
            Cliente.ExecutarPeriodicamente<ITratarNotificacoesNiveisCargosUseCase>(c => c.Executar(), "0 14 * * 1-5");

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoInicioFimPeriodoFechamentoUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoFrequenciaUeUseCase>(c => c.Executar(), Cron.Daily(5, 15));

            //Cliente.ExecutarPeriodicamente<IRemoveConexaoIdleUseCase>(c => c.Executar(), Cron.MinuteInterval(30));

            //Cliente.ExecutarPeriodicamente<IExecutarSyncGeralGoogleClassroomUseCase>(c => c.Executar(), Cron.Daily(11));
            Cliente.ExecutarPeriodicamente<ISyncGeralGoogleClassroomUseCase>(c => c.Executar(), Cron.Daily(11));

            //Cliente.ExecutarPeriodicamente<IExecutaSyncGsaGoogleClassroomUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Sunday, 10));
            Cliente.ExecutarPeriodicamente<ISyncGsaGoogleClassroomUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Sunday, 10));

            Cliente.ExecutarPeriodicamente<IExecutaEncerramentoPlanoAEEEstudantesInativosUseCase>(c => c.Executar(), Cron.Daily(8));

            Cliente.ExecutarPeriodicamente<IExecutaPendenciaValidadePlanoAEEUseCase>(c => c.Executar(), Cron.Daily(8));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPlanoAEEExpiradoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPlanoAEEEmAbertoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoInstitucionalSyncUseCase>(c => c.Executar(), Cron.Daily(13));

            Cliente.ExecutarPeriodicamente<IExecutarConsolidacaoMatriculaTurmasUseCase>(c => c.Executar(), Cron.Daily(10));

            Cliente.ExecutarPeriodicamente<IExecutarConsolidacaoFrequenciaTurmaSyncUseCase>(c => c.Executar(), Cron.Daily(17));

            Cliente.ExecutarPeriodicamente<IExecutarConsolidacaoRegistrosPedagogicosUseCase>(c => c.Executar(), Cron.Daily(6));

            Cliente.ExecutarPeriodicamente<IConsolidacaoDiariosBordoTurmasUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Saturday, 23));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoAulasRegenciaAutomaticasUseCase>(c => c.Executar(), Cron.Daily(9));

            Cliente.ExecutarPeriodicamente<IConciliacaoFrequenciaTurmasCronUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Saturday, 23));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            // Consolidação Acompanhamento Aprendizagem do Aluno
            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            Cliente.ExecutarPeriodicamente<IRotasAgendamentoSyncUseCase>(c => c.Executar(), Cron.Daily(10));

           

            //ToDo: Eduardo - Verificar regra, esta dando erro de validação no PublicarFilaSerapEstudantesCommand
            //Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesProvasUseCase>(c => c.Executar(), Cron.Daily(1));

            Cliente.ExecutarPeriodicamente<IExecutarRemoverAtribuicaoPendenciaUsuariosUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutarVarreduraFechamentosEmProcessamentoPendentes>(c => c.Executar(), Cron.Daily(2));

            Cliente.ExecutarPeriodicamente<IEncerrarEncaminhamentoAEEAutomaticoSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            //TODO: Pendencia Devolutiva 1 Vez ao Dia a noite 
            Cliente.ExecutarPeriodicamente<IReprocessarDiarioBordoPendenciaDevolutivaUseCase>(c => c.Executar(),Cron.Daily(21));

            // Executar rotina de remoção de responsavéis, uma vez ao dia, a noite às 01:00
            Cliente.ExecutarPeriodicamente<IRemoverAtribuicaoResponsaveisUseCase>(c => c.Executar(), Cron.Daily(1));


            // Executar rotina de notificar aprovação de fechamento nota, uma vez ao dia, às 02:00am
            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAprovacaoFechamentoNotaUseCase>(c => c.Executar(), Cron.Daily(2));
            // Executar rotina de notificar aprovação de nota pos conselho classe, uma vez ao dia, às 02:00am
            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoNotaPosConselhoClasseUseCase>(c => c.Executar(), Cron.Daily(5));
            // Executar rotina de notificar aprovação de pareceres conclusivos conselho de classe, uma vez ao dia, às 02:00am
            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoParecerConclusivoConselhoClasseUseCase>(c => c.Executar(), Cron.Daily(5));
        }

        public static void RegistrarServicosSerap()
        {
            Cliente.ExecutarPeriodicamente<IRabbitDeadletterSerapSyncUseCase>(c => c.Executar(), Cron.MinuteInterval(59));

            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesProvasUseCase>(c => c.Executar(), Cron.Daily(1));
            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesProvasBibUseCase>(c => c.Executar(), Cron.Daily(2));
            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesQuestaoCompletaUseCase>(c => c.Executar(), Cron.Daily(2));
            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesAlunoProvaProficienciaUseCase>(c => c.Executar(), Cron.Daily(2));

            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesSincronizacaoInstUseCase>(c => c.Executar(), Cron.Daily(10));
            Cliente.ExecutarPeriodicamente<IIniciarProcessoFinalizarProvasAutomaticamenteUseCase>(c => c.Executar(), Cron.Daily(23));
            Cliente.ExecutarPeriodicamente<ISincronizacaoUsuarioCoreSsoEAbrangenciaUseCase>(c => c.Executar(), Cron.Daily(10));
        }

        public static void RegistrarServicosSerapAcompanhamento()
        {
            Cliente.ExecutarPeriodicamente<IIniciarSyncAcompanhamentoUseCase>(c => c.Executar(), Cron.Daily(22));
            Cliente.ExecutarPeriodicamente<ITratarDeadletterSerapAcompanhamentoSyncUseCase>(c => c.Executar(), Cron.MinuteInterval(59));
        }
    }
}
