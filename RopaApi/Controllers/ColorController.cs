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
    public class ColorController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ColorDto>>> Get()
        {
            var colores = await _unitOfWork.Colores.GetAllAsync();
            return _mapper.Map<List<ColorDto>>(colores);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ColorDto>> Get(int id)
        {
            var color = await _unitOfWork.Colores.GetByIdAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            return _mapper.Map<ColorDto>(color);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Color>> Post(ColorDto ColorDto)
        {
            var color = _mapper.Map<Color>(ColorDto);
            this._unitOfWork.Colores.Add(color);
            await _unitOfWork.SaveAsync();

            if (color == null)
            {
                return BadRequest();
            }
            ColorDto.Id = color.Id;
            return CreatedAtAction(nameof(Post), new { id = ColorDto.Id }, ColorDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ColorDto>> Put(int id, [FromBody] ColorDto ColorDto)
        {
            if (ColorDto.Id == 0)
            {
                ColorDto.Id = id;
            }

            if(ColorDto.Id != id)
            {
                return BadRequest();
            }

            if(ColorDto == null)
            {
                return NotFound();
            }

            var color = _mapper.Map<Color>(ColorDto);
            _unitOfWork.Colores.Update(color);
            await _unitOfWork.SaveAsync();
            return ColorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var color = await _unitOfWork.Colores.GetByIdAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            _unitOfWork.Colores.Remove(color);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}