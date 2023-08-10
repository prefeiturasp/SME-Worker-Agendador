namespace SME.Worker.Agendador.Aplicacao
{
    public static class RotasRabbitSerap
    {
        public const string RotaSincronizacaoInstitucional = "serap.sincronizacao.institucional.dre.sync";
        public const string ProvaSync = "serap.estudante.prova.legado.sync";
        public const string IniciarProcessoFinalizarProvasAutomaticamente = "serap.estudante.prova.finalizar.automaticamente.iniciar";
        public const string UsuarioCoreSsoSync = "serap.estudante.usuario.coresso.sync";
        public const string QuestaoCompletaSync = "serap.estudante.questao.completa.legado.sync";
        public const string ProvaBIBSync = "serap.estudante.provabib.sync";
        public const string ProvaTAISync = "serap.estudante.provatai.sync";
        public const string AlunoProvaProficienciaAsync = "serap.estudante.aluno.prova.proficiencia.sync";
    }
}
