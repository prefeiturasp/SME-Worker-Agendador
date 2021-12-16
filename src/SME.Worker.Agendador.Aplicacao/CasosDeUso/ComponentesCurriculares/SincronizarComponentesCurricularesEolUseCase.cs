using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ComponentesCurriculares
{
    public class SincronizarComponentesCurricularesEolUseCase : AbstractUseCase, ISincronizarComponentesCurricularesEolUseCase
    {
        public SincronizarComponentesCurricularesEolUseCase(IMediator mediator) : base(mediator)
        {

        }
        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.SincronizarComponentesCurricularesEol, Guid.NewGuid()));
        }
    }
}
