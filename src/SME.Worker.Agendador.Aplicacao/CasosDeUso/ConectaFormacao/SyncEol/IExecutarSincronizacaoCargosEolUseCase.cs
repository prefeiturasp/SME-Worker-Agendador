using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConectaFormacao.SyncEol
{
    public interface IExecutarSincronizacaoCargosEolUseCase
    {
        Task<bool> Executar();
    }
}