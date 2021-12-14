using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ComponentesCurriculares
{
    public class SincronizarComponentesCurricularesUseCase : AbstractUseCase, ISincronizarComponentesCurricularesUseCase
    {
        public SincronizarComponentesCurricularesUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.SincronizarComponentesCurriculares, Guid.NewGuid()));
        }
    }
}
