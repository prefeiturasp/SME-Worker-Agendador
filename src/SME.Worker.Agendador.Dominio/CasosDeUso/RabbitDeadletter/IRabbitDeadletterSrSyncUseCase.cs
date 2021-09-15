using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.RabbitDeadletter
{
    public interface IRabbitDeadletterSrSyncUseCase
    {
        //Task<bool> Executar();
        Task Executar();
    }
}
