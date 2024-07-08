using System.Security.Cryptography;
using System.Text;

namespace API.Services.Autre
{
    public class Utils
    {
        public static string ChiffrementPassword(string mdp)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(mdp);
            byte[] hashBytes = SHA1.HashData(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            return hash;
        }
    }
}
