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
            var position = await _unitOfWork.Cargos.GetAllAsync();
            return _mapper.Map<List<CargoDto>>(position);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CargoDto>> Get(int id)
        {
            var position = await _unitOfWork.Cargos.GetByIdAsync(id);

            if (position == null)
            {
                return NotFound();
            }

            return _mapper.Map<CargoDto>(position);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cargo>> Post(CargoDto CargoDto)
        {
            var position = _mapper.Map<Cargo>(CargoDto);
            this._unitOfWork.Cargos.Add(position);
            await _unitOfWork.SaveAsync();

            if (position == null)
            {
                return BadRequest();
            }
            CargoDto.Id = position.Id;
            return CreatedAtAction(nameof(Post), new { id = CargoDto.Id }, CargoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CargoDto>> Put(int id, [FromBody] CargoDto cargoDto)
        {
            if (cargoDto.Id == 0)
            {
                cargoDto.Id = id;
            }

            if(cargoDto.Id != id)
            {
                return BadRequest();
            }

            if(cargoDto == null)
            {
                return NotFound();
            }

            var position = _mapper.Map<Cargo>(cargoDto);
            _unitOfWork.Cargos.Update(position);
            await _unitOfWork.SaveAsync();
            return cargoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var position = await _unitOfWork.Cargos.GetByIdAsync(id);

            if (position == null)
            {
                return NotFound();
            }

            _unitOfWork.Cargos.Remove(position);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}