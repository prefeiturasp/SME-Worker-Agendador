using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.RabbitDeadletter
{
    public interface IRabbitDeadletterSgpSyncUseCase
    {
        Task<bool> Executar();
    }
}
