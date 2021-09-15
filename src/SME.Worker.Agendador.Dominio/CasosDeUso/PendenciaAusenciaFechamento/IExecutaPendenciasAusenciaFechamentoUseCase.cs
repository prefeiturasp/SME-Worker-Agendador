using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.PendenciaAusenciaFechamento
{
    public interface IExecutaPendenciasAusenciaFechamentoUseCase
    {
        Task Executar();
    }
}
