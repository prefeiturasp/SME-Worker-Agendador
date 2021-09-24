using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ObjetivoAprendizagem
{
    public class SincronizarObjetivosComJuremaUseCase : AbstractUseCase, ISincronizarObjetivosComJuremaUseCase
    {
        public SincronizarObjetivosComJuremaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.SincronizarObjetivosComJurema, Guid.NewGuid()));
        }
    }
}
