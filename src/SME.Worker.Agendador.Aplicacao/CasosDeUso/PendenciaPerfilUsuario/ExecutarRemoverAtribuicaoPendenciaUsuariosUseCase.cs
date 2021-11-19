using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaPerfilUsuario
{
    public class ExecutarRemoverAtribuicaoPendenciaUsuariosUseCase : AbstractUseCase, IExecutarRemoverAtribuicaoPendenciaUsuariosUseCase
    {
        public ExecutarRemoverAtribuicaoPendenciaUsuariosUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutarRemoverAtribuicaoPendenciaUsuariosUseCase", "Rabbit - ExecutarRemoverAtribuicaoPendenciaUsuariosUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RemoverAtribuicaoPendenciaUsuariosUseCase, string.Empty, Guid.NewGuid()));
        }
    }
}
