using AspNetWebApiProje.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Service.Interfaces
{
    public interface IPersonService:IService<Personel>
    {
        Task<Personel> PersonWithAdresGet(int id);
    }
}
