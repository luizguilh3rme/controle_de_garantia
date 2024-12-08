﻿using ControleEstoque.Models;

namespace ControleEstoque.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> Buscartodos();
        UsuarioModel Adicionar(UsuarioModel ont);
        UsuarioModel Atualizar(UsuarioModel ont);
        bool Apagar(int id);
    }
}
