using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApiProje.API.Dtos
{
    public class PersonelWithAdresDto:PersonelDto
    {
        public List<AdresDto> Adresler { get; set; }
    }
}
