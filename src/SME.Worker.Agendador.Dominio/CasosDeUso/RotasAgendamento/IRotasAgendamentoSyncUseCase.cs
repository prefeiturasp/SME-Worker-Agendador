using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.RotasAgendamento
{
    public interface IRotasAgendamentoSyncUseCase
    {
        Task<bool> Executar();
    }
}
