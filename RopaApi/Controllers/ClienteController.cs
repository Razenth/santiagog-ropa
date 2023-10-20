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

public class ClienteController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
    {
        var clientes = await _unitOfWork.Clientes.GetAllAsync();
        return _mapper.Map<List<ClienteDto>>(clientes);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDto>> Get(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return _mapper.Map<ClienteDto>(cliente);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Post(ClienteDto ClienteDto)
    {
        var cliente = _mapper.Map<Cliente>(ClienteDto);
        this._unitOfWork.Clientes.Add(cliente);
        await _unitOfWork.SaveAsync();

        if (cliente == null)
        {
            return BadRequest();
        }
        ClienteDto.Id = cliente.Id;
        return CreatedAtAction(nameof(Post), new { id = ClienteDto.Id }, ClienteDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody] ClienteDto ClienteDto)
    {
        if (ClienteDto.Id == 0)
        {
            ClienteDto.Id = id;
        }

        if (ClienteDto.Id != id)
        {
            return BadRequest();
        }

        if (ClienteDto == null)
        {
            return NotFound();
        }
        var cliente = _mapper.Map<Cliente>(ClienteDto);
        _unitOfWork.Clientes.Update(cliente);
        await _unitOfWork.SaveAsync();
        return ClienteDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        _unitOfWork.Clientes.Remove(cliente);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
