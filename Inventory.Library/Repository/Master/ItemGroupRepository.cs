using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory.Library.Context;
using Inventory.Model.Master;

namespace Inventory.Library.Repository.Master
{
    public class ItemGroupManager : IDataRepository<ItemGroupModel>
    {
        readonly InventoryContext _inventoryContext;

        public ItemGroupManager(InventoryContext context)
        {
            _inventoryContext = context;
        }

        public IEnumerable<ItemGroupModel> GetAll()
        {
            return _inventoryContext.ItemGroups.ToList();
        }

        public ItemGroupModel Get(int id)
        {
            return _inventoryContext.ItemGroups
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(ItemGroupModel entity)
        {
            _inventoryContext.ItemGroups.Add(entity);
            _inventoryContext.SaveChanges();
        }

        public void Update(ItemGroupModel itemGroup, ItemGroupModel entity)
        {
            itemGroup.GroupName = entity.GroupName;
            itemGroup.DateCreated = entity.DateCreated;
            itemGroup.DateModified = entity.DateModified;
            itemGroup.IdUserModified = entity.IdUserModified;

            _inventoryContext.SaveChanges();
        }

        public void Delete(ItemGroupModel itemGroup)
        {
            _inventoryContext.ItemGroups.Remove(itemGroup);
            _inventoryContext.SaveChanges();
        }
    }
}
