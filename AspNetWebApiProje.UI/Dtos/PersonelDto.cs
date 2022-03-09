using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApiProje.UI.Dtos
{
    public class PersonelDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim alanını boş bırakmayınız.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim alanını boş bırakmayınız.")]
        public string Surname { get; set; }
    }
}
