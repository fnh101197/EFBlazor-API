using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory.Library.Context;
using Inventory.Model.Master;

namespace Inventory.Library.Repository.Master
{
    public class ItemBrandManager : IDataRepository<ItemBrandModel>
    {
        readonly InventoryContext _inventoryContext;

        public ItemBrandManager(InventoryContext context)
        {
            _inventoryContext = context;
        }

        public IEnumerable<ItemBrandModel> GetAll()
        {
            return _inventoryContext.ItemBrands.ToList();
        }

        public ItemBrandModel Get(int id)
        {
            return _inventoryContext.ItemBrands
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(ItemBrandModel entity)
        {
            _inventoryContext.ItemBrands.Add(entity);
            _inventoryContext.SaveChanges();
        }

        public void Update(ItemBrandModel itemBrand, ItemBrandModel entity)
        {
            itemBrand.BrandName = entity.BrandName;
            itemBrand.DateCreated = entity.DateCreated;
            itemBrand.DateModified = entity.DateModified;
            itemBrand.IdUserModified = entity.IdUserModified;

            _inventoryContext.SaveChanges();
        }

        public void Delete(ItemBrandModel itemBrand)
        {
            _inventoryContext.ItemBrands.Remove(itemBrand);
            _inventoryContext.SaveChanges();
        }
    }
}
