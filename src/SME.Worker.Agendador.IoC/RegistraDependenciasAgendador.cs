using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
using SME.Worker.Agendador.Aplicacao.CasosDeUso.FilaTesteRabbitMQ;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia.ConciliacaoFrequenciaTurmas;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.GoogleClassroom;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAlunosFaltosos;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAndamentoFechamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoFrequenciaUe;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoInicioFimPeriodoFechamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoPeriodoFechamento;
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
using SME.Worker.Agendador.Aplicacao.CasosDeUso.RabbitDeadletter;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.RotasAgendamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.SerapEstudantes;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.SincronizacaoInstitucional;
using SME.Worker.Agendador.Infra.Contexto;
using SME.Worker.Agendador.IoC.Extensions;
using System;

namespace SME.Worker.Agendador.IoC
{
    public static class RegistraDependenciasWorkerServices
    {
        public static void Registrar(IServiceCollection services)
        {
            RegistrarMediator(services);
            ResgistraDependenciaHttp(services);
            RegistrarContextos(services);
            RegistrarCasosDeUso(services);
        }

        private static void RegistrarMediator(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("SME.Worker.Agendador.Aplicacao");
            services.AddMediatR(assembly);
        }

        private static void RegistrarContextos(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<Infra.Interfaces.IContextoAplicacao, WorkerContext>();
        }

        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            RegistrarCasosDeUsoSgp(services);
            RegistrarCasosDeUsoSerap(services);
        }

        private static void RegistrarCasosDeUsoSerap(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IRabbitDeadletterSerapSyncUseCase, RabbitDeadletterSerapSyncUseCase>();

            services.TryAddScopedWorkerService<ISyncSerapEstudantesProvasUseCase, SyncSerapEstudantesProvasUseCase>();
            services.TryAddScopedWorkerService<ISyncSerapEstudantesProvasBibUseCase, SyncSerapEstudantesProvasBibUseCase>();
            services.TryAddScopedWorkerService<ISyncSerapEstudantesQuestaoCompletaUseCase, SyncSerapEstudantesQuestaoCompletaUseCase>();
            services.TryAddScopedWorkerService<ISyncSerapEstudantesAlunoProvaProficienciaUseCase, SyncSerapEstudantesAlunoProvaProficienciaUseCase>();

            services.TryAddScopedWorkerService<ISyncSerapEstudantesSincronizacaoInstUseCase, SyncSerapEstudantesSincronizacaoInstUseCase>();
            services.TryAddScopedWorkerService<IIniciarProcessoFinalizarProvasAutomaticamenteUseCase, IniciarProcessoFinalizarProvasAutomaticamenteUseCase>();
            services.TryAddScopedWorkerService<ISincronizacaoUsuarioCoreSsoEAbrangenciaUseCase, SincronizacaoUsuarioCoreSsoEAbrangenciaUseCase>();
        }

        private static void RegistrarCasosDeUsoSgp(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<INotifificarRegistroFrequenciaUseCase, NotifificarRegistroFrequenciaUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoAulasPrevistasUseCase, ExecutaNotificacaoAulasPrevistasUseCase>();
            services.TryAddScopedWorkerService<ISincronizarObjetivosComJuremaUseCase, SincronizarObjetivosComJuremaUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoAlunosFaltososUseCase, ExecutaNotificacaoAlunosFaltososUseCase>();
            services.TryAddScopedWorkerService<INotificarAlunosFaltososBimestreUseCase, NotificarAlunosFaltososBimestreUseCase>();
            services.TryAddScopedWorkerService<ISincronizarAulasInfantilUseCase, SincronizarAulasInfantilUseCase>();
            services.TryAddScopedWorkerService<ISincronizarComponentesCurricularesEolUseCase, SincronizarComponentesCurricularesEolUseCase>();
            services.TryAddScopedWorkerService<IPendenciasGeraisUseCase, PendenciasGeraisUseCase>();
            services.TryAddScopedWorkerService<IPendenciasAulaUseCase, PendenciasAulaUseCase>();
            services.TryAddScopedWorkerService<IExecutaPendenciasProfessorAvaliacaoUseCase, ExecutaPendenciasProfessorAvaliacaoUseCase>();
            services.TryAddScopedWorkerService<IExecutaPendenciasAusenciaFechamentoUseCase, ExecutaPendenciasAusenciaFechamentoUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoResultadoInsatisfatorioUseCase, ExecutaNotificacaoResultadoInsatisfatorioUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoAndamentoFechamentoUseCase, ExecutaNotificacaoAndamentoFechamentoUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoUeFechamentosInsuficientesUseCase, ExecutaNotificacaoUeFechamentosInsuficientesUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoReuniaoPedagogicaUseCase, ExecutaNotificacaoReuniaoPedagogicaUseCase>();
            services.TryAddScopedWorkerService<IPublicarPendenciaAusenciaRegistroIndividualUseCase, PublicarPendenciaAusenciaRegistroIndividualUseCase>();
            services.TryAddScopedWorkerService<ITratarNotificacoesNiveisCargosUseCase, TratarNotificacoesNiveisCargosUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoInicioFimPeriodoFechamentoUseCase, ExecutaNotificacaoInicioFimPeriodoFechamentoUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoFrequenciaUeUseCase, ExecutaNotificacaoFrequenciaUeUseCase>();
            services.TryAddScopedWorkerService<ISyncGeralGoogleClassroomUseCase, SyncGeralGoogleClassroomUseCase>();
            services.TryAddScopedWorkerService<ISyncGsaGoogleClassroomUseCase, SyncGsaGoogleClassroomUseCase>();
            services.TryAddScopedWorkerService<IExecutaEncerramentoPlanoAEEEstudantesInativosUseCase, ExecutaEncerramentoPlanoAEEEstudantesInativosUseCase>();
            services.TryAddScopedWorkerService<IExecutaPendenciaValidadePlanoAEEUseCase, ExecutaPendenciaValidadePlanoAEEUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoPlanoAEEExpiradoUseCase, ExecutaNotificacaoPlanoAEEExpiradoUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoPlanoAEEEmAbertoUseCase, ExecutaNotificacaoPlanoAEEEmAbertoUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalSyncUseCase, ExecutarSincronizacaoEstruturaInstitucionalSyncUseCase>();
            services.TryAddScopedWorkerService<IExecutarConsolidacaoMatriculaTurmasUseCase, ExecutarConsolidacaoMatriculaTurmasUseCase>();
            services.TryAddScopedWorkerService<IConciliacaoFrequenciaTurmasCronUseCase, ConciliacaoFrequenciaTurmasCronUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase, ExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoAulasRegenciaAutomaticasUseCase, ExecutarSincronizacaoAulasRegenciaAutomaticasUseCase>();
            services.TryAddScopedWorkerService<IRabbitDeadletterSgpSyncUseCase, RabbitDeadletterSgpSyncUseCase>();
            services.TryAddScopedWorkerService<IRabbitDeadletterSrSyncUseCase, RabbitDeadletterSrSyncUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase, ExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase, ExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase>();
            services.TryAddScopedWorkerService<IRotasAgendamentoSyncUseCase, RotasAgendamentoSyncUseCase>();

            services.TryAddScopedWorkerService<IExecutarConsolidacaoFrequenciaTurmaSyncUseCase, ExecutarConsolidacaoFrequenciaTurmaSyncUseCase>();
            services.TryAddScopedWorkerService<IConsolidacaoDiariosBordoTurmasUseCase, ConsolidacaoDiariosBordoTurmasUseCase>();
            services.TryAddScopedWorkerService<IExecutarConsolidacaoRegistrosPedagogicosUseCase, ExecutarConsolidacaoRegistrosPedagogicosUseCase>();
            services.TryAddScopedWorkerService<IExecutarRemoverAtribuicaoPendenciaUsuariosUseCase, ExecutarRemoverAtribuicaoPendenciaUsuariosUseCase>();
            services.TryAddScopedWorkerService<IExecutarVarreduraFechamentosEmProcessamentoPendentes, ExecutarVarreduraFechamentosEmProcessamentoPendentes>();
            services.TryAddScopedWorkerService<IEncerrarEncaminhamentoAEEAutomaticoSyncUseCase, EncerrarEncaminhamentoAEEAutomaticoSyncUseCase>();
            services.TryAddScopedWorkerService<IFilaTesteRabbitMQ, FilaTesteRabbitMQ>();
            services.TryAddScopedWorkerService<IReprocessarDiarioBordoPendenciaDevolutivaUseCase, ReprocessarDiarioBordoPendenciaDevolutivaUseCase>();
            services.TryAddScopedWorkerService<IAtribuicaoResponsaveisUsecase, AtribuicaoResponsaveisUseCase>();

            services.TryAddScopedWorkerService<Infra.Interfaces.IContextoAplicacao, WorkerContext>();
        }

        private static void ResgistraDependenciaHttp(IServiceCollection services)
        {
            /// Este método não deveria existir, as dependencias dos objetos abaixo deveriam ser encapsuladas em um contexto da aplicação para serem utilizadas pela WebApi e WorkserService independentemente
            //services.TryAddScopedWorkerService<System.Net.Http.HttpClient>();
            services.TryAddScopedWorkerService<Microsoft.AspNetCore.Http.IHttpContextAccessor, NoHttpContext>();
        }
    }
}
