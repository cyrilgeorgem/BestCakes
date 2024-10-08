﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestCakes.Models;

namespace BestCakes.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemModel>> GetAllItemsAsync();
        Task<ItemModel> GetItemByIDAsync(int itemId);
        Task<bool> AddItemAsync(ItemModel employee);
        Task<bool> UpdateItemAsync(ItemModel employee);
        Task<bool> DeleteItemAsync(int itemId);
    }
}
