using CoffeShopAPI.Model;

namespace CoffeShopAPI.Service
{
    public interface ICoffeService
    {
        public Task<int> AddMenu(CoffeModel coffe);
        public Task<bool> UpdateMenu(CoffeModel coffe, int id);
        public Task<bool> DeleteMenu(int Id);
        public Task<IEnumerable<CoffeModel>> SelectAllMenu();
        public Task<CoffeModel> SelectMenuById(int id);

    }
}
