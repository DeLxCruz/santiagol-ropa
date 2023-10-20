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
            var color = await _unitOfWork.Colors.GetAllAsync();
            return _mapper.Map<List<ColorDto>>(color);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ColorDto>> Get(int id)
        {
            var color = await _unitOfWork.Colors.GetByIdAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            return _mapper.Map<ColorDto>(color);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Color>> Post(ColorDto colorDto)
        {
            var color = _mapper.Map<Color>(colorDto);
            this._unitOfWork.Colors.Add(color);
            await _unitOfWork.SaveAsync();

            if (color == null)
            {
                return BadRequest();
            }
            colorDto.Id = color.Id;
            return CreatedAtAction(nameof(Post), new { id = colorDto.Id }, colorDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ColorDto>> Put(int id, [FromBody] ColorDto colorDto)
        {
            if (colorDto.Id == 0)
            {
                colorDto.Id = id;
            }

            if(colorDto.Id != id)
            {
                return BadRequest();
            }

            if(colorDto == null)
            {
                return NotFound();
            }

            var color = _mapper.Map<Color>(colorDto);
            _unitOfWork.Colors.Update(color);
            await _unitOfWork.SaveAsync();
            return colorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var color = await _unitOfWork.Colors.GetByIdAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            _unitOfWork.Colors.Remove(color);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}