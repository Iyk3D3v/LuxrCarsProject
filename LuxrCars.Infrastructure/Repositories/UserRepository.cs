using LuxrCars.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxrCars.Domain.Models;
using System.Data.Entity;
using LuxrCars.Infrastructure.Data;

namespace LuxrCars.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserModel Create(UserModel m)
        {
            using (var context = new DataEntities())
            {
                
                var user = new User
                {
                    Email = m.Email,
                    firstName = m.firstName,
                    lastName = m.lastName,
                    Image = m.Image

                };
                context.Users.Add(user);

                context.SaveChanges();

                m.UserID = user.UserID;

                return m;
            }
               


        }

        public UserModel GetUser(string email)
        {
            using (var context = new DataEntities())
            {
                var query = from u in context.Users
                            where u.Email == email
                            select new
                            {
                                u,
                                roles = u.UserRoles.Select(ur => ur.role.Name)
                            };

                var records = query.ToArray();

                var transform = from r in records
                                select new UserModel
                                {
                                    UserID = r.u.UserID,
                                    Email = r.u.Email,
                                    firstName =r.u.firstName,
                                    lastName = r.u.lastName,
                                    Image =r.u.lastName,
                                    Role = r.roles.ToArray() 
                                };

                return transform.FirstOrDefault();
            }
        }

        public void SetPasswordHash(int userID, string passWordHash)
        {
            using (var context = new DataEntities())
            {
                var user = context.Users.Find(userID);
                if (user == null) throw new Exception("User not found");
                user.PasswordHash = passWordHash;
                context.SaveChanges(); 
            }
        }

        public UserModel ValidateUser(string email, string passwordHash)
        {
            using (var context = new DataEntities())
            {
                var query = from u in context.Users
                            where u.Email == email
                            where u.PasswordHash == passwordHash


                            let roles = from userRole in u.UserRoles
                                        select userRole.role.Name

                            select new
                            {
                                u,
                                roles
                            };     

                var record = query.FirstOrDefault();

                if(record != null)
                {
                    return new UserModel
                    {
                        Email = record.u.Email,
                        firstName = record.u.firstName,
                        lastName = record.u.lastName,
                        Role = record.roles.ToArray()
                        //contine in acct controller

                    };
                }


            }


            return null;
        }
    }
}
