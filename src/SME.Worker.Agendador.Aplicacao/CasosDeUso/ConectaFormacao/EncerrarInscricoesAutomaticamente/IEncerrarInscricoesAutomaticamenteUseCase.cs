using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public interface IEncerrarInscricoesAutomaticamenteUseCase
    {
        Task<bool> Executar();
    }
}