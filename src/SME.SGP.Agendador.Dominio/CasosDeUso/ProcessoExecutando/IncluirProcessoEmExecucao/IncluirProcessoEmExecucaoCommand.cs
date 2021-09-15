using MediatR;
using SME.SGP.Agendador.Dominio.Enumerados;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.ProcessoExecutando.IncluirProcessoEmExecucao
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
