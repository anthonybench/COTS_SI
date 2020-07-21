using Microsoft.EntityFrameworkCore;
using COTS_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COTS_Inventory.Data
{
    public class COTSContext : DbContext
    {
        public COTSContext (DbContextOptions<COTSContext> options)
            : base(options)
        {

        }

        public DbSet<ClientMachine> ClientMachine { get; set; }
        public DbSet<Install> Install { get; set; }
        public DbSet<License> Licence { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Test> Test { get; set; }
    }
}
