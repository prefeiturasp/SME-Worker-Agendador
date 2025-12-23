using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Abrangencia
{
    public class SincronizarAbrangenciaUseCase : AbstractUseCase, ISincronizarAbrangenciaUseCase
    {
        public SincronizarAbrangenciaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.SincronizarAbrangencia, Guid.NewGuid()));
        }
    }
}
