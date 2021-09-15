using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.RabbitDeadletter
{
    public interface IRabbitDeadletterSgpSyncUseCase
    {
        Task<bool> Executar();
    }
}
