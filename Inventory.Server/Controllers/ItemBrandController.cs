using System.Collections.Generic;
using Inventory.Library;
using Inventory.Model.Master;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Server.Controllers
{
    [Route("api/itemBrand")]
    [ApiController]
    public class ItemBrandController : ControllerBase
    {
        private readonly IDataRepository<ItemBrandModel> _dataRepository;

        public ItemBrandController(IDataRepository<ItemBrandModel> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Item
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ItemBrandModel> itemBrands = _dataRepository.GetAll();
            return Ok(itemBrands);
        }

        // GET: api/Item/5
        [HttpGet("{id}"/*, Name = "Get"*/)]
        public IActionResult Get(int id)
        {
            ItemBrandModel itemBrand = _dataRepository.Get(id);

            if (itemBrand == null)
            {
                return NotFound("The item record couldn't be found.");
            }

            return Ok(itemBrand);
        }

        // POST: api/Item
        [HttpPost]
        public IActionResult Post([FromBody] ItemBrandModel itemBrand)
        {
            if (itemBrand == null)
            {
                return BadRequest("Item is null.");
            }

            _dataRepository.Add(itemBrand);
            return CreatedAtRoute(
                  "Get",
                  new { Id = itemBrand.Id },
                  itemBrand);
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ItemBrandModel itemBrand)
        {
            if (itemBrand == null)
            {
                return BadRequest("Item is null.");
            }

            ItemBrandModel itemBrandToUpdate = _dataRepository.Get(id);
            if (itemBrandToUpdate == null)
            {
                return NotFound("The Item record couldn't be found.");
            }

            _dataRepository.Update(itemBrandToUpdate, itemBrand);
            return NoContent();
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ItemBrandModel itemBrand = _dataRepository.Get(id);
            if (itemBrand == null)
            {
                return NotFound("The Item record couldn't be found.");
            }

            _dataRepository.Delete(itemBrand);
            return NoContent();
        }
    }
}
