using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UtilitiesClass
{
    /**
     * This class is for Useful and Miscellaneous classes
     */
    public class Utils
    {
        //This method creates hashed token
        public string CreateToken(User user)
        {
            
            string tokenString = user.Name + user.Family + user.Username + user.Password + user.Mobile;

            MD5 hashedToken = MD5.Create();

            byte[] data = hashedToken.ComputeHash(Encoding.Default.GetBytes(tokenString));

            StringBuilder encodeToken = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                encodeToken.Append(data[i].ToString());
            }
            return encodeToken.ToString();
        }
    }
}
