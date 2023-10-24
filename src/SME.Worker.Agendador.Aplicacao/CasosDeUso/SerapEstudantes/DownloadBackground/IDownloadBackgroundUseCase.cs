using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public interface IDownloadBackgroundUseCase
    {
        Task Executar();
    }
}
