using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Services;

namespace SimpleAPI.Controller
{
    [Route("v1/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryServices _services;

        public InventoryController(IInventoryServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Add items to memory using post request
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "price": 100
        ///     }
        ///     
        /// </remarks>
        /// <param name="items">Items to add for demonstration</param>
        /// <returns>Return the added object in JSON format, and the ok code.</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInvetoryItems(InventoryItems items)
        {
            var inventoryItems = _services.AddInventoryItems(items);

            if (inventoryItems==null)
            {
                return NotFound();
            }

            return Created("", inventoryItems);
        }

        /// <summary>
        /// Return the items added by add method on post request. If this list have no items, then return not found.
        /// </summary>
        /// <remarks>
        /// Sample return:
        /// 
        ///     GET 
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "price": 100
        ///     }
        ///     
        /// </remarks>
        /// <returns>Returns a list (Dictionary(string, InventoryItems))</returns>
        ///<response code="200">Success</response>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<string, InventoryItems>> GetInventoryItems() 
        {
            var inventoryItems = _services.GetInventoryItems();

            if (inventoryItems.Count == 0)
            {
                return NotFound();
            }

            return Ok(inventoryItems);
        }
    }
}