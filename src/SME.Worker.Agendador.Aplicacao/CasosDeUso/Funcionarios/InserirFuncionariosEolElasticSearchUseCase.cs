using System;
using System.Threading.Tasks;
using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;

namespace SME.Worker.Agendador.Aplicacao
{
    public class InserirFuncionariosEolElasticSearchUseCase : AbstractUseCase,
        IInserirFuncionariosEolElasticSearchUseCase
    {
        public InserirFuncionariosEolElasticSearchUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitEol.InserirFuncionariosEolElasticSearchSync,
                Guid.NewGuid(), "ExchangeApiEol"));
        }
    }
}