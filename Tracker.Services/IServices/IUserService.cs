using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Services.Models;

namespace Tracker.Services.IServices
{
    public interface IUserService
    {
        UserDTO FindUser(string username, string password);

        bool AddUser(UserDTO user);

    }
}
