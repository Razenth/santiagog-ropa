
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
    public class DetalleOrdenController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleOrdenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleOrdenDto>>> Get()
        {
            var detOrdenes = await _unitOfWork.DetalleOrdenes.GetAllAsync();
            return _mapper.Map<List<DetalleOrdenDto>>(detOrdenes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleOrdenDto>> Get(int id)
        {
            var detOrden = await _unitOfWork.DetalleOrdenes.GetByIdAsync(id);

            if (detOrden == null)
            {
                return NotFound();
            }

            return _mapper.Map<DetalleOrdenDto>(detOrden);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleOrden>> Post(DetalleOrdenDto DetalleOrdenDto)
        {
            var detOrden = _mapper.Map<DetalleOrden>(DetalleOrdenDto);
            this._unitOfWork.DetalleOrdenes.Add(detOrden);
            await _unitOfWork.SaveAsync();

            if (detOrden == null)
            {
                return BadRequest();
            }
            DetalleOrdenDto.Id = detOrden.Id;
            return CreatedAtAction(nameof(Post), new { id = DetalleOrdenDto.Id }, DetalleOrdenDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleOrdenDto>> Put(int id, [FromBody] DetalleOrdenDto DetalleOrdenDto)
        {
            if (DetalleOrdenDto.Id == 0)
            {
                DetalleOrdenDto.Id = id;
            }

            if(DetalleOrdenDto.Id != id)
            {
                return BadRequest();
            }

            if(DetalleOrdenDto == null)
            {
                return NotFound();
            }

            var detOrden = _mapper.Map<DetalleOrden>(DetalleOrdenDto);
            _unitOfWork.DetalleOrdenes.Update(detOrden);
            await _unitOfWork.SaveAsync();
            return DetalleOrdenDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var detOrden = await _unitOfWork.DetalleOrdenes.GetByIdAsync(id);

            if (detOrden == null)
            {
                return NotFound();
            }

            _unitOfWork.DetalleOrdenes.Remove(detOrden);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}