﻿using AnotaAi.Dominio.Entidades.Funcionarios;
using AnotaAi.Dominio.Interface.Respositorios.Funcionarios;
using AnotaAi.Repositorio.Contexto;

namespace AnotaAi.Repositorio.Repositorios.Funcionarios
{
    public class CargoRepositorio : BaseRepositorio<Cargo>, ICargoRepositorio
    {
        public CargoRepositorio(AppDbContext context)
            : base(context)
        {
        }
    }
}