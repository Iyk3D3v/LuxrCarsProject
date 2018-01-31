using LuxrCars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Domain.Interface.Repositories
{
    public interface IUserRepository
    {
        UserModel ValidateUser(string email, string password);

        UserModel GetUser(string email);

        UserModel Create(UserModel m);
        void SetPasswordHash(int userID, string passWordHash);
    }
}
