namespace SME.Worker.Agendador.Aplicacao.Fila
{
    public static class RotasConectaFormacao
    {
        public const string Exchange = "sme.conecta.workers";

        public const string SincronizaEstruturaInstitucionalDre = "conecta.sincronizacao.institucional.dre";
        public const string SincronizaEstruturaInstitucionalDreTratar = "conecta.sincronizacao.institucional.dre.tratar";
        public const string EncerrarInscricaoAutomaticamente = "conecta.inscricao.encerrar.cursista.inativo";
        public const string SincronizaCargosEol = "conecta.sincronizacao.cargos.eol";
        public const string SincronizaAtribuicoesServidoresEol = "conecta.sincronizacao.atribuicoes.servidores.eol";
        public const string SincronizaFuncaoAtividade = "conecta.sincronizacao.funcao.atividade.eol";
    }
}
