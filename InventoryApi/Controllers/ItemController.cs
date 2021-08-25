using InventoryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryApi.Utils;
using InventoryApi.Request;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itm = _itemService.GetList();
                return Ok(itm);
            }
            catch (Exception e)
            {
                return BadRequest(new Error(2, e.Message));
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody]ItemsRequest request)
        {
            try
            {
                _itemService.Create(request);
                return Ok(201);
            }
            catch (Exception e)
            {
                return BadRequest(new Error(2, e.Message));
            }
        }
        [HttpPut]
        public IActionResult Update(ItemsRequest request)
        {
            try
            {
                _itemService.Update(request);
                return Ok(201);
            }
            catch (Exception e)
            {
                return BadRequest(new Error(2, e.Message));
            }
        }
        [HttpDelete]
        public IActionResult Delete(string  Id)
        {
            try
            {
                _itemService.Delete(Id);
                return Ok(201);
            }
            catch (Exception e)
            {
                return BadRequest(new Error(2, e.Message));
            }
        }
    }
}
