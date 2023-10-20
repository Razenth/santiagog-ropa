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
    public class InsumoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsumoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<InsumoDto>>> Get()
        {
            var insumos = await _unitOfWork.Insumos.GetAllAsync();
            return _mapper.Map<List<InsumoDto>>(insumos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InsumoDto>> Get(int id)
        {
            var insumo = await _unitOfWork.Insumos.GetByIdAsync(id);

            if (insumo == null)
            {
                return NotFound();
            }

            return _mapper.Map<InsumoDto>(insumo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Insumo>> Post(InsumoDto InsumoDto)
        {
            var insumo = _mapper.Map<Insumo>(InsumoDto);
            this._unitOfWork.Insumos.Add(insumo);
            await _unitOfWork.SaveAsync();

            if (insumo == null)
            {
                return BadRequest();
            }
            InsumoDto.Id = insumo.Id;
            return CreatedAtAction(nameof(Post), new { id = InsumoDto.Id }, InsumoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InsumoDto>> Put(int id, [FromBody] InsumoDto InsumoDto)
        {
            if (InsumoDto.Id == 0)
            {
                InsumoDto.Id = id;
            }

            if(InsumoDto.Id != id)
            {
                return BadRequest();
            }

            if(InsumoDto == null)
            {
                return NotFound();
            }
            var insumo = _mapper.Map<Insumo>(InsumoDto);
            _unitOfWork.Insumos.Update(insumo);
            await _unitOfWork.SaveAsync();
            return InsumoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var insumo = await _unitOfWork.Insumos.GetByIdAsync(id);

            if (insumo == null)
            {
                return NotFound();
            }

            _unitOfWork.Insumos.Remove(insumo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}