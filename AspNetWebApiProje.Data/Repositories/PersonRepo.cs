using AspNetWebApiProje.Core.Entities;
using AspNetWebApiProje.Core.Interfaces;
using AspNetWebApiProje.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Data.Repositories
{
    public class PersonRepo : Repository<Personel>, IPersonRepo
    {
        public readonly PersonelContext _perContext;
        public PersonRepo(PersonelContext perContext):base(perContext)
        {
            _perContext = perContext;
        }

        
        public async Task<Personel> PersonelWithAdresGet(int id)
        {
            return await _perContext.Personel.Include(x => x.Adresler).Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}
