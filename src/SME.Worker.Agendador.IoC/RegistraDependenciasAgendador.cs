using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.SGP.Dados;
using SME.SGP.Dados.Repositorios;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Interfaces;
using SME.SGP.Dominio.Interfaces.Repositorios;
using SME.Worker.Agendador.IoC.Extensions;
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
            //RegistrarRepositorios(services);
            //RegistrarRepositoriosAplicacao(services);
            
            services.TryAddScopedWorkerService<IRepositorioTestePostgre, RepositorioTestePostgre>();
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
    }
}
