using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetails.Model;

namespace UserDetails.Service.Interface
{
    public interface IUserService
    {
        bool AddUser(User user);
        User GetUserById(int id);
        List<User> GetAllUser();
        bool DeleteUser(int id);
        bool UpdateUser(User user,int id);
    }
}
