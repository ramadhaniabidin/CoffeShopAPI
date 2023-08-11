using CoffeShopAPI.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CoffeShopAPI.Repository
{
    public class CoffeRepository: ICoffeRepository
    {
        private string _connection;
        public CoffeRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("SqlServer");
        }

        public async Task<int> Insert(CoffeModel coffe)
        {
            using (var c = new SqlConnection(_connection))
            {
                await c.OpenAsync();
                var statement = @"insert into CoffeShop (Name, Price, Stock, Code)
                values (@Name, @Price, @Stock, @Code)";
                await c.ExecuteAsync(statement, coffe);
            }
            return 0;
        }
        async Task<bool> ICoffeRepository.Delete(int Id)
        {
            using (var c = new SqlConnection(_connection))
            {
                await c.OpenAsync();
                var statement = @"delete from CoffeShop where CoffeShop.Id = @Id";
                var output = c.Execute(statement, new { Id = Id });
                if (output == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        async Task<IEnumerable<CoffeModel>> ICoffeRepository.SelectAll()
        {
            using (var c = new SqlConnection(_connection))
            {
                await c.OpenAsync();
                var statement = await c.QueryAsync<CoffeModel>($@"select * from CoffeShop");
                return statement.ToList();
            }
        }

        async Task<CoffeModel> ICoffeRepository.SelectById(int id)
        {
            using (var c = new SqlConnection(_connection))
            {
                var statement = @"select * from CoffeShop where CoffeShop.Id = @Id";
                var output = await c.QueryFirstOrDefaultAsync<CoffeModel>(statement, new { Id = id });
                return output;
            }
        }

        async Task<bool> ICoffeRepository.Update(CoffeModel coffe, int id)
        {
            using (var c = new SqlConnection(_connection))
            {
                c.OpenAsync();
                await c.QueryAsync<CoffeModel>($@"update CoffeShop set Name=@Name, Price=@Price, Stock=@Stock, Code=@Code where CoffeShop.Id="+id, coffe);
                return true;
            }
        }
    }

    
}
