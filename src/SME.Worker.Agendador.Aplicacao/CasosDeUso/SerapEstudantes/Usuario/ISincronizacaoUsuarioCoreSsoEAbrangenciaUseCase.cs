using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public interface ISincronizacaoUsuarioCoreSsoEAbrangenciaUseCase
    {
        Task<bool> Executar();
    }
}
