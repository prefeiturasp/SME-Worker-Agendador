using MediatR;
using SME.Worker.Agendador.Aplicacao.Enumerados;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ProcessoExecutando.IncluirProcessoEmExecucao
{
    public class IncluirProcessoEmExecucaoCommand : IRequest<long>
    {
        public IncluirProcessoEmExecucaoCommand(TipoProcesso tipoProcesso)
        {
            TipoProcesso = tipoProcesso;
        }

        public TipoProcesso TipoProcesso { get; set; }
    }
}
