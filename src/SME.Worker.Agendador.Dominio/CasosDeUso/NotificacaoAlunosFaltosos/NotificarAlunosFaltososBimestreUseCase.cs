using MediatR;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.NotificacaoAlunosFaltosos
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
