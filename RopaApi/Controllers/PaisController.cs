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
    public class PaisController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
        {
            var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PaisDto>>(paises);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            return _mapper.Map<PaisDto>(pais);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pais>> Post(PaisDto PaisDto)
        {
            var pais = _mapper.Map<Pais>(PaisDto);
            this._unitOfWork.Paises.Add(pais);
            await _unitOfWork.SaveAsync();

            if (pais == null)
            {
                return BadRequest();
            }
            PaisDto.Id = pais.Id;
            return CreatedAtAction(nameof(Post), new { id = PaisDto.Id }, PaisDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaisDto>> Put(int id, [FromBody] PaisDto PaisDto)
        {
            if (PaisDto.Id == 0)
            {
                PaisDto.Id = id;
            }

            if(PaisDto.Id != id)
            {
                return BadRequest();
            }

            if(PaisDto == null)
            {
                return NotFound();
            }
            var pais = _mapper.Map<Pais>(PaisDto);
            _unitOfWork.Paises.Update(pais);
            await _unitOfWork.SaveAsync();
            return PaisDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            _unitOfWork.Paises.Remove(pais);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}