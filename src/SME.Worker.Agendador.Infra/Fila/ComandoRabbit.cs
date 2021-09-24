﻿using System;

namespace SME.Worker.Agendador.Infra
{
    public class ComandoRabbit
    {
        public ComandoRabbit(string nomeProcesso, Type tipoCasoUso)
        {
            NomeProcesso = nomeProcesso;
            TipoCasoUso = tipoCasoUso;
        }

        public string NomeProcesso { get; private set; }
        public Type TipoCasoUso { get; private set; }
    }
}
