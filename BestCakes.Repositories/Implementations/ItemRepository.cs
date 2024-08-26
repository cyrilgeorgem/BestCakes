using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestCakes.Repositories.Interfaces;
using BestCakes.DAL.Entities;
using BestCakes.Models;
using Microsoft.EntityFrameworkCore;

namespace BestCakes.Repositories.Implementations
{
    public class ItemRepository : IItemRepository
    {
        private BestCakesDbContext _bestCakesDbContext;
        public ItemRepository(BestCakesDbContext bestCakesDbContext)
        {
            _bestCakesDbContext = bestCakesDbContext;
        }

        public async Task<List<ItemModel>> GetAllItemsAsync()
        {
            List<ItemModel> itemList = await (from item in _bestCakesDbContext.TblBcitems
                                            select new ItemModel
                                            {
                                                ItemId = item.ItemId,
                                                Name = item.Name,
                                                Description = item.Description,
                                                Price = item.Price,
                                                OfferPrice = item.OfferPrice,
                                                ImageUrl = item.ImageUrl,
                                                CategoryId = item.CategoryId,
                                            }).ToListAsync();
            return itemList;
        }

        public async Task<ItemModel> GetItemByIDAsync(int itemId)
        {
            ItemModel? itemObj = await (from item in _bestCakesDbContext.TblBcitems
                                       where item.ItemId == itemId
                                       select new ItemModel
                                       {
                                           ItemId = item.ItemId,
                                           Name = item.Name,
                                           Description = item.Description,
                                           Price = item.Price,
                                           OfferPrice = item.OfferPrice,
                                           ImageUrl = item.ImageUrl,
                                           CategoryId = item.CategoryId,
                                       }).FirstOrDefaultAsync();
            return itemObj;
        }

        public async Task<bool> AddItemAsync(ItemModel employee)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(ItemModel employee)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
