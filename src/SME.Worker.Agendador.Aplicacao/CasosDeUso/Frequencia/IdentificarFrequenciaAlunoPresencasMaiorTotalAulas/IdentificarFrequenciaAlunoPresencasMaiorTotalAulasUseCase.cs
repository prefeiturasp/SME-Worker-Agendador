using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Frequencia.IdentificarFrequenciaAlunoPresencasMaiorTotalAulas
{
    public class IdentificarFrequenciaAlunoPresencasMaiorTotalAulasUseCase : IIdentificarFrequenciaAlunoPresencasMaiorTotalAulasUseCase
    {
        private readonly IMediator mediator;

        public IdentificarFrequenciaAlunoPresencasMaiorTotalAulasUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator
                .Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.IdentificarFrequenciaAlunoPresencasMaiorTotalAulas, Guid.NewGuid()));
        }
    }
}
