using AnotaAi.Dominio.Entidades.Funcionarios;
using AnotaAi.Dominio.Interface.Respositorios.Funcionarios;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;

namespace AnotaAi.Web.Controllers.Funcionarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : Controller
    {
        private readonly ICargoRepositorio _cargoRepositorio;

        public CargoController(ICargoRepositorio cargoRepositorio)
        {
            _cargoRepositorio = cargoRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var cargos = _cargoRepositorio.ObterTodos();

                if (!cargos.Any())
                {
                    return NotFound("Nenhum cargo localizado.");
                }

                return Ok(cargos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var cargo = _cargoRepositorio.ObterPorId(id);

                if (cargo == null)
                {
                    return NotFound($"Nenhum cargo localizado com código: {id}.");
                }

                return Ok(cargo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, Cargo cargo)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("Código do cargo não é válido.");
                }

                var cargoExistente = _cargoRepositorio.ObterPorId(id);
                if (cargoExistente is null)
                {
                    return NotFound($"Nenhum cargo localizado com código: {id}.");
                }

                cargoExistente.Atualizar(cargo.Nome, cargo.Descricao);

                _cargoRepositorio.Atualizar(cargoExistente);

                return Ok(cargoExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Cargo cargo)
        {
            try
            {
                _cargoRepositorio.Adicionar(cargo);
                return Created("api/cargo", cargo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                var cargo = _cargoRepositorio.ObterPorId(id);
                if (cargo == null)
                {
                    return NotFound($"Nenhum cargo localizado com código: {id}.");
                }

                _cargoRepositorio.Excluir(cargo);

                return Ok("Cargo deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}