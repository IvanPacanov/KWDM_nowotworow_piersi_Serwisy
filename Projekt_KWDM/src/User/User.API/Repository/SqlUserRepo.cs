using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Data;

namespace User.API.Repository
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly UserContext _userContext;

        public SqlUserRepo(UserContext userContext)
        {
            _userContext = userContext;
        }

        public IEnumerable<Entities.User> GetAllUsers()
        {
            return _userContext.User.ToList();
        }

        public Entities.User GetUserByName(string name)
        {
            return _userContext.User.FirstOrDefault(p => p.UserName == name);
        }
    }
}
