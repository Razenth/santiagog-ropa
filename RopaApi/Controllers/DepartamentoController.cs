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
    public class DepartamentoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
        {
            var departamentos = await _unitOfWork.Departamentos.GetAllAsync();
            return _mapper.Map<List<DepartamentoDto>>(departamentos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartamentoDto>> Get(int id)
        {
            var departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return _mapper.Map<DepartamentoDto>(departamento);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Departamento>> Post(DepartamentoDto DepartamentoDto)
        {
            var departamento = _mapper.Map<Departamento>(DepartamentoDto);
            this._unitOfWork.Departamentos.Add(departamento);
            await _unitOfWork.SaveAsync();

            if (departamento == null)
            {
                return BadRequest();
            }
            DepartamentoDto.Id = departamento.Id;
            return CreatedAtAction(nameof(Post), new { id = DepartamentoDto.Id }, DepartamentoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody] DepartamentoDto DepartamentoDto)
        {
            if (DepartamentoDto.Id == 0)
            {
                DepartamentoDto.Id = id;
            }

            if(DepartamentoDto.Id != id)
            {
                return BadRequest();
            }

            if(DepartamentoDto == null)
            {
                return NotFound();
            }

            var departamentos = _mapper.Map<Departamento>(DepartamentoDto);
            _unitOfWork.Departamentos.Update(departamentos);
            await _unitOfWork.SaveAsync();
            return DepartamentoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            _unitOfWork.Departamentos.Remove(departamento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}