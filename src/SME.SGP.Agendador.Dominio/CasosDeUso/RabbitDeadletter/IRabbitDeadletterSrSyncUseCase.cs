using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.RabbitDeadletter
{
    public interface IRabbitDeadletterSrSyncUseCase
    {
        //Task<bool> Executar();
        Task Executar();
    }
}
