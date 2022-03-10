
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
using System.Text;
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
            else
            {
                return View(new List<PersonelDto>());
            }
            
            
            //var personel = await _personelApiService.GetAllAsync();
            
        }

        public IActionResult Create()
        {
            return View(new CreatePersonelDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonelDto personel)
        {
            var client = _httpClient.CreateClient();

            if(ModelState.IsValid)
            {
                var jsonData = JsonConvert.SerializeObject(personel);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
               var response =  await client.PostAsync("https://localhost:44302/api/personels",content);
                //await _personService.CreateAsync(_mapper.Map<Personel>(personel));
                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    TempData["hata"] = "Bir hata ile karşılaşıldı.";
                }
            }
            return View(personel);
        }

        [HttpGet]
        public async  Task<IActionResult> Delete(int id)
        {
            var client = _httpClient.CreateClient();
            
       
            var silme =await client.DeleteAsync($"https://localhost:44302/api/personels/{id}");
            if(silme.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
           
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClient.CreateClient();
            var jsonData = await client.GetAsync($"https://localhost:44302/api/personels/{id}");
            if(jsonData.IsSuccessStatusCode)
            {
                var oku =await jsonData.Content.ReadAsStringAsync();
                var veri = JsonConvert.DeserializeObject<PersonelDto>(oku);
                return View(veri);
            }
            else
            {
                TempData["hata"] = "Bir hata ile karşılaşıldı.";
            }
            return View();
           // var veri = await _personService.GetByIdAsync(id);
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(PersonelDto personel)
        {
            var client = _httpClient.CreateClient();
            
            if(ModelState.IsValid)
            {

                var veri = JsonConvert.SerializeObject(personel);
                
                StringContent content = new StringContent(veri,Encoding.UTF8,"application/json");
                await client.PutAsync("https://localhost:44302/api/personels", content);
                //_personService.Update(_mapper.Map<Personel>(personel));
                return RedirectToAction("index");
            }
            return View(personel);
        }
    }
}
