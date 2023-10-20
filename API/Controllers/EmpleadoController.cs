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
            var employee = await _unitOfWork.Empleados.GetAllAsync();
            return _mapper.Map<List<EmpleadoDto>>(employee);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoDto>> Get(int id)
        {
            var employee = await _unitOfWork.Empleados.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return _mapper.Map<EmpleadoDto>(employee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empleado>> Post(EmpleadoDto empleadoDto)
        {
            var employee = _mapper.Map<Empleado>(empleadoDto);
            this._unitOfWork.Empleados.Add(employee);
            await _unitOfWork.SaveAsync();

            if (employee == null)
            {
                return BadRequest();
            }
            empleadoDto.Id = employee.Id;
            return CreatedAtAction(nameof(Post), new { id = empleadoDto.Id }, empleadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody] EmpleadoDto empleadoDto)
        {
            if (empleadoDto.Id == 0)
            {
                empleadoDto.Id = id;
            }

            if(empleadoDto.Id != id)
            {
                return BadRequest();
            }

            if(empleadoDto == null)
            {
                return NotFound();
            }

            var employee = _mapper.Map<Empleado>(empleadoDto);
            _unitOfWork.Empleados.Update(employee);
            await _unitOfWork.SaveAsync();
            return empleadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _unitOfWork.Empleados.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _unitOfWork.Empleados.Remove(employee);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}