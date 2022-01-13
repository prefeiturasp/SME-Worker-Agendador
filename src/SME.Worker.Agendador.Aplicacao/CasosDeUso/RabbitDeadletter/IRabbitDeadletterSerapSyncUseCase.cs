using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public interface IRabbitDeadletterSerapSyncUseCase
    {
        Task<bool> Executar();
    }
}
