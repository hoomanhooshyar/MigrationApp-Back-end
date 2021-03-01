using Core.Entities;
using Core.Interfaces;
using Core.DTO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.UtilitiesClass;
using Microsoft.Extensions.Primitives;
using Microsoft.EntityFrameworkCore;
using System;

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

        public async Task<Result> Signup(Signup user)
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
                    User usr = new User();
                    usr.Name = user.Name;
                    usr.Family = user.Family;
                    usr.Username = user.Username;
                    usr.Password = user.Password;
                    usr.Email = user.Email;
                    usr.Phone = user.Phone;
                    usr.Mobile = user.Mobile;
                    usr.Age = user.Age;
                    usr.Image = user.Image;
                    usr.Token = user.Token;
                    usr.RoleId = user.RoleId;
                    usr.Gender = user.Gender;
                    usr.Status = user.Status;
                    var hashedToken = new Utils();
                    string encodeToken = hashedToken.CreateToken(usr);
                    usr.Token = encodeToken;
                    

                    //Insert user into table
                    await _context.Users.AddAsync(usr);

                    _context.SaveChanges();

                    
                    //End Insert user into table

                    //Check user inserted
                    if (usr.Id > 0)
                    {
                        result.Status = usr.RoleId;
                        result.Message = usr.Token;

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

        public async Task<UserDTO> GetUserData(string token)
        {
            var test = (from usr in _context.Users
                        join sf in _context.StudyFields on usr.StudyField.Id equals sf.Id
                        join cc in _context.CountryCities on usr.CountryCity.Id equals cc.Id
                        where usr.Token == token
                        select new { User = usr, StudyField = sf, CountryCity = cc }).FirstOrDefault();
            try
            {
                var user = _context.Users
                .Include(s => s.StudyField)
                .Include(c => c.CountryCity)
                .Where(
                usr => usr.Token == token
                ).FirstOrDefault();
                return new UserDTO
                {
                    Id = user.Id,
                    Age = user.Age,
                    CountryCityId = user.CountryCity.Id,
                    CountryCityTitle = user.CountryCity.Title,
                    Credit = user.Credit,
                    Email = user.Email,
                    Family = user.Family,
                    Gender = user.Gender,
                    Image = user.Image,
                    Mobile = user.Mobile,
                    Name = user.Name,
                    Password = user.Password,
                    Phone = user.Phone,
                    RoleId = user.RoleId,
                    Setting = user.Setting,
                    Status = user.Status,
                    StudyFieldId = user.StudyField.Id,
                    StudyFieldTitle = user.StudyField.Title,
                    StudyFieldType = user.StudyField.Type,
                    Username = user.Username
                };
            }catch(Exception e)
            {
               
                return null;
            }            
            
        }
    }
}
