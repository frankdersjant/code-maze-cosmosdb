using code_maze_cosmosdb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace code_maze_cosmosdb.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Item>> GetMultipleAsync(string query);
        Task<Item> GetAsync(string id);
        Task AddAsync(Item item);
        Task UpdateAsync(string id, Item Updateitem);
        Task DeleteAsync(string id);
    }
}
