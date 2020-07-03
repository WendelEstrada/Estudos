using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wes.Estudos.BoasPraticas.WebApi.Configuration.AuthorizationConfig;
using Wes.Estudos.BoasPraticas.WebApi.V1.Models;
using Wes.Estudos.BoasPraticas.WebApi.V1.Services.Interfaces;

namespace Wes.Estudos.BoasPraticas.WebApi.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        /// <summary>
        /// Obtém a lista de todos os alunos cadastrados
        /// </summary>
        /// <returns>Lista de alunos</returns>
        /// <response code="200">Retorna o aluno encontrado</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="403">Acesso negado</response>
        [HttpGet]
        [Authorize(Policy = Policies.User)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_alunoService.ObterTodos());
        }

        /// <summary>
        /// Obtém somente um aluno através do registro
        /// </summary>
        /// <param name="id">Registro do aluno</param>
        /// <returns>Aluno</returns>
        /// <response code="200">Retorna o aluno encontrado</response>
        /// <response code="204">Não retorna nenhum aluno</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="403">Acesso negado</response>
        [HttpGet("{id:int}")]
        [Authorize(Policy = Policies.User)]
        [ProducesResponseType(typeof(Aluno), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetById(int id)
        {
            var alunoEncontrado = _alunoService.ObterPorRegistro(id);

            if (alunoEncontrado is null)
                return NoContent();

            return Ok(alunoEncontrado);
        }

        /// <summary>
        /// Insere um novo aluno
        /// </summary>
        /// <param name="aluno">Aluno</param>
        /// <returns>Aluno inserido</returns>
        /// <response code="422">Houve um erro de validação nos dados do aluno informado</response>
        /// <response code="400">Houve um erro na validação do aluno, verifique os campos informados</response>
        /// <response code="201">Aluno cadastrado com sucesso</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="403">Acesso negado</response>
        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(typeof(Aluno), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status422UnprocessableEntity)]
        public IActionResult Post([FromBody]Aluno aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest("Houve um erro na validação do aluno, verifique os campos informados");

            var resultadoDaAdicao = _alunoService.Adicionar(aluno);

            if (!resultadoDaAdicao.IsValid)
            {
                var erros = resultadoDaAdicao.Errors.Select(e => e.ErrorMessage);
                return UnprocessableEntity(erros);
            }

            return CreatedAtAction(nameof(GetById), new { id = aluno.Registro }, aluno);
        }

        /// <summary>
        /// Atualiza um aluno através do registro informado
        /// </summary>
        /// <param name="id">Registro do aluno</param>
        /// <param name="aluno">Aluno a ser atualizado</param>
        /// <returns>Sem conteúdo</returns>
        /// <response code="204">Não retorna nenhum aluno, mas confirma que a operação foi realizada com sucesso</response>
        /// <response code="422">Houve um erro de validação nos dados do aluno informado</response>
        /// <response code="400">Houve um erro na validação do aluno, verifique os campos informados</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="403">Acesso negado</response>
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, [FromBody]Aluno aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest("Houve um erro na validação do aluno, verifique os campos informados");

            if (id != aluno.Registro)
                return UnprocessableEntity(new string[] { "O registro informado não pertence ao aluno informado" });

            var alunoEncontrado = _alunoService.ObterPorRegistro(id);

            if (alunoEncontrado is null)
                return UnprocessableEntity(new string[] { "O aluno informado não foi encontrado" });

            var resultadoDaAtualizacao =_alunoService.Atualizar(aluno);

            if (!resultadoDaAtualizacao.IsValid)
            {
                var erros = resultadoDaAtualizacao.Errors.Select(e => e.ErrorMessage).ToArray();
                return UnprocessableEntity(erros);
            }

            return NoContent();
        }

        /// <summary>
        /// Remove somente um aluno através do registro informado
        /// </summary>
        /// <param name="id">Registro do aluno</param>
        /// <returns>OK caso a operação tenha sido realizada com sucesso</returns>
        /// <response code="401">Não autorizado</response>
        /// <response code="403">Acesso negado</response>
        /// <response code="422">Houve um erro de validação nos dados do aluno informado</response>
        /// <response code="200">Removação realizada com sucesso</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public IActionResult Delete(int id)
        {
            var alunoEncontrado = _alunoService.ObterPorRegistro(id);

            if (alunoEncontrado is null)
                return UnprocessableEntity("O aluno informado não foi encontrado" );

            if (_alunoService.Remover(alunoEncontrado))
                return Ok();

            return UnprocessableEntity("Não foi possível deletar o aluno");
        }
    }
}
