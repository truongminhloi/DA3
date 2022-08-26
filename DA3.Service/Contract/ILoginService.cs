using DA3.Models;

namespace DA3.Service.Contract
{
    public interface ILoginService
    {
        bool Login(LoginModel loginModel);

        bool Register(LoginModel loginModel);

        AccountModel GetAccountByPhoneNumber(string phoneNumber);
    }
}
