using MediatR;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class SyncSerapEstudantesAlunoProvaProficienciaUseCase : ISyncSerapEstudantesAlunoProvaProficienciaUseCase
    {
        protected readonly IMediator mediator;

        public SyncSerapEstudantesAlunoProvaProficienciaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbitSerap.AlunoProvaProficienciaAsync, Guid.NewGuid()));
        }
    }
}
