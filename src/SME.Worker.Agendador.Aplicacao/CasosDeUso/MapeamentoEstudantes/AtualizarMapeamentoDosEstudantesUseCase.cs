using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class AtualizarMapeamentoDosEstudantesUseCase : AbstractUseCase, IAtualizarMapeamentoDosEstudantesUseCase
    {
        public AtualizarMapeamentoDosEstudantesUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ExecutarAtualizacaoMapeamentoEstudantes, Guid.NewGuid()));
        }
    }
}
