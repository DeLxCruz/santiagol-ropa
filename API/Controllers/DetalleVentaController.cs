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
    public class DetalleVentaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleVentaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleVentaDto>>> Get()
        {
            var detail = await _unitOfWork.DetalleVentas.GetAllAsync();
            return _mapper.Map<List<DetalleVentaDto>>(detail);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleVentaDto>> Get(int id)
        {
            var detail = await _unitOfWork.DetalleVentas.GetByIdAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            return _mapper.Map<DetalleVentaDto>(detail);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleVenta>> Post(DetalleVentaDto detalleVentaDto)
        {
            var detail = _mapper.Map<DetalleVenta>(detalleVentaDto);
            this._unitOfWork.DetalleVentas.Add(detail);
            await _unitOfWork.SaveAsync();

            if (detail == null)
            {
                return BadRequest();
            }
            detalleVentaDto.Id = detail.Id;
            return CreatedAtAction(nameof(Post), new { id = detalleVentaDto.Id }, detalleVentaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleVentaDto>> Put(int id, [FromBody] DetalleVentaDto detalleVentaDto)
        {
            if (detalleVentaDto.Id == 0)
            {
                detalleVentaDto.Id = id;
            }

            if(detalleVentaDto.Id != id)
            {
                return BadRequest();
            }

            if(detalleVentaDto == null)
            {
                return NotFound();
            }

            var detail = _mapper.Map<DetalleVenta>(detalleVentaDto);
            _unitOfWork.DetalleVentas.Update(detail);
            await _unitOfWork.SaveAsync();
            return detalleVentaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var detail = await _unitOfWork.DetalleVentas.GetByIdAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            _unitOfWork.DetalleVentas.Remove(detail);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}