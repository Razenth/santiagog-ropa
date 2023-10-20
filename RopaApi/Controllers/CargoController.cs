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

    public class CargoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CargoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CargoDto>>> Get()
    {
        var cargos = await _unitOfWork.Cargos.GetAllAsync();
        return _mapper.Map<List<CargoDto>>(cargos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CargoDto>> Get(int id)
    {
        var cargo = await _unitOfWork.Cargos.GetByIdAsync(id);

        if (cargo == null)
        {
            return NotFound();
        }

        return _mapper.Map<CargoDto>(cargo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cargo>> Post(CargoDto CargoDto)
    {
        var cargo = _mapper.Map<Cargo>(CargoDto);
        this._unitOfWork.Cargos.Add(cargo);
        await _unitOfWork.SaveAsync();

        if (cargo == null)
        {
            return BadRequest();
        }
        CargoDto.Id = cargo.Id;
        return CreatedAtAction(nameof(Post), new { id = CargoDto.Id }, CargoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CargoDto>> Put(int id, [FromBody] CargoDto CargoDto)
    {
        if (CargoDto.Id == 0)
        {
            CargoDto.Id = id;
        }

        if (CargoDto.Id != id)
        {
            return BadRequest();
        }

        if (CargoDto == null)
        {
            return NotFound();
        }

        var cargo = _mapper.Map<Cargo>(CargoDto);
        _unitOfWork.Cargos.Update(cargo);
        await _unitOfWork.SaveAsync();
        return CargoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var cargo = await _unitOfWork.Cargos.GetByIdAsync(id);

        if (cargo == null)
        {
            return NotFound();
        }

        _unitOfWork.Cargos.Remove(cargo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
