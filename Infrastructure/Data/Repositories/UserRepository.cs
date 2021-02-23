using Core.Entities;
using Core.Interfaces;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Infrastructure.UtilitiesClass;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreContext _context;

        public UserRepository(StoreContext context)
        {
            _context = context;
        }

        #pragma warning disable 1998
        public async Task<User> Login(string username, string password)
        {

            return _context.Users.Where(
                i => i.Username == username
                && i.Password == password
                ).FirstOrDefault();
        }

        public async Task<Result> Signup(User user)
        {
            Result result = new Result();

            var usernameVerify = _context.Users.Where(usr => usr.Username == user.Username).FirstOrDefault();
            
            //Check username
            if (usernameVerify != null)
            {
                result.Status = -2;
                result.Message = "این نام کاربری قبلا ثبت شده است";
                return result;
            }
            //End Check username
            else
            {
                var mobileVerify = _context.Users.Where(mob => mob.Mobile == user.Mobile).FirstOrDefault();

                //Check mobile
                if (mobileVerify != null)
                {
                    result.Status = -2;
                    result.Message = "این شماره موبایل قبلا ثبت شده است";
                    return result;
                }
                //End Check mobile 
                else
                {
                    var hashedToken = new Utils();
                    string encodeToken = hashedToken.CreateToken(user);
                    user.Token = encodeToken;
                    

                    //Insert user into table
                    await _context.Users.AddAsync(user);

                    _context.SaveChanges();

                    
                    //End Insert user into table

                    //Check user inserted
                    if (user.Id > 0)
                    {
                        result.Status = user.RoleId;
                        result.Message = user.Token;

                    }
                    else
                    {
                        result.Status = -1;
                        result.Message = "اشکال در ثبت نام، لطفا دوباره تلاش کنید";
                    }
                    //End Check user inserted
                    return result;
                }
            }
        }
    }
}
