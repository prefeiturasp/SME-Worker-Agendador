using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.RabbitDeadletter
{
    public interface IRabbitDeadletterSrSyncUseCase
    {
        //Task<bool> Executar();
        Task Executar();
    }
}
