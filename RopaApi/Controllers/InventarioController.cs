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
    public class InventarioController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InventarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<InventarioDto>>> Get()
        {
            var inventarios = await _unitOfWork.Inventarios.GetAllAsync();
            return _mapper.Map<List<InventarioDto>>(inventarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventarioDto>> Get(int id)
        {
            var inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);

            if (inventario == null)
            {
                return NotFound();
            }

            return _mapper.Map<InventarioDto>(inventario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Inventario>> Post(InventarioDto InventarioDto)
        {
            var inventario = _mapper.Map<Inventario>(InventarioDto);
            this._unitOfWork.Inventarios.Add(inventario);
            await _unitOfWork.SaveAsync();

            if (inventario == null)
            {
                return BadRequest();
            }
            InventarioDto.Id = inventario.Id;
            return CreatedAtAction(nameof(Post), new { id = InventarioDto.Id }, InventarioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventarioDto>> Put(int id, [FromBody] InventarioDto InventarioDto)
        {
            if (InventarioDto.Id == 0)
            {
                InventarioDto.Id = id;
            }

            if(InventarioDto.Id != id)
            {
                return BadRequest();
            }

            if(InventarioDto == null)
            {
                return NotFound();
            }
            var inventarios = _mapper.Map<Inventario>(InventarioDto);
            _unitOfWork.Inventarios.Update(inventarios);
            await _unitOfWork.SaveAsync();
            return InventarioDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);

            if (inventario == null)
            {
                return NotFound();
            }

            _unitOfWork.Inventarios.Remove(inventario);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}