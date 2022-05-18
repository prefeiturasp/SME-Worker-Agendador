using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Infra;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Aula.CriacaoAutomatica
{
    public class SincronizarAulasInfantilUseCase : AbstractUseCase, ISincronizarAulasInfantilUseCase
    {
        public SincronizarAulasInfantilUseCase(IMediator mediator)
            : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaSincronizarAulasInfatil, Guid.NewGuid()));
        }        
    }
}
