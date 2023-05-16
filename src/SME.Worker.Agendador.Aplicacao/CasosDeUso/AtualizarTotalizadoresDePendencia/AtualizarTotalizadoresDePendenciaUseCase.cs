using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.AtualizarTotalizadoresDePendencia
{
    public class AtualizarTotalizadoresDePendenciaUseCase : AbstractUseCase, IAtualizarTotalizadoresDePendenciaUseCase
    {
        public AtualizarTotalizadoresDePendenciaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ExecutarAtualizacaoDosTotalizadoresDasPendencias, Guid.NewGuid()));
        }
    }
}
