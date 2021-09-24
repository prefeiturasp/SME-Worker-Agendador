using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Aula.CriacaoAutomatica
{
    public interface ISincronizarAulasInfantilUseCase
    {
        void Executar();

        Task<bool> Executar(long codigoTurma);
    }
}
