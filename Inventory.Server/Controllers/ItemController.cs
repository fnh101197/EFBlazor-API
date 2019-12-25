using System.Collections.Generic;
using Inventory.Library;
using Inventory.Model.Master;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Server.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IDataRepository<ItemModel> _dataRepository;

        public ItemController(IDataRepository<ItemModel> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Item
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ItemModel> items = _dataRepository.GetAll();
            return Ok(items);
        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            ItemModel item = _dataRepository.Get(id);

            if (item == null)
            {
                return NotFound("The item record couldn't be found.");
            }

            return Ok(item);
        }

        // POST: api/Item
        [HttpPost]
        public IActionResult Post([FromBody] ItemModel item)
        {
            if (item == null)
            {
                return BadRequest("Item is null.");
            }

            _dataRepository.Add(item);
            return CreatedAtRoute(
                  "Get",
                  new { Id = item.Id },
                  item);
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ItemModel item)
        {
            if (item == null)
            {
                return BadRequest("Item is null.");
            }

            ItemModel itemToUpdate = _dataRepository.Get(id);
            if (itemToUpdate == null)
            {
                return NotFound("The Item record couldn't be found.");
            }

            _dataRepository.Update(itemToUpdate, item);
            return NoContent();
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ItemModel item = _dataRepository.Get(id);
            if (item == null)
            {
                return NotFound("The Item record couldn't be found.");
            }

            _dataRepository.Delete(item);
            return NoContent();
        }
    }
}
