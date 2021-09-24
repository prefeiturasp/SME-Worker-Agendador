using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoFrequenciaTurma
{
    public interface IExecutarConsolidacaoFrequenciaTurmaSyncUseCase
    {
        Task Executar();
    }
}
