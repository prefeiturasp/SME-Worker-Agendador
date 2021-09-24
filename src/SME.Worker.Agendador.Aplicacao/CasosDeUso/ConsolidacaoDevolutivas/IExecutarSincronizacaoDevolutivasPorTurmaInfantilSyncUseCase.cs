using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoDevolutivas
{
    public interface IExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase
    {
        Task Executar();
    }
}
