using AspNetWebApiProje.Core.Interfaces;
using AspNetWebApiProje.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Data.Repositories
{
    public class Uow : IUow
    {
        private readonly PersonelContext _context;
        public Uow(PersonelContext context)
        {
            _context = context;
        }
        public IPersonRepo personRepo;
        public IPersonRepo _personRepo =>personRepo = personRepo?? new PersonRepo(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
