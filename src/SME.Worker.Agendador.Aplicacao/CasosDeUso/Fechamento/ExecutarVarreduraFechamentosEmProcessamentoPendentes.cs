using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class ExecutarVarreduraFechamentosEmProcessamentoPendentes : AbstractUseCase, IExecutarVarreduraFechamentosEmProcessamentoPendentes
    {
        public ExecutarVarreduraFechamentosEmProcessamentoPendentes(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.VarreduraFechamentosTurmaDisciplinaEmProcessamentoPendentes, string.Empty, Guid.NewGuid(), null));
        }
    }
}
