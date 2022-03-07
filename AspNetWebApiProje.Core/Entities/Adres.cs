using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Core.Entities
{
    public class Adres:BaseEntity
    {
        public string AdresAciklama { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
    }
}
