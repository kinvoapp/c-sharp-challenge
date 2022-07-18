using DesafioKinvo.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKinvo.Core.Interfaces
{
    public interface IService<T> where T : Entity
    {
        Task<bool> Add(T objeto);
        Task<bool> Update(T objeto);

        Task<bool> Delete(Guid Id);
    }
}
