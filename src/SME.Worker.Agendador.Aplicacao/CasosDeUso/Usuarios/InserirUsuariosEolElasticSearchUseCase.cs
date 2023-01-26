using System;
using System.Threading.Tasks;
using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;

namespace SME.Worker.Agendador.Aplicacao
{
    public class InserirUsuariosEolElasticSearch : AbstractUseCase,
        IInserirUsuariosEolElasticSearch
    {
        public InserirUsuariosEolElasticSearch(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitEol.InserirUsuariosEolElasticSearchSync,
                Guid.NewGuid(), "ExchangeApiEol"));
        }
    }
}