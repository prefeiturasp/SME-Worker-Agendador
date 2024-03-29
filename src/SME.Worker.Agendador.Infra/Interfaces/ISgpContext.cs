﻿using System.Data;

namespace SME.Worker.Agendador.Infra
{
    public interface ISgpContext : IDbConnection
    {
        IDbConnection Conexao { get; }
        string UsuarioLogado { get; }
        string PerfilUsuario { get; }
        string UsuarioLogadoNomeCompleto { get; }
        string UsuarioLogadoRF { get; }

        void AbrirConexao();
        void FecharConexao();
    }
}