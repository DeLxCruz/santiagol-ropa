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
    public class EstadoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
        {
            var status = await _unitOfWork.Estados.GetAllAsync();
            return _mapper.Map<List<EstadoDto>>(status);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoDto>> Get(int id)
        {
            var status = await _unitOfWork.Estados.GetByIdAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return _mapper.Map<EstadoDto>(status);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Estado>> Post(EstadoDto EstadoDto)
        {
            var status = _mapper.Map<Estado>(EstadoDto);
            this._unitOfWork.Estados.Add(status);
            await _unitOfWork.SaveAsync();

            if (status == null)
            {
                return BadRequest();
            }
            EstadoDto.Id = status.Id;
            return CreatedAtAction(nameof(Post), new { id = EstadoDto.Id }, EstadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody] EstadoDto EstadoDto)
        {
            if (EstadoDto.Id == 0)
            {
                EstadoDto.Id = id;
            }

            if(EstadoDto.Id != id)
            {
                return BadRequest();
            }

            if(EstadoDto == null)
            {
                return NotFound();
            }

            var status = _mapper.Map<Estado>(EstadoDto);
            _unitOfWork.Estados.Update(status);
            await _unitOfWork.SaveAsync();
            return EstadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _unitOfWork.Estados.GetByIdAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            _unitOfWork.Estados.Remove(status);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}