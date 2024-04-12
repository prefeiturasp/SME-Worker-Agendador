using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia
{
    public class NotificarFreqMinimaMensalInsuficienteAlunoBuscaAtivaUseCase : AbstractUseCase, INotificarFreqMinimaMensalInsuficienteAlunoBuscaAtivaUseCase
    {
        public NotificarFreqMinimaMensalInsuficienteAlunoBuscaAtivaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ExecutarNotificacaoAlunosBaixaFrequenciaBuscaAtiva, Guid.NewGuid()));
        }
    }
}
