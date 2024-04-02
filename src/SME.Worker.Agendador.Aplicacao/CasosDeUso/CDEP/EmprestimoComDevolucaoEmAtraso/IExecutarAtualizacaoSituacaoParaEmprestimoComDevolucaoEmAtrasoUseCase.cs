using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Cdep
{
    public interface IExecutarAtualizacaoSituacaoParaEmprestimoComDevolucaoEmAtrasoUseCase
    {
        Task<bool> Executar();
    }
}
