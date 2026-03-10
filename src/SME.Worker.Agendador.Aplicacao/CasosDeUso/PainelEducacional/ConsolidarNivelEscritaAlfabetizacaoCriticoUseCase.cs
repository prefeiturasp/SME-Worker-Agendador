using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarNivelEscritaAlfabetizacaoCriticoUseCase : AbstractUseCase, IConsolidarNivelEscritaAlfabetizacaoCriticoUseCase
    {
        public ConsolidarNivelEscritaAlfabetizacaoCriticoUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarNivelEscritaAlfabetizacaoCriticoUseCase", "Rabbit - ConsolidarNivelEscritaAlfabetizacaoCriticoUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarNivelEscritaAlfabetizacaoCritico, Guid.NewGuid()));
        }
    }
}
