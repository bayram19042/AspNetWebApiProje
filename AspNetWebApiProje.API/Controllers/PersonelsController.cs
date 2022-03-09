using AspNetWebApiProje.API.Dtos;
using AspNetWebApiProje.Core.Entities;
using AspNetWebApiProje.Core.Interfaces;
using AspNetWebApiProje.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


using System.Threading.Tasks;

namespace AspNetWebApiProje.API.Controllers
{   
    [EnableCors]
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _repo;
        public PersonelsController(IPersonService repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repo.GetAllAsync();
            return Ok(_mapper.Map<List<PersonelDto>>(result));
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {

            var gelen = await _repo.GetByIdAsync(id);
            //   var data = JsonSerializer.Deserialize<>


            //var data = JsonSerializer.Deserialize<Personel>(gelen);
            return Ok(_mapper.Map<PersonelDto>(gelen));
        }

        [HttpGet("{id}/adres")]
        
        public async Task<IActionResult> PersonelWithAdresGet(int id)
        {

            var gelen = await _repo.PersonWithAdresGet(id);
         //   var data = JsonSerializer.Deserialize<>


            //var data = JsonSerializer.Deserialize<Personel>(gelen);
            return Ok(_mapper.Map<PersonelWithAdresDto>(gelen));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePersonelDto entity)
        {
            await _repo.CreateAsync(_mapper.Map<Personel>(entity));
            
            return Created(string.Empty, entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Remove(id);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Personel entity)
        {
            _repo.Update(entity);

            return NoContent();
        }
    }
}
