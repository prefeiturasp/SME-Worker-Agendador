using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.FilaTesteRabbitMQ
{
    public interface IFilaTesteRabbitMQ
    {
        Task Executar();
    }
}
