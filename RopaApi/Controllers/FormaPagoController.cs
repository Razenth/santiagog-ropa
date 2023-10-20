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
    public class FormaPagoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FormaPagoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FormaPagoDto>>> Get()
        {
            var forPagos = await _unitOfWork.FormaPagos.GetAllAsync();
            return _mapper.Map<List<FormaPagoDto>>(forPagos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormaPagoDto>> Get(int id)
        {
            var forPago = await _unitOfWork.FormaPagos.GetByIdAsync(id);

            if (forPago == null)
            {
                return NotFound();
            }

            return _mapper.Map<FormaPagoDto>(forPago);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FormaPago>> Post(FormaPagoDto FormaPagoDto)
        {
            var forPago = _mapper.Map<FormaPago>(FormaPagoDto);
            this._unitOfWork.FormaPagos.Add(forPago);
            await _unitOfWork.SaveAsync();

            if (forPago == null)
            {
                return BadRequest();
            }
            FormaPagoDto.Id = forPago.Id;
            return CreatedAtAction(nameof(Post), new { id = FormaPagoDto.Id }, FormaPagoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormaPagoDto>> Put(int id, [FromBody] FormaPagoDto FormaPagoDto)
        {
            if (FormaPagoDto.Id == 0)
            {
                FormaPagoDto.Id = id;
            }

            if(FormaPagoDto.Id != id)
            {
                return BadRequest();
            }

            if(FormaPagoDto == null)
            {
                return NotFound();
            }
            var forPago = _mapper.Map<FormaPago>(FormaPagoDto);
            _unitOfWork.FormaPagos.Update(forPago);
            await _unitOfWork.SaveAsync();
            return FormaPagoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var forPago = await _unitOfWork.FormaPagos.GetByIdAsync(id);

            if (forPago == null)
            {
                return NotFound();
            }

            _unitOfWork.FormaPagos.Remove(forPago);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}