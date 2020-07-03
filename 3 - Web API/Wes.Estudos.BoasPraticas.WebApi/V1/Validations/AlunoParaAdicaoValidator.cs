using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wes.Estudos.BoasPraticas.WebApi.V1.Models;
using Wes.Estudos.BoasPraticas.WebApi.V1.Repositories.Interfaces;

namespace Wes.Estudos.BoasPraticas.WebApi.V1.Validations
{
    public class AlunoParaAdicaoValidator : AbstractValidator<Aluno>
    {
        private readonly IRepository<Aluno> _repository;

        public AlunoParaAdicaoValidator(IRepository<Aluno> repository)
        {
            _repository = repository;

            RuleFor(aluno => aluno.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("É necessário informar um nome para o aluno");

            RuleFor(aluno => aluno.Nome)
                .MinimumLength(3)
                .WithMessage("O nome deve conter no minimo 3 caracteres");

            RuleFor(aluno => aluno)
                .Must(RegistroUnico)
                .WithMessage("O registro informado já existe");

            RuleFor(aluno => aluno)
                .Must(NomeUnico)
                .WithMessage("O nome informado já está cadastrado");
        }

        private bool RegistroUnico(Aluno aluno)
        {
            var alunoEncontrado = _repository.Buscar(a => a.Registro == aluno.Registro);

            if (alunoEncontrado is null)
                return true;

            return false;
        }

        private bool NomeUnico(Aluno aluno)
        {
            var alunoEncontrado = _repository.Buscar(a => a.Nome.ToUpper() == aluno.Nome.ToUpper());

            if (alunoEncontrado is null)
                return true;

            return false;
        }
    }
}
