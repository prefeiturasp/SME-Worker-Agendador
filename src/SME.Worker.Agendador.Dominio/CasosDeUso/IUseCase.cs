﻿using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso
{
    public interface IUseCase<in TParameter, TResponse>
    {
        Task<TResponse> Executar(TParameter param);
    }
}