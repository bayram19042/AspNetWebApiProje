using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Core.Entities
{
    public class Personel:BaseEntity
    {
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Adres> Adresler { get; set; }
    }
}
