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
    public class TipoPersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
        {
            var tipPersonas = await _unitOfWork.TipoPersonas.GetAllAsync();
            return _mapper.Map<List<TipoPersonaDto>>(tipPersonas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoPersonaDto>> Get(int id)
        {
            var tipPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);

            if (tipPersona == null)
            {
                return NotFound();
            }

            return _mapper.Map<TipoPersonaDto>(tipPersona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto TipoPersonaDto)
        {
            var tipPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
            this._unitOfWork.TipoPersonas.Add(tipPersona);
            await _unitOfWork.SaveAsync();

            if (tipPersona == null)
            {
                return BadRequest();
            }
            TipoPersonaDto.Id = tipPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoPersonaDto.Id }, TipoPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto TipoPersonaDto)
        {
            if (TipoPersonaDto.Id == 0)
            {
                TipoPersonaDto.Id = id;
            }

            if(TipoPersonaDto.Id != id)
            {
                return BadRequest();
            }

            if(TipoPersonaDto == null)
            {
                return NotFound();
            }
            var tipPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TipoPersonas.Update(tipPersona);
            await _unitOfWork.SaveAsync();
            return TipoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);

            if (tipPersona == null)
            {
                return NotFound();
            }

            _unitOfWork.TipoPersonas.Remove(tipPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}