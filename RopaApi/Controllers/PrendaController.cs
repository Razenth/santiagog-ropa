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
    public class PrendaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrendaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PrendaDto>>> Get()
        {
            var prendas = await _unitOfWork.Prendas.GetAllAsync();
            return _mapper.Map<List<PrendaDto>>(prendas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PrendaDto>> Get(int id)
        {
            var prenda = await _unitOfWork.Prendas.GetByIdAsync(id);

            if (prenda == null)
            {
                return NotFound();
            }

            return _mapper.Map<PrendaDto>(prenda);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Prenda>> Post(PrendaDto PrendaDto)
        {
            var prenda = _mapper.Map<Prenda>(PrendaDto);
            this._unitOfWork.Prendas.Add(prenda);
            await _unitOfWork.SaveAsync();

            if (prenda == null)
            {
                return BadRequest();
            }
            PrendaDto.Id = prenda.Id;
            return CreatedAtAction(nameof(Post), new { id = PrendaDto.Id }, PrendaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PrendaDto>> Put(int id, [FromBody] PrendaDto PrendaDto)
        {
            if (PrendaDto.Id == 0)
            {
                PrendaDto.Id = id;
            }

            if(PrendaDto.Id != id)
            {
                return BadRequest();
            }

            if(PrendaDto == null)
            {
                return NotFound();
            }
            var prenda = _mapper.Map<Prenda>(PrendaDto);
            _unitOfWork.Prendas.Update(prenda);
            await _unitOfWork.SaveAsync();
            return PrendaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var prenda = await _unitOfWork.Prendas.GetByIdAsync(id);

            if (prenda == null)
            {
                return NotFound();
            }

            _unitOfWork.Prendas.Remove(prenda);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}