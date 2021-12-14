using MediatR;
using SME.Worker.Agendador.Infra.Dtos;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia.ConciliacaoFrequenciaTurmas
{
    public class ConciliacaoFrequenciaTurmasCronUseCase : AbstractUseCase, IConciliacaoFrequenciaTurmasCronUseCase
    {
        public ConciliacaoFrequenciaTurmasCronUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await ProcessarNaData(DateTime.Now, "");
        }

        public async Task ProcessarNaData(DateTime dataPeriodo, string turmaCodigo)
        {
            var mensagem = new ConciliacaoFrequenciaTurmasSyncDto(dataPeriodo, turmaCodigo);
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaConciliacaoFrequenciaTurmasSync, mensagem, Guid.NewGuid()));
        }
    }
}
