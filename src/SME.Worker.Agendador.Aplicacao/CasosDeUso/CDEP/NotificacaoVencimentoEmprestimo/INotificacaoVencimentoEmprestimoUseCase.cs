using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Cdep
{
    public interface INotificacaoVencimentoEmprestimoUseCase
    {
        Task<bool> Executar();
    }
}
