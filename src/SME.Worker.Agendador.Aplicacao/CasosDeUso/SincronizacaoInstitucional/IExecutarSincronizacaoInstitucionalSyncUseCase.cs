using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.SincronizacaoInstitucional
{
    public interface IExecutarSincronizacaoInstitucionalSyncUseCase
    {
        Task Executar();
    }
}
