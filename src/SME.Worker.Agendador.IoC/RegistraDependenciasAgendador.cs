﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SME.Worker.Agendador.Aplicacao;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.AtualizarTotalizadoresDePendencia;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Aula.CriacaoAutomatica;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.AulasPrevistas;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ComponentesCurriculares;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.ConectaFormacao.SincronizacaoInstitucionalDre;
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
using SME.Worker.Agendador.Aplicacao.CasosDeUso.FilaTesteRabbitMQ;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia.ConciliacaoFrequenciaTurmas;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia.IdentificarFrequenciaAlunoPresencasMaiorTotalAulas;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.GoogleClassroom;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas.DevolutivaDuplicado;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas.DevolutivaMaisDeUmDiario;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas.DevolutivaSemDiario;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAlunosFaltosos;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAndamentoFechamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoInicioFimPeriodoFechamento;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoPeriodoFechamento;
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
using SME.Worker.Agendador.Aplicacao.CasosDeUso.SerapEstudantes;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.SincronizacaoInstitucional;
using SME.Worker.Agendador.Infra.Contexto;
using SME.Worker.Agendador.IoC.Extensions;
using System;
using SME.Worker.Agendador.Aplicacao.CasosDeUso.Cdep;

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
            RegistrarCasoDeUsoEol(services);
            RegistrarCasosDeUsoSerap(services);
            RegistrarCasosDeUsoSerapAcompanhamento(services);
            RegistrarCasosDeUsoSerapItens(services);
            RegistrarCasoDeUsoMetricas(services);
            RegistrarCasosDeUsoConectaFormacao(services);
            RegistrarCasosDeUsoCdep(services);
        }

        private static void RegistrarCasoDeUsoEol(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IInserirInformacoesListagemListaoEolUseCase, InserirInformacoesListagemListaoEolUseCase>();
            services.TryAddScopedWorkerService<IInserirFuncionariosEolElasticSearchUseCase, InserirFuncionariosEolElasticSearchUseCase>();
            services.TryAddScopedWorkerService<ISincronismoAgrupamentoComponentesTerritorioEolUseCase, SincronizarAgrupamentoComponentesTerritorioEolUseCase>();
            services.TryAddScopedWorkerService<IGerarAbrangenciasPerfisUsuarioElasticSearchUseCase, GerarAbrangenciasPerfisUsuarioElasticSearchUseCase>();
        }

        private static void RegistrarCasoDeUsoMetricas(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IRegistrarMetricaAcessosSGPUseCase, RegistrarMetricaAcessosSGPUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaConselhoClasseDuplicadoUseCase, RegistrarMetricaConselhoClasseDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaConselhoClasseAlunoDuplicadoUseCase, RegistrarMetricaConselhoClasseAlunoDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaConselhoClasseNotaDuplicadoUseCase, RegistrarMetricaConselhoClasseNotaDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaFechamentoTurmaDuplicadoUseCase, RegistrarMetricaFechamentoTurmaDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaFechamentoTurmaDisciplinaDuplicadoUseCase, RegistrarMetricaFechamentoTurmaDisciplinaDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaFechamentoAlunoDuplicadoUseCase, RegistrarMetricaFechamentoAlunoDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaFechamentoNotaDuplicadoUseCase, RegistrarMetricaFechamentoNotaDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaConsolidacaoCCNotaNuloUseCase, RegistrarMetricaConsolidacaoCCNotaNuloUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaDuplicacaoConsolidacaoCCAlunoTurmaUseCase, RegistrarMetricaDuplicacaoConsolidacaoCCAlunoTurmaUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaDuplicacaoConsolidacaoCCNotaUseCase, RegistrarMetricaDuplicacaoConsolidacaoCCNotaUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaConselhoClasseNaoConsolidadoUseCase, RegistrarMetricaConselhoClasseNaoConsolidadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaFrequenciaAlunoInconsistenteUseCase, RegistrarMetricaFrequenciaAlunoInconsistenteUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaFrequenciaAlunoDuplicadoUseCase, RegistrarMetricaFrequenciaAlunoDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaRegistroFrequenciaDuplicadoUseCase, RegistrarMetricaRegistroFrequenciaDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaRegistroFrequenciaAlunoDuplicadoUseCase, RegistrarMetricaRegistroFrequenciaAlunoDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaConsolidacaoFrequenciaAlunoMensalInconsistenteUseCase, RegistrarMetricaConsolidacaoFrequenciaAlunoMensalInconsistenteUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaDiarioBordoDuplicadoUseCase, RegistrarMetricaDiarioBordoDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaRegistrosFrequenciaUseCase, RegistrarMetricaRegistrosFrequenciaUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaDiariosBordoUseCase, RegistrarMetricaDiariosBordoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaDevolutivasDiarioBordoUseCase, RegistrarMetricaDevolutivasDiarioBordoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaAulasCJUseCase, RegistrarMetricaAulasCJUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaEncaminhamentosAEEUseCase, RegistrarMetricaEncaminhamentosAEEUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaPlanosAEEUseCase, RegistrarMetricaPlanosAEEUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaPlanosAulaUseCase, RegistrarMetricaPlanosAulaUseCase>();
            services.TryAddScopedWorkerService<IRegistrarDevolutivaDuplicadoUseCase, RegistrarDevolutivaDuplicadoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarDevolutivaMaisDeUmaNoDiarioUseCase, RegistrarDevolutivaMaisDeUmaNoDiarioUseCase>();
            services.TryAddScopedWorkerService<IRegistrarDevolutivaSemDiarioUseCase, RegistrarDevolutivaSemDiarioUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaFechamentosNotaUseCase, RegistrarMetricaFechamentosNotaUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaConselhosClasseAlunoUseCase, RegistrarMetricaConselhosClasseAlunoUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaFechamentosTurmaDisciplinaUseCase, RegistrarMetricaFechamentosTurmaDisciplinaUseCase>();
            services.TryAddScopedWorkerService<IRegistrarMetricaAulasSemAtribuicoesSubstituicoesUseCase, RegistrarMetricaAulasSemAtribuicoesSubstituicoesUseCase>();
        }

        private static void RegistrarCasosDeUsoSerap(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<ISyncSerapEstudantesProvasUseCase, SyncSerapEstudantesProvasUseCase>();
            services.TryAddScopedWorkerService<ISyncSerapEstudantesProvasBibUseCase, SyncSerapEstudantesProvasBibUseCase>();
            services.TryAddScopedWorkerService<ISyncSerapEstudantesProvasTaiUseCase, SyncSerapEstudantesProvasTaiUseCase>();
            services.TryAddScopedWorkerService<ISyncSerapEstudantesQuestaoCompletaUseCase, SyncSerapEstudantesQuestaoCompletaUseCase>();
            services.TryAddScopedWorkerService<ISyncSerapEstudantesAlunoProvaProficienciaUseCase, SyncSerapEstudantesAlunoProvaProficienciaUseCase>();
            services.TryAddScopedWorkerService<ISyncSerapEstudantesSincronizacaoInstUseCase, SyncSerapEstudantesSincronizacaoInstUseCase>();
            services.TryAddScopedWorkerService<IIniciarProcessoFinalizarProvasAutomaticamenteUseCase, IniciarProcessoFinalizarProvasAutomaticamenteUseCase>();
            services.TryAddScopedWorkerService<ISincronizacaoUsuarioCoreSsoEAbrangenciaUseCase, SincronizacaoUsuarioCoreSsoEAbrangenciaUseCase>();
            services.TryAddScopedWorkerService<IWebPushTestSyncUseCase, WebPushTestSyncUseCase>();
            services.TryAddScopedWorkerService<IPropagarCacheUseCase, PropagarCacheUseCase>();
        }

        private static void RegistrarCasosDeUsoSerapAcompanhamento(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IIniciarSyncAcompanhamentoUseCase, IniciarSyncAcompanhamentoUseCase>();
        }

        private static void RegistrarCasosDeUsoSerapItens(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IIniciarImportacoesSerapItensUseCase, IniciarImportacoesSerapItensUseCase>();
        }

        private static void RegistrarCasosDeUsoConectaFormacao(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<ISincronizacaoInstitucionalDreConectaFormacaoUseCase, SincronizacaoInstitucionalDreConectaFormacaoUseCase>();
            services.TryAddScopedWorkerService<IEncerrarInscricoesAutomaticamenteUseCase, EncerrarInscricoesAutomaticamenteUseCase>();
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
            services.TryAddScopedWorkerService<IExecutaNotificacaoAprovacaoFechamentoNotaUseCase, ExecutaNotificacaoAprovacaoFechamentoNotaUseCase>();
            services.TryAddScopedWorkerService<IPublicarPendenciaAusenciaRegistroIndividualUseCase, PublicarPendenciaAusenciaRegistroIndividualUseCase>();
            services.TryAddScopedWorkerService<ITratarNotificacoesNiveisCargosUseCase, TratarNotificacoesNiveisCargosUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoInicioFimPeriodoFechamentoUseCase, ExecutaNotificacaoInicioFimPeriodoFechamentoUseCase>();
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
            services.TryAddScopedWorkerService<IIdentificarFrequenciaAlunoPresencasMaiorTotalAulasUseCase, IdentificarFrequenciaAlunoPresencasMaiorTotalAulasUseCase>();
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
            services.TryAddScopedWorkerService<IRemoverAtribuicaoResponsaveisUseCase, RemoverAtribuicaoResponsaveisUseCase>();

            services.TryAddScopedWorkerService<IExecutaNotificacaoNotaPosConselhoClasseUseCase, ExecutaNotificacaoNotaPosConselhoClasseUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoParecerConclusivoConselhoClasseUseCase, ExecutaNotificacaoParecerConclusivoConselhoClasseUseCase>();

            services.TryAddScopedWorkerService<IAtualizarInformacoesDoEncaminhamentoNAAPA, AtualizarInformacoesDoEncaminhamentoNAAPA>();
            services.TryAddScopedWorkerService<IExcluirPendenciaCalendarioAnoAnteriorUseCase, ExcluirPendenciaCalendarioAnoAnteriorUseCase>();
            services.TryAddScopedWorkerService<IRemoverPendenciasNoFinalDoAnoLetivoUseCase, RemoverPendenciasNoFinalDoAnoLetivoUseCase>();
            services.TryAddScopedWorkerService<IAtualizarTotalizadoresDePendenciaUseCase, AtualizarTotalizadoresDePendenciaUseCase>();
            services.TryAddScopedWorkerService<IAtualizarCargaDashboardConsolidadoEncaminhamentoNAAPA, AtualizarCargaDashboardConsolidadoEncaminhamentoNAAPA>();
            services.TryAddScopedWorkerService<INotificarInatividadeDoAtendimentoNAAPAUseCase, NotificarInatividadeDoAtendimentoNAAPAUseCase>();

            services.TryAddScopedWorkerService<IAtualizarInformacoesDoPlanoAEE, AtualizarInformacoesDoPlanoAEE>();
            services.TryAddScopedWorkerService<IAtualizarPlanoAEETurmaAlunoUseCase, AtualizarPlanoAEETurmaAlunoUseCase>();
            services.TryAddScopedWorkerService<IAtualizarEncaminhamentoAEETurmaAlunoUseCase, AtualizarEncaminhamentoAEETurmaAlunoUseCase>();
            services.TryAddScopedWorkerService<ISincronismoAgrupamentoComponentesTerritorioEolUseCase, SincronizarAgrupamentoComponentesTerritorioEolUseCase>();
            services.TryAddScopedWorkerService<IGerarCacheAtribuicaoResponsaveisUseCase, GerarCacheAtribuicaoResponsaveisUseCase>();
            services.TryAddScopedWorkerService<IConsolidacaoReflexoFrequenciaBuscaAtivaUseCase, ConsolidacaoReflexoFrequenciaBuscaAtivaUseCase>();
            
            services.TryAddScopedWorkerService<IExecutarExclusaoDasNotificacoesUseCase, ExecutarExclusaoDasNotificacoesUseCase>();
            services.TryAddScopedWorkerService<INotificarFreqMinimaMensalInsuficienteAlunoBuscaAtivaUseCase, NotificarFreqMinimaMensalInsuficienteAlunoBuscaAtivaUseCase>();

            services.TryAddScopedWorkerService<Infra.Interfaces.IContextoAplicacao, WorkerContext>();
        }
        
        private static void RegistrarCasosDeUsoCdep(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IExecutarAtualizacaoSituacaoParaEmprestimoComDevolucaoEmAtrasoUseCase, ExecutarAtualizacaoSituacaoParaEmprestimoComDevolucaoEmAtrasoUseCase>();
            services.TryAddScopedWorkerService<INotificacaoVencimentoEmprestimoUseCase, NotificacaoVencimentoEmprestimoUseCase>();
            services.TryAddScopedWorkerService<INotificacaoDevolucaoEmprestimoAtrasadoUseCase, NotificacaoDevolucaoEmprestimoAtrasadoUseCase>();
            services.TryAddScopedWorkerService<INotificacaoDevolucaoEmprestimoAtrasoProlongadoUseCase, NotificacaoDevolucaoEmprestimoAtrasoProlongadoUseCase>();
        }

        private static void ResgistraDependenciaHttp(IServiceCollection services)
        {
            /// Este método não deveria existir, as dependencias dos objetos abaixo deveriam ser encapsuladas em um contexto da aplicação para serem utilizadas pela WebApi e WorkserService independentemente
            //services.TryAddScopedWorkerService<System.Net.Http.HttpClient>();
            services.TryAddScopedWorkerService<Microsoft.AspNetCore.Http.IHttpContextAccessor, NoHttpContext>();
        }
    }
}
