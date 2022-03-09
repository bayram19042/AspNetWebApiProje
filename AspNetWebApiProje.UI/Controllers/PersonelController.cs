
using AspNetWebApiProje.Core.Entities;
using AspNetWebApiProje.Service.Interfaces;
using AspNetWebApiProje.UI.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApiProje.UI.Controllers
{
    public class PersonelController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public PersonelController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var personel = await _personService.GetAllAsync();
            return View(_mapper.Map<List<PersonelDto>>(personel));
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
