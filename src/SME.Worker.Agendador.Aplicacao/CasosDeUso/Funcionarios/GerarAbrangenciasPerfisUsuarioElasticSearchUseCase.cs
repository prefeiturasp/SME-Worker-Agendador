using System;
using System.Threading.Tasks;
using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;

namespace SME.Worker.Agendador.Aplicacao
{
    public class GerarAbrangenciasPerfisUsuarioElasticSearchUseCase : AbstractUseCase,
        IGerarAbrangenciasPerfisUsuarioElasticSearchUseCase
    {
        public GerarAbrangenciasPerfisUsuarioElasticSearchUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitEol.GerarAbrangenciasPerfisUsuarioEolSync,
                Guid.NewGuid(), "ExchangeApiEol"));
        }
    }
}