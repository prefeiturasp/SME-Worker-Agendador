using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.EncaminhamentoNAAPA
{
    public class AtualizarInformacoesDoEncaminhamentoNAAPA : AbstractUseCase, IAtualizarInformacoesDoEncaminhamentoNAAPA
    {
        public AtualizarInformacoesDoEncaminhamentoNAAPA(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ExecutarAtualizacaoDasInformacoesEncaminhamentoNAAPA, Guid.NewGuid()));
        }
    }
}
