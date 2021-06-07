using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetails.Model;
using UserDetails.Service.Interface;

namespace UserDetails.Service
{
    public class UserService : IUserService
    {
        public List<User> userList;
        public UserService()
        {
            userList = new List<User>();
            userList.Add(new User
            {
                Id = 1,
                Name = "Navya",
                Email = "navya.hegde@gmail.com",
                Country = "India"
            });
            userList.Add(new User
            {
                Id = 2,
                Name = "Kirana",
                Email = "kiran@gmail.com",
                Country = "United Kingdom"
            });
        }
        public bool AddUser(User user)
        {         
            var selectedUser = userList.Find(x=>x.Id==user.Id);
            if (selectedUser?.Id == user.Id)
            {
                return false;
            }
            userList.Add(new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Country = user.Country
            });
            return true;
        }

        public List<User> GetAllUser()=>userList;        

        public User GetUserById(int id)
        {
            var selectedUser = userList.FirstOrDefault<User>(x=>x.Id==id);           
            return selectedUser;
        }

        public bool DeleteUser(int id)
        {
            var selectedUser = userList.FirstOrDefault<User>(x => x.Id == id);
            if (selectedUser == null)
            {
                return false;
            }            
            userList.Remove(GetUserById(id));
            return true;
        }
        public bool UpdateUser(User user,int id)
        {
            var selectedUser = userList.FirstOrDefault<User>(x => x.Id == id);
            if(selectedUser==null)
            {
                return false;
            }
            else
            {
                userList.Remove(GetUserById(id));
                AddUser(user);
                return true;
            }
        }
    }
}