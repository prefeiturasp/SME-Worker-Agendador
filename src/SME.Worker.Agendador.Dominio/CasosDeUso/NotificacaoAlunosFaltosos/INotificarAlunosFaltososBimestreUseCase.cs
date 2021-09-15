using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoAlunosFaltosos
{
    public interface INotificarAlunosFaltososBimestreUseCase
    {
        Task Executar();
    }
}
