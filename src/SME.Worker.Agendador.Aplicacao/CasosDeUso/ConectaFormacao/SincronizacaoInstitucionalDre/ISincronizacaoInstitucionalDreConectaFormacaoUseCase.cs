using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public interface ISincronizacaoInstitucionalDreConectaFormacaoUseCase
    {
        Task<bool> Executar();
    }
}
