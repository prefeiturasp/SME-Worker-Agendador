﻿using MediatR;
using SME.SGP.Infra.Dtos;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.Frequencia.ConciliacaoFrequenciaTurmas
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
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaConciliacaoFrequenciaTurmasSync, mensagem, Guid.NewGuid()));
        }
    }
}