using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PlanoAEE
{
    public class AtualizarPlanoAEETurmaAlunoUseCase : AbstractUseCase, IAtualizarPlanoAEETurmaAlunoUseCase
    {
        public AtualizarPlanoAEETurmaAlunoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ExecutarAtualizacaoTabelaPlanoAEETurmaAluno, Guid.NewGuid()));
        }
    }
}
