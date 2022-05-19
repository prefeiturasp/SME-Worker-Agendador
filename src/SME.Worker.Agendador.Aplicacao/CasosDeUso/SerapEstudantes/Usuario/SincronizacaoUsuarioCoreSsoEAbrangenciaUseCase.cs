using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Infra;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class SincronizacaoUsuarioCoreSsoEAbrangenciaUseCase : ISincronizacaoUsuarioCoreSsoEAbrangenciaUseCase
    {
        protected readonly IMediator mediator;

        public SincronizacaoUsuarioCoreSsoEAbrangenciaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSerap.UsuarioCoreSsoSync, Guid.NewGuid(), ExchangeRabbit.SerapEstudantes));
        }
    }
}
