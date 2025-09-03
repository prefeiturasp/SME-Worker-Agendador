using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarNivelEscritaAlfabetizacaoUseCase : AbstractUseCase, IConsolidarNivelEscritaAlfabetizacaoUseCase
    {
        public ConsolidarNivelEscritaAlfabetizacaoUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarNivelEscritaAlfabetizacaoUseCase", "Rabbit - ConsolidarNivelEscritaAlfabetizacaoUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarNivelEscritaAlfabetizacao, Guid.NewGuid()));
        }
    }
}
