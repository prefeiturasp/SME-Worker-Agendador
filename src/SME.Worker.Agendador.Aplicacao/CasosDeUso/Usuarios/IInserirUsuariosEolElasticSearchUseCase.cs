using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public interface IInserirUsuariosEolElasticSearch
    {
        Task Executar();
    }
}