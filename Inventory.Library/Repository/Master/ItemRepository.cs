using System.Collections.Generic;
using System.Linq;
using Inventory.Library.Context;
using Inventory.Model.Master;

namespace Inventory.Library.Repository.Master
{
    public class ItemManager : IDataRepository<ItemModel>
    {
        readonly InventoryContext _inventoryContext;

        public ItemManager(InventoryContext context)
        {
            _inventoryContext = context;
        }

        public IEnumerable<ItemModel> GetAll()
        {
            return _inventoryContext.Items.ToList();
        }

        public ItemModel Get(int id)
        {
            return _inventoryContext.Items
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(ItemModel entity)
        {
            _inventoryContext.Items.Add(entity);
            _inventoryContext.SaveChanges();
        }

        public void Update(ItemModel item, ItemModel entity)
        {
            item.ItemName = entity.ItemName;
            item.IdItemBrand = entity.IdItemBrand;
            item.IdItemGroup = entity.IdItemGroup;
            item.DateCreated = entity.DateCreated;
            item.DateModified = entity.DateModified;
            item.IdUserModified = entity.IdUserModified;

            _inventoryContext.SaveChanges();
        }

        public void Delete(ItemModel item)
        {
            _inventoryContext.Items.Remove(item);
            _inventoryContext.SaveChanges();
        }
    }
}
