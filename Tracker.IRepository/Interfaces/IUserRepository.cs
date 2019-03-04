using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Models;

namespace Tracker.IRepository.Interfaces
{
    public interface IUserRepository
    {
        UserModel FindUser(string username, string password);
        void AddUser(UserModel user);
    }
}
