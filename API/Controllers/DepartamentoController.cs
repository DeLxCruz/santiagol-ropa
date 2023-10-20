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
            var departament = await _unitOfWork.Departamentos.GetAllAsync();
            return _mapper.Map<List<DepartamentoDto>>(departament);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartamentoDto>> Get(int id)
        {
            var departament = await _unitOfWork.Departamentos.GetByIdAsync(id);

            if (departament == null)
            {
                return NotFound();
            }

            return _mapper.Map<DepartamentoDto>(departament);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Departamento>> Post(DepartamentoDto departamentoDto)
        {
            var departament = _mapper.Map<Departamento>(departamentoDto);
            this._unitOfWork.Departamentos.Add(departament);
            await _unitOfWork.SaveAsync();

            if (departament == null)
            {
                return BadRequest();
            }
            departamentoDto.Id = departament.Id;
            return CreatedAtAction(nameof(Post), new { id = departamentoDto.Id }, departamentoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody] DepartamentoDto departamentoDto)
        {
            if (departamentoDto.Id == 0)
            {
                departamentoDto.Id = id;
            }

            if(departamentoDto.Id != id)
            {
                return BadRequest();
            }

            if(departamentoDto == null)
            {
                return NotFound();
            }

            var departament = _mapper.Map<Departamento>(departamentoDto);
            _unitOfWork.Departamentos.Update(departament);
            await _unitOfWork.SaveAsync();
            return departamentoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var departament = await _unitOfWork.Departamentos.GetByIdAsync(id);

            if (departament == null)
            {
                return NotFound();
            }

            _unitOfWork.Departamentos.Remove(departament);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}