namespace SME.Worker.Agendador.Aplicacao
{
    public static class RotasRabbitMetricas
    {
        public const string AcessosSGP = "sgp.metricas.acessos";
        public const string DuplicacaoConselhoClasse = "sgp.metricas.conselho.classe.duplicado";
        public const string DuplicacaoConselhoClasseAluno = "sgp.metricas.conselho.classe.aluno.duplicado";
        public const string DuplicacaoConselhoClasseNota = "sgp.metricas.conselho.classe.nota.duplicado";
        public const string DuplicacaoFechamentoTurma = "sgp.metricas.fechamento.turma.duplicado";
        public const string DuplicacaoFechamentoTurmaDisciplina = "sgp.metricas.fechamento.disciplina.duplicado";
        public const string DuplicacaoFechamentoAluno = "sgp.metricas.fechamento.aluno.duplicado";
        public const string DuplicacaoFechamentoNota = "sgp.metricas.fechamento.nota.duplicado";
        public const string ConsolidacaoCCNotaNulo = "sgp.metricas.consolidacao.cc.nota.nulo";
        public const string DuplicacaoConsolidacaoCCAlunoTurma = "sgp.metricas.consolidacao.cc.aluno.turma.duplicado";
        public const string DuplicacaoConsolidacaoCCNota = "sgp.metricas.consolidacao.cc.nota.duplicado";
        public const string ConselhoClasseNaoConsolidado = "sgp.metricas.consolidacao.cc.faltante";
        public const string FrequenciaAlunoInconsistente = "sgp.metricas.frequencia.inconsistente";
        public const string DuplicacaoFrequenciaAluno = "sgp.metricas.frequencia.aluno.duplicado";
        public const string DuplicacaoRegistroFrequencia = "sgp.metricas.registro.frequencia.duplicado";
        public const string DuplicacaoRegistroFrequenciaAluno = "sgp.metricas.registro.frequencia.aluno.duplicado";
        public const string ConsolidacaoFrequenciaAlunoMensalInconsistente = "sgp.metricas.consolidacao.frequencia.aluno.mensal.inconsistente";
        public const string DuplicacaoDiarioBordo = "sgp.metricas.diario.bordo.duplicado";
        public const string RegistrosFrequenciaDiarios = "sgp.metricas.registro.frequencia.dia";
        public const string DiariosBordoDiarios = "sgp.metricas.diario.bordo.dia";
        public const string DevolutivasDiarioBordoMensais = "sgp.metricas.devolutiva.diario.bordo.mes";
        public const string AulasCJMensais = "sgp.metricas.aula.cj.mes";
        public const string EncaminhamentosAEEMensais = "sgp.metricas.encaminhamento.aee.mes";
        public const string PlanosAEEMensais = "sgp.metricas.plano.aee.mes";
        public const string PlanosAulaDiarios = "sgp.metricas.plano.aula.dia";
        public const string FechamentosNotaDiarios = "sgp.metricas.fechamento.nota.dia";
        public const string ConselhosClasseAlunoDiarios = "sgp.metricas.conselho.classe.aluno.dia";
        public const string FechamentosTurmaDisciplinaDiarios = "sgp.metricas.fechamento.turma.disciplina.dia";
    }
}
