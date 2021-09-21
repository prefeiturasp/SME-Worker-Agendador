using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.RotasAgendamento
{
    public interface IRotasAgendamentoSyncUseCase
    {
        Task<bool> Executar();
    }
}
