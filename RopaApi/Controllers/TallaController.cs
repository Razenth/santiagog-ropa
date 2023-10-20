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
    public class TallaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TallaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TallaDto>>> Get()
        {
            var tallas = await _unitOfWork.Tallas.GetAllAsync();
            return _mapper.Map<List<TallaDto>>(tallas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TallaDto>> Get(int id)
        {
            var talla = await _unitOfWork.Tallas.GetByIdAsync(id);

            if (talla == null)
            {
                return NotFound();
            }

            return _mapper.Map<TallaDto>(talla);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Talla>> Post(TallaDto TallaDto)
        {
            var talla = _mapper.Map<Talla>(TallaDto);
            this._unitOfWork.Tallas.Add(talla);
            await _unitOfWork.SaveAsync();

            if (talla == null)
            {
                return BadRequest();
            }
            TallaDto.Id = talla.Id;
            return CreatedAtAction(nameof(Post), new { id = TallaDto.Id }, TallaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TallaDto>> Put(int id, [FromBody] TallaDto TallaDto)
        {
            if (TallaDto.Id == 0)
            {
                TallaDto.Id = id;
            }

            if(TallaDto.Id != id)
            {
                return BadRequest();
            }

            if(TallaDto == null)
            {
                return NotFound();
            }
            var talla = _mapper.Map<Talla>(TallaDto);
            _unitOfWork.Tallas.Update(talla);
            await _unitOfWork.SaveAsync();
            return TallaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var talla = await _unitOfWork.Tallas.GetByIdAsync(id);

            if (talla == null)
            {
                return NotFound();
            }

            _unitOfWork.Tallas.Remove(talla);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}