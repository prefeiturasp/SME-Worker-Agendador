using MediatR;
using SME.Worker.Agendador.Infra;
using System;
using System.Threading.Tasks;


namespace SME.Worker.Agendador.Aplicacao
{
    public class IniciarSyncAcompanhamentoUseCase : IIniciarSyncAcompanhamentoUseCase
    {

        protected readonly IMediator mediator;

        public IniciarSyncAcompanhamentoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSerapAcompanhamentoCommand(RotasRabbitSerapAcompanhamento.IniciarSync, Guid.NewGuid()));
        }
    }
}
