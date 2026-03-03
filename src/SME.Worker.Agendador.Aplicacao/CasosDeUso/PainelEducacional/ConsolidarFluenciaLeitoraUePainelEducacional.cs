using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarFluenciaLeitoraUePainelEducacional : AbstractUseCase, IConsolidarFluenciaLeitoraUePainelEducacional
    {
        public ConsolidarFluenciaLeitoraUePainelEducacional(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarFluenciaLeitoraUePainelEducacional", "Rabbit - ConsolidarFluenciaLeitoraUePainelEducacional");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarFluenciaLeitoraUePainelEducacional, Guid.NewGuid()));
        }
    }
}

