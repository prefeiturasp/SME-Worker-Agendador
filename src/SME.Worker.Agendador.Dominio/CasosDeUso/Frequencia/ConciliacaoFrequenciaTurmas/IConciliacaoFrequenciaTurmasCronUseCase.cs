using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.Frequencia.ConciliacaoFrequenciaTurmas
{
    public interface IConciliacaoFrequenciaTurmasCronUseCase
    {
        Task Executar();
        Task ProcessarNaData(DateTime dataPeriodo, string turmaCodigo);
    }
}
