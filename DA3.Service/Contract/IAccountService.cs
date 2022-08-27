using DA3.Models;

namespace DA3.Service.Contract
{
    public interface IAccountService
    {
        List<AccountModel> GetAll();

        string Update(AccountModel model);

        string Create(AccountModel model);

        AccountModel GetById(string id);
    }
}
