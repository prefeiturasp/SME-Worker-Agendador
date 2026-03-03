using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarTaxaAlfabetizacaoPainelEducacional : AbstractUseCase, IConsolidarTaxaAlfabetizacaoPainelEducacional
    {
        public ConsolidarTaxaAlfabetizacaoPainelEducacional(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarTaxaAlfabetizacaoPainelEducacional", "Rabbit - ConsolidarTaxaAlfabetizacaoPainelEducacional");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarTaxaAlfabetizacaoPainelEducacional, Guid.NewGuid()));
        }
    }
}

