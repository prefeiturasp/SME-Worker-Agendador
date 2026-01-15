using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.CDEP.ConsolidacaoSolicitacoesAcervos
{
    public interface IExecutarConsolidacaoDasSolicitacoesDeAcervoUseCase
    {
        Task<bool> Executar();
    }
}