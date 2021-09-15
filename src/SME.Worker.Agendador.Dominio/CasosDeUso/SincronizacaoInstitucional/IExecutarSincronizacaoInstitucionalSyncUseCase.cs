using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.SincronizacaoInstitucional
{
    public interface IExecutarSincronizacaoInstitucionalSyncUseCase
    {
        Task Executar();
    }
}
