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
public class EmpleadoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        var empleados = await _unitOfWork.Empleados.GetAllAsync();
        return _mapper.Map<List<EmpleadoDto>>(empleados);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDto>> Get(int id)
    {
        var empleado = await _unitOfWork.Empleados.GetByIdAsync(id);

        if (empleado == null)
        {
            return NotFound();
        }

        return _mapper.Map<EmpleadoDto>(empleado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto)
    {
        var empleado = _mapper.Map<Empleado>(EmpleadoDto);
        this._unitOfWork.Empleados.Add(empleado);
        await _unitOfWork.SaveAsync();

        if (empleado == null)
        {
            return BadRequest();
        }
        EmpleadoDto.Id = empleado.Id;
        return CreatedAtAction(nameof(Post), new { id = EmpleadoDto.Id }, EmpleadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody] EmpleadoDto EmpleadoDto)
    {
        if (EmpleadoDto.Id == 0)
        {
            EmpleadoDto.Id = id;
        }

        if (EmpleadoDto.Id != id)
        {
            return BadRequest();
        }

        if (EmpleadoDto == null)
        {
            return NotFound();
        }
        var empleado = _mapper.Map<Empleado>(EmpleadoDto);
        _unitOfWork.Empleados.Update(empleado);
        await _unitOfWork.SaveAsync();
        return EmpleadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var empleado = await _unitOfWork.Empleados.GetByIdAsync(id);

        if (empleado == null)
        {
            return NotFound();
        }

        _unitOfWork.Empleados.Remove(empleado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
