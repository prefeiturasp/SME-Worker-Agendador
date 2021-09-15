using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.SincronizacaoInstitucional
{
    public interface IExecutarSincronizacaoInstitucionalSyncUseCase
    {
        Task Executar();
    }
}
