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
    public class TipoProteccionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoProteccionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoProteccionDto>>> Get()
        {
            var tipProtecciones = await _unitOfWork.TipoProtecciones.GetAllAsync();
            return _mapper.Map<List<TipoProteccionDto>>(tipProtecciones);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoProteccionDto>> Get(int id)
        {
            var tipProteccion = await _unitOfWork.TipoProtecciones.GetByIdAsync(id);

            if (tipProteccion == null)
            {
                return NotFound();
            }

            return _mapper.Map<TipoProteccionDto>(tipProteccion);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoProteccion>> Post(TipoProteccionDto TipoProteccionDto)
        {
            var tipProteccion = _mapper.Map<TipoProteccion>(TipoProteccionDto);
            this._unitOfWork.TipoProtecciones.Add(tipProteccion);
            await _unitOfWork.SaveAsync();

            if (tipProteccion == null)
            {
                return BadRequest();
            }
            TipoProteccionDto.Id = tipProteccion.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoProteccionDto.Id }, TipoProteccionDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoProteccionDto>> Put(int id, [FromBody] TipoProteccionDto TipoProteccionDto)
        {
            if (TipoProteccionDto.Id == 0)
            {
                TipoProteccionDto.Id = id;
            }

            if(TipoProteccionDto.Id != id)
            {
                return BadRequest();
            }

            if(TipoProteccionDto == null)
            {
                return NotFound();
            }

            var tipProteccion = _mapper.Map<TipoProteccion>(TipoProteccionDto);
            _unitOfWork.TipoProtecciones.Update(tipProteccion);
            await _unitOfWork.SaveAsync();
            return TipoProteccionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipProteccion = await _unitOfWork.TipoProtecciones.GetByIdAsync(id);

            if (tipProteccion == null)
            {
                return NotFound();
            }

            _unitOfWork.TipoProtecciones.Remove(tipProteccion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}