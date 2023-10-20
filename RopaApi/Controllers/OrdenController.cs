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
    public class OrdenController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrdenDto>>> Get()
        {
            var ordenes = await _unitOfWork.Ordenes.GetAllAsync();
            return _mapper.Map<List<OrdenDto>>(ordenes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrdenDto>> Get(int id)
        {
            var orden = await _unitOfWork.Ordenes.GetByIdAsync(id);

            if (orden == null)
            {
                return NotFound();
            }

            return _mapper.Map<OrdenDto>(orden);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Orden>> Post(OrdenDto OrdenDto)
        {
            var orden = _mapper.Map<Orden>(OrdenDto);
            this._unitOfWork.Ordenes.Add(orden);
            await _unitOfWork.SaveAsync();

            if (orden == null)
            {
                return BadRequest();
            }
            OrdenDto.Id = orden.Id;
            return CreatedAtAction(nameof(Post), new { id = OrdenDto.Id }, OrdenDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrdenDto>> Put(int id, [FromBody] OrdenDto OrdenDto)
        {
            if (OrdenDto.Id == 0)
            {
                OrdenDto.Id = id;
            }

            if(OrdenDto.Id != id)
            {
                return BadRequest();
            }

            if(OrdenDto == null)
            {
                return NotFound();
            }
            var orden = _mapper.Map<Orden>(OrdenDto);
            _unitOfWork.Ordenes.Update(orden);
            await _unitOfWork.SaveAsync();
            return OrdenDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var orden = await _unitOfWork.Ordenes.GetByIdAsync(id);

            if (orden == null)
            {
                return NotFound();
            }

            _unitOfWork.Ordenes.Remove(orden);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}