using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public interface IUseCase<in TParameter, TResponse>
    {
        Task<TResponse> Executar(TParameter param);
    }
}
