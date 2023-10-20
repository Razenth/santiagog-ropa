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
    public class GeneroController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GeneroController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GeneroDto>>> Get()
        {
            var generos = await _unitOfWork.Generos.GetAllAsync();
            return _mapper.Map<List<GeneroDto>>(generos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GeneroDto>> Get(int id)
        {
            var genero = await _unitOfWork.Generos.GetByIdAsync(id);

            if (genero == null)
            {
                return NotFound();
            }

            return _mapper.Map<GeneroDto>(genero);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Genero>> Post(GeneroDto GeneroDto)
        {
            var genero = _mapper.Map<Genero>(GeneroDto);
            this._unitOfWork.Generos.Add(genero);
            await _unitOfWork.SaveAsync();

            if (genero == null)
            {
                return BadRequest();
            }
            GeneroDto.Id = genero.Id;
            return CreatedAtAction(nameof(Post), new { id = GeneroDto.Id }, GeneroDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GeneroDto>> Put(int id, [FromBody] GeneroDto GeneroDto)
        {
            if (GeneroDto.Id == 0)
            {
                GeneroDto.Id = id;
            }

            if(GeneroDto.Id != id)
            {
                return BadRequest();
            }

            if(GeneroDto == null)
            {
                return NotFound();
            }
            var genero = _mapper.Map<Genero>(GeneroDto);
            _unitOfWork.Generos.Update(genero);
            await _unitOfWork.SaveAsync();
            return GeneroDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var genero = await _unitOfWork.Generos.GetByIdAsync(id);

            if (genero == null)
            {
                return NotFound();
            }

            _unitOfWork.Generos.Remove(genero);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}