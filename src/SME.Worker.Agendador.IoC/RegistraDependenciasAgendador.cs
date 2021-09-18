using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SME.Worker.Agendador.Aplicacao;
using SME.Worker.Agendador.Dominio.CasosDeUso.Aula.CriacaoAutomatica;
using SME.Worker.Agendador.Dominio.CasosDeUso.AulasPrevistas;
using SME.Worker.Agendador.Dominio.CasosDeUso.ComponentesCurriculares;
using SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoAcompanhamentoAprendizagemAluno;
using SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoDevolutivas;
using SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoFrequenciaTurma;
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
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacoesPipeline<,>));
        }

        private static void RegistrarContextos(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<Infra.Interfaces.IContextoAplicacao, WorkerContext>();
        }



        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<INotifificarRegistroFrequenciaUseCase, NotifificarRegistroFrequenciaUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoAulasPrevistasUseCase, ExecutaNotificacaoAulasPrevistasUseCase>();
            services.TryAddScopedWorkerService<ISincronizarObjetivosComJuremaUseCase, SincronizarObjetivosComJuremaUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoAlunosFaltososUseCase, ExecutaNotificacaoAlunosFaltososUseCase>();
            services.TryAddScopedWorkerService<INotificarAlunosFaltososBimestreUseCase, NotificarAlunosFaltososBimestreUseCase>();
            services.TryAddScopedWorkerService<ISincronizarAulasInfantilUseCase, SincronizarAulasInfantilUseCase>();
            services.TryAddScopedWorkerService<ISincronizarComponentesCurricularesEolUseCase, SincronizarComponentesCurricularesEolUseCase>();
            services.TryAddScopedWorkerService<IPendenciasGeraisUseCase, PendenciasGeraisUseCase>();
            services.TryAddScopedWorkerService<IExecutaPendenciasProfessorAvaliacaoUseCase, ExecutaPendenciasProfessorAvaliacaoUseCase>();
            services.TryAddScopedWorkerService<IExecutaPendenciasAusenciaFechamentoUseCase, ExecutaPendenciasAusenciaFechamentoUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoResultadoInsatisfatorioUseCase, ExecutaNotificacaoResultadoInsatisfatorioUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoAndamentoFechamentoUseCase, ExecutaNotificacaoAndamentoFechamentoUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoUeFechamentosInsuficientesUseCase, ExecutaNotificacaoUeFechamentosInsuficientesUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoReuniaoPedagogicaUseCase, ExecutaNotificacaoReuniaoPedagogicaUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoPeriodoFechamentoUseCase, ExecutaNotificacaoPeriodoFechamentoUseCase>();
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
            services.TryAddScopedWorkerService<ISyncSerapEstudantesProvasUseCase, SyncSerapEstudantesProvasUseCase>();
            services.TryAddScopedWorkerService<IExecutarConsolidacaoFrequenciaTurmaSyncUseCase, ExecutarConsolidacaoFrequenciaTurmaSyncUseCase>();
        }

        private static void ResgistraDependenciaHttp(IServiceCollection services)
        {
            /// Este método não deveria existir, as dependencias dos objetos abaixo deveriam ser encapsuladas em um contexto da aplicação para serem utilizadas pela WebApi e WorkserService independentemente
            //services.TryAddScopedWorkerService<System.Net.Http.HttpClient>();
            services.TryAddScopedWorkerService<Microsoft.AspNetCore.Http.IHttpContextAccessor, NoHttpContext>();
        }
    }
}
