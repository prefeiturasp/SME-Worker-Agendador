namespace SME.Worker.Agendador.Aplicacao
{
    public static class RotasRabbitCdep
    {
        public const string ExecutarAtualizacaoSituacaoParaEmprestimoComDevolucaoEmAtraso = "cdep.emprestimo.situacao.devolucao.atraso";
        public const string NotificacaoVencimentoEmprestimo = "cdep.emprestimo.situacao.vencimento.aviso";
        public const string NotificacaoDevolucaoEmprestimoAtrasado = "cdep.emprestimo.situacao.atrasado.aviso";
        public const string NotificacaoDevolucaoEmprestimoAtrasoProlongado = "cdep.emprestimo.situacao.atraso.prolongado.aviso";
    }
}
