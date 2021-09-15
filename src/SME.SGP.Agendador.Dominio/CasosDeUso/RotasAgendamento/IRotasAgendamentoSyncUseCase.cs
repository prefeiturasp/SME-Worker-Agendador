using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.RotasAgendamento
{
    public interface IRotasAgendamentoSyncUseCase
    {
        Task<bool> Executar();
    }
}
