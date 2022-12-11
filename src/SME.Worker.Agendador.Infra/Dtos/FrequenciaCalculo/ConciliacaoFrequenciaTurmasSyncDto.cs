using System;

namespace SME.Worker.Agendador.Infra.Dtos
{
    public class ConciliacaoFrequenciaTurmasSyncDto
    {
        public DateTime DataPeriodo { get; set; }

        public string TurmaCodigo { get; set; }
        public bool Bimestral { get; }
        public bool Mensal { get; }

        public ConciliacaoFrequenciaTurmasSyncDto(DateTime dataPeriodo, string turmaCodigo, bool bimestral, bool mensal)
        {
            this.DataPeriodo = dataPeriodo;
            this.TurmaCodigo = turmaCodigo;
            Bimestral = bimestral;
            Mensal = mensal;
        }
    }
}
