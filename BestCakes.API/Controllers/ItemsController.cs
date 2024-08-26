using Microsoft.AspNetCore.Mvc;
using BestCakes.DAL.Entities;
using BestCakes.Repositories;
using BestCakes.Repositories.Interfaces;
using BestCakes.Models;

namespace BestCakes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        //private readonly BestCakesDbContext _dbContext;

        //public ItemsController(BestCakesDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        
        private readonly IItemRepository _itemRepository;
        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: api/GetItemList
        [HttpGet("GetItemList")]
        public async Task<IActionResult> GetItemList()//Task<IActionResult<List<ItemModel>>>
        {
            try
            {
                List<ItemModel> itemList = new List<ItemModel>();
                itemList = await _itemRepository.GetAllItemsAsync();
                return Ok(itemList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/GetItemList
        [HttpGet("GetItemById")]
        public async Task<IActionResult> GetItemById(int itemId)//Task<IActionResult<List<ItemModel>>>
        {
            try
            {
                ItemModel itemObj = new ItemModel();
                itemObj = await _itemRepository.GetItemByIDAsync(itemId);
                return Ok(itemObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
