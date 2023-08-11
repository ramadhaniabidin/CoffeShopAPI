using CoffeShopAPI.Model;
using CoffeShopAPI.Repository;

namespace CoffeShopAPI.Service
{
    public class CoffeService : ICoffeService
    {
        private readonly ICoffeRepository _coffe;
        public CoffeService(ICoffeRepository coffe)
        {
            _coffe = coffe;
        }
        Task<int> ICoffeService.AddMenu(CoffeModel coffe)
        {
            return _coffe.Insert(coffe);
        }

        Task<bool> ICoffeService.DeleteMenu(int Id)
        {
            return _coffe.Delete(Id);
        }

        Task<IEnumerable<CoffeModel>> ICoffeService.SelectAllMenu()
        {
            return _coffe.SelectAll();
        }

        Task<CoffeModel> ICoffeService.SelectMenuById(int id)
        {
            return _coffe.SelectById(id);
        }

        Task<bool> ICoffeService.UpdateMenu(CoffeModel coffe, int id)
        {
            return _coffe.Update(coffe, id);
        }
    }
}
