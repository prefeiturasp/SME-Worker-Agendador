using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Aula.CriacaoAutomatica
{
    public class SincronizarAulasInfantilUseCase : ISincronizarAulasInfantilUseCase
    {
        private readonly IMediator mediator;

        public SincronizarAulasInfantilUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public void Executar()
        {
            mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaSincronizarAulasInfatil, Guid.NewGuid()));
        }

        public async Task<bool> Executar(long codigoTurma)
        {
            return await mediator
                .Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaSincronizarAulasInfatil, codigoTurma, Guid.NewGuid()));
        }
    }
}
