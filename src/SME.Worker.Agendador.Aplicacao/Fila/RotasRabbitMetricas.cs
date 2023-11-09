﻿namespace SME.Worker.Agendador.Aplicacao
{
    public static class RotasRabbitMetricas
    {
        public const string AcessosSGP = "sgp.metricas.sgp.acessos";
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
    }
}