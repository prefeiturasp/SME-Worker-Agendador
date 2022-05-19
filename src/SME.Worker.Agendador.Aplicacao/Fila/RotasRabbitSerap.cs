namespace SME.Worker.Agendador.Aplicacao
{
    public static class RotasRabbitSerap
    {
        public const string RotaSincronizacaoInstitucional = "serap.sincronizacao.institucional.dre.sync";
        public const string ProvaSync = "serap.estudante.prova.legado.sync";
        public const string IniciarProcessoFinalizarProvasAutomaticamente = "serap.estudante.prova.finalizar.automaticamente.iniciar";
        public const string UsuarioCoreSsoSync = "serap.estudante.usuario.coresso.sync";
    }
}
