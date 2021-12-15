using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public interface IIniciarProcessoFinalizarProvasAutomaticamenteUseCase
    {
        Task<bool> Executar();
    }
}
