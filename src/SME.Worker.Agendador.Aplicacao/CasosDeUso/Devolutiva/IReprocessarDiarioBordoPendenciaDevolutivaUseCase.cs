using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Devolutiva
{
    public interface IReprocessarDiarioBordoPendenciaDevolutivaUseCase
    {
        Task Executar();
    }
}
