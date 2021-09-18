using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.FilaTesteRabbitMQ
{
    public interface IFilaTesteRabbitMQ
    {
        Task Executar();
    }
}
