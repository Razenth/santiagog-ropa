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
    public class EmpresaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpresaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpresaDto>>> Get()
        {
            var empresas = await _unitOfWork.Empresas.GetAllAsync();
            return _mapper.Map<List<EmpresaDto>>(empresas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpresaDto>> Get(int id)
        {
            var empresa = await _unitOfWork.Empresas.GetByIdAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return _mapper.Map<EmpresaDto>(empresa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empresa>> Post(EmpresaDto EmpresaDto)
        {
            var empresa = _mapper.Map<Empresa>(EmpresaDto);
            this._unitOfWork.Empresas.Add(empresa);
            await _unitOfWork.SaveAsync();

            if (empresa == null)
            {
                return BadRequest();
            }
            EmpresaDto.Id = empresa.Id;
            return CreatedAtAction(nameof(Post), new { id = EmpresaDto.Id }, EmpresaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpresaDto>> Put(int id, [FromBody] EmpresaDto EmpresaDto)
        {
            if (EmpresaDto.Id == 0)
            {
                EmpresaDto.Id = id;
            }

            if(EmpresaDto.Id != id)
            {
                return BadRequest();
            }

            if(EmpresaDto == null)
            {
                return NotFound();
            }

            var empresa = _mapper.Map<Empresa>(EmpresaDto);
            _unitOfWork.Empresas.Update(empresa);
            await _unitOfWork.SaveAsync();
            return EmpresaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var empresa = await _unitOfWork.Empresas.GetByIdAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            _unitOfWork.Empresas.Remove(empresa);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}