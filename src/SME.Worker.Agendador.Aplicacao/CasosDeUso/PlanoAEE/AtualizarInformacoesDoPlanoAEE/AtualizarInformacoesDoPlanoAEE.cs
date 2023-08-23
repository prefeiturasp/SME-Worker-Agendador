using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PlanoAEE
{
    public class AtualizarInformacoesDoPlanoAEE : AbstractUseCase, IAtualizarInformacoesDoPlanoAEE
    {
        public AtualizarInformacoesDoPlanoAEE(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ExecutarAtualizacaoDasInformacoesPlanoAEE, Guid.NewGuid()));
        }
    }
}
