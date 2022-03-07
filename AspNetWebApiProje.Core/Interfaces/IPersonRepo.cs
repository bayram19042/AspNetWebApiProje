using AspNetWebApiProje.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Core.Interfaces
{
    public interface IPersonRepo:IRepository<Personel>
    {
        Task<Personel> PersonelWithAdresGet(int id);
    }
}
