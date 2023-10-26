namespace SME.Worker.Agendador.Aplicacao
{
    public static class RotasRabbitSgp
    {
        public const string RotaSincronizarAulasInfatil = "sgp.aulas.infantil.sincronizar";
        public const string RotaExecutaVerificacaoPendenciasProfessor = "sgp.pendencias.professor.executa.verificacao";
        public const string RotaExecutaVerificacaoPendenciasAusenciaFechamento = "sgp.pendencias.bimestre.ausencia.fechamento.verificacao";
        public const string RotaNotificacaoAndamentoFechamento = "sgp.fechamento.andamento.notificar";
        public const string RotaNotificacaoInicioFimPeriodoFechamento = "sgp.fechamento.abertura.iniciofim.periodo.notificar";
        public const string RotaGeracaoPendenciasFechamento = "sgp.fechamento.pendencias.gerar";
        public const string RotaNotificacaoUeFechamentosInsuficientes = "sgp.fechamento.insuficiente.notificar";
        public const string RotaNotificacaoResultadoInsatisfatorio = "sgp.notificacao.nova.resultado.insatisfatorio";
        public const string RotaNotificacaoReuniaoPedagogica = "sgp.evento.reuniao.pedagogica.notificar";
        public const string RotaNotificacaoPeriodoFechamento = "sgp.periodo.fechamento.notificar";
        public const string RotaNotificacaoAprovacaoFechamento = "sgp.fechamento.nota.aprovacao.notificar";
        public const string RotaPendenciaAusenciaRegistroIndividual = "sgp.pendencias.professor.ausencia.registro.individual";
        public const string RotaValidacaoAusenciaConciliacaoFrequenciaTurma = "sgp.frequencia.turma.conciliacao.validar";
        public const string EncerrarPlanoAEEEstudantesInativos = "plano.aee.encerrar.inativos";
        public const string GerarPendenciaValidadePlanoAEE = "plano.aee.pendencia.validade";
        public const string NotificarPlanoAEEExpirado = "plano.aee.notificar.expirados";
        public const string NotificarPlanoAEEEmAberto = "plano.aee.notificar.emaberto";
        public const string SincronizaEstruturaInstitucionalDreSync = "sgp.sincronizacao.institucional.dre.sync";
        public const string SincronizaEstruturaInstitucionalTipoEscolaSync = "sgp.sincronizacao.institucional.tipoescola.sync";
        public const string SincronizaEstruturaInstitucionalCicloSync = "sgp.sincronizacao.institucional.ciclo.sync";
        public const string ConsolidacaoMatriculasTurmasDreCarregar = "sgp.matricula.turma.consolidar.dre.carregar";
        public const string RotaConciliacaoFrequenciaTurmasSync = "sgp.frequencia.turma.conciliacao.sync";
        public const string RotaNotificacaoAlunosFaltosos = "sgp.aulas.alunos.faltosos.notificar";
        public const string RotaNotificacaoAulasPrevistasSync = "sgp.aulas.previstas.notificacao.sync";
        public const string ConsolidarDevolutivasPorUE = "sgp.consolidacao.devolutivas.turma.infantil.ue";
        public const string ConsolidarDevolutivasPorTurmaInfantil = "sgp.consolidacao.devolutivas.turma.infantil";
        public const string ConsolidarDiariosBordoCarregar = "sgp.consolidacao.diarios.bordo.carregar";
        public const string CarregarDadosUeTurmaRegenciaAutomaticamente = "aulas.automaticas.regencia.ue.turma.carregar";
        public const string ConsolidarMediaRegistrosIndividuaisTurma = "sgp.consolidacao.media.registros.individuais.turma";
        public const string ConsolidarAcompanhamentoAprendizagemAluno = "sgp.sincronizacao.acompanhamento.aprendizado.aluno";
        public const string RotaAgendamentoTratar = "sgp.agendamento.tratar";
        public const string NotifificarRegistroFrequencia = "sgp.registro.frequencia.notificacao";
        public const string SincronizarObjetivosComJurema = "sgp.sincronizar.objetivos.com.jurema";
        public const string NotificarAlunosFaltososBimestre = "sgp.alunos.faltosos.bimestre.notificacao";
        public const string NotificacoesNiveisCargos = "sgp.notificacoes.nivel.cargos";
        public const string SincronizarComponentesCurriculares = "sgp.sincronizar.componentes.curriculares";
        public const string SincronizarComponentesCurricularesEol = "sgp.sincronizar.componentes.curriculares.eol";
        public const string SyncGeralGoogleClassroom = "sgp.sync.geral.google.classroom";
        public const string SyncGsaGoogleClassroom = "sgp.sync.gsa.google.classroom";        
        public const string TratarNotificacoesNiveisCargos = "sgp.tratar.notificacoes.niveis.cargos";
        public const string PendenciasGerais = "sgp.pendencias.gerais";
        public const string ExecutaPendenciasAula = "sgp.pendencias.aulas.executa";
        public const string ConsolidacaoFrequenciasTurmasCarregar = "sgp.frequencia.turma.carregar";
        public const string ConsolidarRegistrosPedagogicos = "sgp.consolidacao.registros.pedagogicos";
        public const string RemoverAtribuicaoPendenciaUsuariosUseCase = "sgp.pendencias.perfil.usuario.remover.atribuicao";
        public const string VarreduraFechamentosTurmaDisciplinaEmProcessamentoPendentes = "sgp.fechamento.turma.disciplina.processamento.varredura";
        public const string EncerrarEncaminhamentoAEEAutomaticoSync = "sgp.encaminhamento.aee.encerrar.automatico.sync";

        public const string SyncSerapEstudantesProvas = "sgp.sync.serap.estudantes.provas";
        public const string RotaReprocessarDiarioBordoPendenciaDevolutivaPorDre = "sgp.diario.bordo.pendencia.devolutiva.dre";
        public const string RotaRemoverAtribuicaoDeResponsaveis = "sgp.remover.atribuicao.responsaveis";
        public const string RotaNotificacaoAprovacaoNotaPosConselho = "sgp.conselho.classe.nota.pos.conselho.aprovacao.notificar";
        public const string RotaNotificacaoAprovacaoParecerConclusivoConselhoClasse = "sgp.conselho.classe.parecer.conclusivo.aprovacao.notificar";
        public const string ExecutarAtualizacaoDasInformacoesEncaminhamentoNAAPA = "sgp.atualizar.informacoes.encaminhamento.naapa";
        public const string RotaExcluirPendenciaCalendarioAnoAnteriorCalendario = "sgp.pendencias.calendario.excluir.ano.anterior";
        public const string RotaExecutarExclusaoPendenciasNoFinalDoAnoLetivoPorAno = "sgp.pendencias.excluir.final.anoletivo.ano";
        public const string ExecutarAtualizacaoDosTotalizadoresDasPendencias = "sgp.atualizar.totalizadores.pendencias";
        public const string ExecutarCargaConsolidadoEncaminhamentoNAAPA = "sgp.carga.consolidado.encaminhamento.naapa";
        public const string ExecutarAtualizacaoDasInformacoesPlanoAEE = "sgp.atualizar.informacoes.plano.aee";
        public const string ExecutarAtualizacaoTabelaPlanoAEETurmaAluno = "plano.aee.turma.aluno.sync";
        public const string ExecutarAtualizacaoTabelaEncaminhamentoAEETurmaAluno = "encaminhamento.aee.turma.aluno.sync";
        public const string IdentificarFrequenciaAlunoPresencasMaiorTotalAulas = "sgp.frequencia.aluno.identificar.presencas.maior.total.aulas";
        public const string ExecutarNotificacaoInatividadeAtendimentoNAAPA = "sgp.encaminhamento.naapa.inatividade.atendimento.notificar";
    }
}
