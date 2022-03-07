using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Core.Interfaces
{
    public interface IUow
    {
        IPersonRepo _personRepo{ get;}
        Task CommitAsync();
        void Commit();
    }
}
