using DA3.Service.Contract;
using System.Text;

namespace DA3.Service.Implement
{
    public class CommonService : ICommonService
    {
        public string GetHashedStringPwd(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}
