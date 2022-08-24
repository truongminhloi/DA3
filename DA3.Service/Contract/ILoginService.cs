using DA3.Service.Request;

namespace DA3.Service.Contract
{
    public interface ILoginService
    {
        Task<bool> Login(LoginRequest request);
    }
}
