using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.EncaminhamentoAEE
{
    public class AtualizarEncaminhamentoAEETurmaAlunoUseCase : AbstractUseCase, IAtualizarEncaminhamentoAEETurmaAlunoUseCase
    {
        public AtualizarEncaminhamentoAEETurmaAlunoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ExecutarAtualizacaoTabelaEncaminhamentoAEETurmaAluno, Guid.NewGuid()));
        }
    }
}
