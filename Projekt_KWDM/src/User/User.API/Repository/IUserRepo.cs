using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Repository
{
    public interface IUserRepo
    {
        IEnumerable<Entities.User> GetAllUsers();
        Entities.User GetUserByName(string name);
    }
}
