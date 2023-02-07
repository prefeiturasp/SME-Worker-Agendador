namespace SME.Worker.Agendador.Aplicacao
{
    public static class RotasRabbitSerapItens
    {        
        public static string ExchangeSerapItens => "serap.estudante.item.workers";

        public const string IniciarImportacoes = "serap.estudante.item.iniciar.importacoes";
    }
}
