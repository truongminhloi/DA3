using DA3.Models;

namespace DA3.Service.Contract
{
    public interface IFavoriteService
    {
        List<FavoriteModel> GetAllFavorites();

        string SaveChange(FavoriteModel model);
    }
}
