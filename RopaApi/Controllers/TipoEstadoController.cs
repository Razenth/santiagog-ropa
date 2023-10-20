using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RopaApi.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace RopaApi.Controllers 
{
    public class TipoEstadoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoEstadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoEstadoDto>>> Get()
        {
            var tipEstados = await _unitOfWork.TipoEstados.GetAllAsync();
            return _mapper.Map<List<TipoEstadoDto>>(tipEstados);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoEstadoDto>> Get(int id)
        {
            var tipEstado = await _unitOfWork.TipoEstados.GetByIdAsync(id);

            if (tipEstado == null)
            {
                return NotFound();
            }

            return _mapper.Map<TipoEstadoDto>(tipEstado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoEstado>> Post(TipoEstadoDto TipoEstadoDto)
        {
            var tipEstado = _mapper.Map<TipoEstado>(TipoEstadoDto);
            this._unitOfWork.TipoEstados.Add(tipEstado);
            await _unitOfWork.SaveAsync();

            if (tipEstado == null)
            {
                return BadRequest();
            }
            TipoEstadoDto.Id = tipEstado.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoEstadoDto.Id }, TipoEstadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoEstadoDto>> Put(int id, [FromBody] TipoEstadoDto TipoEstadoDto)
        {
            if (TipoEstadoDto.Id == 0)
            {
                TipoEstadoDto.Id = id;
            }

            if(TipoEstadoDto.Id != id)
            {
                return BadRequest();
            }

            if(TipoEstadoDto == null)
            {
                return NotFound();
            }
            var tipEstado = _mapper.Map<TipoEstado>(TipoEstadoDto);
            _unitOfWork.TipoEstados.Update(tipEstado);
            await _unitOfWork.SaveAsync();
            return TipoEstadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipEstado = await _unitOfWork.TipoEstados.GetByIdAsync(id);

            if (tipEstado == null)
            {
                return NotFound();
            }

            _unitOfWork.TipoEstados.Remove(tipEstado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}