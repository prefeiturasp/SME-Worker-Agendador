using System;
using System.Threading.Tasks;
using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;

namespace SME.Worker.Agendador.Aplicacao
{
    public class InserirComponentesTurmasProfessoresEolElasticSearchUseCase: AbstractUseCase,
        IInserirComponentesTurmasProfessoresEolElasticSearchUseCase
    {
        public InserirComponentesTurmasProfessoresEolElasticSearchUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitEol.InserirComponentesTurmasProfessoresEolElasticSearchSync,DateTime.Now.Year,
                Guid.NewGuid(), "ExchangeApiEol"));
        }
    }
}