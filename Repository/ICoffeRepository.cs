using CoffeShopAPI.Model;

namespace CoffeShopAPI.Repository
{
    public interface ICoffeRepository
    {
        public Task<int> Insert(CoffeModel coffe);
        public Task<bool> Update(CoffeModel coffe, int id);
        public Task<bool> Delete(int Id);
        public Task<IEnumerable<CoffeModel>> SelectAll();
        public Task<CoffeModel> SelectById(int id);
    }
}
