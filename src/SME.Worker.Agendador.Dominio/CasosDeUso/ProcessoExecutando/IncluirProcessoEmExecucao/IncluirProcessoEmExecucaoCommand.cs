using MediatR;
using SME.Worker.Agendador.Dominio.Enumerados;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.ProcessoExecutando.IncluirProcessoEmExecucao
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
