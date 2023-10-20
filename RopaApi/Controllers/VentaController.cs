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

namespace RopaApi.Controllers;
    public class VentaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VentaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VentaDto>>> Get()
        {
            var nombreVariable = await _unitOfWork.Ventas.GetAllAsync();
            return _mapper.Map<List<VentaDto>>(nombreVariable);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VentaDto>> Get(int id)
        {
            var nombreVariable = await _unitOfWork.Ventas.GetByIdAsync(id);

            if (nombreVariable == null)
            {
                return NotFound();
            }

            return _mapper.Map<VentaDto>(nombreVariable);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Venta>> Post(VentaDto VentaDto)
        {
            var nombreVariable = _mapper.Map<Venta>(VentaDto);
            this._unitOfWork.Ventas.Add(nombreVariable);
            await _unitOfWork.SaveAsync();

            if (nombreVariable == null)
            {
                return BadRequest();
            }
            VentaDto.Id = nombreVariable.Id;
            return CreatedAtAction(nameof(Post), new { id = VentaDto.Id }, VentaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VentaDto>> Put(int id, [FromBody] VentaDto VentaDto)
        {
            if (VentaDto.Id == 0)
            {
                VentaDto.Id = id;
            }

            if(VentaDto.Id != id)
            {
                return BadRequest();
            }

            if(VentaDto == null)
            {
                return NotFound();
            }
            var nombreVariable = _mapper.Map<Venta>(VentaDto);
            _unitOfWork.Ventas.Update(nombreVariable);
            await _unitOfWork.SaveAsync();
            return VentaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var nombreVariable = await _unitOfWork.Ventas.GetByIdAsync(id);

            if (nombreVariable == null)
            {
                return NotFound();
            }

            _unitOfWork.Ventas.Remove(nombreVariable);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }