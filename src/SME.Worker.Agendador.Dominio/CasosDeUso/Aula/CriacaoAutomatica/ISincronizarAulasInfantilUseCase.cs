using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.Aula.CriacaoAutomatica
{
    public interface ISincronizarAulasInfantilUseCase
    {
        void Executar();

        Task<bool> Executar(long codigoTurma);
    }
}
