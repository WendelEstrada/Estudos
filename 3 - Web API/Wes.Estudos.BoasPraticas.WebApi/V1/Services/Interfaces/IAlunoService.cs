using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wes.Estudos.BoasPraticas.WebApi.V1.Models;

namespace Wes.Estudos.BoasPraticas.WebApi.V1.Services.Interfaces
{
    public interface IAlunoService
    {
        IEnumerable<Aluno> ObterTodos();
        Aluno ObterPorRegistro(int registro);
        ValidationResult Adicionar(Aluno aluno);
        ValidationResult Atualizar(Aluno aluno);
        bool Remover(Aluno aluno);
    }
}
