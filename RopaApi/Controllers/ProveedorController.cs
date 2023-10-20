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
    public class ProveedorController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
        {
            var proveedores = await _unitOfWork.Proveedores.GetAllAsync();
            return _mapper.Map<List<ProveedorDto>>(proveedores);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProveedorDto>> Get(int id)
        {
            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProveedorDto>(proveedor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Proveedor>> Post(ProveedorDto ProveedorDto)
        {
            var proveedor = _mapper.Map<Proveedor>(ProveedorDto);
            this._unitOfWork.Proveedores.Add(proveedor);
            await _unitOfWork.SaveAsync();

            if (proveedor == null)
            {
                return BadRequest();
            }
            ProveedorDto.Id = proveedor.Id;
            return CreatedAtAction(nameof(Post), new { id = ProveedorDto.Id }, ProveedorDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody] ProveedorDto ProveedorDto)
        {
            if (ProveedorDto.Id == 0)
            {
                ProveedorDto.Id = id;
            }

            if(ProveedorDto.Id != id)
            {
                return BadRequest();
            }

            if(ProveedorDto == null)
            {
                return NotFound();
            }
            var proveedor = _mapper.Map<Proveedor>(ProveedorDto);
            _unitOfWork.Proveedores.Update(proveedor);
            await _unitOfWork.SaveAsync();
            return ProveedorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            _unitOfWork.Proveedores.Remove(proveedor);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}