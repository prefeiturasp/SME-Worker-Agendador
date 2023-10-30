using Hangfire;
using SME.Worker.Agendador.Aplicacao;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.AtualizarTotalizadoresDePendencia;
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
using SME.Worker.Agendador.Aplicacao.CasosDeUso.EncaminhamentoAEE;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.EncaminhamentoNAAPA;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.EncerrarEncaminhamentoAeeAutomatico;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia.ConciliacaoFrequenciaTurmas;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia.IdentificarFrequenciaAlunoPresencasMaiorTotalAulas;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAlunosFaltosos;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAndamentoFechamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoInicioFimPeriodoFechamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoResultadoInsatisfatorio;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoReuniaoPedagogica;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoUeFechamentosInsuficientes;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacoesNiveisCargos;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ObjetivoAprendizagem;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaAusenciaFechamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaCalendarioUe.ExcluirPendenciaCalendarioAnoAnterior;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaPerfilUsuario;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaProfessor;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaRegistroIndividual;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciasAula;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciasGerais;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciasGerais.RemoverPendencias;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.PlanoAEE;
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
            RegistrarServicosSerapItens();
        }
        
        private static void RegistrarServicoEol()
        {
            Cliente.ExecutarPeriodicamente<IInserirInformacoesListagemListaoEolUseCase>(c => c.Executar(), Cron.Daily(8, 30));
            Cliente.ExecutarPeriodicamente<IInserirFuncionariosEolElasticSearchUseCase>(c => c.Executar(), Cron.Daily(8, 30));
            // Executar rotina de atualizar carga agrupamentos atribuições de componentes território saber, uma vez ao dia, às 05:30am
            Cliente.ExecutarPeriodicamente<ISincronismoAgrupamentoComponentesTerritorioEolUseCase>(c => c.Executar(), Cron.Daily(8, 30));
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

            //Cliente.ExecutarPeriodicamente<IRemoveConexaoIdleUseCase>(c => c.Executar(), Cron.MinuteInterval(30));

            //Encerramnto de planos diariamente às 22 horas
            Cliente.ExecutarPeriodicamente<IExecutaEncerramentoPlanoAEEEstudantesInativosUseCase>(c => c.Executar(), "0 01 * * *");

            Cliente.ExecutarPeriodicamente<IExecutaPendenciaValidadePlanoAEEUseCase>(c => c.Executar(), Cron.Daily(8));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPlanoAEEExpiradoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoPlanoAEEEmAbertoUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoInstitucionalSyncUseCase>(c => c.Executar(), Cron.Daily(9, 30));

            Cliente.ExecutarPeriodicamente<IExecutarConsolidacaoMatriculaTurmasUseCase>(c => c.Executar(), Cron.Daily(10));

            Cliente.ExecutarPeriodicamente<IExecutarConsolidacaoFrequenciaTurmaSyncUseCase>(c => c.Executar(), Cron.Daily(17));

            Cliente.ExecutarPeriodicamente<IExecutarConsolidacaoRegistrosPedagogicosUseCase>(c => c.Executar(), Cron.Daily(6));

            Cliente.ExecutarPeriodicamente<IConsolidacaoDiariosBordoTurmasUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Saturday, 23));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase>(c => c.Executar(), Cron.Daily(7));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoAulasRegenciaAutomaticasUseCase>(c => c.Executar(), Cron.Daily(9));

            Cliente.ExecutarPeriodicamente<IConciliacaoFrequenciaTurmasCronUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Saturday, 23));

            Cliente.ExecutarPeriodicamente<IIdentificarFrequenciaAlunoPresencasMaiorTotalAulasUseCase>(c => c.Executar(), Cron.Weekly(System.DayOfWeek.Monday, 18));

            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            // Consolidação Acompanhamento Aprendizagem do Aluno
            Cliente.ExecutarPeriodicamente<IExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            Cliente.ExecutarPeriodicamente<IRotasAgendamentoSyncUseCase>(c => c.Executar(), Cron.Daily(10));           

            Cliente.ExecutarPeriodicamente<IExecutarRemoverAtribuicaoPendenciaUsuariosUseCase>(c => c.Executar(), Cron.Daily(5));

            Cliente.ExecutarPeriodicamente<IExecutarVarreduraFechamentosEmProcessamentoPendentes>(c => c.Executar(), Cron.Daily(2));

            Cliente.ExecutarPeriodicamente<IEncerrarEncaminhamentoAEEAutomaticoSyncUseCase>(c => c.Executar(), Cron.Daily(9));

            //TODO: Pendencia Devolutiva 1 Vez ao Dia a noite 
            Cliente.ExecutarPeriodicamente<IReprocessarDiarioBordoPendenciaDevolutivaUseCase>(c => c.Executar(),Cron.Daily(21));

            // Executar rotina de remoção de responsavéis, uma vez ao dia, às 10:30
            Cliente.ExecutarPeriodicamente<IRemoverAtribuicaoResponsaveisUseCase>(c => c.Executar(), Cron.Daily(10, 30));


            // Executar rotina de notificar aprovação de fechamento nota, uma vez ao dia, às 02:00am
            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoAprovacaoFechamentoNotaUseCase>(c => c.Executar(), Cron.Daily(2));
            // Executar rotina de notificar aprovação de nota pos conselho classe, uma vez ao dia, às 02:00am
            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoNotaPosConselhoClasseUseCase>(c => c.Executar(), Cron.Daily(5));
            // Executar rotina de notificar aprovação de pareceres conclusivos conselho de classe, uma vez ao dia, às 02:00am
            Cliente.ExecutarPeriodicamente<IExecutaNotificacaoParecerConclusivoConselhoClasseUseCase>(c => c.Executar(), Cron.Daily(5));
            // Executar rotina de atualizar as informações do encaminhamento NAAPA, uma vez ao dia, às 07:00am
            Cliente.ExecutarPeriodicamente<IAtualizarInformacoesDoEncaminhamentoNAAPA>(c => c.Executar(), Cron.Daily(10));

            //Executa rotina de exclusão de pendencia calendario no primeiro dia do ano às 00:00am
            Cliente.ExecutarPeriodicamente<IExcluirPendenciaCalendarioAnoAnteriorUseCase>(c => c.Executar(),Cron.Yearly(1,1,3));
            //Executa rotina de exclusão de pendência no primeiro dia do ano às 00:00am
            Cliente.ExecutarPeriodicamente<IRemoverPendenciasNoFinalDoAnoLetivoUseCase>(c => c.Executar(), Cron.Yearly(1, 1, 3));

            // Executar rotina de atualizar do totalizadores de pendências, uma vez ao dia, às 07:00am
            Cliente.ExecutarPeriodicamente<IAtualizarTotalizadoresDePendenciaUseCase>(c => c.Executar(), Cron.Daily(10));

            // Executar rotina de atualizar carga dashboard consolidado NAAPA, uma vez ao dia, às 05:00am
            Cliente.ExecutarPeriodicamente<IAtualizarCargaDashboardConsolidadoEncaminhamentoNAAPA>(c => c.Executar(), Cron.Daily(8));

            // Executar rotina de atualizar as informações do plano AEE, uma vez ao dia, às 07:00am
            Cliente.ExecutarPeriodicamente<IAtualizarInformacoesDoPlanoAEE>(c => c.Executar(), Cron.Daily(10));

            // Executar rotina de atualizar as turmas regular e SRM ativas do aluno no plano AEE, uma vez ao dia, às 07:00am
            Cliente.ExecutarPeriodicamente<IAtualizarPlanoAEETurmaAlunoUseCase>(c => c.Executar(), Cron.Daily(10));

            // Executar rotina de atualizar as turmas regular e SRM ativas do aluno no encaminhamento AEE, uma vez ao dia, às 07:00am
            Cliente.ExecutarPeriodicamente<IAtualizarEncaminhamentoAEETurmaAlunoUseCase>(c => c.Executar(), Cron.Daily(10));

            // Executar rotina de noficação de inatividade do atendimento do encaminhamento naapa, uma vez ao dia, às 07:00am
            Cliente.ExecutarPeriodicamente<INotificarInatividadeDoAtendimentoNAAPAUseCase>(c => c.Executar(), Cron.Daily(10));
        }

        public static void RegistrarServicosSerap()
        {
            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesProvasUseCase>(c => c.Executar(), Cron.Daily(1));
            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesSincronizacaoInstUseCase>(c => c.Executar(), Cron.Daily(7));
            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesProvasBibUseCase>(c => c.Executar(), Cron.Daily(8));
            // TODO: Por hora, manter manualmente pelo Rabbit Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesProvasTaiUseCase>(c => c.Executar(), Cron.Daily(2));
            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesQuestaoCompletaUseCase>(c => c.Executar(), Cron.Daily(2));
            Cliente.ExecutarPeriodicamente<ISyncSerapEstudantesAlunoProvaProficienciaUseCase>(c => c.Executar(), Cron.Daily(2));
            Cliente.ExecutarPeriodicamente<IIniciarProcessoFinalizarProvasAutomaticamenteUseCase>(c => c.Executar(), Cron.Daily(1));
            Cliente.ExecutarPeriodicamente<ISincronizacaoUsuarioCoreSsoEAbrangenciaUseCase>(c => c.Executar(), Cron.Daily(8));
            Cliente.ExecutarPeriodicamente<IWebPushTestSyncUseCase>(c => c.Executar(), "0 */6 * * *");
        }

        public static void RegistrarServicosSerapAcompanhamento()
        {
            Cliente.ExecutarPeriodicamente<IIniciarSyncAcompanhamentoUseCase>(c => c.Executar(), Cron.Daily(3));
        }

        public static void RegistrarServicosSerapItens()
        {
            Cliente.ExecutarPeriodicamente<IIniciarImportacoesSerapItensUseCase>(c => c.Executar(), Cron.Daily(23));
        }
    }
}
