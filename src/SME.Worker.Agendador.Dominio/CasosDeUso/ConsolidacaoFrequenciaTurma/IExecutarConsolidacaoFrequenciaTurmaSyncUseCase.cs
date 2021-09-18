using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.ConsolidacaoFrequenciaTurma
{
    public interface IExecutarConsolidacaoFrequenciaTurmaSyncUseCase
    {
        Task Executar();
    }
}
