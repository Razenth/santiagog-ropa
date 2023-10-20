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
    public class MunicipioController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MunicipioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MunicipioDto>>> Get()
        {
            var municipios = await _unitOfWork.Municipios.GetAllAsync();
            return _mapper.Map<List<MunicipioDto>>(municipios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MunicipioDto>> Get(int id)
        {
            var municipio = await _unitOfWork.Municipios.GetByIdAsync(id);

            if (municipio == null)
            {
                return NotFound();
            }

            return _mapper.Map<MunicipioDto>(municipio);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Municipio>> Post(MunicipioDto MunicipioDto)
        {
            var municipio = _mapper.Map<Municipio>(MunicipioDto);
            this._unitOfWork.Municipios.Add(municipio);
            await _unitOfWork.SaveAsync();

            if (municipio == null)
            {
                return BadRequest();
            }
            MunicipioDto.Id = municipio.Id;
            return CreatedAtAction(nameof(Post), new { id = MunicipioDto.Id }, MunicipioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MunicipioDto>> Put(int id, [FromBody] MunicipioDto MunicipioDto)
        {
            if (MunicipioDto.Id == 0)
            {
                MunicipioDto.Id = id;
            }

            if(MunicipioDto.Id != id)
            {
                return BadRequest();
            }

            if(MunicipioDto == null)
            {
                return NotFound();
            }
            var municipio = _mapper.Map<Municipio>(MunicipioDto);
            _unitOfWork.Municipios.Update(municipio);
            await _unitOfWork.SaveAsync();
            return MunicipioDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var municipio = await _unitOfWork.Municipios.GetByIdAsync(id);

            if (municipio == null)
            {
                return NotFound();
            }

            _unitOfWork.Municipios.Remove(municipio);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}