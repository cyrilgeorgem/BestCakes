using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestCakes.Models;

namespace BestCakes.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<List<ItemModel>> GetAllItemsAsync();
        Task<ItemModel> GetItemAsync(int itemId);
        Task<bool> AddItemAsync(ItemModel employee);
        Task<bool> UpdateItemAsync(ItemModel employee);
        Task<bool> DeleteItemAsync(int itemId);
    }
}
