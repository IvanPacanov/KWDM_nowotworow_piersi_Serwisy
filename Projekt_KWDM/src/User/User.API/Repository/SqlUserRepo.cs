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

        public bool CheckUser(Entities.User user)
        {
            var User = _userContext.User.FirstOrDefault(p => p.UserName == user.UserName && p.Password == user.Password);
            if(User != null)
            {
                return true;
            }
            return false;
        }
        public bool CreateNewUser(Entities.User user)
        {
            var User = _userContext.User.Add(user);
            if (User.State ==  Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                _userContext.SaveChanges();
                return true;
            }            
            return false;
        }
    }
}
