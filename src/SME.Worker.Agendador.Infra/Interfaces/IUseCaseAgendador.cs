using System.Threading.Tasks;

namespace SME.Worker.Agendador.Infra
{
    public interface IUseCaseAgendador
    {
        Task Executar();
    }
}
