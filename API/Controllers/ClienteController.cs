using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
            var client = await _unitOfWork.Clientes.GetAllAsync();
            return _mapper.Map<List<ClienteDto>>(client);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var client = await _unitOfWork.Clientes.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return _mapper.Map<ClienteDto>(client);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> Post(ClienteDto clienteDto)
        {
            var client = _mapper.Map<Cliente>(clienteDto);
            this._unitOfWork.Clientes.Add(client);
            await _unitOfWork.SaveAsync();

            if (client == null)
            {
                return BadRequest();
            }
            clienteDto.Id = client.Id;
            return CreatedAtAction(nameof(Post), new { id = clienteDto.Id }, clienteDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody] ClienteDto clienteDto)
        {
            if (clienteDto.Id == 0)
            {
                clienteDto.Id = id;
            }

            if(clienteDto.Id != id)
            {
                return BadRequest();
            }

            if(clienteDto == null)
            {
                return NotFound();
            }

            var client = _mapper.Map<Cliente>(clienteDto);
            _unitOfWork.Clientes.Update(client);
            await _unitOfWork.SaveAsync();
            return clienteDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _unitOfWork.Clientes.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            _unitOfWork.Clientes.Remove(client);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}