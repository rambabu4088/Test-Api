using InventoryApi.Data;
using InventoryApi.Helpers;
using InventoryApi.Models;
using InventoryApi.Request;
using InventoryApi.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Services
{
    public interface IItemService
    {
        List<ItemResponse> GetList();
        void Create(ItemsRequest request);
        void Update(ItemsRequest request);
        void Delete(string Id);
    }
    public class ItemService:IItemService
    {
        InventoryDBContext _inventoryDbContext;
       // private readonly AppSettings _appSettings;
        public ItemService(InventoryDBContext inventoryDBContext)
        {
            _inventoryDbContext = inventoryDBContext;
            //_appSettings = appSettings;
        }
        public List<ItemResponse> GetList()
        {
            try
            {
                var itm = (from it in _inventoryDbContext.Item
                           select new ItemResponse
                           {
                               Id = it.Id,
                               Name = it.Name,
                               Description = it.Description,
                               Price = it.Price,
                               ItemCode = it.ItemCode
                           }).ToList();
                return itm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Create(ItemsRequest request)
        {
            try
            {
                Item itm = new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    ItemCode = request.ItemCode
                };
                _inventoryDbContext.Item.Add(itm);
                _inventoryDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(ItemsRequest request)
        {
            try
            {
                var itm = _inventoryDbContext.Item.Find(request.Id);
                itm.Name = request.Name;
                itm.Description = request.Description;
                itm.Price = request.Price;
                itm.ItemCode = request.ItemCode;
                _inventoryDbContext.Item.Update(itm);
                _inventoryDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(string Id)
        {
            try
            {
                var itm = _inventoryDbContext.Item.Find(Id);
                _inventoryDbContext.Item.Remove(itm);
                _inventoryDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
