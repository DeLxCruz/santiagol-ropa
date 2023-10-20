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
    public class EmpresaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpresaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpresaDto>>> Get()
        {
            var company = await _unitOfWork.Empresas.GetAllAsync();
            return _mapper.Map<List<EmpresaDto>>(company);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpresaDto>> Get(int id)
        {
            var company = await _unitOfWork.Empresas.GetByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return _mapper.Map<EmpresaDto>(company);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empresa>> Post(EmpresaDto EmpresaDto)
        {
            var company = _mapper.Map<Empresa>(EmpresaDto);
            this._unitOfWork.Empresas.Add(company);
            await _unitOfWork.SaveAsync();

            if (company == null)
            {
                return BadRequest();
            }
            EmpresaDto.Id = company.Id;
            return CreatedAtAction(nameof(Post), new { id = EmpresaDto.Id }, EmpresaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpresaDto>> Put(int id, [FromBody] EmpresaDto EmpresaDto)
        {
            if (EmpresaDto.Id == 0)
            {
                EmpresaDto.Id = id;
            }

            if(EmpresaDto.Id != id)
            {
                return BadRequest();
            }

            if(EmpresaDto == null)
            {
                return NotFound();
            }

            var company = _mapper.Map<Empresa>(EmpresaDto);
            _unitOfWork.Empresas.Update(company);
            await _unitOfWork.SaveAsync();
            return EmpresaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _unitOfWork.Empresas.GetByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            _unitOfWork.Empresas.Remove(company);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}