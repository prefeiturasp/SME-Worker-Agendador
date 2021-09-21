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
            SentrySdk.AddBreadcrumb($"Mensagem ExecutaSincronismoComponentesCurricularesEolUseCase", "Rabbit - ExecutaSincronismoComponentesCurricularesEolUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.SincronizarComponentesCurricularesEol, Guid.NewGuid()));
        }
    }
}
