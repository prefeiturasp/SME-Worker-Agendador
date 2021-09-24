using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.RabbitDeadletter
{
    public interface IRabbitDeadletterSgpSyncUseCase
    {
        Task<bool> Executar();
    }
}
