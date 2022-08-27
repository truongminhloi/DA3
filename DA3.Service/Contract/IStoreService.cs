using DA3.Models;

namespace DA3.Service.Contract
{
    public interface IStoreService
    {
        StoreModel GetStoreInfo();

        string SaveChange(StoreModel model);
    }
}
