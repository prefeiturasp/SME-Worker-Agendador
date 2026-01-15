using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.CDEP.AtualizacaoSituacaoSolicitacao
{
    public interface IAtualizarSituacaoDasSolicitacoesDeAcervoVencidasUseCase
    {
        Task<bool> Executar();
    }
}
