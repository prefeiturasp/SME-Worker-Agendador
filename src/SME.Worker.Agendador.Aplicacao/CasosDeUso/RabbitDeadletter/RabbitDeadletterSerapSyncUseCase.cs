using MediatR;
using SME.Worker.Agendador.Infra;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class RabbitDeadletterSerapSyncUseCase : AbstractUseCase, IRabbitDeadletterSerapSyncUseCase
    {
        public RabbitDeadletterSerapSyncUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar()
        {
            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbitSerapEstudantes.FilaDeadletterSync, string.Empty));
        }
    }
}
