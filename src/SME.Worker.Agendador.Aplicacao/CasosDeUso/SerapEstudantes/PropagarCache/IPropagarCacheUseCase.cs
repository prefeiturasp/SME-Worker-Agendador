using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public interface IPropagarCacheUseCase
    {
        Task Executar();
    }
}
