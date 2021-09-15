using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoMediaRegistrosIndividuais
{
    public interface IExecutarSincronizacaoMediaRegistrosIndividuaisSyncUseCase
    {
        Task Executar();
    }
}
