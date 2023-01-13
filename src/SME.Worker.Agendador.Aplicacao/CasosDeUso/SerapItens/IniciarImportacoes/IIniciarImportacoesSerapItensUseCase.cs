using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public interface IIniciarImportacoesSerapItensUseCase
    {
        Task<bool> Executar();
    }
}
