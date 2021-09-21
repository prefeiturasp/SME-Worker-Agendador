using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAlunosFaltosos
{
    public interface IExecutaNotificacaoAlunosFaltososUseCase
    {
        Task Executar();
    }
}
