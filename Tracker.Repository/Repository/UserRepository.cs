using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;
using Tracker.IRepository.Interfaces;
using Tracker.IRepository.Models;

namespace Tracker.Repository.Repository
{
    public class UserRepository : BaseRepository,IUserRepository
   {
        public UserModel FindUser(string username, string password)
        {
            return DbContext.Users.Where(x => x.Username == username && x.PasswordHash == password).Select(x=>new UserModel() {
                Username = x.Username,
                Email = x.Email,
                Id_User = x.Id_User
            }).FirstOrDefault();
        }

        public void AddUser(UserModel userModel)
        {
            DbContext.Users.Add(new Users()
            {
                Username = userModel.Username,
                PasswordHash = userModel.Password,
                Email = userModel.Email
            });
            DbContext.SaveChanges();
        }

    }
}
