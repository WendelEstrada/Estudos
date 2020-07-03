using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wes.Estudos.BoasPraticas.WebApi.V1.Models;
using Wes.Estudos.BoasPraticas.WebApi.V1.Repositories.Interfaces;
using Wes.Estudos.BoasPraticas.WebApi.V1.Services.Interfaces;
using Wes.Estudos.BoasPraticas.WebApi.V1.Validations;

namespace Wes.Estudos.BoasPraticas.WebApi.V1.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IRepository<Aluno> _repository;

        public AlunoService(IRepository<Aluno> repository)
        {
            _repository = repository;
        }

        public ValidationResult Adicionar(Aluno aluno)
        {
            var resultadoDaValidacao = new AlunoParaAdicaoValidator(_repository).Validate(aluno);

            if (resultadoDaValidacao.IsValid)
            {
                _repository.Adicionar(aluno);
                _repository.Salvar();
            }

            return resultadoDaValidacao;
        }

        public ValidationResult Atualizar(Aluno aluno)
        {
            var resultadoDaValidacao = new AlunoParaAtualizacaoValidator(_repository).Validate(aluno);

            if (resultadoDaValidacao.IsValid)
            {
                _repository.Atualizar(aluno);
                _repository.Salvar();
            }

            return resultadoDaValidacao;
        }

        public Aluno ObterPorRegistro(int registro)
        {
            return _repository.ObterPorID(registro);
        }

        public IEnumerable<Aluno> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public bool Remover(Aluno aluno)
        {
            var alunoEncontrado = _repository.ObterPorID(aluno.Registro);

            if (alunoEncontrado != null)
            {
                _repository.Deletar(alunoEncontrado);
                _repository.Salvar();
                return true;
            }

            return false;
        }
    }
}
