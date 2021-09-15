using MediatR;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.ObjetivoAprendizagem
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
