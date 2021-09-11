using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.SGP.Aplicacao;
using SME.SGP.Aplicacao.CasosDeUso;
using SME.SGP.Aplicacao.Consultas;
using SME.SGP.Aplicacao.Integracoes;
using SME.SGP.Aplicacao.Interfaces;
using SME.SGP.Aplicacao.Interfaces.CasosDeUso;
using SME.SGP.Aplicacao.Pipelines;
using SME.SGP.Aplicacao.Servicos;
using SME.SGP.Dados;
using SME.SGP.Dados.Contexto;
using SME.SGP.Dados.Repositorios;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Interfaces;
using SME.SGP.Dominio.Interfaces.Repositorios;
using SME.SGP.Dominio.Servicos;
using SME.SGP.Infra;
using SME.SGP.Infra.Interfaces;
using SME.Worker.Agendador.Infra.Contexto;
using SME.Worker.Agendador.Infra.Interfaces;
using SME.Worker.Agendador.IoC.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.IoC
{
    public class RepositorioTestePostgre : IRepositorioTestePostgre
    {
        public Task<bool> Exists(long id, string coluna = null) => throw new System.NotImplementedException();
        public IEnumerable<Ciclo> Listar() => throw new System.NotImplementedException();
        public Ciclo ObterPorId(long id) => throw new System.NotImplementedException();
        public Task<Ciclo> ObterPorIdAsync(long id) => throw new System.NotImplementedException();
        public void Remover(long id) => throw new System.NotImplementedException();
        public void Remover(Ciclo entidade) => throw new System.NotImplementedException();
        public Task RemoverAsync(Ciclo entidade) => throw new System.NotImplementedException();
        public Task<long> RemoverLogico(long id, string coluna = null) => throw new System.NotImplementedException();
        public long Salvar(Ciclo entidade) => throw new System.NotImplementedException();
        public Task<long> SalvarAsync(Ciclo entidade) => throw new System.NotImplementedException();
    }

    public class RegistraDependenciasAgendador
    {

        public static void Registrar(IServiceCollection services)
        {
            RegistrarMediator(services);

            ResgistraDependenciaHttp(services);
            RegistrarRepositorios(services);
            RegistrarContextos(services);
            RegistrarComandos(services);
            RegistrarConsultas(services);
            RegistrarServicos(services);
            RegistrarCasosDeUso(services);

            //RegistrarRepositorios(services);
            //RegistrarRepositoriosAplicacao(services);

            services.TryAddScopedWorkerService<IRepositorioTestePostgre, RepositorioTestePostgre>();
        }

        private static void RegistrarRepositoriosLocal(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IRepositorioAbrangencia, RepositorioAbrangencia>();
            services.TryAddScopedWorkerService<IRepositorioAtividadeAvaliativa, RepositorioAtividadeAvaliativa>();
            services.TryAddScopedWorkerService<IRepositorioAtividadeAvaliativaDisciplina, RepositorioAtividadeAvaliativaDisciplina>();
            services.TryAddScopedWorkerService<IRepositorioAtividadeAvaliativaRegencia, RepositorioAtividadeAvaliativaRegencia>();
            services.TryAddScopedWorkerService<IRepositorioAtribuicaoCJ, RepositorioAtribuicaoCJ>();
            services.TryAddScopedWorkerService<IRepositorioAtribuicaoEsporadica, RepositorioAtribuicaoEsporadica>();
            services.TryAddScopedWorkerService<IRepositorioAula, RepositorioAula>();
            services.TryAddScopedWorkerService<IRepositorioAulaPrevista, RepositorioAulaPrevista>();
            services.TryAddScopedWorkerService<IRepositorioAulaPrevistaBimestre, RepositorioAulaPrevistaBimestre>();
            services.TryAddScopedWorkerService<IRepositorioCache, RepositorioCache>();
            services.TryAddScopedWorkerService<IRepositorioCiclo, RepositorioCiclo>();
            services.TryAddScopedWorkerService<IRepositorioComponenteCurricularJurema, RepositorioComponenteCurricularJurema>();
            services.TryAddScopedWorkerService<IRepositorioComponenteCurricular, RepositorioComponenteCurricular>();
            services.TryAddScopedWorkerService<IRepositorioConceito, RepositorioConceito>();
            services.TryAddScopedWorkerService<IRepositorioConfiguracaoEmail, RepositorioConfiguracaoEmail>();
            services.TryAddScopedWorkerService<IRepositorioDre, RepositorioDre>();
            services.TryAddScopedWorkerService<IRepositorioEvento, RepositorioEvento>();
            services.TryAddScopedWorkerService<IRepositorioEventoMatricula, RepositorioEventoMatricula>();
            services.TryAddScopedWorkerService<IRepositorioFeriadoCalendario, RepositorioFeriadoCalendario>();
            services.TryAddScopedWorkerService<IRepositorioFrequencia, RepositorioFrequencia>();
            services.TryAddScopedWorkerService<IRepositorioFrequenciaAlunoDisciplinaPeriodo, RepositorioFrequenciaAlunoDisciplinaPeriodo>();
            services.TryAddScopedWorkerService<IRepositorioGrade, RepositorioGrade>();
            services.TryAddScopedWorkerService<IRepositorioGradeDisciplina, RepositorioGradeDisciplina>();
            services.TryAddScopedWorkerService<IRepositorioGradeFiltro, RepositorioGradeFiltro>();
            services.TryAddScopedWorkerService<IRepositorioMatrizSaber, RepositorioMatrizSaber>();
            services.TryAddScopedWorkerService<IRepositorioMatrizSaberPlano, RepositorioMatrizSaberPlano>();
            services.TryAddScopedWorkerService<IRepositorioNotaParametro, RepositorioNotaParametro>();
            services.TryAddScopedWorkerService<IRepositorioNotaTipoValor, RepositorioNotaTipoValor>();
            services.TryAddScopedWorkerService<IRepositorioNotasConceitos, RepositorioNotasConceitos>();
            services.TryAddScopedWorkerService<IRepositorioNotificacao, RepositorioNotificacao>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoAulaPrevista, RepositorioNotificacaoAulaPrevista>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoFrequencia, RepositorioNotificacaoFrequencia>();
            services.TryAddScopedWorkerService<IRepositorioObjetivoAprendizagemAula, RepositorioObjetivoAprendizagemAula>();
            services.TryAddScopedWorkerService<IRepositorioObjetivoAprendizagemPlano, RepositorioObjetivoAprendizagemPlano>();
            services.TryAddScopedWorkerService<IRepositorioObjetivoDesenvolvimento, RepositorioObjetivoDesenvolvimento>();
            services.TryAddScopedWorkerService<IRepositorioObjetivoDesenvolvimentoPlano, RepositorioObjetivoDesenvolvimentoPlano>();
            services.TryAddScopedWorkerService<IRepositorioParametrosSistema, RepositorioParametrosSistema>();
            services.TryAddScopedWorkerService<IRepositorioPeriodoEscolar, RepositorioPeriodoEscolar>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAnual, RepositorioPlanoAnual>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAula, RepositorioPlanoAula>();
            services.TryAddScopedWorkerService<IRepositorioPlanoCiclo, RepositorioPlanoCiclo>();
            services.TryAddScopedWorkerService<IRepositorioPrioridadePerfil, RepositorioPrioridadePerfil>();
            services.TryAddScopedWorkerService<IRepositorioRegistroAusenciaAluno, RepositorioRegistroAusenciaAluno>();
            services.TryAddScopedWorkerService<IRepositorioRegistroPoa, RepositorioRegistroPoa>();
            services.TryAddScopedWorkerService<IRepositorioCompensacaoAusencia, RepositorioCompensacaoAusencia>();
            services.TryAddScopedWorkerService<IRepositorioCompensacaoAusenciaAluno, RepositorioCompensacaoAusenciaAluno>();
            services.TryAddScopedWorkerService<IRepositorioCompensacaoAusenciaDisciplinaRegencia, RepositorioCompensacaoAusenciaDisciplinaRegencia>();
            services.TryAddScopedWorkerService<IRepositorioSupervisorEscolaDre, RepositorioSupervisorEscolaDre>();
            services.TryAddScopedWorkerService<IRepositorioTipoAvaliacao, RepositorioTipoAvaliacao>();
            services.TryAddScopedWorkerService<IRepositorioTipoCalendario, RepositorioTipoCalendario>();
            services.TryAddScopedWorkerService<IRepositorioTurma, RepositorioTurma>();
            services.TryAddScopedWorkerService<IRepositorioUe, RepositorioUe>();
            services.TryAddScopedWorkerService<IRepositorioUsuario, RepositorioUsuario>();
            services.TryAddScopedWorkerService<IRepositorioWorkflowAprovacao, RepositorioWorkflowAprovacao>();
            services.TryAddScopedWorkerService<IRepositorioWorkflowAprovacaoNivel, RepositorioWorkflowAprovacaoNivel>();
            services.TryAddScopedWorkerService<IRepositorioWorkflowAprovacaoNivelNotificacao, RepositorioWorkflowAprovaNivelNotificacao>();
            services.TryAddScopedWorkerService<IRepositorioWorkflowAprovacaoNivelUsuario, RepositorioWorkflowAprovacaoNivelUsuario>();
            services.TryAddScopedWorkerService<IRepositorioProcessoExecutando, RepositorioProcessoExecutando>();
            services.TryAddScopedWorkerService<IRepositorioPeriodoFechamento, RepositorioPeriodoFechamento>();
            services.TryAddScopedWorkerService<IRepositorioPeriodoFechamentoBimestre, RepositorioPeriodoFechamentoBimestre>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoCompensacaoAusencia, RepositorioNotificacaoCompensacaoAusencia>();
            services.TryAddScopedWorkerService<IRepositorioEventoFechamento, RepositorioEventoFechamento>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoTurmaDisciplina, RepositorioFechamentoTurmaDisciplina>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoNota, RepositorioFechamentoNota>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoReabertura, RepositorioFechamentoReabertura>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoAula, RepositorioNotificacaoAula>();
            services.TryAddScopedWorkerService<IRepositorioHistoricoEmailUsuario, RepositorioHistoricoEmailUsuario>();
            services.TryAddScopedWorkerService<IRepositorioPendencia, RepositorioPendencia>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaFechamento, RepositorioPendenciaFechamento>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaUsuario, RepositorioPendenciaUsuario>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaRegistroIndividual, RepositorioPendenciaRegistroIndividual>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaRegistroIndividualAluno, RepositorioPendenciaRegistroIndividualAluno>();
            services.TryAddScopedWorkerService<IRepositorioSintese, RepositorioSintese>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoAluno, RepositorioFechamentoAluno>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoTurma, RepositorioFechamentoTurma>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasse, RepositorioConselhoClasse>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasseAluno, RepositorioConselhoClasseAluno>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasseAlunoTurmaComplementar, RepositorioConselhoClasseAlunoTurmaComplementar>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasseNota, RepositorioConselhoClasseNota>();
            services.TryAddScopedWorkerService<IRepositorioWfAprovacaoNotaFechamento, RepositorioWfAprovacaoNotaFechamento>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasseRecomendacao, RepositorioConselhoClasseRecomendacao>();
            services.TryAddScopedWorkerService<IRepositorioCicloEnsino, RepositorioCicloEnsino>();
            services.TryAddScopedWorkerService<IRepositorioTipoEscola, RepositorioTipoEscola>();
            services.TryAddScopedWorkerService<IRepositorioRelatorioSemestralTurmaPAP, RepositorioRelatorioSemestralTurmaPAP>();
            services.TryAddScopedWorkerService<IRepositorioRelatorioSemestralPAPAluno, RepositorioRelatorioSemestralPAPAluno>();
            services.TryAddScopedWorkerService<IRepositorioRelatorioSemestralPAPAlunoSecao, RepositorioRelatorioSemestralPAPAlunoSecao>();
            services.TryAddScopedWorkerService<IRepositorioSecaoRelatorioSemestralPAP, RepositorioSecaoRelatorioSemestralPAP>();
            services.TryAddScopedWorkerService<IRepositorioObjetivoAprendizagem, RepositorioObjetivoAprendizagem>();
            services.TryAddScopedWorkerService<IRepositorioCorrelacaoRelatorio, RepositorioCorrelacaoRelatorio>();
            services.TryAddScopedWorkerService<IRepositorioCorrelacaoRelatorioJasper, RepositorioRelatorioCorrelacaoJasper>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoConsolidado, RepositorioFechamentoConsolidado>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasseConsolidado, RepositorioConselhoClasseConsolidado>();
            //services.TryAddScopedWorkerService<IRepositorioTestePostgre, RepositorioTestePostgre>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoReaberturaBimestre, RepositorioFechamentoReaberturaBimestre>();
            services.TryAddScopedWorkerService<IRepositorioHistoricoReinicioSenha, RepositorioHistoricoReinicioSenha>();
            services.TryAddScopedWorkerService<IRepositorioComunicado, RepositorioComunicado>();
            services.TryAddScopedWorkerService<IRepositorioComunicadoAluno, RepositorioComunicadoAluno>();
            services.TryAddScopedWorkerService<IRepositorioComunicadoTurma, RepositorioComunicadoTurma>();
            services.TryAddScopedWorkerService<IRepositorioDiarioBordo, RepositorioDiarioBordo>();
            services.TryAddScopedWorkerService<IRepositorioDevolutiva, RepositorioDevolutiva>();
            services.TryAddScopedWorkerService<IRepositorioAnoEscolar, RepositorioAnoEscolar>();
            services.TryAddScopedWorkerService<IRepositorioCartaIntencoes, RepositorioCartaIntencoes>();
            services.TryAddScopedWorkerService<IRepositorioCartaIntencoesObservacao, RepositorioCartaIntencoesObservacao>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoCartaIntencoesObservacao, RepositorioNotificacaoCartaIntencoesObservacao>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoDevolutiva, RepositorioNotificacaoDevolutiva>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaAula, RepositorioPendenciaAula>();
            services.TryAddScopedWorkerService<IRepositorioPlanejamentoAnual, RepositorioPlanejamentoAnual>();
            services.TryAddScopedWorkerService<IRepositorioComponenteCurricular, RepositorioComponenteCurricular>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaProfessor, RepositorioPendenciaProfessor>();
            services.TryAddScopedWorkerService<IRepositorioRemoveConexaoIdle, RepositorioRemoveConexaoIdle>();
            services.TryAddScopedWorkerService<IRepositorioAreaDoConhecimento, RepositorioAreaDoConhecimento>();
            services.TryAddScopedWorkerService<IRepositorioComponenteCurricularGrupoAreaOrdenacao, RepositorioComponenteCurricularGrupoAreaOrdenacao>();


            // Acompanhamento Aluno
            services.TryAddScopedWorkerService<IRepositorioAcompanhamentoAluno, RepositorioAcompanhamentoAluno>();
            services.TryAddScopedWorkerService<IRepositorioAcompanhamentoAlunoSemestre, RepositorioAcompanhamentoAlunoSemestre>();
            services.TryAddScopedWorkerService<IRepositorioAcompanhamentoAlunoFoto, RepositorioAcompanhamentoAlunoFoto>();

            // Acompanhamento Turma
            //services.TryAddScopedWorkerService<IObterParametroQuantidadeImagensPercursoColetivoTurmaUseCase, ObterParametroQuantidadeImagensPercursoColetivoTurmaUseCase>();

            // Mural de Avisos
            services.TryAddScopedWorkerService<IRepositorioAviso, RepositorioAviso>();

            // Encaminhamento AEE
            services.TryAddScopedWorkerService<IRepositorioSecaoEncaminhamentoAEE, RepositorioSecaoEncaminhamentoAEE>();
            services.TryAddScopedWorkerService<IRepositorioEncaminhamentoAEE, RepositorioEncaminhamentoAEE>();
            services.TryAddScopedWorkerService<IRepositorioEncaminhamentoAEESecao, RepositorioEncaminhamentoAEESecao>();
            services.TryAddScopedWorkerService<IRepositorioQuestaoEncaminhamentoAEE, RepositorioQuestaoEncaminhamentoAEE>();
            services.TryAddScopedWorkerService<IRepositorioRespostaEncaminhamentoAEE, RepositorioRespostaEncaminhamentoAEE>();

            // EventoTipo
            services.TryAddScopedWorkerService<IRepositorioEventoTipo, RepositorioEventoTipo>();
            services.TryAddScopedWorkerService<IRepositorioPerfilEventoTipo, RepositorioPerfilEventoTipo>();

            // Questionario
            services.TryAddScopedWorkerService<IRepositorioQuestionario, RepositorioQuestionario>();
            services.TryAddScopedWorkerService<IRepositorioQuestao, RepositorioQuestao>();
            services.TryAddScopedWorkerService<IRepositorioOpcaoResposta, RepositorioOpcaoResposta>();

            services.TryAddScoped<IRepositorioRegistroIndividual, RepositorioRegistroIndividual>();
            services.TryAddScopedWorkerService<IRepositorioOcorrencia, RepositorioOcorrencia>();
            services.TryAddScopedWorkerService<IRepositorioOcorrenciaAluno, RepositorioOcorrenciaAluno>();
            services.TryAddScopedWorkerService<IRepositorioOcorrenciaTipo, RepositorioOcorrenciaTipo>();

            // Itinerância
            services.TryAddScopedWorkerService<IRepositorioWfAprovacaoItinerancia, RepositorioWfAprovacaoItinerancia>();

            // PlanoAEE
            services.TryAddScopedWorkerService<IRepositorioPlanoAEE, RepositorioPlanoAEE>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAEEVersao, RepositorioPlanoAEEVersao>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAEEQuestao, RepositorioPlanoAEEQuestao>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAEEResposta, RepositorioPlanoAEEResposta>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAEEReestruturacao, RepositorioPlanoAEEReestruturacao>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaPlanoAEE, RepositorioPendenciaPlanoAEE>();

            services.TryAddScopedWorkerService<IRepositorioPlanoAEEObservacao, RepositorioPlanoAEEObservacao>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoPlanoAEEObservacao, RepositorioNotificacaoPlanoAEEObservacao>();

            // Consolidação Frequencia Turma
            services.TryAddScopedWorkerService<IRepositorioConsolidacaoFrequenciaTurma, RepositorioConsolidacaoFrequenciaTurma>();


            // Consolidação Devolutivas
            services.TryAddScopedWorkerService<IRepositorioConsolidacaoDevolutivas, RepositorioConsolidacaoDevolutivas>();
            services.TryAddScopedWorkerService<IRepositorioRegistroFrequenciaAluno, RepositorioRegistroFrequenciaAluno>();


            // Consolidacao de Acompanhamento Aprendizagem Aluno
            services.TryAddScoped<IRepositorioConsolidacaoAcompanhamentoAprendizagemAluno, RepositorioConsolidacaoAcompanhamentoAprendizagemAluno>();
        }

        private static void RegistrarRepositoriosAplicacao(IServiceCollection services)
        {
            services.TryAddScoped<IRepositorioPlanoCiclo, RepositorioPlanoCiclo>();
            services.TryAddScoped<IRepositorioMatrizSaberPlano, RepositorioMatrizSaberPlano>();
            services.TryAddScoped<IRepositorioObjetivoDesenvolvimentoPlano, RepositorioObjetivoDesenvolvimentoPlano>();
            services.TryAddScoped<IRepositorioMatrizSaber, RepositorioMatrizSaber>();
            services.TryAddScoped<IRepositorioObjetivoDesenvolvimento, RepositorioObjetivoDesenvolvimento>();
            services.TryAddScoped<IRepositorioCiclo, RepositorioCiclo>();
            services.TryAddScoped<IRepositorioPlanoAnual, RepositorioPlanoAnual>();
            services.TryAddScoped<IRepositorioObjetivoAprendizagemPlano, RepositorioObjetivoAprendizagemPlano>();
            services.TryAddScoped<IRepositorioCache, RepositorioCache>();
            services.TryAddScoped<IRepositorioComponenteCurricularJurema, RepositorioComponenteCurricularJurema>();
            services.TryAddScoped<IRepositorioComponenteCurricular, RepositorioComponenteCurricular>();
            services.TryAddScoped<IRepositorioSupervisorEscolaDre, RepositorioSupervisorEscolaDre>();
            services.TryAddScoped<IRepositorioNotificacao, RepositorioNotificacao>();
            services.TryAddScoped<IRepositorioWorkflowAprovacao, RepositorioWorkflowAprovacao>();
            services.TryAddScoped<IRepositorioWorkflowAprovacaoNivelNotificacao, RepositorioWorkflowAprovaNivelNotificacao>();
            services.TryAddScoped<IRepositorioWorkflowAprovacaoNivel, RepositorioWorkflowAprovacaoNivel>();
            services.TryAddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.TryAddScoped<IRepositorioWorkflowAprovacaoNivelUsuario, RepositorioWorkflowAprovacaoNivelUsuario>();
            services.TryAddScoped<IRepositorioPrioridadePerfil, RepositorioPrioridadePerfil>();
            services.TryAddScoped<IRepositorioConfiguracaoEmail, RepositorioConfiguracaoEmail>();
            services.TryAddScoped<IRepositorioAbrangencia, RepositorioAbrangencia>();
            services.TryAddScoped<IRepositorioTipoCalendario, RepositorioTipoCalendario>();
            services.TryAddScoped<IRepositorioFeriadoCalendario, RepositorioFeriadoCalendario>();
            services.TryAddScoped<IRepositorioPeriodoEscolar, RepositorioPeriodoEscolar>();
            services.TryAddScoped<IRepositorioEvento, RepositorioEvento>();
            services.TryAddScoped<IRepositorioParametrosSistema, RepositorioParametrosSistema>();
            services.TryAddScoped<IRepositorioAula, RepositorioAula>();
            services.TryAddScoped<IRepositorioGrade, RepositorioGrade>();
            services.TryAddScoped<IRepositorioGradeFiltro, RepositorioGradeFiltro>();
            services.TryAddScoped<IRepositorioGradeDisciplina, RepositorioGradeDisciplina>();
            services.TryAddScoped<IRepositorioFrequencia, RepositorioFrequencia>();
            services.TryAddScoped<IRepositorioRegistroAusenciaAluno, RepositorioRegistroAusenciaAluno>();
            services.TryAddScoped<IRepositorioAtribuicaoEsporadica, RepositorioAtribuicaoEsporadica>();
            services.TryAddScoped<IRepositorioFrequenciaAlunoDisciplinaPeriodo, RepositorioFrequenciaAlunoDisciplinaPeriodo>();
            services.TryAddScoped<IRepositorioAtividadeAvaliativa, RepositorioAtividadeAvaliativa>();
            services.TryAddScoped<IRepositorioTipoAvaliacao, RepositorioTipoAvaliacao>();
            services.TryAddScoped<IRepositorioPlanoAula, RepositorioPlanoAula>();
            services.TryAddScoped<IRepositorioObjetivoAprendizagemAula, RepositorioObjetivoAprendizagemAula>();
            services.TryAddScoped<IRepositorioAtribuicaoCJ, RepositorioAtribuicaoCJ>();
            services.TryAddScoped<IRepositorioDre, RepositorioDre>();
            services.TryAddScoped<IRepositorioUe, RepositorioUe>();
            services.TryAddScoped<IRepositorioTurma, RepositorioTurma>();
            services.TryAddScoped<IRepositorioAtividadeAvaliativaRegencia, RepositorioAtividadeAvaliativaRegencia>();
            services.TryAddScoped<IRepositorioNotasConceitos, RepositorioNotasConceitos>();
            services.TryAddScoped<IRepositorioAtividadeAvaliativa, RepositorioAtividadeAvaliativa>();
            services.TryAddScoped<IRepositorioConceito, RepositorioConceito>();
            services.TryAddScoped<IRepositorioNotaParametro, RepositorioNotaParametro>();
            services.TryAddScoped<IRepositorioNotaTipoValor, RepositorioNotaTipoValor>();
            services.TryAddScoped<IRepositorioNotificacaoFrequencia, RepositorioNotificacaoFrequencia>();
            services.TryAddScoped<IRepositorioEventoMatricula, RepositorioEventoMatricula>();
            services.TryAddScoped<IRepositorioAulaPrevista, RepositorioAulaPrevista>();
            services.TryAddScoped<IRepositorioNotificacaoAulaPrevista, RepositorioNotificacaoAulaPrevista>();
            services.TryAddScoped<IRepositorioAulaPrevistaBimestre, RepositorioAulaPrevistaBimestre>();
            services.TryAddScoped<IRepositorioRegistroPoa, RepositorioRegistroPoa>();
            services.TryAddScoped<IRepositorioAtividadeAvaliativaDisciplina, RepositorioAtividadeAvaliativaDisciplina>();
            services.TryAddScoped<IRepositorioFechamentoReabertura, RepositorioFechamentoReabertura>();
            services.TryAddScoped<IRepositorioFechamentoConsolidado, RepositorioFechamentoConsolidado>();
            services.TryAddScoped<IRepositorioConselhoClasseConsolidado, RepositorioConselhoClasseConsolidado>();
            services.TryAddScoped<IRepositorioCompensacaoAusencia, RepositorioCompensacaoAusencia>();
            services.TryAddScoped<IRepositorioCompensacaoAusenciaAluno, RepositorioCompensacaoAusenciaAluno>();
            services.TryAddScoped<IRepositorioCompensacaoAusenciaDisciplinaRegencia, RepositorioCompensacaoAusenciaDisciplinaRegencia>();
            services.TryAddScoped<IRepositorioProcessoExecutando, RepositorioProcessoExecutando>();
            services.TryAddScoped<IRepositorioPeriodoFechamento, RepositorioPeriodoFechamento>();
            services.TryAddScoped<IRepositorioPeriodoFechamentoBimestre, RepositorioPeriodoFechamentoBimestre>();
            services.TryAddScoped<IRepositorioNotificacaoCompensacaoAusencia, RepositorioNotificacaoCompensacaoAusencia>();
            services.TryAddScoped<IRepositorioEventoFechamento, RepositorioEventoFechamento>();
            services.TryAddScoped<IRepositorioFechamentoTurmaDisciplina, RepositorioFechamentoTurmaDisciplina>();
            services.TryAddScoped<IRepositorioFechamentoNota, RepositorioFechamentoNota>();
            services.TryAddScoped<IRepositorioRecuperacaoParalela, RepositorioRecuperacaoParalela>();
            services.TryAddScoped<IRepositorioRecuperacaoParalelaPeriodo, RepositorioRecuperacaoParalelaPeriodo>();
            services.TryAddScoped<IRepositorioRecuperacaoParalelaPeriodoObjetivoResposta, RepositorioRecuperacaoParalelaPeriodoObjetivoResposta>();
            services.TryAddScoped<IRepositorioEixo, RepositorioEixo>();
            services.TryAddScoped<IRepositorioResposta, RepositorioResposta>();
            services.TryAddScoped<IRepositorioObjetivo, RepositorioObjetivo>();
            services.TryAddScoped<IRepositorioNotificacaoAula, RepositorioNotificacaoAula>();
            services.TryAddScoped<IRepositorioHistoricoEmailUsuario, RepositorioHistoricoEmailUsuario>();
            services.TryAddScoped<IRepositorioSintese, RepositorioSintese>();
            services.TryAddScoped<IRepositorioFechamentoAluno, RepositorioFechamentoAluno>();
            services.TryAddScoped<IRepositorioFechamentoTurma, RepositorioFechamentoTurma>();
            services.TryAddScoped<IRepositorioConselhoClasse, RepositorioConselhoClasse>();
            services.TryAddScoped<IRepositorioConselhoClasseAluno, RepositorioConselhoClasseAluno>();
            services.TryAddScoped<IRepositorioConselhoClasseAlunoTurmaComplementar, RepositorioConselhoClasseAlunoTurmaComplementar>();
            services.TryAddScoped<IRepositorioConselhoClasseNota, RepositorioConselhoClasseNota>();
            services.TryAddScoped<IRepositorioComunicado, RepositorioComunicado>();
            services.TryAddScoped<IRepositorioWfAprovacaoNotaFechamento, RepositorioWfAprovacaoNotaFechamento>();
            services.TryAddScoped<IRepositorioConselhoClasseRecomendacao, RepositorioConselhoClasseRecomendacao>();
            services.TryAddScoped<IRepositorioCicloEnsino, RepositorioCicloEnsino>();
            services.TryAddScoped<IRepositorioTipoEscola, RepositorioTipoEscola>();
            services.TryAddScoped<IRepositorioRelatorioSemestralTurmaPAP, RepositorioRelatorioSemestralTurmaPAP>();
            services.TryAddScoped<IRepositorioRelatorioSemestralPAPAluno, RepositorioRelatorioSemestralPAPAluno>();
            services.TryAddScoped<IRepositorioRelatorioSemestralPAPAlunoSecao, RepositorioRelatorioSemestralPAPAlunoSecao>();
            services.TryAddScoped<IRepositorioSecaoRelatorioSemestralPAP, RepositorioSecaoRelatorioSemestralPAP>();
            services.TryAddScoped<IRepositorioObjetivoAprendizagem, RepositorioObjetivoAprendizagem>();
            services.TryAddScoped<IRepositorioConselhoClasseParecerConclusivo, RepositorioConselhoClasseParecerConclusivo>();
            services.TryAddScoped<IRepositorioPlanoAnualTerritorioSaber, RepositorioPlanoAnualTerritorioSaber>();
            services.TryAddScoped<IRepositorioCorrelacaoRelatorio, RepositorioCorrelacaoRelatorio>();
            services.TryAddScoped<IRepositorioCorrelacaoRelatorioJasper, RepositorioRelatorioCorrelacaoJasper>();
            services.TryAddScoped<IRepositorioFechamentoReaberturaBimestre, RepositorioFechamentoReaberturaBimestre>();
            services.TryAddScoped<IRepositorioHistoricoReinicioSenha, RepositorioHistoricoReinicioSenha>();
            services.TryAddScoped<IRepositorioComunicadoAluno, RepositorioComunicadoAluno>();
            services.TryAddScoped<IRepositorioComunicadoTurma, RepositorioComunicadoTurma>();
            services.TryAddScoped<IRepositorioComunicadoModalidade, RepositorioComunicadoModalidade>();
            services.TryAddScoped<IRepositorioComunicadoTipoEscola, RepositorioComunicadoTipoEscola>();
            services.TryAddScoped<IRepositorioComunicadoAnoEscolar, RepositorioComunicadoAnoEscolar>();
            services.TryAddScoped<IRepositorioDiarioBordo, RepositorioDiarioBordo>();
            services.TryAddScoped<IRepositorioDevolutiva, RepositorioDevolutiva>();
            services.TryAddScoped<IRepositorioAnoEscolar, RepositorioAnoEscolar>();
            services.TryAddScoped<IRepositorioCartaIntencoes, RepositorioCartaIntencoes>();
            services.TryAddScoped<IRepositorioDiarioBordoObservacao, RepositorioDiarioBordoObservacao>();
            services.TryAddScoped<IRepositorioAnotacaoFrequenciaAluno, RepositorioAnotacaoFrequenciaAluno>();
            services.TryAddScoped<IRepositorioMotivoAusencia, RepositorioMotivoAusencia>();
            services.TryAddScoped<IRepositorioCartaIntencoesObservacao, RepositorioCartaIntencoesObservacao>();
            services.TryAddScoped<IRepositorioPlanejamentoAnual, RepositorioPlanejamentoAnual>();
            services.TryAddScoped<IRepositorioPlanejamentoAnualPeriodoEscolar, RepositorioPlanejamentoAnualPeriodoEscolar>();
            services.TryAddScoped<IRepositorioPlanejamentoAnualComponente, RepositorioPlanejamentoAnualComponente>();
            services.TryAddScoped<IRepositorioPlanejamentoAnualObjetivosAprendizagem, RepositorioPlanejamentoAnualObjetivosAprendizagem>();
            services.TryAddScoped<IRepositorioNotificacaoCartaIntencoesObservacao, RepositorioNotificacaoCartaIntencoesObservacao>();
            services.TryAddScoped<IRepositorioDiarioBordoObservacaoNotificacao, RepositorioDiarioBordoObservacaoNotificacao>();
            services.TryAddScoped<IRepositorioNotificacaoDevolutiva, RepositorioNotificacaoDevolutiva>();
            services.TryAddScoped<IRepositorioComponenteCurricular, RepositorioComponenteCurricular>();
            services.TryAddScoped<IRepositorioArquivo, RepositorioArquivo>();
            services.TryAddScoped<IRepositorioHistoricoNota, RepositorioHistoricoNota>();
            services.TryAddScoped<IRepositorioHistoricoNotaConselhoClasse, RepositorioHistoricoNotaConselhoClasse>();
            services.TryAddScoped<IRepositorioHistoricoNotaFechamento, RepositorioHistoricoNotaFechamento>();
            services.TryAddScoped<IRepositorioDocumento, RepositorioDocumento>();
            services.TryAddScoped<IRepositorioClassificacaoDocumento, RepositorioClassificacaoDocumento>();
            services.TryAddScoped<IRepositorioTipoDocumento, RepositorioTipoDocumento>();
            services.TryAddScoped<IRepositorioRemoveConexaoIdle, RepositorioRemoveConexaoIdle>();
            services.TryAddScoped<IRepositorioRegistroIndividual, RepositorioRegistroIndividual>();
            services.TryAddScoped<IRepositorioOcorrencia, RepositorioOcorrencia>();
            services.TryAddScoped<IRepositorioOcorrenciaAluno, RepositorioOcorrenciaAluno>();
            services.TryAddScoped<IRepositorioOcorrenciaTipo, RepositorioOcorrenciaTipo>();
            services.TryAddScoped<IRepositorioAlunoFoto, RepositorioAlunoFoto>();
            services.TryAddScoped<IRepositorioAreaDoConhecimento, RepositorioAreaDoConhecimento>();
            services.TryAddScoped<IRepositorioComponenteCurricularGrupoAreaOrdenacao, RepositorioComponenteCurricularGrupoAreaOrdenacao>();

            // Acompanhamento Aluno
            services.TryAddScoped<IRepositorioAcompanhamentoAluno, RepositorioAcompanhamentoAluno>();
            services.TryAddScoped<IRepositorioAcompanhamentoTurma, RepositorioAcompanhamentoTurma>();
            services.TryAddScoped<IRepositorioAcompanhamentoAlunoSemestre, RepositorioAcompanhamentoAlunoSemestre>();
            services.TryAddScoped<IRepositorioAcompanhamentoAlunoFoto, RepositorioAcompanhamentoAlunoFoto>();

            // Mural de Avisos
            services.TryAddScoped<IRepositorioAviso, RepositorioAviso>();

            // Encaminhamento AEE
            services.TryAddScoped<IRepositorioSecaoEncaminhamentoAEE, RepositorioSecaoEncaminhamentoAEE>();
            services.TryAddScoped<IRepositorioEncaminhamentoAEE, RepositorioEncaminhamentoAEE>();
            services.TryAddScoped<IRepositorioEncaminhamentoAEESecao, RepositorioEncaminhamentoAEESecao>();
            services.TryAddScoped<IRepositorioQuestaoEncaminhamentoAEE, RepositorioQuestaoEncaminhamentoAEE>();
            services.TryAddScoped<IRepositorioRespostaEncaminhamentoAEE, RepositorioRespostaEncaminhamentoAEE>();

            // EventoTipo
            services.TryAddScoped<IRepositorioEventoTipo, RepositorioEventoTipo>();
            services.TryAddScoped<IRepositorioPerfilEventoTipo, RepositorioPerfilEventoTipo>();

            // Pendencias do EncaminhamentoAEE
            services.TryAddScoped<IRepositorioPendenciaEncaminhamentoAEE, RepositorioPendenciaEncaminhamentoAEE>();



            // Questionario
            services.TryAddScoped<IRepositorioQuestionario, RepositorioQuestionario>();
            services.TryAddScoped<IRepositorioQuestao, RepositorioQuestao>();
            services.TryAddScoped<IRepositorioOpcaoResposta, RepositorioOpcaoResposta>();
            services.TryAddScoped<IRepositorioOpcaoQuestaoComplementar, RepositorioOpcaoQuestaoComplementar>();

            // Pendencias
            services.TryAddScoped<IRepositorioPendencia, RepositorioPendencia>();
            services.TryAddScoped<IRepositorioPendenciaFechamento, RepositorioPendenciaFechamento>();
            services.TryAddScoped<IRepositorioPendenciaAula, RepositorioPendenciaAula>();
            services.TryAddScoped<IRepositorioPendenciaUsuario, RepositorioPendenciaUsuario>();
            services.TryAddScoped<IRepositorioPendenciaCalendarioUe, RepositorioPendenciaCalendarioUe>();
            services.TryAddScoped<IRepositorioPendenciaParametroEvento, RepositorioPendenciaParametroEvento>();
            services.TryAddScoped<IRepositorioPendenciaProfessor, RepositorioPendenciaProfessor>();
            services.TryAddScoped<IRepositorioPendenciaRegistroIndividual, RepositorioPendenciaRegistroIndividual>();
            services.TryAddScoped<IRepositorioPendenciaRegistroIndividualAluno, RepositorioPendenciaRegistroIndividualAluno>();

            // Itinerancia
            services.TryAddScoped<IRepositorioItinerancia, RepositorioItinerancia>();
            services.TryAddScoped<IRepositorioItineranciaAluno, RepositorioItineranciaAluno>();
            services.TryAddScoped<IRepositorioItineranciaAlunoQuestao, RepositorioItineranciaAlunoQuestao>();
            services.TryAddScoped<IRepositorioItineranciaQuestao, RepositorioItineranciaQuestao>();
            services.TryAddScoped<IRepositorioItineranciaObjetivo, RepositorioItineranciaObjetivo>();
            services.TryAddScoped<IRepositorioWfAprovacaoItinerancia, RepositorioWfAprovacaoItinerancia>();

            services.TryAddScoped<IRepositorioItineranciaEvento, RepositorioItineranciaEvento>();

            // PlanoAEE
            services.TryAddScoped<IRepositorioPlanoAEE, RepositorioPlanoAEE>();
            services.TryAddScoped<IRepositorioPlanoAEEVersao, RepositorioPlanoAEEVersao>();
            services.TryAddScoped<IRepositorioPlanoAEEQuestao, RepositorioPlanoAEEQuestao>();
            services.TryAddScoped<IRepositorioPlanoAEEResposta, RepositorioPlanoAEEResposta>();
            services.TryAddScoped<IRepositorioPlanoAEEReestruturacao, RepositorioPlanoAEEReestruturacao>();
            services.TryAddScoped<IRepositorioPendenciaPlanoAEE, RepositorioPendenciaPlanoAEE>();

            services.TryAddScoped<IRepositorioPlanoAEEObservacao, RepositorioPlanoAEEObservacao>();
            services.TryAddScoped<IRepositorioNotificacaoPlanoAEEObservacao, RepositorioNotificacaoPlanoAEEObservacao>();

            // Notificações Plano AEE
            services.TryAddScoped<IRepositorioNotificacaoPlanoAEE, RepositorioNotificacaoPlanoAEE>();

            // Consolidação Frequeência Turma
            services.TryAddScoped<IRepositorioConsolidacaoFrequenciaTurma, RepositorioConsolidacaoFrequenciaTurma>();

            // Consolidação Devolutivas
            services.TryAddScoped<IRepositorioConsolidacaoDevolutivas, RepositorioConsolidacaoDevolutivas>();

            // Frequência 
            services.TryAddScoped<IRepositorioFrequenciaPreDefinida, RepositorioFrequenciaPreDefinida>();
            services.TryAddScoped<IRepositorioRegistroFrequenciaAluno, RepositorioRegistroFrequenciaAluno>();


            //Evento Bimestre
            services.TryAddScoped<IRepositorioEventoBimestre, RepositorioEventoBimestre>();
            //Consolidacao registro individual média
            services.TryAddScoped<IRepositorioConsolidacaoRegistroIndividualMedia, RepositorioConsolidacaoRegistroIndividualMedia>();


            // Consolidacao de Acompanhamento Aprendizagem Aluno
            services.TryAddScoped<IRepositorioConsolidacaoAcompanhamentoAprendizagemAluno, RepositorioConsolidacaoAcompanhamentoAprendizagemAluno>();


            // Consolidação Matrícula Turma
            services.TryAddScoped<IRepositorioConsolidacaoMatriculaTurma, RepositorioConsolidacaoMatriculaTurma>();
        }

        private static void RegistrarMediator(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("SME.SGP.Aplicacao");
            services.AddMediatR(assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacoesPipeline<,>));
        }

        private static void RegistrarComandos(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IComandosPlanoCiclo, ComandosPlanoCiclo>();
            services.TryAddScopedWorkerService<IComandosPlanoAnual, ComandosPlanoAnual>();
            services.TryAddScopedWorkerService<IComandosSupervisor, ComandosSupervisor>();
            services.TryAddScopedWorkerService<IComandosNotificacao, ComandosNotificacao>();
            services.TryAddScopedWorkerService<IComandosWorkflowAprovacao, ComandosWorkflowAprovacao>();
            services.TryAddScopedWorkerService<IComandosUsuario, ComandosUsuario>();
            services.TryAddScopedWorkerService<IComandosTipoCalendario, ComandosTipoCalendario>();
            services.TryAddScopedWorkerService<IComandosFeriadoCalendario, ComandosFeriadoCalendario>();
            services.TryAddScopedWorkerService<IComandosPeriodoEscolar, ComandosPeriodoEscolar>();
            services.TryAddScopedWorkerService<IComandosEventoTipo, ComandosEventoTipo>();
            services.TryAddScopedWorkerService<IComandosEvento, ComandosEvento>();
            services.TryAddScopedWorkerService<IComandosDiasLetivos, ComandosDiasLetivos>();
            services.TryAddScopedWorkerService<IComandosGrade, ComandosGrade>();
            services.TryAddScopedWorkerService<IComandosAtribuicaoEsporadica, ComandosAtribuicaoEsporadica>();
            services.TryAddScopedWorkerService<IComandosAtividadeAvaliativa, ComandosAtividadeAvaliativa>();
            services.TryAddScopedWorkerService<IComandosTipoAvaliacao, ComandosTipoAavaliacao>();
            services.TryAddScopedWorkerService<IComandosAtribuicaoCJ, ComandosAtribuicaoCJ>();
            services.TryAddScopedWorkerService<IComandosEventoMatricula, ComandosEventoMatricula>();
            services.TryAddScopedWorkerService<IComandosNotasConceitos, ComandosNotasConceitos>();
            services.TryAddScopedWorkerService<IComandosAulaPrevista, ComandosAulaPrevista>();
            services.TryAddScopedWorkerService<IComandosRegistroPoa, ComandosRegistroPoa>();
            services.TryAddScopedWorkerService<IComandosFechamentoReabertura, ComandosFechamentoReabertura>();
            services.TryAddScopedWorkerService<IComandosCompensacaoAusencia, ComandosCompensacaoAusencia>();
            services.TryAddScopedWorkerService<IComandosCompensacaoAusenciaAluno, ComandosCompensacaoAusenciaAluno>();
            services.TryAddScopedWorkerService<IComandosCompensacaoAusenciaDisciplinaRegencia, ComandosCompensacaoAusenciaDisciplinaRegencia>();
            services.TryAddScopedWorkerService<IComandosProcessoExecutando, ComandosProcessoExecutando>();
            services.TryAddScopedWorkerService<IComandosFechamentoFinal, ComandosFechamentoFinal>();
            services.TryAddScopedWorkerService<IComandosPeriodoFechamento, ComandosPeriodoFechamento>();
            services.TryAddScopedWorkerService<IComandosFechamentoTurmaDisciplina, ComandosFechamentoTurmaDisciplina>();
            services.TryAddScopedWorkerService<IComandosFechamentoNota, ComandosFechamentoNota>();
            services.TryAddScopedWorkerService<IComandosNotificacaoAula, ComandosNotificacaoAula>();
            services.TryAddScopedWorkerService<IComandosPendenciaFechamento, ComandosPendenciaFechamento>();
            services.TryAddScopedWorkerService<IComandosFechamentoAluno, ComandosFechamentoAluno>();
            services.TryAddScopedWorkerService<IComandosFechamentoTurma, ComandosFechamentoTurma>();
            services.TryAddScopedWorkerService<IComandosConselhoClasse, ComandosConselhoClasse>();
            services.TryAddScopedWorkerService<IComandosConselhoClasseAluno, ComandosConselhoClasseAluno>();
            services.TryAddScopedWorkerService<IComandosConselhoClasseNota, ComandosConselhoClasseNota>();
            services.TryAddScopedWorkerService<IComandosRelatorioSemestralTurmaPAP, ComandosRelatorioSemestralTurmaPAP>();
            services.TryAddScopedWorkerService<IComandosRelatorioSemestralPAPAluno, ComandosRelatorioSemestralPAPAluno>();
            services.TryAddScopedWorkerService<IComandosRelatorioSemestralPAPAlunoSecao, ComandosRelatorioSemestralPAPAlunoSecao>();
        }

        private static void RegistrarConsultas(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IConsultasPlanoCiclo, ConsultasPlanoCiclo>();
            services.TryAddScopedWorkerService<IConsultasMatrizSaber, ConsultasMatrizSaber>();
            services.TryAddScopedWorkerService<IConsultasObjetivoDesenvolvimento, ConsultasObjetivoDesenvolvimento>();
            services.TryAddScopedWorkerService<IConsultasCiclo, ConsultasCiclo>();
            services.TryAddScopedWorkerService<IConsultasObjetivoAprendizagem, ConsultasObjetivoAprendizagem>();
            services.TryAddScopedWorkerService<IConsultasPlanoAnual, ConsultasPlanoAnual>();
            services.TryAddScopedWorkerService<IConsultasDisciplina, ConsultasDisciplina>();
            services.TryAddScopedWorkerService<IConsultasProfessor, ConsultasProfessor>();
            services.TryAddScopedWorkerService<IConsultasSupervisor, ConsultasSupervisor>();
            services.TryAddScopedWorkerService<IConsultaDres, ConsultaDres>();
            services.TryAddScopedWorkerService<IConsultasNotificacao, ConsultasNotificacao>();
            services.TryAddScopedWorkerService<IConsultasWorkflowAprovacao, ConsultasWorkflowAprovacao>();
            services.TryAddScopedWorkerService<IConsultasUnidadesEscolares, ConsultasUnidadesEscolares>();
            services.TryAddScopedWorkerService<IConsultasTipoCalendario, ConsultasTipoCalendario>();
            services.TryAddScopedWorkerService<IConsultasFeriadoCalendario, ConsultasFeriadoCalendario>();
            services.TryAddScopedWorkerService<IConsultasPeriodoEscolar, ConsultasPeriodoEscolar>();
            services.TryAddScopedWorkerService<IConsultasUsuario, ConsultasUsuario>();
            services.TryAddScopedWorkerService<IConsultasAbrangencia, ConsultasAbrangencia>();
            services.TryAddScopedWorkerService<IConsultasEventoTipo, ConsultasEventoTipo>();
            services.TryAddScopedWorkerService<IConsultasEvento, ConsultasEvento>();
            services.TryAddScopedWorkerService<IConsultasAula, ConsultasAula>();
            services.TryAddScopedWorkerService<IConsultasGrade, ConsultasGrade>();
            services.TryAddScopedWorkerService<IConsultasFrequencia, ConsultasFrequencia>();
            services.TryAddScopedWorkerService<IConsultasAtribuicaoEsporadica, ConsultasAtribuicaoEsporadica>();
            services.TryAddScopedWorkerService<IConsultasEventoMatricula, ConsultasEventoMatricula>();
            services.TryAddScopedWorkerService<IConsultasRegistroPoa, ConsultasRegistroPoa>();
            services.TryAddScopedWorkerService<IConsultasPlanoAula, ConsultasPlanoAula>();
            services.TryAddScopedWorkerService<IConsultasObjetivoAprendizagemAula, ConsultasObjetivoAprendizagemAula>();
            services.TryAddScopedWorkerService<IConsultasCompensacaoAusencia, ConsultasCompensacaoAusencia>();
            services.TryAddScopedWorkerService<IConsultasCompensacaoAusenciaAluno, ConsultasCompensacaoAusenciaAluno>();
            services.TryAddScopedWorkerService<IConsultasCompensacaoAusenciaDisciplinaRegencia, ConsultasCompensacaoAusenciaDisciplinaRegencia>();
            services.TryAddScopedWorkerService<IConsultasAulaPrevista, ConsultasAulaPrevista>();
            services.TryAddScopedWorkerService<IConsultasNotasConceitos, ConsultasNotasConceitos>();
            services.TryAddScopedWorkerService<IConsultasAtribuicoes, ConsultasAtribuicoes>();
            services.TryAddScopedWorkerService<IConsultaAtividadeAvaliativa, ConsultaAtividadeAvaliativa>();
            services.TryAddScopedWorkerService<IConsultaTipoAvaliacao, ConsultaTipoAvaliacao>();
            services.TryAddScopedWorkerService<IConsultasAtribuicaoCJ, ConsultasAtribuicaoCJ>();
            services.TryAddScopedWorkerService<IConsultasUe, ConsultasUe>();
            services.TryAddScopedWorkerService<IConsultasEventosAulasCalendario, ConsultasEventosAulasCalendario>();
            services.TryAddScopedWorkerService<IConsultasProcessoExecutando, ConsultasProcessoExecutando>();
            services.TryAddScopedWorkerService<IConsultasPeriodoFechamento, ConsultasPeriodoFechamento>();
            services.TryAddScopedWorkerService<IConsultasFechamentoTurmaDisciplina, ConsultasFechamentoTurmaDisciplina>();
            services.TryAddScopedWorkerService<IConsultasFechamentoNota, ConsultasFechamentoNota>();
            services.TryAddScopedWorkerService<IConsultasFechamentoReabertura, ConsultasFechamentoReabertura>();
            services.TryAddScopedWorkerService<IConsultasTurma, ConsultasTurma>();
            services.TryAddScopedWorkerService<IConsultasPendenciaFechamento, ConsultasPendenciaFechamento>();
            services.TryAddScopedWorkerService<IConsultasFechamentoAluno, ConsultasFechamentoAluno>();
            services.TryAddScopedWorkerService<IConsultasFechamentoTurma, ConsultasFechamentoTurma>();
            services.TryAddScopedWorkerService<IConsultasConselhoClasse, ConsultasConselhoClasse>();
            services.TryAddScopedWorkerService<IConsultasConselhoClasseAluno, ConsultasConselhoClasseAluno>();
            services.TryAddScopedWorkerService<IConsultasConselhoClasseNota, ConsultasConselhoClasseNota>();
            services.TryAddScopedWorkerService<IConsultasConselhoClasseRecomendacao, ConsultasConselhoClasseRecomendacao>();
            services.TryAddScopedWorkerService<IConsultasRelatorioSemestralTurmaPAP, ConsultasRelatorioSemestralTurmaPAP>();
            services.TryAddScopedWorkerService<IConsultasRelatorioSemestralPAPAluno, ConsultasRelatorioSemestralPAPAluno>();
            services.TryAddScopedWorkerService<IConsultasRelatorioSemestralPAPAlunoSecao, ConsultasRelatorioSemestralPAPAlunoSecao>();
            services.TryAddScopedWorkerService<IConsultasSecaoRelatorioSemestralPAP, ConsultasSecaoRelatorioSemestralPAP>();

            services.TryAddScopedWorkerService<IExecutarSincronizacaoDadosFrequenciaUseCase, ExecutarSincronizacaoDadosFrequenciaUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoDadosTurmasFrequenciaUseCase, ExecutarSincronizacaoDadosTurmasFrequenciaUseCase>();
            services.TryAddScopedWorkerService<ICarregarDadosAulasFrequenciaUseCase, CarregarDadosAulasFrequenciaUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoRegistroFrequenciaAlunosUseCase, ExecutarSincronizacaoRegistroFrequenciaAlunosUseCase>();
            services.TryAddScopedWorkerService<ICarregarRegistroFrequenciaAlunosUseCase, CarregarRegistroFrequenciaAlunosUseCase>();

            services.TryAddScopedWorkerService<IExecutarSyncSerapEstudantesProvasUseCase, ExecutarSyncSerapEstudantesProvasUseCase>();
        }

        private static void RegistrarContextos(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<SME.SGP.Infra.Interfaces.IContextoAplicacao, SME.SGP.Infra.Contexto.WorkerContext>();
            services.TryAddScopedWorkerService<SME.Worker.Agendador.Infra.Interfaces.IContextoAplicacao, SME.Worker.Agendador.Infra.Contexto.WorkerContext>();
            services.TryAddScopedWorkerService<ISgpContext, SgpContext>();
            services.TryAddScopedWorkerService<IUnitOfWork, UnitOfWork>();
        }

        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IRepositorioAbrangencia, RepositorioAbrangencia>();
            services.TryAddScopedWorkerService<IRepositorioAtividadeAvaliativa, RepositorioAtividadeAvaliativa>();
            services.TryAddScopedWorkerService<IRepositorioAtividadeAvaliativaDisciplina, RepositorioAtividadeAvaliativaDisciplina>();
            services.TryAddScopedWorkerService<IRepositorioAtividadeAvaliativaRegencia, RepositorioAtividadeAvaliativaRegencia>();
            services.TryAddScopedWorkerService<IRepositorioAtribuicaoCJ, RepositorioAtribuicaoCJ>();
            services.TryAddScopedWorkerService<IRepositorioAtribuicaoEsporadica, RepositorioAtribuicaoEsporadica>();
            services.TryAddScopedWorkerService<IRepositorioAula, RepositorioAula>();
            services.TryAddScopedWorkerService<IRepositorioAulaPrevista, RepositorioAulaPrevista>();
            services.TryAddScopedWorkerService<IRepositorioAulaPrevistaBimestre, RepositorioAulaPrevistaBimestre>();
            services.TryAddScopedWorkerService<IRepositorioCache, RepositorioCache>();
            services.TryAddScopedWorkerService<IRepositorioCiclo, RepositorioCiclo>();
            services.TryAddScopedWorkerService<IRepositorioComponenteCurricularJurema, RepositorioComponenteCurricularJurema>();
            services.TryAddScopedWorkerService<IRepositorioComponenteCurricular, RepositorioComponenteCurricular>();
            services.TryAddScopedWorkerService<IRepositorioConceito, RepositorioConceito>();
            services.TryAddScopedWorkerService<IRepositorioConfiguracaoEmail, RepositorioConfiguracaoEmail>();
            services.TryAddScopedWorkerService<IRepositorioDre, RepositorioDre>();
            services.TryAddScopedWorkerService<IRepositorioEvento, RepositorioEvento>();
            services.TryAddScopedWorkerService<IRepositorioEventoMatricula, RepositorioEventoMatricula>();
            services.TryAddScopedWorkerService<IRepositorioFeriadoCalendario, RepositorioFeriadoCalendario>();
            services.TryAddScopedWorkerService<IRepositorioFrequencia, RepositorioFrequencia>();
            services.TryAddScopedWorkerService<IRepositorioFrequenciaAlunoDisciplinaPeriodo, RepositorioFrequenciaAlunoDisciplinaPeriodo>();
            services.TryAddScopedWorkerService<IRepositorioGrade, RepositorioGrade>();
            services.TryAddScopedWorkerService<IRepositorioGradeDisciplina, RepositorioGradeDisciplina>();
            services.TryAddScopedWorkerService<IRepositorioGradeFiltro, RepositorioGradeFiltro>();
            services.TryAddScopedWorkerService<IRepositorioMatrizSaber, RepositorioMatrizSaber>();
            services.TryAddScopedWorkerService<IRepositorioMatrizSaberPlano, RepositorioMatrizSaberPlano>();
            services.TryAddScopedWorkerService<IRepositorioNotaParametro, RepositorioNotaParametro>();
            services.TryAddScopedWorkerService<IRepositorioNotaTipoValor, RepositorioNotaTipoValor>();
            services.TryAddScopedWorkerService<IRepositorioNotasConceitos, RepositorioNotasConceitos>();
            services.TryAddScopedWorkerService<IRepositorioNotificacao, RepositorioNotificacao>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoAulaPrevista, RepositorioNotificacaoAulaPrevista>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoFrequencia, RepositorioNotificacaoFrequencia>();
            services.TryAddScopedWorkerService<IRepositorioObjetivoAprendizagemAula, RepositorioObjetivoAprendizagemAula>();
            services.TryAddScopedWorkerService<IRepositorioObjetivoAprendizagemPlano, RepositorioObjetivoAprendizagemPlano>();
            services.TryAddScopedWorkerService<IRepositorioObjetivoDesenvolvimento, RepositorioObjetivoDesenvolvimento>();
            services.TryAddScopedWorkerService<IRepositorioObjetivoDesenvolvimentoPlano, RepositorioObjetivoDesenvolvimentoPlano>();
            services.TryAddScopedWorkerService<IRepositorioParametrosSistema, RepositorioParametrosSistema>();
            services.TryAddScopedWorkerService<IRepositorioPeriodoEscolar, RepositorioPeriodoEscolar>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAnual, RepositorioPlanoAnual>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAula, RepositorioPlanoAula>();
            services.TryAddScopedWorkerService<IRepositorioPlanoCiclo, RepositorioPlanoCiclo>();
            services.TryAddScopedWorkerService<IRepositorioPrioridadePerfil, RepositorioPrioridadePerfil>();
            services.TryAddScopedWorkerService<IRepositorioRegistroAusenciaAluno, RepositorioRegistroAusenciaAluno>();
            services.TryAddScopedWorkerService<IRepositorioRegistroPoa, RepositorioRegistroPoa>();
            services.TryAddScopedWorkerService<IRepositorioCompensacaoAusencia, RepositorioCompensacaoAusencia>();
            services.TryAddScopedWorkerService<IRepositorioCompensacaoAusenciaAluno, RepositorioCompensacaoAusenciaAluno>();
            services.TryAddScopedWorkerService<IRepositorioCompensacaoAusenciaDisciplinaRegencia, RepositorioCompensacaoAusenciaDisciplinaRegencia>();
            services.TryAddScopedWorkerService<IRepositorioSupervisorEscolaDre, RepositorioSupervisorEscolaDre>();
            services.TryAddScopedWorkerService<IRepositorioTipoAvaliacao, RepositorioTipoAvaliacao>();
            services.TryAddScopedWorkerService<IRepositorioTipoCalendario, RepositorioTipoCalendario>();
            services.TryAddScopedWorkerService<IRepositorioTurma, RepositorioTurma>();
            services.TryAddScopedWorkerService<IRepositorioUe, RepositorioUe>();
            services.TryAddScopedWorkerService<IRepositorioUsuario, RepositorioUsuario>();
            services.TryAddScopedWorkerService<IRepositorioWorkflowAprovacao, RepositorioWorkflowAprovacao>();
            services.TryAddScopedWorkerService<IRepositorioWorkflowAprovacaoNivel, RepositorioWorkflowAprovacaoNivel>();
            services.TryAddScopedWorkerService<IRepositorioWorkflowAprovacaoNivelNotificacao, RepositorioWorkflowAprovaNivelNotificacao>();
            services.TryAddScopedWorkerService<IRepositorioWorkflowAprovacaoNivelUsuario, RepositorioWorkflowAprovacaoNivelUsuario>();
            services.TryAddScopedWorkerService<IRepositorioProcessoExecutando, RepositorioProcessoExecutando>();
            services.TryAddScopedWorkerService<IRepositorioPeriodoFechamento, RepositorioPeriodoFechamento>();
            services.TryAddScopedWorkerService<IRepositorioPeriodoFechamentoBimestre, RepositorioPeriodoFechamentoBimestre>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoCompensacaoAusencia, RepositorioNotificacaoCompensacaoAusencia>();
            services.TryAddScopedWorkerService<IRepositorioEventoFechamento, RepositorioEventoFechamento>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoTurmaDisciplina, RepositorioFechamentoTurmaDisciplina>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoNota, RepositorioFechamentoNota>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoReabertura, RepositorioFechamentoReabertura>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoAula, RepositorioNotificacaoAula>();
            services.TryAddScopedWorkerService<IRepositorioHistoricoEmailUsuario, RepositorioHistoricoEmailUsuario>();
            services.TryAddScopedWorkerService<IRepositorioPendencia, RepositorioPendencia>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaFechamento, RepositorioPendenciaFechamento>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaUsuario, RepositorioPendenciaUsuario>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaRegistroIndividual, RepositorioPendenciaRegistroIndividual>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaRegistroIndividualAluno, RepositorioPendenciaRegistroIndividualAluno>();
            services.TryAddScopedWorkerService<IRepositorioSintese, RepositorioSintese>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoAluno, RepositorioFechamentoAluno>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoTurma, RepositorioFechamentoTurma>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasse, RepositorioConselhoClasse>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasseAluno, RepositorioConselhoClasseAluno>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasseAlunoTurmaComplementar, RepositorioConselhoClasseAlunoTurmaComplementar>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasseNota, RepositorioConselhoClasseNota>();
            services.TryAddScopedWorkerService<IRepositorioWfAprovacaoNotaFechamento, RepositorioWfAprovacaoNotaFechamento>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasseRecomendacao, RepositorioConselhoClasseRecomendacao>();
            services.TryAddScopedWorkerService<IRepositorioCicloEnsino, RepositorioCicloEnsino>();
            services.TryAddScopedWorkerService<IRepositorioTipoEscola, RepositorioTipoEscola>();
            services.TryAddScopedWorkerService<IRepositorioRelatorioSemestralTurmaPAP, RepositorioRelatorioSemestralTurmaPAP>();
            services.TryAddScopedWorkerService<IRepositorioRelatorioSemestralPAPAluno, RepositorioRelatorioSemestralPAPAluno>();
            services.TryAddScopedWorkerService<IRepositorioRelatorioSemestralPAPAlunoSecao, RepositorioRelatorioSemestralPAPAlunoSecao>();
            services.TryAddScopedWorkerService<IRepositorioSecaoRelatorioSemestralPAP, RepositorioSecaoRelatorioSemestralPAP>();
            services.TryAddScopedWorkerService<IRepositorioObjetivoAprendizagem, RepositorioObjetivoAprendizagem>();
            services.TryAddScopedWorkerService<IRepositorioCorrelacaoRelatorio, RepositorioCorrelacaoRelatorio>();
            services.TryAddScopedWorkerService<IRepositorioCorrelacaoRelatorioJasper, RepositorioRelatorioCorrelacaoJasper>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoConsolidado, RepositorioFechamentoConsolidado>();
            services.TryAddScopedWorkerService<IRepositorioConselhoClasseConsolidado, RepositorioConselhoClasseConsolidado>();
            //services.TryAddScopedWorkerService<IRepositorioTestePostgre, RepositorioTestePostgre>();
            services.TryAddScopedWorkerService<IRepositorioFechamentoReaberturaBimestre, RepositorioFechamentoReaberturaBimestre>();
            services.TryAddScopedWorkerService<IRepositorioHistoricoReinicioSenha, RepositorioHistoricoReinicioSenha>();
            services.TryAddScopedWorkerService<IRepositorioComunicado, RepositorioComunicado>();
            services.TryAddScopedWorkerService<IRepositorioComunicadoAluno, RepositorioComunicadoAluno>();
            services.TryAddScopedWorkerService<IRepositorioComunicadoTurma, RepositorioComunicadoTurma>();
            services.TryAddScopedWorkerService<IRepositorioDiarioBordo, RepositorioDiarioBordo>();
            services.TryAddScopedWorkerService<IRepositorioDevolutiva, RepositorioDevolutiva>();
            services.TryAddScopedWorkerService<IRepositorioAnoEscolar, RepositorioAnoEscolar>();
            services.TryAddScopedWorkerService<IRepositorioCartaIntencoes, RepositorioCartaIntencoes>();
            services.TryAddScopedWorkerService<IRepositorioCartaIntencoesObservacao, RepositorioCartaIntencoesObservacao>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoCartaIntencoesObservacao, RepositorioNotificacaoCartaIntencoesObservacao>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoDevolutiva, RepositorioNotificacaoDevolutiva>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaAula, RepositorioPendenciaAula>();
            services.TryAddScopedWorkerService<IRepositorioPlanejamentoAnual, RepositorioPlanejamentoAnual>();
            services.TryAddScopedWorkerService<IRepositorioComponenteCurricular, RepositorioComponenteCurricular>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaProfessor, RepositorioPendenciaProfessor>();
            services.TryAddScopedWorkerService<IRepositorioRemoveConexaoIdle, RepositorioRemoveConexaoIdle>();
            services.TryAddScopedWorkerService<IRepositorioAreaDoConhecimento, RepositorioAreaDoConhecimento>();
            services.TryAddScopedWorkerService<IRepositorioComponenteCurricularGrupoAreaOrdenacao, RepositorioComponenteCurricularGrupoAreaOrdenacao>();


            // Acompanhamento Aluno
            services.TryAddScopedWorkerService<IRepositorioAcompanhamentoAluno, RepositorioAcompanhamentoAluno>();
            services.TryAddScopedWorkerService<IRepositorioAcompanhamentoAlunoSemestre, RepositorioAcompanhamentoAlunoSemestre>();
            services.TryAddScopedWorkerService<IRepositorioAcompanhamentoAlunoFoto, RepositorioAcompanhamentoAlunoFoto>();

            // Acompanhamento Turma
            services.TryAddScopedWorkerService<IObterParametroQuantidadeImagensPercursoColetivoTurmaUseCase, ObterParametroQuantidadeImagensPercursoColetivoTurmaUseCase>();

            // Mural de Avisos
            services.TryAddScopedWorkerService<IRepositorioAviso, RepositorioAviso>();

            // Encaminhamento AEE
            services.TryAddScopedWorkerService<IRepositorioSecaoEncaminhamentoAEE, RepositorioSecaoEncaminhamentoAEE>();
            services.TryAddScopedWorkerService<IRepositorioEncaminhamentoAEE, RepositorioEncaminhamentoAEE>();
            services.TryAddScopedWorkerService<IRepositorioEncaminhamentoAEESecao, RepositorioEncaminhamentoAEESecao>();
            services.TryAddScopedWorkerService<IRepositorioQuestaoEncaminhamentoAEE, RepositorioQuestaoEncaminhamentoAEE>();
            services.TryAddScopedWorkerService<IRepositorioRespostaEncaminhamentoAEE, RepositorioRespostaEncaminhamentoAEE>();

            // EventoTipo
            services.TryAddScopedWorkerService<IRepositorioEventoTipo, RepositorioEventoTipo>();
            services.TryAddScopedWorkerService<IRepositorioPerfilEventoTipo, RepositorioPerfilEventoTipo>();

            // Questionario
            services.TryAddScopedWorkerService<IRepositorioQuestionario, RepositorioQuestionario>();
            services.TryAddScopedWorkerService<IRepositorioQuestao, RepositorioQuestao>();
            services.TryAddScopedWorkerService<IRepositorioOpcaoResposta, RepositorioOpcaoResposta>();

            services.TryAddScoped<IRepositorioRegistroIndividual, RepositorioRegistroIndividual>();
            services.TryAddScopedWorkerService<IRepositorioOcorrencia, RepositorioOcorrencia>();
            services.TryAddScopedWorkerService<IRepositorioOcorrenciaAluno, RepositorioOcorrenciaAluno>();
            services.TryAddScopedWorkerService<IRepositorioOcorrenciaTipo, RepositorioOcorrenciaTipo>();

            // Itinerância
            services.TryAddScopedWorkerService<IRepositorioWfAprovacaoItinerancia, RepositorioWfAprovacaoItinerancia>();

            // PlanoAEE
            services.TryAddScopedWorkerService<IRepositorioPlanoAEE, RepositorioPlanoAEE>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAEEVersao, RepositorioPlanoAEEVersao>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAEEQuestao, RepositorioPlanoAEEQuestao>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAEEResposta, RepositorioPlanoAEEResposta>();
            services.TryAddScopedWorkerService<IRepositorioPlanoAEEReestruturacao, RepositorioPlanoAEEReestruturacao>();
            services.TryAddScopedWorkerService<IRepositorioPendenciaPlanoAEE, RepositorioPendenciaPlanoAEE>();

            services.TryAddScopedWorkerService<IRepositorioPlanoAEEObservacao, RepositorioPlanoAEEObservacao>();
            services.TryAddScopedWorkerService<IRepositorioNotificacaoPlanoAEEObservacao, RepositorioNotificacaoPlanoAEEObservacao>();

            // Consolidação Frequencia Turma
            services.TryAddScopedWorkerService<IRepositorioConsolidacaoFrequenciaTurma, RepositorioConsolidacaoFrequenciaTurma>();


            // Consolidação Devolutivas
            services.TryAddScopedWorkerService<IRepositorioConsolidacaoDevolutivas, RepositorioConsolidacaoDevolutivas>();
            services.TryAddScopedWorkerService<IRepositorioRegistroFrequenciaAluno, RepositorioRegistroFrequenciaAluno>();


            // Consolidacao de Acompanhamento Aprendizagem Aluno
            services.TryAddScoped<IRepositorioConsolidacaoAcompanhamentoAprendizagemAluno, RepositorioConsolidacaoAcompanhamentoAprendizagemAluno>();
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IServicoWorkflowAprovacao, ServicoWorkflowAprovacao>();
            services.TryAddScopedWorkerService<IServicoNotificacao, ServicoNotificacao>();
            services.TryAddScopedWorkerService<IServicoUsuario, ServicoUsuario>();
            services.TryAddScopedWorkerService<IServicoAutenticacao, ServicoAutenticacao>();
            services.TryAddScopedWorkerService<IServicoPerfil, ServicoPerfil>();
            services.TryAddScopedWorkerService<IServicoEmail, ServicoEmail>();
            services.TryAddScopedWorkerService<IServicoTokenJwt, ServicoTokenJwt>();
            services.TryAddScopedWorkerService<IServicoMenu, ServicoMenu>();
            services.TryAddScopedWorkerService<IServicoPeriodoEscolar, ServicoPeriodoEscolar>();
            services.TryAddScopedWorkerService<IServicoFeriadoCalendario, ServicoFeriadoCalendario>();
            services.TryAddScopedWorkerService<IServicoAbrangencia, ServicoAbrangencia>();
            services.TryAddScopedWorkerService<IServicoEvento, ServicoEvento>();
            services.TryAddScopedWorkerService<IServicoLog, ServicoLog>();
            services.TryAddScopedWorkerService<IServicoFrequencia, ServicoFrequencia>();
            services.TryAddScopedWorkerService<IServicoAtribuicaoEsporadica, ServicoAtribuicaoEsporadica>();
            services.TryAddScopedWorkerService<IServicoCalculoFrequencia, ServicoCalculoFrequencia>();
            services.TryAddScopedWorkerService<IServicoNotificacaoFrequencia, ServicoNotificacaoFrequencia>();
            services.TryAddScopedWorkerService<IServicoAluno, ServicoAluno>();
            services.TryAddScopedWorkerService<IServicoCompensacaoAusencia, ServicoCompensacaoAusencia>();
            services.TryAddScopedWorkerService<IServicoAtribuicaoCJ, ServicoAtribuicaoCJ>();
            services.TryAddScopedWorkerService<IServicoDeNotasConceitos, ServicoDeNotasConceitos>();
            services.TryAddScopedWorkerService<IServicoFechamentoFinal, ServicoFechamentoFinal>();
            services.TryAddScopedWorkerService<IServicoPeriodoFechamento, ServicoPeriodoFechamento>();
            services.TryAddScopedWorkerService<IServicoFechamentoTurmaDisciplina, ServicoFechamentoTurmaDisciplina>();
            services.TryAddScopedWorkerService<IServicoPendenciaFechamento, ServicoPendenciaFechamento>();
            services.TryAddScopedWorkerService<IServicoConselhoClasse, ServicoConselhoClasse>();
            services.TryAddScopedWorkerService<IServicoCalculoParecerConclusivo, ServicoCalculoParecerConclusivo>();
            services.TryAddScopedWorkerService<IServicoObjetivosAprendizagem, ServicoObjetivosAprendizagem>();
            services.TryAddScopedWorkerService<IServicoFila, FilaRabbit>();
        }

        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IObterUltimaVersaoUseCase, ObterUltimaVersaoUseCase>();
            services.TryAddScopedWorkerService<IImpressaoConselhoClasseAlunoUseCase, ImpressaoConselhoClasseAlunoUseCase>();
            services.TryAddScopedWorkerService<IImpressaoConselhoClasseTurmaUseCase, ImpressaoConselhoClasseTurmaUseCase>();
            services.TryAddScopedWorkerService<IReceberRelatorioProntoUseCase, ReceberRelatorioProntoUseCase>();
            services.TryAddScopedWorkerService<IBoletimUseCase, BoletimUseCase>();
            services.TryAddScopedWorkerService<IObterListaAlunosDaTurmaUseCase, ObterListaAlunosDaTurmaUseCase>();
            services.TryAddScopedWorkerService<IReceberDadosDownloadRelatorioUseCase, ReceberDadosDownloadRelatorioUseCase>();
            services.TryAddScopedWorkerService<IRelatorioConselhoClasseAtaFinalUseCase, RelatorioConselhoClasseAtaFinalUseCase>();
            services.TryAddScopedWorkerService<IGamesUseCase, GamesUseCase>();
            services.TryAddScopedWorkerService<IPodeCadastrarAulaUseCase, PodeCadastrarAulaUseCase>();
            services.TryAddScopedWorkerService<IExcluirAulaRecorrenteUseCase, ExcluirAulaRecorrenteUseCase>();
            services.TryAddScopedWorkerService<IInserirAulaRecorrenteUseCase, InserirAulaRecorrenteUseCase>();
            services.TryAddScopedWorkerService<IAlterarAulaRecorrenteUseCase, AlterarAulaRecorrenteUseCase>();
            services.TryAddScopedWorkerService<INotificarUsuarioUseCase, NotificarUsuarioUseCase>();
            services.TryAddScoped<IHistoricoEscolarUseCase, HistoricoEscolarUseCase>();
            services.TryAddScoped<IObterAlunosPorCodigoEolNomeUseCase, ObterAlunosPorCodigoEolNomeUseCase>();
            services.TryAddScoped<IRelatorioPendenciasUseCase, RelatorioPendenciasFechamentoUseCase>();
            services.TryAddScoped<IInserirDiarioBordoUseCase, InserirDiarioBordoUseCase>();
            services.TryAddScoped<IObterDatasAulasPorTurmaEComponenteUseCase, ObterDatasAulasPorTurmaEComponenteUseCase>();
            services.TryAddScoped<IObterFrequenciaOuPlanoNaRecorrenciaUseCase, ObterFrequenciaOuPlanoNaRecorrenciaUseCase>();
            services.TryAddScoped<IObterFiltroRelatoriosAnosPorCicloModalidadeUseCase, ObterFiltroRelatoriosAnosPorCicloModalidadeUseCase>();
            services.TryAddScoped<IRelatorioCompensacaoAusenciaUseCase, RelatorioCompensacaoAusenciaUseCase>();
            services.TryAddScoped<IRelatorioCalendarioUseCase, RelatorioCalendarioUseCase>();

            services.TryAddScopedWorkerService<IExcluirDevolutivaUseCase, ExcluirDevolutivaUseCase>();
            services.TryAddScopedWorkerService<IObterListaDevolutivasPorTurmaComponenteUseCase, ObterListaDevolutivasPorTurmaComponenteUseCase>();
            services.TryAddScopedWorkerService<IObterDiariosBordoPorDevolutiva, ObterDiariosBordoPorDevolutiva>();
            services.TryAddScopedWorkerService<IObterDevolutivaPorIdUseCase, ObterDevolutivaPorIdUseCase>();
            services.TryAddScopedWorkerService<IObterDiariosDeBordoPorPeriodoUseCase, ObterDiariosDeBordoPorPeriodoUseCase>();
            services.TryAddScopedWorkerService<IObterDataDiarioBordoSemDevolutivaPorTurmaComponenteUseCase, ObterDataDiarioBordoSemDevolutivaPorTurmaComponenteUseCase>();
            services.TryAddScopedWorkerService<IObterDiarioBordoPorIdUseCase, ObterDiarioBordoPorIdUseCase>();
            services.TryAddScopedWorkerService<ICartaIntencoesPersistenciaUseCase, CartaIntencoesPersistenciaUseCase>();
            services.TryAddScopedWorkerService<IObterCartasDeIntencoesPorTurmaEComponenteUseCase, ObterCartasDeIntencoesPorTurmaEComponenteUseCase>();
            services.TryAddScoped<ICriarAulasInfantilAutomaticamenteUseCase, CriarAulasInfantilAutomaticamenteUseCase>();
            services.TryAddScoped<ICriarAulasInfantilUseCase, CriarAulasInfantilUseCase>();
            services.TryAddScoped<ISincronizarAulasInfantilUseCase, SincronizarAulasInfantilUseCase>();
            services.TryAddScoped<IObterAnotacaoFrequenciaAlunoUseCase, ObterAnotacaoFrequenciaAlunoUseCase>();
            services.TryAddScoped<IAlterarAnotacaoFrequenciaAlunoUseCase, AlterarAnotacaoFrequenciaAlunoUseCase>();
            services.TryAddScoped<IExcluirAnotacaoFrequenciaAlunoUseCase, ExcluirAnotacaoFrequenciaAlunoUseCase>();
            services.TryAddScopedWorkerService<IObterAnotacaoFrequenciaAlunoPorIdUseCase, ObterAnotacaoFrequenciaAlunoPorIdUseCase>();
            services.TryAddScoped<IObterMotivosAusenciaUseCase, ObterMotivosAusenciaUseCase>();

            services.TryAddScopedWorkerService<IObterDashBoardUseCase, ObterDashBoardUseCase>();

            services.TryAddScopedWorkerService<IInserirDevolutivaUseCase, InserirDevolutivaUseCase>();
            services.TryAddScopedWorkerService<IAlterarDevolutivaUseCase, AlterarDevolutivaUseCase>();

            services.TryAddScopedWorkerService<IListarCartaIntencoesObservacoesPorTurmaEComponenteUseCase, ListarCartaIntencoesObservacoesPorTurmaEComponenteUseCase>();
            services.TryAddScopedWorkerService<ISalvarCartaIntencoesObservacaoUseCase, SalvarCartaIntencoesObservacaoUseCase>();
            services.TryAddScopedWorkerService<IAlterarCartaIntencoesObservacaoUseCase, AlterarCartaIntencoesObservacaoUseCase>();
            services.TryAddScopedWorkerService<IExcluirCartaIntencoesObservacaoUseCase, ExcluirCartaIntencoesObservacaoUseCase>();
            services.TryAddScopedWorkerService<IObterPeriodosEscolaresParaCopiaPorPlanejamentoAnualIdUseCase, ObterPeriodosEscolaresParaCopiaPorPlanejamentoAnualIdUseCase>();
            services.TryAddScopedWorkerService<IObterPlanejamentoAnualPorTurmaComponentePeriodoEscolarUseCase, ObterPlanejamentoAnualPorTurmaComponentePeriodoEscolarUseCase>();
            services.TryAddScopedWorkerService<IObterPlanejamentoAnualPorTurmaComponenteUseCase, ObterPlanejamentoAnualPorTurmaComponenteUseCase>();
            services.TryAddScopedWorkerService<IPendenciaAulaUseCase, PendenciaAulaUseCase>();
            services.TryAddScopedWorkerService<IExecutaPendenciaAulaUseCase, ExecutaPendenciaAulaUseCase>();
            services.TryAddScopedWorkerService<ISalvarNotificacaoCartaIntencoesObservacaoUseCase, SalvarNotificacaoCartaIntencoesObservacaoUseCase>();
            services.TryAddScopedWorkerService<IExcluirNotificacaoCartaIntencoesObservacaoUseCase, ExcluirNotificacaoCartaIntencoesObservacaoUseCase>();
            services.TryAddScopedWorkerService<INotificarDiarioBordoObservacaoUseCase, NotificarDiarioBordoObservacaoUseCase>();
            services.TryAddScopedWorkerService<IObterJustificativasAlunoPorComponenteCurricularUseCase, ObterJustificativasAlunoPorComponenteCurricularUseCase>();
            services.TryAddScopedWorkerService<IAlterarNotificacaoObservacaoDiarioBordoUseCase, AlterarNotificacaoObservacaoDiarioBordoUseCase>();
            services.TryAddScopedWorkerService<IObterFechamentoConsolidadoPorTurmaBimestreUseCase, ObterFechamentoConsolidadoPorTurmaBimestreUseCase>();
            services.TryAddScopedWorkerService<IExecutarConsolidacaoTurmaFechamentoComponenteUseCase, ExecutarConsolidacaoTurmaFechamentoComponenteUseCase>();
            services.TryAddScopedWorkerService<IExecutarConsolidacaoTurmaGeralUseCase, ExecutarConsolidacaoTurmaGeralUseCase>();

            services.TryAddScopedWorkerService<ISalvarNotificacaoDevolutivaUseCase, SalvarNotificacaoDevolutivaUseCase>();
            services.TryAddScopedWorkerService<IExcluirNotificacaoDevolutivaUseCase, ExcluirNotificacaoDevolutivaUseCase>();

            services.TryAddScopedWorkerService<IExcluirNotificacaoDiarioBordoUseCase, ExcluirNotificacaoDiarioBordoUseCase>();
            services.TryAddScopedWorkerService<IObterListagemDiariosDeBordoPorPeriodoUseCase, ObterListagemDiariosDeBordoPorPeriodoUseCase>();
            services.TryAddScopedWorkerService<IObterDataDiarioBordoSemDevolutivaPorTurmaComponenteUseCase, ObterDataDiarioBordoSemDevolutivaPorTurmaComponenteUseCase>();
            services.TryAddScopedWorkerService<IObterAnosLetivosPAPUseCase, ObterAnosLetivosPAPUseCase>();
            services.TryAddScopedWorkerService<IObterPeriodosEscolaresPorAnoEModalidadeTurmaUseCase, ObterPeriodosEscolaresPorAnoEModalidadeTurmaUseCase>();
            services.TryAddScopedWorkerService<IRelatorioPlanoAulaUseCase, RelatorioPlanoAulaUseCase>();
            services.TryAddScopedWorkerService<IObterComponentesCurricularesRegenciaPorTurmaUseCase, ObterComponentesCurricularesRegenciaPorTurmaUseCase>();
            services.TryAddScopedWorkerService<IObterPeriodoEscolarPorTurmaUseCase, ObterPeriodoEscolarPorTurmaUseCase>();

            // Aulas Previstas
            services.TryAddScopedWorkerService<IExecutaNotificacaoAulasPrevistasUseCase, ExecutaNotificacaoAulasPrevistasUseCase>();
            services.TryAddScopedWorkerService<INotificacaoAulasPrevistrasSyncUseCase, NotificacaoAulasPrevistrasSyncUseCase>();
            services.TryAddScopedWorkerService<INotificacaoAulasPrevistrasUseCase, NotificacaoAulasPrevistrasUseCase>();

            // Avisos do Mural Gsa
            services.TryAddScopedWorkerService<IImportarAvisoDoMuralGsaUseCase, ImportarAvisoDoMuralGsaUseCase>();
            services.TryAddScopedWorkerService<IObterMuralAvisosUseCase, ObterMuralAvisosUseCase>();

            // Conselho de classe
            services.TryAddScopedWorkerService<IAtualizarSituacaoConselhoClasseUseCase, AtualizarSituacaoConselhoClasseUseCase>();

            // Consolidacao Frequencia Turma
            services.TryAddScopedWorkerService<IExecutarConsolidacaoFrequenciaTurmaSyncUseCase, ExecutarConsolidacaoFrequenciaTurmaSyncUseCase>();
            services.TryAddScopedWorkerService<IConsolidarFrequenciaTurmasUseCase, ConsolidarFrequenciaTurmasUseCase>();
            services.TryAddScopedWorkerService<IConsolidarFrequenciaPorTurmaUseCase, ConsolidarFrequenciaPorTurmaUseCase>();

            // Fechamento
            services.TryAddScopedWorkerService<IGerarPendenciasFechamentoUseCase, GerarPendenciasFechamentoUseCase>();

            // Frequência
            services.TryAddScopedWorkerService<IConciliacaoFrequenciaTurmasCronUseCase, ConciliacaoFrequenciaTurmasCronUseCase>();
            services.TryAddScopedWorkerService<IConciliacaoFrequenciaTurmasSyncUseCase, ConciliacaoFrequenciaTurmasSyncUseCase>();
            services.TryAddScopedWorkerService<IValidacaoAusenciaConcolidacaoFrequenciaTurmaUseCase, ValidacaoAusenciaConcolidacaoFrequenciaTurmaUseCase>();

            // Notificações
            services.TryAddScopedWorkerService<IExecutaNotificacaoAndamentoFechamentoUseCase, ExecutaNotificacaoAndamentoFechamentoUseCase>();
            services.TryAddScopedWorkerService<INotificacaoAndamentoFechamentoUseCase, NotificacaoAndamentoFechamentoUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoUeFechamentosInsuficientesUseCase, ExecutaNotificacaoUeFechamentosInsuficientesUseCase>();
            services.TryAddScopedWorkerService<INotificacaoUeFechamentosInsuficientesUseCase, NotificacaoUeFechamentosInsuficientesUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoReuniaoPedagogicaUseCase, ExecutaNotificacaoReuniaoPedagogicaUseCase>();
            services.TryAddScopedWorkerService<INotificacaoReuniaoPedagogicaUseCase, NotificacaoReuniaoPedagogicaUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoPeriodoFechamentoUseCase, ExecutaNotificacaoPeriodoFechamentoUseCase>();
            services.TryAddScopedWorkerService<INotificacaoPeriodoFechamentoUseCase, NotificacaoPeriodoFechamentoUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoInicioFimPeriodoFechamentoUseCase, ExecutaNotificacaoInicioFimPeriodoFechamentoUseCase>();
            services.TryAddScopedWorkerService<INotificacaoInicioFimPeriodoFechamentoUseCase, NotificacaoInicioFimPeriodoFechamentoUseCase>();

            //Sincronismo CC Eol
            services.TryAddScopedWorkerService<IListarComponentesCurricularesEolUseCase, ListarComponentesCurricularesEolUseCase>();
            services.TryAddScopedWorkerService<ISincronizarComponentesCurricularesUseCase, SincronizarComponentesCurricularesUseCase>();
            services.TryAddScopedWorkerService<IExecutaSincronismoComponentesCurricularesEolUseCase, ExecutaSincronismoComponentesCurricularesEolUseCase>();

            services.TryAddScopedWorkerService<IObterTurmasParaCopiaUseCase, ObterTurmasParaCopiaUseCase>();
            services.TryAddScopedWorkerService<ISalvarPlanoAulaUseCase, SalvarPlanoAulaUseCase>();
            services.TryAddScopedWorkerService<ICalculoFrequenciaTurmaDisciplinaUseCase, CalculoFrequenciaTurmaDisciplinaUseCase>();

            // Notificação
            services.TryAddScopedWorkerService<IExecutaNotificacaoFrequenciaUeUseCase, ExecutaNotificacaoFrequenciaUeUseCase>();
            services.TryAddScopedWorkerService<INotificacaoFrequenciaUeUseCase, NotificacaoFrequenciaUeUseCase>();

            //Pendências Gerais
            services.TryAddScopedWorkerService<IExecutaVerificacaoPendenciasGeraisUseCase, ExecutaVerificacaoPendenciasGeraisUseCase>();
            services.TryAddScopedWorkerService<IExecutarExclusaoPendenciasAulaUseCase, ExecutarExclusaoPendenciasAulaUseCase>();
            services.TryAddScopedWorkerService<IExecutarExclusaoPendenciaDiasLetivosInsuficientes, ExecutarExclusaoPendenciaDiasLetivosInsuficientes>();
            services.TryAddScopedWorkerService<IExecutarExclusaoPendenciaParametroEvento, ExecutarExclusaoPendenciaParametroEvento>();
            services.TryAddScopedWorkerService<IPendenciasGeraisUseCase, PendenciasGeraisUseCase>();

            // Pendências Professor
            services.TryAddScopedWorkerService<IExecutaPendenciasProfessorAvaliacaoUseCase, ExecutaPendenciasProfessorAvaliacaoUseCase>();
            services.TryAddScopedWorkerService<IExecutaVerificacaoGeracaoPendenciaProfessorAvaliacaoUseCase, ExecutaVerificacaoGeracaoPendenciaProfessorAvaliacaoUseCase>();
            services.TryAddScopedWorkerService<IExecutarExclusaoPendenciasAusenciaAvaliacaoUseCase, ExecutarExclusaoPendenciasAusenciaAvaliacaoUseCase>();

            //Notificação Resultado Insatisfatorio 
            services.TryAddScoped<IExecutaNotificacaoResultadoInsatisfatorioUseCase, ExecutaNotificacaoResultadoInsatisfatorioUseCase>();
            services.TryAddScoped<INotificarResultadoInsatisfatorioUseCase, NotificarResultadoInsatisfatorioUseCase>();

            // Pendencias Ausencia Fechamento
            services.TryAddScopedWorkerService<IExecutaVerificacaoGeracaoPendenciaAusenciaFechamentoUseCase, ExecutaVerificacaoGeracaoPendenciaAusenciaFechamentoUseCase>();
            services.TryAddScopedWorkerService<IExecutaPendenciasAusenciaFechamentoUseCase, ExecutaPendenciasAusenciaFechamentoUseCase>();
            services.TryAddScopedWorkerService<IExecutarExclusaoPendenciasAusenciaFechamentoUseCase, ExecutarExclusaoPendenciasAusenciaFechamentoUseCase>();

            // Pendencias Ausencia Registro Individual
            services.TryAddScoped<IPublicarPendenciaAusenciaRegistroIndividualUseCase, PublicarPendenciaAusenciaRegistroIndividualUseCase>();
            services.TryAddScoped<IGerarPendenciaAusenciaRegistroIndividualUseCase, GerarPendenciaAusenciaRegistroIndividualUseCase>();
            services.TryAddScoped<IAtualizarPendenciaRegistroIndividualUseCase, AtualizarPendenciaRegistroIndividualUseCase>();

            // Plano AEE
            services.TryAddScopedWorkerService<IExecutaEncerramentoPlanoAEEEstudantesInativosUseCase, ExecutaEncerramentoPlanoAEEEstudantesInativosUseCase>();
            services.TryAddScopedWorkerService<IExecutaPendenciaValidadePlanoAEEUseCase, ExecutaPendenciaValidadePlanoAEEUseCase>();
            services.TryAddScopedWorkerService<IGerarPendenciaValidadePlanoAEEUseCase, GerarPendenciaValidadePlanoAEEUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoPlanoAEEExpiradoUseCase, ExecutaNotificacaoPlanoAEEExpiradoUseCase>();
            services.TryAddScopedWorkerService<INotificarPlanosAEEExpiradosUseCase, NotificarPlanosAEEExpiradosUseCase>();
            services.TryAddScopedWorkerService<IExecutaNotificacaoPlanoAEEEmAbertoUseCase, ExecutaNotificacaoPlanoAEEEmAbertoUseCase>();
            services.TryAddScopedWorkerService<INotificarPlanosAEEEmAbertoUseCase, NotificarPlanosAEEEmAbertoUseCase>();
            services.TryAddScopedWorkerService<IEnviarNotificacaoReestruturacaoPlanoAEEUseCase, EnviarNotificacaoReestruturacaoPlanoAEEUseCase>();
            services.TryAddScopedWorkerService<IEnviarNotificacaoCriacaoPlanoAEEUseCase, EnviarNotificacaoCriacaoPlanoAEEUseCase>();
            services.TryAddScopedWorkerService<IEnviarNotificacaoEncerramentoPlanoAEEUseCase, EnviarNotificacaoEncerramentoPlanoAEEUseCase>();


            services.TryAddScopedWorkerService<IUsuarioPossuiAbrangenciaAcessoSondagemUseCase, UsuarioPossuiAbrangenciaAcessoSondagemUseCase>();

            services.TryAddScopedWorkerService<ITrataNotificacoesNiveisCargosUseCase, TrataNotificacoesNiveisCargosUseCase>();
            services.TryAddScopedWorkerService<IExecutaTrataNotificacoesNiveisCargosUseCase, ExecutaTrataNotificacoesNiveisCargosUseCase>();

            services.TryAddScopedWorkerService<IRelatorioAEAdesaoUseCase, RelatorioAEAdesaoUseCase>();

            services.TryAddScopedWorkerService<ICalculoFrequenciaTurmaDisciplinaUseCase, CalculoFrequenciaTurmaDisciplinaUseCase>();
            services.TryAddScopedWorkerService<IRemoveConexaoIdleUseCase, RemoveConexaoIdleUseCase>();

            services.TryAddScoped<IAlterarRegistroIndividualUseCase, AlterarRegistroIndividualUseCase>();
            services.TryAddScoped<IInserirRegistroIndividualUseCase, InserirRegistroIndividualUseCase>();
            services.TryAddScoped<IExcluirRegistroIndividualUseCase, ExcluirRegistroIndividualUseCase>();
            services.TryAddScoped<IListarAlunosDaTurmaRegistroIndividualUseCase, ListarAlunosDaTurmaRegistroIndividualUseCase>();
            services.TryAddScoped<IObterRegistroIndividualPorAlunoDataUseCase, ObterRegistroIndividualPorAlunoDataUseCase>();
            services.TryAddScoped<IObterRegistroIndividualUseCase, ObterRegistroIndividualUseCase>();
            services.TryAddScoped<IObterRegistrosIndividuaisPorAlunoPeriodoUseCase, ObterRegistrosIndividuaisPorAlunoPeriodoUseCase>();

            services.TryAddScopedWorkerService<IListarOcorrenciasUseCase, ListarOcorrenciasUseCase>();
            services.TryAddScopedWorkerService<IListarTiposOcorrenciaUseCase, ListarTiposOcorrenciaUseCase>();
            services.TryAddScopedWorkerService<IObterOcorrenciaUseCase, ObterOcorrenciaUseCase>();
            services.TryAddScopedWorkerService<IAlterarOcorrenciaUseCase, AlterarOcorrenciaUseCase>();
            services.TryAddScopedWorkerService<IExcluirOcorrenciaUseCase, ExcluirOcorrenciaUseCase>();
            services.TryAddScopedWorkerService<IInserirOcorrenciaUseCase, InserirOcorrenciaUseCase>();

            // Notas GSA
            services.TryAddScopedWorkerService<IImportarNotaAtividadeAvaliativaGsaUseCase, ImportarNotaAtividadeAvaliativaGsaUseCase>();


            //Notificacoes EncaminhamentoAEE
            services.TryAddScopedWorkerService<INotificacaoConclusaoEncaminhamentoAEEUseCase, NotificacaoConclusaoEncaminhamentoAEEUseCase>();
            services.TryAddScopedWorkerService<INotificacaoEncerramentoEncaminhamentoAEEUseCase, NotificacaoEncerramentoEncaminhamentoAEEUseCase>();
            services.TryAddScopedWorkerService<INotificacaoDevolucaoEncaminhamentoAEEUseCase, NotificacaoDevolucaoEncaminhamentoAEEUseCase>();

            services.TryAddScopedWorkerService<IExecutarSyncGeralGoogleClassroomUseCase, ExecutarSyncGeralGoogleClassroomUseCase>();
            services.TryAddScopedWorkerService<IExecutaSyncGsaGoogleClassroomUseCase, ExecutaSyncGsaGoogleClassroomUseCase>();

            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalSyncUseCase, ExecutarSincronizacaoEstruturaInstitucionalSyncUseCase>();

            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalDreSyncUseCase, ExecutarSincronizacaoInstitucionalDreSyncUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalDreTratarUseCase, ExecutarSincronizacaoInstitucionalDreTratarUseCase>();

            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalUeTratarUseCase, ExecutarSincronizacaoInstitucionalUeTratarUseCase>();

            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalTipoEscolaSyncUseCase, ExecutarSincronizacaoInstitucionalTipoEscolaSyncUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalTipoEscolaTratarUseCase, ExecutarSincronizacaoInstitucionalTipoEscolaTratarUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalCicloSyncUseCase, ExecutarSincronizacaoInstitucionalCicloSyncUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalCicloTratarUseCase, ExecutarSincronizacaoInstitucionalCicloTratarUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalTurmaSyncUseCase, ExecutarSincronizacaoInstitucionalTurmaSyncUseCase>();
            services.TryAddScopedWorkerService<IExecutarSincronizacaoInstitucionalTurmaTratarUseCase, ExecutarSincronizacaoInstitucionalTurmaTratarUseCase>();

            services.TryAddScopedWorkerService<INotificacaoSalvarItineranciaUseCase, NotificacaoSalvarItineranciaUseCase>();

            services.TryAddScopedWorkerService<IExecutarConsolidacaoTurmaConselhoClasseAlunoUseCase, ExecutarConsolidacaoTurmaConselhoClasseAlunoUseCase>();
            services.TryAddScopedWorkerService<IExecutarConsolidacaoTurmaUseCase, ExecutarConsolidacaoTurmaUseCase>();

            services.TryAddScopedWorkerService<IExecutarConsolidacaoMatriculaTurmasUseCase, ExecutarConsolidacaoMatriculaTurmasUseCase>();

            // Consolidação Devolutivas
            services.TryAddScopedWorkerService<IExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase, ExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase>();
            services.TryAddScopedWorkerService<IConsolidarDevolutivasPorTurmaInfantilUseCase, ConsolidarDevolutivasPorTurmaInfantilUseCase>();
            services.TryAddScopedWorkerService<IConsolidarFrequenciaPorTurmaUseCase, ConsolidarFrequenciaPorTurmaUseCase>();

            services.TryAddScopedWorkerService<INotificacaoSalvarItineranciaUseCase, NotificacaoSalvarItineranciaUseCase>();

            services.TryAddScopedWorkerService<IAlterarAulaFrequenciaTratarUseCase, AlterarAulaFrequenciaTratarUseCase>();

            services.TryAddScopedWorkerService<IRabbitDeadletterSgpSyncUseCase, RabbitDeadletterSgpSyncUseCase>();
            services.TryAddScopedWorkerService<IRabbitDeadletterSgpTratarUseCase, RabbitDeadletterSgpTratarUseCase>();

            services.TryAddScopedWorkerService<IRabbitDeadletterSrSyncUseCase, RabbitDeadletterSrSyncUseCase>();
            services.TryAddScopedWorkerService<IRabbitDeadletterSrTratarUseCase, RabbitDeadletterSrTratarUseCase>();

            services.TryAddScopedWorkerService<IConciliacaoFrequenciaTurmasAlunosCronUseCase, ConciliacaoFrequenciaTurmasAlunosCronUseCase>();
            services.TryAddScopedWorkerService<IConciliacaoFrequenciaTurmasAlunosSyncUseCase, ConciliacaoFrequenciaTurmasAlunosSyncUseCase>();
            services.TryAddScopedWorkerService<IConciliacaoFrequenciaTurmasAlunosBuscarUseCase, ConciliacaoFrequenciaTurmasAlunosBuscarUseCase>();

            services.TryAddScopedWorkerService<IObterNotasParaAvaliacoesUseCase, ObterNotasParaAvaliacoesUseCase>();
            services.TryAddScopedWorkerService<IObterPeriodosParaConsultaNotasUseCase, ObterPeriodosParaConsultaNotasUseCase>();

            services.TryAddScopedWorkerService<IExecutaNotificacaoAlunosFaltososUseCase, ExecutaNotificacaoAlunosFaltososUseCase>();
            services.TryAddScopedWorkerService<INotificarAlunosFaltososUseCase, NotificarAlunosFaltososUseCase>();
            //Aulas automáticas regencia
            services.TryAddScopedWorkerService<IExecutarSincronizacaoAulasRegenciaAutomaticasUseCase, ExecutarSincronizacaoAulasRegenciaAutomaticasUseCase>();
            services.TryAddScopedWorkerService<ICarregarUesTurmasRegenciaAulaAutomaticaUseCase, CarregarUesTurmasRegenciaAulaAutomaticaUseCase>();
            services.TryAddScopedWorkerService<ISincronizarUeTurmaAulaRegenciaAutomaticaUseCase, SincronizarUeTurmaAulaRegenciaAutomaticaUseCase>();
            services.TryAddScopedWorkerService<ISincronizarAulasRegenciaAutomaticamenteUseCase, SincronizarAulasRegenciaAutomaticamenteUseCase>();

            // Sincronização de Média dos Registros Individuais
            services.TryAddScopedWorkerService<IExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase, ExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase>();
            services.TryAddScopedWorkerService<IConsolidacaoMediaRegistrosIndividuaisTurmaUseCase, ConsolidacaoMediaRegistrosIndividuaisTurmaUseCase>();
            services.TryAddScopedWorkerService<IConsolidacaoMediaRegistrosIndividuaisUseCase, ConsolidacaoMediaRegistrosIndividuaisUseCase>();

            // Sincronizacao Acompanhamento Aprendizagem
            services.TryAddScopedWorkerService<IExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase, ExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase>();
            services.TryAddScopedWorkerService<IConsolidacaoAcompanhamentoAprendizagemAlunosSyncUseCase, ConsolidacaoAcompanhamentoAprendizagemAlunosSyncUseCase>();
            services.TryAddScopedWorkerService<IConsolidacaoAcompanhamentoAprendizagemAlunosPorUEUseCase, ConsolidacaoAcompanhamentoAprendizagemAlunosPorUEUseCase>();
            services.TryAddScopedWorkerService<IConsolidacaoAcompanhamentoAprendizagemAlunosTratarUseCase, ConsolidacaoAcompanhamentoAprendizagemAlunosTratarUseCase>();

            // Rotas Agendamento Sync
            services.TryAddScopedWorkerService<IRotasAgendamentoSyncUseCase, RotasAgendamentoSyncUseCase>();
            services.TryAddScopedWorkerService<IRotasAgendamentoTratarUseCase, RotasAgendamentoTratarUseCase>();

            services.TryAddScopedWorkerService<IExcluirWorkflowAprovacaoPorIdUseCase, ExcluirWorkflowAprovacaoPorIdUseCase>();
            services.TryAddScopedWorkerService<IExcluirNotificacoesPorAulaIdUseCase, ExcluirNotificacoesPorAulaIdUseCase>();
            services.TryAddScopedWorkerService<IExcluirFrequenciaPorAulaIdUseCase, ExcluirFrequenciaPorAulaIdUseCase>();
            services.TryAddScopedWorkerService<IExcluirPlanoAulaPorAulaIdUseCase, ExcluirPlanoAulaPorAulaIdUseCase>();
            services.TryAddScopedWorkerService<IExcluirAnotacoesFrequenciaPorAulaIdUseCase, ExcluirAnotacoesFrequenciaPorAulaIdUseCase>();
            services.TryAddScopedWorkerService<IExcluirDiarioBordoPorAulaIdUseCase, ExcluirDiarioBordoPorAulaIdUseCase>();
        }

        private static void ResgistraDependenciaHttp(IServiceCollection services)
        {
            /// Este método não deveria existir, as dependencias dos objetos abaixo deveriam ser encapsuladas em um contexto da aplicação para serem utilizadas pela WebApi e WorkserService independentemente
            //services.TryAddScopedWorkerService<System.Net.Http.HttpClient>();
            services.TryAddScopedWorkerService<Microsoft.AspNetCore.Http.IHttpContextAccessor, NoHttpContext>();
        }
    }
}
