using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.PlanoAEE.EncerramentoPlanoAEEEstudantesInativos
{
    public interface IExecutaEncerramentoPlanoAEEEstudantesInativosUseCase
    {
        Task Executar();
    }
}
