using AspNetWebApiProje.Core.Entities;
using AspNetWebApiProje.Core.Interfaces;
using AspNetWebApiProje.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Service.Services
{
    public class PersonService : RepositoryService<Personel>, IPersonService
    {
        protected readonly IUow _unitOfWork;
     
        public PersonService(IUow uow,IRepository<Personel> repo):base(repo,uow)
        {
            _unitOfWork =  uow;
            
        }
        public async Task<Personel> PersonWithAdresGet(int id)
        {
            return await _unitOfWork._personRepo.PersonelWithAdresGet(id);
        }
    }
}
