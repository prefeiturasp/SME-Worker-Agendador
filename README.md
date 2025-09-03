# SME-Worker-Agendador

---

# Agendamento de Tarefas Recorrentes (Jobs)

A tabela abaixo descreve todas as tarefas recorrentes (jobs) executadas pelo Worker.

**IMPORTANTE:** O servidor opera em fuso horário **UTC**. A coluna "Horário (Local)" representa o horário de Brasília (**UTC-3**), que é o horário de referência para a execução das tarefas.

## SGP (Sistema de Gestão Pedagógica)

| Horário (Local) | Horário (UTC) | Frequência | Tarefa (UseCase) | Descrição |
| :--- | :--- | :--- | :--- | :--- |
| 11:00 | 14:00 | Seg a Sex | `ITratarNotificacoesNiveisCargos` | Trata as notificações por níveis de cargos. |
| 14:00 | 17:00 | Diária | `IExecutarConsolidacaoFrequenciaTurmaSync` | Executa a consolidação da frequência da turma. |
| 15:00 | 18:00 | Semanal (Seg) | `IIdentificarFrequenciaAlunoPresencasMaiorTotalAulas` | Identifica inconsistências de frequência de alunos. |
| 18:00 | 21:00 | Diária | `IReprocessarDiarioBordoPendenciaDevolutiva` | Reprocessa diários de bordo com pendência de devolutiva. |
| 19:00 | 22:00 | Diária | `ISincronizarObjetivosComJurema` | Sincroniza os objetivos de aprendizagem com a Jurema. |
| 20:00 | 23:00 | Semanal (Sáb) | `IConsolidacaoDiariosBordoTurmas` | Consolida os diários de bordo das turmas. |
| 20:00 | 23:00 | Semanal (Sáb) | `IConciliacaoFrequenciaTurmasCron` | Executa a conciliação de frequência das turmas. |
| 22:00 | 01:00 | Diária | `IExecutaEncerramentoPlanoAEEEstudantesInativos` | Encerra planos AEE de estudantes inativos. |
| 23:00 | 02:00 | Diária | `INotifificarRegistroFrequencia` | Notifica sobre o registro de frequência. |
| 23:00 | 02:00 | Diária | `IExecutaNotificacaoAulasPrevistas` | Notifica sobre aulas previstas. |
| 23:00 | 02:00 | Diária | `IExecutaNotificacaoAlunosFaltosos` | Notifica sobre alunos faltosos. |
| 23:00 | 02:00 | Diária | `IPublicarPendenciaAusenciaRegistroIndividual` | Publica pendências de ausência de registro individual. |
| 23:00 | 02:00 | Diária | `IExecutarVarreduraFechamentosEmProcessamentoPendentes` | Varre fechamentos em processamento com pendências. |
| 23:00 | 02:00 | Diária | `IExecutaNotificacaoAprovacaoFechamentoNota` | Notifica sobre a aprovação de fechamento de nota. |
| 23:00 | 02:00 | Diária | `INotificarFreqMinimaMensalInsuficienteAlunoBuscaAtiva` | Notifica sobre frequência mínima mensal insuficiente. |
| 00:00 | 03:00 | Anual (1/Jan) | `IExcluirPendenciaCalendarioAnoAnterior` | Exclui pendências de calendário do ano anterior. |
| 00:00 | 03:00 | Anual (1/Jan) | `IRemoverPendenciasNoFinalDoAnoLetivo` | Remove pendências ao final do ano letivo. |
| 00:00 | 03:00 | Diária | `INotificarAlunosFaltososBimestre` | Notifica alunos faltosos no bimestre. |
| 00:30 | 03:30 | Diária | `IConsolidarNivelEscritaAlfabetizacao` | Consolida o nível de escrita e alfabetização. |
| 00:50 | 03:50 | Diária | `IConsolidarNivelEscritaAlfabetizacaoCritico` | Consolida o nível de escrita crítico. |
| 01:00 | 04:00 | Diária | `ISincronizarComponentesCurricularesEol` | Sincroniza componentes curriculares do EOL. |
| 01:00 | 04:00 | Diária | `IConsolidacaoReflexoFrequenciaBuscaAtiva` | Consolida reflexo de frequência da busca ativa. |
| 02:00 | 05:00 | Diária | `IPendenciasGerais`, `IPendenciasAula`, e mais 9 jobs | Executa um grande volume de jobs de pendências e notificações. |
| 02:15 | 05:15 | Diária | `IExecutaNotificacaoAndamentoFechamento` e mais 3 jobs | Executa jobs de notificação sobre andamento de fechamentos. |
| 03:00 | 06:00 | Diária | `ISincronizarAulasInfantil` | Sincroniza aulas da educação infantil. |
| 03:00 | 06:00 | Diária | `IExecutarConsolidacaoRegistrosPedagogicos` | Executa a consolidação de registros pedagógicos. |
| 03:00 | 06:00 | Diária | `IConsolidacaoInformacoesProdutividadeFrequencia` | Consolida informações de produtividade e frequência. |
| 04:00 | 07:00 | Diária | `IExecutarSincronizacaoDevolutivasPorTurmaInfantilSync` | Sincroniza devolutivas por turma da ed. infantil. |
| 04:00 | 07:00 | Diária | `IConsolidarInformacoesFrequenciaPainelEducacional` | Consolida informações de frequência para o painel. |
| 05:00 | 08:00 | Diária | `IExecutaPendenciaValidadePlanoAEE` | Executa pendências de validade do plano AEE. |
| 05:00 | 08:00 | Diária | `IAtualizarCargaDashboardConsolidadoEncaminhamentoNAAPA` | Atualiza carga do dashboard consolidado do NAAPA. |
| 05:00 | 08:00 | Diária | `IExecutarExclusaoDasNotificacoes` | Executa a exclusão de notificações antigas. |
| 05:00 | 08:00 | Diária | `IAtualizarMapeamentoDosEstudantes` | Atualiza o mapeamento dos estudantes. |
| 06:00 | 09:00 | Diária | `IExecutarSincronizacaoAulasRegenciaAutomaticas` | Sincroniza aulas de regência automáticas. |
| 06:00 | 09:00 | Diária | `IExecutarSincronizacaoMediaRegistrosIndividuaisSync` | Sincroniza a média de registros individuais. |
| 06:00 | 09:00 | Diária | `IExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSync` | Sincroniza o acompanhamento da aprendizagem do aluno. |
| 06:00 | 09:00 | Diária | `IEncerrarEncaminhamentoAEEAutomaticoSync` | Encerra encaminhamentos AEE automaticamente. |
| 06:30 | 09:30 | Diária | `IExecutarSincronizacaoInstitucionalSync` | Sincroniza dados institucionais. |
| 07:00 | 10:00 | Diária | `IExecutarConsolidacaoMatriculaTurmas` | Executa a consolidação de matrículas das turmas. |
| 07:00 | 10:00 | Diária | `IRotasAgendamentoSync` | Sincroniza rotas de agendamento. |
| 07:00 | 10:00 | Diária | `IAtualizarInformacoesDoEncaminhamentoNAAPA` | Atualiza informações do encaminhamento NAAPA. |
| 07:00 | 10:00 | Diária | `IAtualizarTotalizadoresDePendencia` | Atualiza os totalizadores de pendências. |
| 07:00 | 10:00 | Diária | `IAtualizarInformacoesDoPlanoAEE` e mais 3 jobs | Atualiza informações de planos e encaminhamentos AEE/NAAPA. |
| 07:30 | 10:30 | Diária | `IRemoverAtribuicaoResponsaveis` | Remove atribuição de responsáveis. |

## EOL (Escola Online)

| Horário (Local) | Horário (UTC) | Frequência | Tarefa (UseCase) | Descrição |
| :--- | :--- | :--- | :--- | :--- |
| 04:30 | 07:30 | Diária | `IInserirFuncionariosEolElasticSearch` | Insere funcionários do EOL no ElasticSearch. |
| 05:30 | 08:30 | Diária | `ISincronismoAgrupamentoComponentesTerritorioEol` | Sincroniza agrupamento de componentes do Território Saber. |
| 05:30 | 08:30 | Diária | `IGerarCacheAtribuicaoResponsaveis` | Gera cache de atribuições de responsáveis/esporádicas. |
| 06:00 | 09:00 | Diária | `IGerarAbrangenciasPerfisUsuarioElasticSearch` | Gera abrangências e perfis de usuário no ElasticSearch. |
| 06:30 e 07:30| 09:30 e 10:30| Diária | `IInserirInformacoesListagemListaoEol` | Insere informações de listagem/listão do EOL. |

## Métricas

| Horário (Local) | Horário (UTC) | Frequência | Tarefa (UseCase) | Descrição |
| :--- | :--- | :--- | :--- | :--- |
| 01:00 | 04:00 | Diária | `IRegistrarMetricaAcessosSGP` e mais 10 jobs | Registra um grande volume de métricas gerais da plataforma. |
| 01:15 | 04:15 | Diária | `IRegistrarMetricaConselhoClasseAlunoDuplicado` e mais 1 job | Registra métricas de duplicidade em conselho e fechamento. |
| 01:30 | 04:30 | Diária | `IRegistrarMetricaConselhoClasseNotaDuplicado` e mais 1 job | Registra métricas de duplicidade de notas. |
| 01:45 | 04:45 | Diária | `IRegistrarMetricaFechamentoNotaDuplicado` | Registra métricas de duplicidade de notas de fechamento. |
| 02:00 | 05:00 | Diária | `IRegistrarMetricaConsolidacaoCCNotaNulo` e mais 11 jobs | Registra um grande volume de métricas de inconsistências. |
| 02:15 | 05:15 | Diária | `IRegistrarMetricaDuplicacaoConsolidacaoCCNota` e mais 3 jobs | Registra métricas de duplicidade e inconsistência em frequência. |

## SERAP

| Horário (Local) | Horário (UTC) | Frequência | Tarefa (UseCase) | Descrição |
| :--- | :--- | :--- | :--- | :--- |
| 20:00 | 23:00 | Diária | `IIniciarImportacoesSerapItens` | Inicia importações de itens do SERAP. |
| 22:00 | 01:00 | Diária | `ISyncSerapEstudantesProvas` | Sincroniza provas de estudantes do SERAP. |
| 22:00 | 01:00 | Diária | `IIniciarProcessoFinalizarProvasAutomaticamente` | Inicia o processo de finalização automática de provas. |
| 23:00 | 02:00 | Diária | `ISyncSerapEstudantesProvasTai` e mais 2 jobs | Sincroniza provas TAI, questões e proficiência do SERAP. |
| 02:00 | 05:00 | Diária | `IExecutarConsolidacaoBoletimProvaAluno` | Consolida boletins de provas de alunos. |
| 04:00 | 07:00 | Diária | `IPropagarCache` | Propaga o cache do SERAP. |
| 05:00 | 08:00 | Diária | `ISyncSerapEstudantesSincronizacaoInst` | Sincroniza dados institucionais de estudantes do SERAP. |
| 05:00 | 08:00 | Diária | `ISincronizacaoUsuarioCoreSsoEAbrangencia` | Sincroniza usuários e abrangências do CoreSSO. |
| 06:00 | 09:00 | Diária | `ISyncSerapEstudantesProvasBib` | Sincroniza provas do tipo BIB de estudantes do SERAP. |
| 06:00 | 09:00 | Diária | `IIniciarSyncAcompanhamento` | Inicia a sincronização de acompanhamento do SERAP. |
| A cada 6h| - | Contínua | `IWebPushTestSync` | Sincroniza testes de Web Push. |

## Conecta Formação

| Horário (Local) | Horário (UTC) | Frequência | Tarefa (UseCase) | Descrição |
| :--- | :--- | :--- | :--- | :--- |
| 05:00 | 08:00 | Diária | `ISincronizacaoInstitucionalDreConectaFormacao` | Sincroniza DREs institucionais do Conecta Formação. |
| 05:00 | 08:00 | Diária | `IEncerrarInscricoesAutomaticamente` | Encerra inscrições automaticamente. |

## CDEP (Controle de Empréstimo)

| Horário (Local) | Horário (UTC) | Frequência | Tarefa (UseCase) | Descrição |
| :--- | :--- | :--- | :--- | :--- |
| 19:00 | 22:00 | Diária | `IExecutarAtualizacaoSituacaoParaEmprestimoComDevolucaoEmAtraso` e 3 jobs | Atualiza situação e envia notificações sobre empréstimos. |