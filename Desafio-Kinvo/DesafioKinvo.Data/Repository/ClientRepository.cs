using DesafioKinvo.Domain.Interfaces;
using DesafioKinvo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DesafioKinvo.Data.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DataContext db) : base(db)
        {
        }
    }
}
