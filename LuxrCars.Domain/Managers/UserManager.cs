using LuxrCars.Domain.Interface.Repositories;
using LuxrCars.Domain.Interface.Services;
using LuxrCars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Domain.Managers
{
    public class UserManager
    {
        private IUserRepository _userRepo;

        private IEncryption _encryption;
        public UserManager(IUserRepository userRepo, IEncryption encryption)
        {
            _userRepo = userRepo;
            _encryption = encryption;
        }

       public UserModel Login(string email, string password)
        {
            var passwordHash = _encryption.Encrpyt(password);
            //chk to see if user exist, chk if passwords match
            var user = _userRepo.ValidateUser(email, passwordHash);

            return user;

        }

        public UserModel RegisterUser(UserModel model, string password)
        {
            model.Validate();
            //ck if user exsits
            var user = _userRepo.GetUser(model.Email);
            if(user != null)
            {
                throw new Exception($"Email ({model.Email}) already exsists");
            }

            //create user
            user = _userRepo.Create(model);

            //encrpyt password
            var passWordHash = _encryption.Encrpyt(password);


            //store encrypted password
            _userRepo.SetPasswordHash(user.UserID, passWordHash);
            return model;
        }
    }
}
