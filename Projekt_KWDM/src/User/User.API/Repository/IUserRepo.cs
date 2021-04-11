using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Repository
{
    public interface IUserRepo
    {
        IEnumerable<Entities.User> GetAllUsers();
        bool CheckUser(Entities.User user);
        bool CreateNewUser(Entities.User user);
    }
}
