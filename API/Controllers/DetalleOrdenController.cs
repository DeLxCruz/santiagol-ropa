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
    public class DetalleOrdenController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleOrdenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleOrdenDto>>> Get()
        {
            var detail = await _unitOfWork.DetalleOrdenes.GetAllAsync();
            return _mapper.Map<List<DetalleOrdenDto>>(detail);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleOrdenDto>> Get(int id)
        {
            var detail = await _unitOfWork.DetalleOrdenes.GetByIdAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            return _mapper.Map<DetalleOrdenDto>(detail);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleOrden>> Post(DetalleOrdenDto detalleOrdenDto)
        {
            var detail = _mapper.Map<DetalleOrden>(detalleOrdenDto);
            this._unitOfWork.DetalleOrdenes.Add(detail);
            await _unitOfWork.SaveAsync();

            if (detail == null)
            {
                return BadRequest();
            }
            detalleOrdenDto.Id = detail.Id;
            return CreatedAtAction(nameof(Post), new { id = detalleOrdenDto.Id }, detalleOrdenDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleOrdenDto>> Put(int id, [FromBody] DetalleOrdenDto detalleOrdenDto)
        {
            if (detalleOrdenDto.Id == 0)
            {
                detalleOrdenDto.Id = id;
            }

            if(detalleOrdenDto.Id != id)
            {
                return BadRequest();
            }

            if(detalleOrdenDto == null)
            {
                return NotFound();
            }

            var detail = _mapper.Map<DetalleOrden>(detalleOrdenDto);
            _unitOfWork.DetalleOrdenes.Update(detail);
            await _unitOfWork.SaveAsync();
            return detalleOrdenDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var detail = await _unitOfWork.DetalleOrdens.GetByIdAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            _unitOfWork.DetalleOrdenes.Remove(detail);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}