using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.NotificacaoAlunosFaltosos
{
    public class NotificarAlunosFaltososBimestreUseCase : AbstractUseCase, INotificarAlunosFaltososBimestreUseCase
    {
        public NotificarAlunosFaltososBimestreUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.NotificarAlunosFaltososBimestre, Guid.NewGuid()));
        }
    }
}
