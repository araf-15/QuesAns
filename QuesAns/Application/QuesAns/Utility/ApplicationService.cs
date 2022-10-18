using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuesAns.Utility
{
    public class ApplicationService
    {

        public string HasedPassword(string plainPassword)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(plainPassword);
            return Convert.ToBase64String(sha.ComputeHash(asByteArray));
        }

    }
}
