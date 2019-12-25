using System;
using System.Collections.Generic;
using System.Text;
using Inventory.Model.Master;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Library.Context
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ItemBrandModel> ItemBrands { get; set; }
        public DbSet<ItemGroupModel> ItemGroups { get; set; }
    }
}
