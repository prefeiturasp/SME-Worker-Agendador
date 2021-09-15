using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoDevolutivas
{
    public interface IExecutarSincronizacaoDevolutivasPorTurmaInfantilSyncUseCase
    {
        Task Executar();
    }
}
