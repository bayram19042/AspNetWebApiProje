
using AspNetWebApiProje.Core.Entities;
using AspNetWebApiProje.Service.Interfaces;
using AspNetWebApiProje.UI.Dtos;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetWebApiProje.UI.Controllers
{
    public class PersonelController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClient;
        public PersonelController(IPersonService personService, IMapper mapper,IHttpClientFactory httpClient)
        {
            _personService = personService;
            _mapper = mapper;
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {

            List<PersonelDto> personelDto;
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:44302/api/personels");
            if (response.IsSuccessStatusCode)
            {
                personelDto = JsonConvert.DeserializeObject<List<PersonelDto>>(await response.Content.ReadAsStringAsync());
                return View(_mapper.Map<List<PersonelDto>>(personelDto));
            }
            return View();
            
            //var personel = await _personelApiService.GetAllAsync();
            
        }

        public IActionResult Create()
        {
            return View(new CreatePersonelDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonelDto personel)
        {
            if(ModelState.IsValid)
            {
                await _personService.CreateAsync(_mapper.Map<Personel>(personel));

                return RedirectToAction("index");
            }
            return View(personel);
        }

        [HttpGet]
        public  IActionResult Delete(int id)
        {
            _personService.Remove(id);
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var veri = await _personService.GetByIdAsync(id);
            return View(_mapper.Map<PersonelDto>(veri));
        }
        [HttpPost]
        public IActionResult Update(PersonelDto personel)
        {
            if(ModelState.IsValid)
            {
                _personService.Update(_mapper.Map<Personel>(personel));
                return RedirectToAction("index");
            }
            return View(personel);
        }
    }
}
