using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Aula.CriacaoAutomatica
{
    public class ExecutarSincronizacaoAulasRegenciaAutomaticasUseCase : AbstractUseCase, IExecutarSincronizacaoAulasRegenciaAutomaticasUseCase
    {
        public ExecutarSincronizacaoAulasRegenciaAutomaticasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.CarregarDadosUeTurmaRegenciaAutomaticamente, Guid.NewGuid()));
        }
    }
}
