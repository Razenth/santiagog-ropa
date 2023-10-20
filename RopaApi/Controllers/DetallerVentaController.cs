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
    public class DetalleVentaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleVentaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleVentaDto>>> Get()
        {
            var detVentas = await _unitOfWork.DetalleVentas.GetAllAsync();
            return _mapper.Map<List<DetalleVentaDto>>(detVentas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleVentaDto>> Get(int id)
        {
            var detVenta = await _unitOfWork.DetalleVentas.GetByIdAsync(id);

            if (detVenta == null)
            {
                return NotFound();
            }

            return _mapper.Map<DetalleVentaDto>(detVenta);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleVenta>> Post(DetalleVentaDto DetalleVentaDto)
        {
            var detVenta = _mapper.Map<DetalleVenta>(DetalleVentaDto);
            this._unitOfWork.DetalleVentas.Add(detVenta);
            await _unitOfWork.SaveAsync();

            if (detVenta == null)
            {
                return BadRequest();
            }
            DetalleVentaDto.Id = detVenta.Id;
            return CreatedAtAction(nameof(Post), new { id = DetalleVentaDto.Id }, DetalleVentaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleVentaDto>> Put(int id, [FromBody] DetalleVentaDto DetalleVentaDto)
        {
            if (DetalleVentaDto.Id == 0)
            {
                DetalleVentaDto.Id = id;
            }

            if(DetalleVentaDto.Id != id)
            {
                return BadRequest();
            }

            if(DetalleVentaDto == null)
            {
                return NotFound();
            }

            var detVenta = _mapper.Map<DetalleVenta>(DetalleVentaDto);
            _unitOfWork.DetalleVentas.Update(detVenta);
            await _unitOfWork.SaveAsync();
            return DetalleVentaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var detVenta = await _unitOfWork.DetalleVentas.GetByIdAsync(id);

            if (detVenta == null)
            {
                return NotFound();
            }

            _unitOfWork.DetalleVentas.Remove(detVenta);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}